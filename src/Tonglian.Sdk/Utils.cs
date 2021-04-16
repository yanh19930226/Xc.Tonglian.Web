using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Tonglian.Sdk.Models;

namespace Tonglian.Sdk
{
    public static class Utils
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        public const string SignerMethod = "GCP1-RSA-SHA512";
        /// <summary>
        /// X-AGCP-Send时间格式
        /// </summary>
        public const string XAGCPSendDateTimeFormat = "YYYYMMDDHHmmssSSS";
        /// <summary>
        /// UrlEnCodeValidUrlCharacters
        /// </summary>
        public const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public const string ContentTypeHeaderName = "Content-Type";
        public const string XAGCPCrdtHeaderName = "X-AGCP-Crdt";
        public const string XAGCPDateHeaderName = "X-AGCP-Date";
        public const string XAGCPSendHeaderName = "X-AGCP-Send";
        public const string XAGCPAuthHeaderName = "X-AGCP-Auth";
        public const string ServiceName = "gcpapi";
        public const string TerminationString = "aws4_request";


        /// <summary>
        /// Returns hashed value of input data using SHA256
        /// </summary>
        /// <param name="data">String to be hashed</param>
        /// <returns>Hashed value of input data</returns>
        private static byte[] Hash(string data)
        {
            return new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        /// <summary>
        /// SHA512Hash
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] SHA512Hash(string source)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(source);//UTF-8 编码

            //64字节,512位
            SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            byte[] h5 = SHA512.ComputeHash(buffer);

            return h5;

            //result = BitConverter.ToString(h5).Replace("-", string.Empty);

            //return result.ToLower();
        }

        private static byte[] GetKeyedHash(byte[] key, string value)
        {
            KeyedHashAlgorithm hashAlgorithm = new HMACSHA256(key);
            hashAlgorithm.Initialize();
            return hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Returns lowercase hexadecimal string of input byte array
        /// </summary>
        /// <param name="data">Data to be converted</param>
        /// <returns>Lowercase hexadecimal string</returns>
        private static string ToHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 构造字典
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ToDictionary(object obj)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理 
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        if (m.ReturnType == typeof(string))
                        {
                            map.Add(p.Name, (string)m.Invoke(obj, new object[] { })); // 向字典添加元素
                        }
                        else
                        {
                            map.Add(p.Name, JsonConvert.SerializeObject(m.Invoke(obj, new object[] { }))); // 向字典添加元素
                        }
                    }
                }
            }

            return map.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
        }

        /// <summary>
        /// Returns URL encoded version of input data according to RFC-3986
        /// </summary>
        /// <param name="data">String to be URL-encoded</param>
        /// <returns>URL encoded version of input data</returns>
        public static string UrlEncode(string data)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (char symbol in Encoding.UTF8.GetBytes(data))
            {
                if (ValidUrlCharacters.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)symbol));
                }
            }
            return encoded.ToString();
        }

        /// <summary>
        ///构造规范查询字符串
        /// </summary>
        /// <param name="request">RestRequest</param>
        /// <returns>Query parameters in canonical order with URL encoding</returns>
        public static string ExtractCanonicalQueryString<T,K>(BaseRequest<T, K> request)
        {
            var sortedqueryParameters = ToDictionary(request.Config);

            StringBuilder canonicalQueryString = new StringBuilder();

            foreach (var key in sortedqueryParameters.Keys)
            {
                if (canonicalQueryString.Length > 0)
                {
                    canonicalQueryString.Append("&");
                }
                canonicalQueryString.AppendFormat("{0}={1}",
                   key,
                   sortedqueryParameters[key]);

                //UrlEncode(key),
                //   UrlEncode(sortedqueryParameters[key]));
            }

            return canonicalQueryString.ToString();

        }

        /// <summary>
        /// 构建请求体Hash
        /// </summary>
        /// <param name="request">RestRequest</param>
        /// <returns>Hexadecimal hashed value of payload in the body of request</returns>
        public static string HashRequestBody<T, K>(BaseRequest<T, K> request)
        {
            var parametersJson = JsonConvert.SerializeObject(request.Parameters);
            return ToHex(Hash(parametersJson.ToString()));
        }

        /// <summary>
        /// 构造签名字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string BuildStringToSign<T,K>(BaseRequest<T,K> request)
        {
            var CanonicalQueryString = ExtractCanonicalQueryString(request);

            var HashRequestBodyString= HashRequestBody(request);

            var StringToSign =
                                  SignerMethod + "\n" +
                                  ServiceName+request.Uri + "\n" +
                                  CanonicalQueryString + "\n" +
                                  request.Header.XAGCPDate + "\n" +
                                  HashRequestBodyString;

            return StringToSign;
        }
    

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="StringToSign"></param>
        /// <returns></returns>
        public static string CalculateSignature(string StringToSign)
        {
            var key = @"MIICXAIBAAKBgQDQxFcRbvyiIJEb70ulxAKBpEsQ4eoFoI3xIpXL1OI3j2dJCffc
XXEtGslqpKSAR/HdS0NrX3hm3gMrs/s7DRA8DcuoyuA9e/ANoNUe7hWwIa0Suazp
BNJFeaxQtk2j6CxQPRtxMw9wXf6O2TatQWq24s6TA0HkQqz8HojQW/puIQIDAQAB
AoGBALlEhMBD7o8yt5RC2K9TM6Y5VyS0WCqGQXEtcCJj2h3UdaSr4/r8MeQFUZoC
Yro1Hr90e3BeWUtw2v99ygatoSkOaFav5U7e8hPnBg/8dmI6Sa+jn7yEgE7CHGzJ
xg9fybqgsctRqnUAu3g+QVx8mVgVLfV3U3R3y1qk6sFaBKQBAkEA/IjEXaGiwjoI
9B02twJehsMmwNBcA4uaCoUOLQTGsTNjxjv1u995F+129H/fdUeb1kNMYlMviMWr
xpz0la9/eQJBANOhzf6xVZ5PmxDAHbpkhrQk90CO8LXK/I4FdceHbtSv/IvOLMi3
OccD9FsPADtQlJyKGiqTqcK1KNVBrkITcekCQGf9Pbc8txP55/P2D7DexeQCenPN
mQZQtzb7wXGiVNtlSQG5cSBTDr9epqxZ97+IpFBf2BVpIdrVYz3fJgx5fykCQDP+
S6KoJLXJLvqViHgznFiDwG8O7xpqrVOjCcWkg1kjh3M9iwkg4sP/N7hrXg40hN5U
m4scThe09Dw4b7xyFIkCQGm1PQ8841qTvm7pexWuMB2zFRMicP6QIDPjV7nwCUcv
b/sGVqoF0c2e4fZ9hoKPww4c55uL3sQ+J18LoKljxSs=";


            var s = "<RSAKeyValue><Modulus>sl9tnC9IJ47nHSJRGv4n1WC5XR57xUmKg/74DDBg65ZI7eRhVHzm5vWB4I+qy9CiqakyZLJVsAKD8AdL+9no+J/ABkFxXmoeVZjuG3WvxRBeiGmBkXnUtwJmlhBjtA8zmtCFJtP3bvPUtQt1640m0SwaZBJ16GZTS1YLDQmqfjE=</Modulus><Exponent>AQAB</Exponent><P>60vA84ia5S6gLgTWTUdJPKobMoKUtTVQKtTOSyOFUrryzbWY7PLSXPPLE0VhxU/yVO04raNv8aKmvsdUpZuWbw==</P><Q>whFuRwLnsMoqYDnPVBkTT/aGoxUmi1NZVgQ3T8n+IFkeclwhHJBoTZIU5y5DF1R14Y3Nh6bh35eHKNY7T5qFXw==</Q><DP>dtz+7UfeD9a8/mJdLA7N9YJtWNfUbbIv/GMij5yzFjbwv3B0f4avNFvIA8Ux/e5EGhj4X+dHfsbO+2NQ5JQzqw==</DP><DQ>cQ48gyvjE6/CngoviRuOj5/bcXgp2zK0MZMFMftHi0q/nPmk5IIP8Vivyrm9pgKzJbI5UNRcc6hPue+L3+Tx2w==</DQ><InverseQ>LT8fQgvGTTsczGhQAnMMF+XT7tyGY0AzzxHGAR3sKPld1+QFFTznTPR4ZZPnuMANUIowOB04fm2VaXnvjoLIzg==</InverseQ><D>Nld4T0LgWpzgsDGKQAz6Gbmz/ziQQJSdDIWbECuU+3D3mvIe7Nx4hBh7jux1/k37oHCZl6/1BwBdLb0rWvkSTlmd3yCM2qIRJgEFX4JlBtRMAHlDni4qi1rSxBXlAf4uZXyKjbRIHr3OtH7QELUppcxe1vvQkbmuwxanaJnYszk=</D></RSAKeyValue>";

            byte[] kSecret = Encoding.UTF8.GetBytes(key.Replace(" ", ""));

            var str = GetKeyedHash(kSecret, StringToSign);

            RSACryption rsa = new RSACryption();

            //var str = CreateSignature(StringToSign, key);

            //var Signature = SignerMethod + ":" + ToHex(str);

            //var Signature = SignerMethod + ":" + ToHex(str);

            var Signature = SignerMethod + ":" + rsa.CreateSignature(StringToSign, s);

            //var Signature = SignerMethod + ":" + ToHex(rsa.CreateSignature(StringToSign, s));

            return Signature;
        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="StringToSign"></param>
        /// <returns></returns>
        public static string CalculateSignatureHmac<T, K>(BaseRequest<T, K> request)
        {
            var StringToSign = Utils.BuildStringToSign(request);
            byte[] kSecret = Encoding.UTF8.GetBytes(request.KSecret);
            byte[] kDate = GetKeyedHash(kSecret, request.Header.XAGCPCrdt);
            byte[] kTermination = GetKeyedHash(kDate, TerminationString);
            return SignerMethod + ":" + ToHex(GetKeyedHash(kTermination, StringToSign));
        }

        /// <summary>
        /// 构建最终请求头
        /// </summary>
        /// <returns></returns>
        //public static string BuildHeaders<T, K>(BaseRequest<T, K> request)
        //{
        //    Dictionary<string, string> sortedHeaders = new Dictionary<string, string>();
        //    return "";
        //}
    }
}

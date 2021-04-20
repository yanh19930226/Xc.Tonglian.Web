using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        public const string XAGCPSendDateTimeFormat = "yyyyMMddHHmmssfff";
        /// <summary>
        /// UrlEnCodeValidUrlCharacters
        /// </summary>
        public const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public const string ContentTypeHeaderName = "Content-Type";
        public const string XAGCPCrdtHeaderName = "X-AGCP-Crdt";
        public const string XAGCPDateHeaderName = "X-AGCP-Date";
        public const string XAGCPSendHeaderName = "X-AGCP-Send";
        public const string XAGCPAuthHeaderName = "X-AGCP-Auth";
        public const string ServiceName = "/gcpapi";
        public const string TerminationString = "aws4_request";


        /// <summary>
        /// Returns hashed value of input data using SHA256
        /// </summary>
        /// <param name="data">String to be hashed</param>
        /// <returns>Hashed value of input data</returns>
        private static byte[] ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            }
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
        public  static Dictionary<string, string> ToDictionary(object obj)
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
            var parametersJson1 = JsonConvert.SerializeObject(request.Parameters);
            var Signature = ComputeSha256Hash(parametersJson);
            return ToHex(Signature);
        }

        public static byte[] SHA512WithRSA(string rawData)
        {
            AsymmetricAlgorithm RSA1 = new RSACryptoServiceProvider();
            RSA1.FromXmlString(System.IO.File.ReadAllText("d:\\mycert\\key.xml"));
            SHA512 sha1 = new SHA512CryptoServiceProvider();
            byte[] hashbytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            RSAPKCS1SignatureFormatter signe = new RSAPKCS1SignatureFormatter();
            signe.SetKey(RSA1);
            signe.SetHashAlgorithm("SHA512");
            byte[] reslut = signe.CreateSignature(hashbytes);
            return reslut;
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

            System.Text.StringBuilder StringToSign = new System.Text.StringBuilder();
            StringToSign.Append(SignerMethod + "\n");
            StringToSign.Append(request.Header.XAGCPDate + "\n");
            StringToSign.Append(ServiceName + request.Uri + "\n");
            StringToSign.Append(CanonicalQueryString + "\n");
            StringToSign.Append(HashRequestBodyString);

            return StringToSign.ToString();

        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="StringToSign"></param>
        /// <returns></returns>
        public static string CalculateSignature(string StringToSign)
        {

            #region 读取文件加签

            //2.获取证书信息
            //X509Certificate2 c1 = DataCertificate.GetCertificateFromPfxFile("d:\\mycert\\test.pfx", "123456");
            //3.使用证书私钥加签待签字符串
            //RSACryption rsa = new RSACryption();
            //var Signature = rsa.CreateSignatureByte(StringToSign, "d:\\mycert\\test.pfx", "123456");

            #endregion

            #region 代码生成密钥加签验签测试
            //byte[] messagebytes = Encoding.UTF8.GetBytes(StringToSign);
            //RSACryptoServiceProvider oRSA = new RSACryptoServiceProvider();
            //string privatekey = oRSA.ToXmlString(true);
            //string publickey = oRSA.ToXmlString(false);

            ////私钥签名 
            //RSACryptoServiceProvider oRSA3 = new RSACryptoServiceProvider();
            //oRSA3.FromXmlString(privatekey);
            //byte[] AOutput = oRSA3.SignData(messagebytes, "SHA512");

            //var Signature = SignerMethod + ":" + ToHex(AOutput);
            ////公钥验证 
            //RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            //oRSA4.FromXmlString(publickey);
            //bool bVerify = oRSA4.VerifyData(messagebytes, "SHA512", AOutput); 
            #endregion

            var Signature = ToHex(SHA512WithRSA(StringToSign));

            var result = SignerMethod + ":" + Signature;

            return result;
        }

        #region MyRegion
        /// 构建最终请求头
        /// </summary>
        /// <returns></returns>
        //public static string BuildHeaders<T, K>(BaseRequest<T, K> request)
        //{
        //    Dictionary<string, string> sortedHeaders = new Dictionary<string, string>();
        //    return "";
        //} 
        #endregion
    }
}

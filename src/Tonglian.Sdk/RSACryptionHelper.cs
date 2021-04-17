using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tonglian.Sdk
{
    public class RSACryption
    {
        /// <summary>
        /// 获取xml私钥
        /// </summary>
        /// <param name="path">pfx文件地址</param>
        /// <param name="password">文件密码</param>
        /// <returns></returns>
        private  string GetPrivateKeyxml(string path, string password)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(path, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                return cert.PrivateKey.ToXmlString(true);
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <param name="pubKeyFile">cer文件地址</param>
        /// <returns></returns>
        private  RSACryptoServiceProvider GetPublicKey(string pubKeyFile)
        {
            var pc = new X509Certificate2(pubKeyFile);
            return (RSACryptoServiceProvider)pc.PublicKey.Key;
        }
        /// <summary>
        /// 生成密匙
        /// </summary>
        /// <param name="privateKey">私匙</param>
        /// <param name="publicKey">公匙></param>
        public void GenerateKeys(out string privateKey, out string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                privateKey = rsa.ToXmlString(true);
                publicKey = rsa.ToXmlString(false);
            }
        }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="sSource" >明文</param>
        /// <param name="sPrivateKey" >私匙</param>
        /// <returns>密文</returns>
        public  string CreateSignature(string sSource, string sPrivateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(sPrivateKey);

                RSAPKCS1SignatureFormatter sf = new RSAPKCS1SignatureFormatter(rsa);
                sf.SetHashAlgorithm("SHA512");

                byte[] source = Encoding.UTF8.GetBytes(sSource);

                SHA512Managed sha2 = new SHA512Managed();
                byte[] result = sha2.ComputeHash(source);
                byte[] signature = sf.CreateSignature(result);
             
                return Convert.ToBase64String(signature);
            }
        }
        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="_privateKey">私钥</param>
        /// <param name="text">待签字符串</param>
        /// <returns></returns>
        public  string CreateSignature(RSACryptoServiceProvider _privateKey, string sSource)
        {
            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(_privateKey);
            formatter.SetHashAlgorithm("SHA512");
            byte[] rgbHash = new SHA512CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(sSource));
            return Convert.ToBase64String(formatter.CreateSignature(rgbHash));
        }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="sSource">待签字符串</param>
        /// <param name="priKeyFile">pfx文件地址</param>
        /// <param name="keyPwd">文件问密码</param>
        /// <returns></returns>
        public  string CreateSignature(string sSource, string priKeyFile, string keyPwd)
        {
            using (RSACryptoServiceProvider SHA512 = new RSACryptoServiceProvider())
            {
                var privateKey = GetPrivateKeyxml(priKeyFile, keyPwd);  //获取私钥
                byte[] dataInBytes = Encoding.UTF8.GetBytes(sSource);
                SHA512.FromXmlString(privateKey);
                byte[] inArray = SHA512.SignData(dataInBytes, CryptoConfig.MapNameToOID("SHA512"));
                string sign = Convert.ToBase64String(inArray);
                return sign;
            }

        }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="sSource">待签字符串</param>
        /// <param name="priKeyFile">pfx文件地址</param>
        /// <param name="keyPwd">文件问密码</param>
        /// <returns></returns>
        public byte[] CreateSignatureByte(string sSource, string priKeyFile, string keyPwd)
        {
            using (RSACryptoServiceProvider SHA512 = new RSACryptoServiceProvider())
            {
                var privateKey = GetPrivateKeyxml(priKeyFile, keyPwd);  //获取私钥
                byte[] dataInBytes = Encoding.UTF8.GetBytes(sSource);
                SHA512.FromXmlString(privateKey);
                byte[] inArray = SHA512.SignData(dataInBytes, CryptoConfig.MapNameToOID("SHA512"));
                return inArray;
            }
        }

        /// <summary>
        /// RSA签名验证
        /// </summary>
        /// <param name="sEncryptSource">密文</param>
        /// <param name="sCompareString">需要比较的明文字符串</param>
        /// <param name="sPublicKey">公匙</param>
        /// <returns>是否相同</returns>
        public  bool VerifySignature(string sEncryptSource, string sCompareString, string sPublicKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(sPublicKey);

                    RSAPKCS1SignatureDeformatter df = new RSAPKCS1SignatureDeformatter(rsa);
                    df.SetHashAlgorithm("SHA512");

                    byte[] signature = Convert.FromBase64String(sEncryptSource);

                    SHA512Managed sha2 = new SHA512Managed();
                    byte[] compareByte = sha2.ComputeHash(Encoding.UTF8.GetBytes(sCompareString));

                    return df.VerifySignature(compareByte, signature);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// RSA签名验证
        /// </summary>
        /// <param name="sSource">待签字符串</param>
        /// <param name="signedData">签名字符串</param>
        /// <param name="pubKeyFile">cert文件地址</param>
        /// <returns></returns>
        public  bool VerifySign(string sSource, string signedData, string pubKeyFile)
        {
            var rsa = GetPublicKey(pubKeyFile);
            using (var SHA512 = new SHA512CryptoServiceProvider())
            {
                return rsa.VerifyData(Encoding.UTF8.GetBytes(sSource), SHA512, Convert.FromBase64String(signedData));
            }
        }
    }
}

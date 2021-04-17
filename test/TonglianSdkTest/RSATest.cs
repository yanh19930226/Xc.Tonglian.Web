using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tonglian.Sdk;
using Xunit;

namespace TonglianSdkTest
{
    public class RSATest
    {
        /// <summary>
        /// RSATest
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void  RsaTest()
        {

            #region MyRegion
            //string privateKey = "";

            //string publicKey = "";

            //RSACryption rsa = new RSACryption();

            //string context = "sdfssfsd";

            //rsa.GenerateKeys(out privateKey, out publicKey);

            //var signature = rsa.CreateSignature(context, privateKey);

            //var verifyRes = rsa.VerifySignature(signature, context, publicKey); 
            #endregion

            #region DataCertificate1
            //// 在personal（个人）里面创建一个foo的证书
            //DataCertificate.CreateCertWithPrivateKey("test", "D:\\Work\\ERP\\Xc.Tonglian.Web\\src\\Tonglian.Sdk\\makecert.exe");

            //// 获取证书
            //X509Certificate2 c1 = DataCertificate.GetCertificateFromStore("test");

            //string keyPublic = c1.PublicKey.Key.ToXmlString(false);  // 公钥
            //string keyPrivate = c1.PrivateKey.ToXmlString(true);  // 私钥

            //string cypher = RSAEncrypt(keyPublic, "xxx");  // 加密
            //string plain = RSADecrypt(keyPrivate, cypher);  // 解密

            //Debug.Assert(plain == "xxx");

            //// 生成一个cert文件
            //DataCertificate.ExportToCerFile("test", "d:\\mycert\\test.cer");

            //X509Certificate2 c2 = DataCertificate.GetCertFromCerFile("d:\\mycert\\test.cer");

            //string keyPublic2 = c2.PublicKey.Key.ToXmlString(false);

            //bool b = keyPublic2 == keyPublic;
            //string cypher2 = RSAEncrypt(keyPublic2, "xxx2");  // 加密
            //string plain2 = RSADecrypt(keyPrivate, cypher2);  // 解密, cer里面并没有私钥，所以这里使用前面得到的私钥来解密

            //Debug.Assert(plain2 == "xxx2");

            //// 生成一个pfx， 并且从store里面删除
            //DataCertificate.ExportToPfxFile("test", "d:\\mycert\\foo.pfx", "123456", true);

            //X509Certificate2 c3 = DataCertificate.GetCertificateFromPfxFile("d:\\mycert\\test.pfx", "123456");

            //string keyPublic3 = c3.PublicKey.Key.ToXmlString(false);  // 公钥
            //string keyPrivate3 = c3.PrivateKey.ToXmlString(true);  // 私钥

            //string cypher3 = RSAEncrypt(keyPublic3, "xxx3");  // 加密
            //string plain3 = RSADecrypt(keyPrivate3, cypher3);  // 解密

            //Debug.Assert(plain3 == "xxx3");
            #endregion

            #region DataCertificate2

            // 在personal（个人）里面创建一个foo的证书
            //DataCertificate.CreateCertWithPrivateKey("test", "D:\\Work\\ERP\\Xc.Tonglian.Web\\src\\Tonglian.Sdk\\makecert.exe");

            // 生成一个cert文件
            DataCertificate.ExportToCerFile("test", "d:\\mycert\\test.cer");

            // 生成一个pfx， 并且从store里面删除
            DataCertificate.ExportToPfxFile("test", "d:\\mycert\\test.pfx", "123456", true);

            //读取私钥加签
            X509Certificate2 c1 = DataCertificate.GetCertificateFromPfxFile("d:\\mycert\\test.pfx", "123456");

            RSACryption rsa = new RSACryption();

            string strToSingn = "yanh";

            var Signature=rsa.CreateSignature(strToSingn, "d:\\mycert\\test.pfx", "123456");

            //var s = (RSACryptoServiceProvider)c1.PrivateKey;

            //var Signature2 = rsa.CreateSignature((RSACryptoServiceProvider)c1.PrivateKey, strToSingn);

            //使用公钥验签
            //var Result = rsa.VerifySign(strToSingn, Signature, "d:\\mycert\\test.cer");

            string keyPublic = c1.PublicKey.Key.ToXmlString(false);

            var Result2 = rsa.VerifySignature(Signature, strToSingn, keyPublic);

            var sr = "done";

            #endregion


        }

        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPrivateKey);
            byte[] rgb = Convert.FromBase64String(m_strDecryptString);
            byte[] bytes = provider.Decrypt(rgb, false);
            return new UnicodeEncoding().GetString(bytes);
        }
        /// <summary>   
        /// RSA加密   
        /// </summary>   
        /// <param name="xmlPublicKey"></param>   
        /// <param name="m_strEncryptString"></param>   
        /// <returns></returns>   
        public static string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));
        }
    }
}




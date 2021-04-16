using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tonglian.Sdk
{
    public class RSACryption
    {
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

                byte[] source = System.Text.ASCIIEncoding.ASCII.GetBytes(sSource);

                SHA512Managed sha2 = new SHA512Managed();
                byte[] result = sha2.ComputeHash(source);
                byte[] signature = sf.CreateSignature(result);

                return Convert.ToBase64String(signature);
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
                    byte[] compareByte = sha2.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sCompareString));

                    return df.VerifySignature(compareByte, signature);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            string privateKey = "";

            string publicKey = "";

            RSACryption rsa = new RSACryption();

            string context = "sdfssfsd";

            rsa.GenerateKeys(out privateKey, out publicKey);

            var signature = rsa.CreateSignature(context, privateKey);

            var verifyRes = rsa.VerifySignature(signature, context, publicKey);
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models
{
    public abstract class BaseRequest<T>
    {
        protected BaseRequest(T Parameters)
        {
            this.Parameters = Parameters;
        }
        /// <summary>
        /// 商户配置
        /// </summary>
        public Config Config { get; set; } = new Config();
        /// <summary>
        /// 请求头
        /// </summary>
        public RequestHeader Header { get; set; } = new RequestHeader();
        /// <summary>
        /// 请求参数
        /// </summary>
        public T Parameters { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public abstract string Uri { get; }
        /// <summary>
        /// 通联签名秘钥Id
        /// </summary>
        public string KSecretId => "2C52B53741103B2FB-1GA08-3";
        /// <summary>
        /// 通联签名公钥(用于客户端对通联通知内容的验签)
        /// </summary>
        public string KSecret => "MFkwEwYHKoZIzj0CAQYIKoEcz1UBgi0DQgAEob2LdDlv18Uy/4r0VKW2qjm1rdezGcTHw6RhpL2lbQOJgHQAU2etqQc7IWCywRkMrokFX0nqfDBMrtqBeCZ98A==";
    }
    /// <summary>
    /// 证书配置
    /// </summary>
    public class CertificateConfig
    {
        /// <summary>
        /// 证书路径
        /// </summary>
        /// <returns></returns>
        public string GetCertPath()
        {
            return "";
        }
        /// <summary>
        /// 证书访问密码
        /// </summary>
        /// <returns></returns>
        public string GetCertPassword()
        {
            return "";
        }
    }
    /// <summary>
    /// 公共配置(以Url查询字符串形式发送)
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string authcus { get; set; } = "665000000001030";
        /// <summary>
        /// 商户号
        /// </summary>
        public string merid { get; set; } = "668000000001074";
        /// <summary>
        /// 请求流水号
        /// </summary>
        public string reqid { get; set; } = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7);
     
    }

    /// <summary>
    /// 公共请求头以报文形式发送
    /// </summary>
    public class RequestHeader
    {
        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; } = "application/json;charset=UTF-8";
        /// <summary>
        /// 签名密钥ID
        /// </summary>
        public string XAGCPCrdt => "2C52B53741103B2FB-1GA08-3:" + DateTime.UtcNow.ToString("yyyyMMdd") + ":gcpservice";
        /// <summary>
        /// 签名密钥ID:UTC日期:范围(固定gcpservice)
        /// UTC时间戳(YYYYMMDDHHmmss)
        /// </summary>
        public string XAGCPDate => DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        /// <summary>
        /// 发送报文的UTC时间(yyyyMMddHHmmssfff)
        /// </summary>
        public string XAGCPSend => DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        /// <summary>
        /// 签名值
        /// </summary>
        public string XAGCPAuth { get; set; }
    }

    public class BaseResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string rspcode { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string rspinfo { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string authcus { get; set; } 
        /// <summary>
        /// 商户号
        /// </summary>
        public string merid { get; set; } 
        /// <summary>
        /// 请求流水号
        /// </summary>
        public string reqid { get; set; } 
    }
}

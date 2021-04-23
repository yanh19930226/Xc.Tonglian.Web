using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Dto.UserConfig
{
    public class UserConfigEditDto
    {
        /// <summary>
        /// 通联SecretId
        /// </summary>
        public string SecretId { get; set; }
        /// <summary>
        /// 通联SecretKey
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string Authcus { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerId { get; set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        ///私钥
        /// </summary>
        public string PrivateKey { get; set; }
    }
}

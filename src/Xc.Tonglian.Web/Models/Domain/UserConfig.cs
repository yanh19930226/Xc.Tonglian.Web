using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class UserConfig : Entity
    {
        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }
        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Authcus
        /// </summary>
        public string Authcus { get; set; }
        /// <summary>
        /// MerId
        /// </summary>
        public string MerId { get; set; }
    }
}

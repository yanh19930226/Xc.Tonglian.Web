using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class User:Entity
    {
        /// <summary>
        /// SecretId
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SecretKey
        /// </summary>
        public string Pwd { get; set; }

    }
}

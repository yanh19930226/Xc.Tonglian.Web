using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class Customer : Entity
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string CtId { get; set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 所属分公司
        /// </summary>
        public string Belongbranch { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string Areacode { get; set; }
        /// <summary>
        /// 客户性质
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 客户分类
        /// </summary>
        public string Cuskind { get; set; }
        /// <summary>
        /// 客户业务
        /// </summary>
        public string Businesskind { get; set; }
        /// <summary>
        /// 是否三证合
        /// </summary>
        public string Threcertflag { get; set; }
        /// <summary>
        /// 社会信用证代码
        /// </summary>
        public string Creditcode { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string Organcode { get; set; }
        /// <summary>
        /// 营业执照代码
        /// </summary>
        public string Buslicense { get; set; }
        /// <summary>
        /// 社会信用代码证有效期
        /// </summary>
        public string Creditcodeexpire { get; set; }
        /// <summary>
        /// 法人代表证件号
        /// </summary>
        public string Legalidno { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string Legal { get; set; }
        /// <summary>
        /// 法人身份证有效期
        /// </summary>
        public string Legalidexpire { get; set; }
        /// <summary>
        /// 经营场所
        /// </summary>
        public string Businessplace { get; set; }
        /// <summary>
        /// 交易网站所属国家/地区
        /// </summary>
        public string Websitecountry { get; set; }
        /// <summary>
        /// 交易网站名称
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 跨境交易地址
        /// </summary>
        public string Tradingplatform { get; set; }
        /// <summary>
        /// 员工人数
        /// </summary>
        public string Stafftotal { get; set; }
        /// <summary>
        /// 合同有效期
        /// </summary>
        public string Protocolexpire { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        public string Tlinstcode { get; set; }
        /// <summary>
        /// 控股股东或实际控制人姓名
        /// </summary>
        public string Holdername { get; set; }
        /// <summary>
        /// 控股股东或实际控制人身份证件号码
        /// </summary>
        public string Holderidno { get; set; }
        /// <summary>
        /// 控股股东或实际控制人身份证件有效期
        /// </summary>
        public string Holderexpire { get; set; }
        /// <summary>
        /// 受益所有人姓名
        /// </summary>
        public string Bnfname { get; set; }
        /// <summary>
        /// 受益所有人有效身份证件号码
        /// </summary>
        public string Bnfidno { get; set; }
        /// <summary>
        /// 受益所有人有效身份证件有效期
        /// </summary>
        public string Bnfexpire { get; set; }
        /// <summary>
        /// 受益所有人地址
        /// </summary>
        public string Bnfaddress { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Legalemail { get; set; }
        /// <summary>
        /// 商户数组
        /// </summary>
        public string Mers { get; set; }
        /// <summary>
        /// 银行账号数组
        /// </summary>
        public string Accts { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}

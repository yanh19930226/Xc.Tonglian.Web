using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Customers
{
    public class CustomerCreateRequest : BaseRequest<CustomerCreateRequestModel, CustomerCreateResponse>
    {
        public CustomerCreateRequest(CustomerCreateRequestModel data) : base(data)
        {

        }
        public override string Uri => "/entity/regcus";
    }
    public class CustomerCreateRequestModel
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string ctid { get; set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string cusname { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 所属分公司
        /// </summary>
        public string belongbranch { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string areacode { get; set; }
        /// <summary>
        /// 客户性质
        /// </summary>
        public string flag { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 客户分类
        /// </summary>
        public string cuskind { get; set; }
        /// <summary>
        /// 客户业务
        /// </summary>
        public string businesskind { get; set; }
        /// <summary>
        /// 是否三证合
        /// </summary>
        public string threcertflag { get; set; }
        /// <summary>
        /// 社会信用证代码
        /// </summary>
        public string creditcode { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string organcode { get; set; }
        /// <summary>
        /// 营业执照代码
        /// </summary>
        public string buslicense { get; set; }
        /// <summary>
        /// 社会信用代码证有效期
        /// </summary>
        public string creditcodeexpire { get; set; }
        /// <summary>
        /// 法人代表证件号
        /// </summary>
        public string legalidno { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string legal { get; set; }
        /// <summary>
        /// 法人身份证有效期
        /// </summary>
        public string legalidexpire { get; set; }
        /// <summary>
        /// 经营场所
        /// </summary>
        public string businessplace { get; set; }
        /// <summary>
        /// 交易网站所属国家/地区
        /// </summary>
        public string websitecountry { get; set; }
        /// <summary>
        /// 交易网站名称
        /// </summary>
        public string website { get; set; }
        /// <summary>
        /// 跨境交易地址
        /// </summary>
        public string tradingplatform { get; set; }
        /// <summary>
        /// 员工人数
        /// </summary>
        public int stafftotal { get; set; }
        /// <summary>
        /// 合同有效期
        /// </summary>
        public string protocolexpire { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        public string tlinstcode { get; set; }
        /// <summary>
        /// 控股股东或实际控制人姓名
        /// </summary>
        public string holdername { get; set; }
        /// <summary>
        /// 控股股东或实际控制人身份证件号码
        /// </summary>
        public string holderidno { get; set; }
        /// <summary>
        /// 控股股东或实际控制人身份证件有效期
        /// </summary>
        public string holderexpire { get; set; }
        /// <summary>
        /// 受益所有人姓名
        /// </summary>
        public string bnfname { get; set; }
        /// <summary>
        /// 受益所有人有效身份证件号码
        /// </summary>
        public string bnfidno { get; set; }
        /// <summary>
        /// 受益所有人有效身份证件有效期
        /// </summary>
        public string bnfexpire { get; set; }
        /// <summary>
        /// 受益所有人地址
        /// </summary>
        public string bnfaddress { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string legalemail { get; set; }
        /// <summary>
        /// 商户数组
        /// </summary>
        public string mers { get; set; }
        /// <summary>
        /// 银行账号数组
        /// </summary>
        public string accts { get; set; }
        //public List<FileUpload> efis { get; set; }
    }


    public class FileUpload
    {
        public string fid { get; set; }
        public int ftype { get; set; }
    }

    public class CustomerCreateResponse:BaseResponse
    {
    }
}

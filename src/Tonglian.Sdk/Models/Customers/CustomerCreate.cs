using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Customers
{
    public class CustomerCreateRequest
    {
        public string ctid { get; set; }
        public string entityname { get; set; }

        public string address { get; set; }

        public string belongbranch { get; set; }

        public string areacode { get; set; }

        public int flag { get; set; }

        public string tel { get; set; }

        public string cuskind { get; set; }

        public string businesskind { get; set; }

        public string threcertflag { get; set; }

        public string creditcode { get; set; }

        public string organcode { get; set; }


        public string buslicense { get; set; }

        public string creditcodeexpire { get; set; }

        public string legalidno { get; set; }

        public string legal { get; set; }

        public string legalidexpire { get; set; }

        public string businessplace { get; set; }
        public string websitecountry { get; set; }
        public string website { get; set; }
        public string tradingplatform { get; set; }
        public string stafftotal { get; set; }
        public string protocolexpire { get; set; }
        public string tlinstcode { get; set; }
        public string holdername { get; set; }
        public string holderidno { get; set; }
        public string holderexpire { get; set; }
        public string bnfname { get; set; }
        public string bnfidno { get; set; }
        public string bnfexpire { get; set; }
        public string bnfaddress { get; set; }
        public string legalemail { get; set; }
        public string mers { get; set; }
        public string accts { get; set; }
        public List<FileUpload> efis { get; set; }
    }


    public class FileUpload
    {
        public string fid { get; set; }
        public int ftype { get; set; }
    }

    public class CustomerCreateResponse
    {
    }
}

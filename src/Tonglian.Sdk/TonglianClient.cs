using Flurl.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk.Models;

namespace Tonglian.Sdk
{
    public class TonglianClient
    {
        private readonly EnvEnum _envEnum;
        public TonglianClient(EnvEnum envEnum, HttpClient client)
        {
            _envEnum = envEnum;
        }

        private string GetApiBaseUrl()
        {
            switch (_envEnum)
            {
                case EnvEnum.Dev:
                    return "https://test.allinpaygd.com";
                case EnvEnum.Prod:
                    return "https://global.allinpay.com";
                default:
                    return "https://global.allinpay.com";
            }
        }

     
        public  TonglianResult<BaseResponse> RequestAsync<T>(BaseRequest<T> request)
        {
            TonglianResult<BaseResponse> result = new TonglianResult<BaseResponse>();

            var StringToSign = Utils.BuildStringToSign(request);

            var Signature = Utils.CalculateSignature(StringToSign);
            
            var client = new RestClient(GetApiBaseUrl());

            var rq = new RestRequest("/gcpapi"+request.Uri+"?authcus=" + request.Config.authcus + "&merid=" + request.Config.merid + "&reqid=" + request.Config.reqid, DataFormat.Json);

            rq.AddHeader("X-AGCP-Crdt", request.Header.XAGCPCrdt);
            rq.AddHeader("X-AGCP-Date", request.Header.XAGCPDate);
            rq.AddHeader("X-AGCP-Send", request.Header.XAGCPSend);
            rq.AddHeader("X-AGCP-Auth", Signature);

            rq.AddJsonBody(JsonConvert.SerializeObject(request.Parameters));

            var httpResponse = client.Post(rq).Content;

            var rqResult = JsonConvert.DeserializeObject<BaseResponse>(httpResponse);

            if (rqResult.rspcode!="0000")
            {
                result.Failed(rqResult.rspinfo.ToString());
            }
            else
            {
                result.Success(rqResult.rspinfo.ToString());
            }
            result.Result = rqResult;

            return result;

        }
    }
}

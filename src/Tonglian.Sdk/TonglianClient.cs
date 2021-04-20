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
        private readonly string _service;
        private readonly string _secretId;
        private readonly string _secretKey;
        private readonly string _authcus;
        private readonly string _merid;

        //private readonly Config _config;
        private readonly EnvEnum _envEnum;

        public TonglianClient(string service,string secretId,string secretKey, string authcus, string merid, EnvEnum envEnum)
        {
            _service = service;
            _secretId = secretId;
            _secretKey = secretKey;
            _authcus = authcus;
            _merid = merid;
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

     
        public  K RequestAsync<T,K>(BaseRequest<T,K> request)
        {
            RequestHeader header = new RequestHeader(_secretId, _service);

            Config conf = new Config() {
                authcus = _authcus,
                merid=_merid
            };

            request.Header= header;

            request.KSecretId = _secretId;

            request.KSecret = _secretKey;

            request.Config = conf;
           

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

            var result = JsonConvert.DeserializeObject<K>(httpResponse);

            return result;

        }
    }
}

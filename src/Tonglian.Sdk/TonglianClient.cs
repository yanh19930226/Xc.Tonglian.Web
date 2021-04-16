using Newtonsoft.Json;
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
        private HttpClient _client { get; }
        public TonglianClient(EnvEnum envEnum, HttpClient client)
        {
            _envEnum = envEnum;
            _client = client;
        }
        private class JsonContent : StringContent
        {
            public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
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

        #region Post
        public async Task<TonglianResult<K>> RequestAsync<T, K>(BaseRequest<T, K> request)
        {
            var StringToSign = Utils.BuildStringToSign(request);
            var Signature = Utils.CalculateSignature(StringToSign);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-AGCP-Crdt", request.Header.XAGCPCrdt);
            _client.DefaultRequestHeaders.Add("X-AGCP-Date", request.Header.XAGCPSend);
            _client.DefaultRequestHeaders.Add("X-AGCP-Send", request.Header.XAGCPSend);
            _client.DefaultRequestHeaders.Add("X-AGCP-Auth", Signature);
            //_client.DefaultRequestHeaders.Add("Content-Type", request.Header.ContentType);
            TonglianResult<K> result = new TonglianResult<K>();

            var url = GetApiBaseUrl()+ "/gcpapi" + request.Uri+ "?authcus="+request.Config.authcus+ "&merid="+request.Config.merid+ "&reqid="+request.Config.reqid;

            var httpResponse =  _client.PostAsync(url, new JsonContent(new { request.Parameters })).Result;

            var content = await httpResponse.Content.ReadAsStringAsync();

            K obj = JsonConvert.DeserializeObject<K>(content);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                result.Failed(httpResponse.Content.ToString());
            }
            else
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                result.Success(httpResponse.Content.ToString());
            }
            result.Result = obj;

            return await Task.FromResult(result);

        }
        #endregion
    }
}

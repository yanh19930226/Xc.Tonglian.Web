using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk
{
    /// <summary>
    /// 响应实体
    /// </summary>
    public class TonglianResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public TonglianResultCode Code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 成功
        /// </summary>
        public bool IsSuccess => Code == TonglianResultCode.Succeed;
        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Success(string message = "")
        {
            Message = message;
            Code = TonglianResultCode.Succeed;
        }
        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Failed(string message = "")
        {
            Message = message;
            Code = TonglianResultCode.Failed;
        }
        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exexception></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Failed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = TonglianResultCode.Failed;
        }
    }
    /// <summary>
    /// 响应实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TonglianResult<T> : TonglianResult
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void Success(T result = default(T), string message = "")
        {
            Message = message;
            Code = TonglianResultCode.Succeed;
            Result = result;
        }
    }

    public enum TonglianResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Failed = 0
    }
}

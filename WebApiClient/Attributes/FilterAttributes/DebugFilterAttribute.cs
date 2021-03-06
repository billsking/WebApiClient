﻿using System;
using System.Diagnostics;
using System.Text;
using WebApiClient.Contexts;

namespace WebApiClient.Attributes
{
    /// <summary>
    /// 表示将请求响应内容打印到输出调试窗口的过滤器
    /// </summary>
    public class DebugFilterAttribute : TraceFilterBaseAttribute
    {
        /// <summary>
        /// 输出异常
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="exception">异常</param>
        /// <param name="message">消息</param>    
        protected override void LogError(ApiActionContext context, Exception exception, string message)
        {
            this.Log(context, message, exception);
        }

        /// <summary>
        /// 输出消息
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="message">消息</param>
        protected override void LogInformation(ApiActionContext context, string message)
        {
            this.Log(context, message, null);
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>       
        private void Log(ApiActionContext context, string message, Exception ex)
        {
            var method = context.ApiActionDescriptor.Member;
            var methodName = $"{method.DeclaringType.Name}.{method.Name}";

            var log = new StringBuilder()
                .AppendLine(methodName)
                .AppendLine(message);

            if (ex != null)
            {
                log.AppendLine(ex.ToString());
            }
            Debug.Write(log.ToString());
        }
    }
}

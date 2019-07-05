using LogApiHandler.Common;
using LogApiHandler.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApiHandler
{
    internal class LogWriter
    {
        private readonly string UserName = null;
        private readonly string Password = null;
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private LogWriter() { }
        /// <summary>
        /// 获取LogWriter实例
        /// </summary>
        /// <returns></returns>
        public static LogWriter GetLogWriter()
        {
            return new LogWriter();
        }

        public void Writer(object logDataAsync)
        {
            try
            {
                var led = GetLoggingData((LogDataAsync)logDataAsync);
                var level = LogLevel.FromString(led.Level);
                string logapi = level.LogApi;
                RequestHelpers.DoPost<LogData>(logapi, led);//MessagePack进行数据压缩，减小传输数据
            }
            catch (Exception ex) { }
        }

        public void Writer(object logDataAsync, string UserName, string Password)
        {
            try
            {
                var led = GetLoggingData((LogDataAsync)logDataAsync);
                var level = LogLevel.FromString(led.Level);
                string logapi = level.LogApi;
                RequestHelpers.DoPost<LogData>(logapi, led, UserName, Password);//MessagePack进行数据压缩，减小传输数据
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 获取日志数据
        /// </summary>
        /// <param name="logDataAsync"></param>
        /// <returns></returns>
        private LogData GetLoggingData(LogDataAsync logDataAsync)
        {
            LocationInfo locationInfo = new LocationInfo(logDataAsync.CallerStackBoundaryDeclaringType, logDataAsync.CallerStackTrace);
            LogData logData = new LogData
            {
                Message = logDataAsync.Message,
                Date = DateTime.Now,
                Level = logDataAsync.Level,
                LogSource = string.IsNullOrEmpty(logDataAsync.LogSource) ? locationInfo.ClassName : logDataAsync.LogSource,
                ClassName = locationInfo.ClassName,
                MethodName = locationInfo.MethodName,
                LineNumber = locationInfo.LineNumber,
                FileName = locationInfo.FileName,
                IP = "NA",
                Emails = logDataAsync.Emails,
                FullInfo = locationInfo.FullInfo
            };
            return logData;
        }
    }
}

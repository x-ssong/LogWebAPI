using System;

namespace LogApiHandler
{
    public class LogData
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 错误级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 日志来源
        /// </summary>
        public string LogSource { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 完整信息
        /// </summary>
        public string FullInfo { get; set; }
        /// <summary>
        /// 行号
        /// </summary>        
        public string LineNumber { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>        
        public string FileName { get; set; }
        /// <summary>
        /// ip
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 不为空则发送邮件，多个接收人用英文分号 ; 隔开
        /// </summary>
        public string Emails { get; set; }
    }
}

using System;
using System.Diagnostics;
using System.Reflection;
using LogLibrary.Models;
using NLog;

namespace LogLibrary
{
    public class LogDb
    {
        public static readonly Logger HttpLogger = LogManager.GetLogger("HttpLogger");
        public static readonly Logger ExceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public static void AddHttpLog(HttpLogModel logModel)
        {
            var logEventInfo = new LogEventInfo(
                LogLevel.Info,
                "HttpLogger",
                "HTTP Request and Response Log"
            );

            logEventInfo.Properties["AppName"] = logModel.AppName;
            // ReSharper disable once HeapView.BoxingAllocation
            logEventInfo.Properties["Direction"] = (sbyte) logModel.Direction;
            logEventInfo.Properties["RequestTime"] = logModel.RequestTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            logEventInfo.Properties["RequestIp"] = logModel.RequestIp;
            logEventInfo.Properties["RequestUri"] = logModel.RequestUri;
            logEventInfo.Properties["RequestQueryString"] = logModel.RequestQueryString;
            logEventInfo.Properties["RequestContentType"] = logModel.RequestContentType;
            logEventInfo.Properties["RequestMethod"] = logModel.RequestMethod;
            logEventInfo.Properties["RequestBody"] = logModel.RequestBody;
            logEventInfo.Properties["RequestCookies"] = logModel.RequestCookies;
            logEventInfo.Properties["RequestHeader"] = logModel.RequestHeader;
            logEventInfo.Properties["ResponseTime"] = logModel.ResponseTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            logEventInfo.Properties["ResponseBody"] = logModel.ResponseBody;
            logEventInfo.Properties["ResponseStatusCode"] = logModel.ResponseStatusCode;
            logEventInfo.Properties["ResponseContentType"] = logModel.ResponseContentType;
            logEventInfo.Properties["ResponseHeader"] = logModel.ResponseHeader;
        }

        public static void AddExceptionLog(StackFrame stackFrame, Exception e, string content = null)
        {
            var logEventInfo = new LogEventInfo(
                LogLevel.Info,
                "ExceptionLogger",
                "Exception Log"
            );

            logEventInfo.Properties["AppName"] = Assembly.GetEntryAssembly()?.GetName().Name;
            logEventInfo.Properties["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            logEventInfo.Properties["ClassName"] = stackFrame.GetMethod()?.DeclaringType?.Name;
            logEventInfo.Properties["MethodName"] = stackFrame.GetMethod()?.Name;
            logEventInfo.Properties["Message"] = e.Message;
            logEventInfo.Properties["StackTrace"] = e.StackTrace;
            logEventInfo.Properties["Content"] = content;
        }
        
        public static void AddProgramLog(LogLevel logLevel, string message, string data)
        {
            var logEventInfo = new LogEventInfo(
                LogLevel.Trace,
                "ExceptionLogger",
                "Exception Log"
            );

            logEventInfo.Properties["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            logEventInfo.Properties["AppName"] = Assembly.GetEntryAssembly()?.GetName().Name;
            logEventInfo.Properties["LogLevel"] = logLevel.ToString();
            logEventInfo.Properties["Message"] = message;
            logEventInfo.Properties["Data"] = data;
        }

    }
}
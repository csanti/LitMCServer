using System;
using NLog;

namespace LitMC.Utils
{
    public class Log
    {
        private static readonly Logger Logger = LogManager.GetLogger("Logger");

        //Trace 0

        public static void Trace(string format, params object[] args)
        {
            Logger.Trace(format, args);
        }

        public static void TraceException(string message, Exception ex)
        {
            Logger.Trace(ex, message);
        }

        //Debug 1

        public static void Debug(string format, params object[] args)
        {
            Logger.Debug(format, args);
        }

        public static void DebugException(string message, Exception ex)
        {
            Logger.Debug(ex, message);
        }

        //Info  2

        public static void Info(string format, params object[] args)
        {
            Logger.Info(format, args);
        }

        public static void InfoException(string message, Exception ex)
        {
            Logger.Info(ex, message);
        }

        //Warn  3

        public static void Warn(string format, params object[] args)
        {
            Logger.Warn(format, args);
        }

        public static void WarnException(string message, Exception ex)
        {
            Logger.Warn(ex, message);
        }

        //Error 4

        public static void Error(string format, params object[] args)
        {
            Logger.Error(format, args);
        }

        public static void ErrorException(string message, Exception ex)
        {
            Logger.Error(ex, message);
        }

        //Fatal 5

        public static void Fatal(string format, params object[] args)
        {
            Logger.Fatal(format, args);
        }

        public static void FatalException(string message, Exception ex)
        {
            Logger.Fatal(ex, message);
        }
    }
}

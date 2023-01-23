using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Repository.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogCritical(string message)
        {
            logger.Fatal(message);
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogTrace(string message)
        {
            logger.Trace(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}

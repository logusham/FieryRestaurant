using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Repository.Logger
{
    public interface ILoggerManager
    {
        public void LogCritical(string message);
        public void LogWarning(string message);
        public void LogDebug(string message);
        public void LogError(string message);
        public void LogInfo(string message);
        public void LogTrace(string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace batch15webAPI
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError (string message);
    }
}

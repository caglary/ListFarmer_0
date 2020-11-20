using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logger
{
   public static class LogTryCatch
    {
        
        public static void TryCatch(Action action,string nameofproject)
        {
            try
            {
               
                action.Invoke();
            }
            catch (Exception exception)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Error,nameofproject+": "+ exception.Message);
               
            }
        }
        public static void TryCatch(Exception exception,string nameOfClass)
        {
        
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Error, nameOfClass + ": " + exception.Message);
           
        }
    }
}

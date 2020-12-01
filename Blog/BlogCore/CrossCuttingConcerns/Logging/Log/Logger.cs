using log4net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.CrossCuttingConcerns.Logging.Log
{

    public class Logger : Microsoft.Extensions.Logging.ILogger
    {
      

        //    IHostingEnvironment _hostingEnvironment;
        //    public Logger(IHostingEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;
        //    public IDisposable BeginScope<TState>(TState state) => null;
        //    public bool IsEnabled(LogLevel logLevel) => true;
        //    public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        //    {
        //        using (StreamWriter streamWriter = new StreamWriter($"{_hostingEnvironment.ContentRootPath}/log.txt", true))
        //        {
        //            await streamWriter.WriteLineAsync($"Log Level : {logLevel.ToString()} | Event ID : {eventId.Id} | Event Name : {eventId.Name} | Formatter : {formatter(state, exception)}");
        //            streamWriter.Close();
        //            await streamWriter.DisposeAsync();
        //        }
        //    }
        //}
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.CrossCuttingConcerns.Logging.Log
{
    public class LoggerProvider : ILoggerProvider
    {
        //public IHostingEnvironment _hostingEnvironment;
        //public LoggerProvider(IHostingEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;
        //public ILogger CreateLogger(string categoryName) => new Logger(_hostingEnvironment);
        //public void Dispose() => throw new NotImplementedException();
        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

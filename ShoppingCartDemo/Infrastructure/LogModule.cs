using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Infrastructure
{
    public class LogModule : IHttpModule
    {
        private static int sharedCounter = 0;
        private int requestCounter;
        private static object lockObject = new object();
        private Exception requestException = null;

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                requestCounter = ++sharedCounter;
            };

            app.Error += (src, args) =>
            {
                requestException = HttpContext.Current.Error;
            };

            app.LogRequest += (src, args) =>
            {
                WriteLogMessage(HttpContext.Current);
            };
        }

        private void WriteLogMessage(HttpContext context)
        {
            StringWriter log = new StringWriter();
            log.WriteLine("--------");
            log.WriteLine("Request: {0} for {1}", requestCounter, context.Request.RawUrl);

            if (context.Handler != null)
            {
                log.WriteLine("Handler: {0}", context.Handler.GetType());
            }

            log.WriteLine("Status Code: {0}, Message: {1}", 
                context.Response.StatusCode, context.Response.StatusDescription);
            log.WriteLine("Elapsed time: {0} ms", DateTime.Now.Subtract(context.Timestamp).Milliseconds);

            if (requestException != null)
            {
                log.WriteLine("Error: {0}", requestException.GetType());
            }

            lock (lockObject)
            {
                Debug.Write(log.ToString());
            }
        }

        public void Dispose()
        {

        }
    }
}
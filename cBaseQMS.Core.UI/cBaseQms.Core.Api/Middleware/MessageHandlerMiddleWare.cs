using cBaseQms.Core.Api.ValidationResponse;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cBaseQms.Core.Api.Middleware
{
    public class MessageHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public MessageHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                //set the current response to the memorystream.
                context.Response.Body = memoryStream;

                await _next(context);

                //reset the body 
                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = JsonConvert.DeserializeObject(readToEnd);

                var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, null);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }

          //  await this._next.Invoke(context).ConfigureAwait(false);
          

            // Do some response logic here.
        }
    }
}

using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ISBN
{
    public static class HttpConverter
    {
        [FunctionName("Convert10to13")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "HttpTriggerCSharp/name/{name}")]HttpRequestMessage req, string ISBN10, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, Converter.ConvertTo13(ISBN10));
        }
        [FunctionName("Convert13to10")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "HttpTriggerCSharp/name/{name}")]HttpRequestMessage req, string ISBN13, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, Converter.ConvertTo10(ISBN13));
        }
    }
}

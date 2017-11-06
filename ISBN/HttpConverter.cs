using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ISBN
{
    public static class Convert
    {
        [FunctionName("ISBNtoEAN")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Convert/ISBNtoEAN/{ISBN}")]HttpRequestMessage req, string ISBN, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Fetching the name from the path parameter in the request URL
            if (!string.IsNullOrEmpty(ISBN))
            {
                if (ISBN.Length == 10)
                    return req.CreateResponse(HttpStatusCode.OK, Converter.ConvertTo13(ISBN));
                else if (ISBN.Length == 13)
                    return req.CreateResponse(HttpStatusCode.OK, Converter.ConvertTo10(ISBN));
            }
            
            return req.CreateResponse(HttpStatusCode.BadRequest, "Invalid ISBN/EAN");
        }
    }
}

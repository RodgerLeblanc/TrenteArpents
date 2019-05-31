using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TrenteArpentsHearts
{
    public static class HeartCount
    {
        [FunctionName(nameof(HeartCount))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request,
            [Table("Hearts")] CloudTable table,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string name = request.Query["name"];

                string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;

                return (ActionResult)new OkObjectResult($"Hello, {name}");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
        }
    }
}

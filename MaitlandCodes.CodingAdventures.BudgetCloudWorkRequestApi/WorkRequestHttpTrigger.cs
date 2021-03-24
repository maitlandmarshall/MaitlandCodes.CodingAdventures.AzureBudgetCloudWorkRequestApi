using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi
{
    public class WorkRequestHttpTrigger
    {
        private readonly WorkRequestDbContext dbContext;

        public WorkRequestHttpTrigger(WorkRequestDbContext dbConext)
        {
            this.dbContext = dbConext;
        }

        [FunctionName(nameof(CreateWorkRequest))]
        public async Task<IActionResult> CreateWorkRequest(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] [FromBody] CreateWorkRequestDto requestDto,            
            ILogger log)
        {
            await this.dbContext.Database.EnsureCreatedAsync();

            var workRequest = new WorkRequest
            {
                Description = requestDto.Description
            };

            this.dbContext.Add(workRequest);
            await this.dbContext.SaveChangesAsync();

            return new OkResult();
        }

        [FunctionName(nameof(ListWorkRequests))]
        public async Task<IActionResult> ListWorkRequests(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request)
        {
            try
            {
                await this.dbContext.Database.EnsureCreatedAsync();
                var workRequests = await this.dbContext.WorkRequests.Take(10).ToListAsync();

                return new OkObjectResult(workRequests);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }
    }

    public class CreateWorkRequestDto
    {
        public string Description { get; set; }
    }
}


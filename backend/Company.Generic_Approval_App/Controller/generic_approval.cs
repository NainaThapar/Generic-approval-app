using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Company.Generic_Approval_App
{
    public class GenericApproval
    {
        private readonly ILogger<GenericApproval> _logger;

        public GenericApproval(ILogger<GenericApproval> logger)
        {
            _logger = logger;
        }

        // Get all PRs to approve
        [Function("GetApprovals")]
        public IActionResult GetApprovals([HttpTrigger(AuthorizationLevel.Function, "get", Route = "approvals")] HttpRequest req)
        {
            _logger.LogInformation("Getting all PR approvals.");

            var approvals = new List<object>
            {
                new { id = "000000000-00000-00000-0000000", name = "Approve this PR", description = "some description here on the item" },
                new { id = "000000000-00000-00000-0000001", name = "Approve this PR", description = "some description here on the item" }
            };

            return new OkObjectResult(approvals);
        }

        // Get a specific PR approval by id
        [Function("GetApprovalById")]
        public IActionResult GetApprovalById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "approvals/{id}")] HttpRequest req, string id)
        {
            _logger.LogInformation($"Getting approval for PR with id {id}.");

            var approval = new 
            {
                id = id,
                name = "Approve this PR",
                description = "some description here on the item",
                fullDescription = $"This is the link for the PR that I need you to approve: https://github.com/pr/{id}"
            };

            return new OkObjectResult(approval);
        }
    }
}
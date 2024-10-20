using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoSlices.API.Data;
using TodoSlices.API.Features.Workspaces.CreateWorkspace;

namespace TodoSlices.API.Controllers
{
    [Route("api/workspace")]
    [ApiController]
    public class WorkspacesController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkspacesController(TodoSlicesDatabaseContext context, ISender sender)
        {
            this._sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorkspace(CreateWorkspacesCommand command)
        {
            Guid workspaceGuid = await this._sender.Send(command);
            return Ok(workspaceGuid);
        }
    }
}

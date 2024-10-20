using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoSlices.API.Data;
using TodoSlices.API.Entities;
using TodoSlices.API.Features.Workspaces.CreateWorkspace;
using TodoSlices.API.Features.Workspaces.GetWorkspace;

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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkspace(string guid)
        {
            Workspace? workspace = await this._sender.Send(new GetWorkspaceQuery { WorkspaceId = new Guid(guid) });
            if (workspace == null)
                return NotFound();
            else
                return Ok(workspace);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorkspace(CreateWorkspacesCommand command)
        {
            Guid workspaceGuid = await this._sender.Send(command);
            return Ok(workspaceGuid);
        }
    }
}

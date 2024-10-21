using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoSlices.API.Data;
using TodoSlices.API.Entities;
using TodoSlices.API.Features.Workspaces.CreateWorkspace;
using TodoSlices.API.Features.Workspaces.GetWorkspace;
using TodoSlices.API.Features.Workspaces.RemoveWorkspace;
using TodoSlices.API.Features.Workspaces.UpdateWorkspace;

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

        [HttpDelete]
        public async Task<ActionResult> RemoveWorkspace(RemoveWorkspacesCommand command)
        {
            Guid workspaceGuid = await this._sender.Send(command);
            return Ok(workspaceGuid);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkspace(string id)
        {
            Workspace? workspace = await this._sender.Send(new GetWorkspaceQuery { WorkspaceId = new Guid(id) });
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

        [HttpPut]
        public async Task<ActionResult> UpdateWorkspace(UpdateWorkspaceCommand command)
        {
            await this._sender.Send(command);
            return Ok();
        }
    }
}

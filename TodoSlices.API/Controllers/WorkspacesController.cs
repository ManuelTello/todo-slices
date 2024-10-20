using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoSlices.API.Data;
using TodoSlices.API.Features.Workspaces.CreateWorkspaces;

namespace TodoSlices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspacesController : ControllerBase
    {
        private readonly TodoSlicesDatabaseContext _databaseContext;
        private readonly ISender _sender;

        public WorkspacesController(TodoSlicesDatabaseContext context, ISender sender)
        {
            this._databaseContext = context;
            this._sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorkspace(CreateWorkspacesCommand newWorkspace)
        {
            Guid workspaceId = await this._sender.Send(newWorkspace);
            return Ok(workspaceId);
        }
    }
}

using MediatR;
using TodoSlices.API.Entities;

namespace TodoSlices.API.Features.Workspaces.GetWorkspace
{
    public class GetWorkspaceQuery : IRequest<Workspace?>
    {
        public Guid WorkspaceId { get; set; }
    }
}
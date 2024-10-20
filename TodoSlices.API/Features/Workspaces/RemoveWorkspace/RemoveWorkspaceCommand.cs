using MediatR;

namespace TodoSlices.API.Features.Workspaces.RemoveWorkspace
{
    public class RemoveWorkspacesCommand : IRequest<Guid>
    {
        public Guid WorkspaceId { get; set; }
    }
}

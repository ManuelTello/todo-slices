using MediatR;

namespace TodoSlices.API.Features.Workspaces.UpdateWorkspace
{
    public class UpdateWorkspaceCommand : IRequest
    {
        public Guid WorkspaceId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }
    }
}
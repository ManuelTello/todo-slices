using MediatR;

namespace TodoSlices.API.Features.Workspaces.CreateWorkspaces
{
    public class CreateWorkspacesCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }

        public DateTime DateCreated { get; } = DateTime.UtcNow;
    }
}

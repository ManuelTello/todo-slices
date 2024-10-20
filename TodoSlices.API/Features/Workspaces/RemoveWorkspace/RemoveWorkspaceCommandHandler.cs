using MediatR;
using TodoSlices.API.Data;
using TodoSlices.API.Entities;

namespace TodoSlices.API.Features.Workspaces.RemoveWorkspace
{
    internal sealed class Handler : IRequestHandler<RemoveWorkspacesCommand, Guid>
    {
        private readonly TodoSlicesDatabaseContext _databaseContext;

        public Handler(TodoSlicesDatabaseContext context)
        {
            this._databaseContext = context;
        }

        public async Task<Guid> Handle(RemoveWorkspacesCommand request, CancellationToken cancellationToken)
        {
            Workspace workspace = new Workspace()
            {
                Id = request.WorkspaceId
            };

            this._databaseContext.Workspaces.Remove(workspace);
            await this._databaseContext.SaveChangesAsync(cancellationToken);
            return request.WorkspaceId;
        }
    }
}
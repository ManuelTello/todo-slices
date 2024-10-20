using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoSlices.API.Data;
using TodoSlices.API.Entities;

namespace TodoSlices.API.Features.Workspaces.GetWorkspace
{
    internal sealed class Handler : IRequestHandler<GetWorkspaceQuery, Workspace?>
    {
        private readonly TodoSlicesDatabaseContext _databaseContext;

        public Handler(TodoSlicesDatabaseContext context)
        {
            this._databaseContext = context;
        }

        public async Task<Workspace?> Handle(GetWorkspaceQuery request, CancellationToken cancellationToken)
        {
            Workspace? workspace = await this._databaseContext.Workspaces.FirstOrDefaultAsync(w => w.Id == request.WorkspaceId);
            return workspace;
        }
    }
}
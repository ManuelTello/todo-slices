using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoSlices.API.Data;

namespace TodoSlices.API.Features.Workspaces.UpdateWorkspace
{
    internal sealed class Handler : IRequestHandler<UpdateWorkspaceCommand>
    {
        private readonly TodoSlicesDatabaseContext _databaseContext;

        public Handler(TodoSlicesDatabaseContext context)
        {
            this._databaseContext = context;
        }

        public async Task Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            await this._databaseContext.Workspaces.Where(w => w.Id == request.WorkspaceId).ExecuteUpdateAsync(setter => setter
                .SetProperty(w => w.Title, request.Title)
                .SetProperty(w => w.SubTitle, request.SubTitle)
            );
        }
    }
}
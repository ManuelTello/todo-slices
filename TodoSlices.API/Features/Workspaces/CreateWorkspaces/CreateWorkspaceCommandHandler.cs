using MediatR;
using TodoSlices.API.Data;

namespace TodoSlices.API.Features.Workspaces.CreateWorkspaces
{
    internal sealed class Handler : IRequestHandler<CreateWorkspacesCommand, Guid>
    {
        private readonly TodoSlicesDatabaseContext _dataContext;

        public Handler(TodoSlicesDatabaseContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Guid> Handle(CreateWorkspacesCommand request, CancellationToken cancellationToken)
        {
            Entities.Workspace newWorkspace = new Entities.Workspace
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                SubTitle = request.SubTitle,
                DateCreated = DateTime.UtcNow,
            };

            await this._dataContext.Workspaces.AddAsync(newWorkspace);
            await this._dataContext.SaveChangesAsync(cancellationToken);

            return newWorkspace.Id;
        }
    }
}
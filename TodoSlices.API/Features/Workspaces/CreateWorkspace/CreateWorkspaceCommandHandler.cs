using MediatR;
using TodoSlices.API.Data;
using TodoSlices.API.Entities;

namespace TodoSlices.API.Features.Workspaces.CreateWorkspace
{
    internal sealed class Handler : IRequestHandler<CreateWorkspacesCommand, Guid>
    {
        private readonly TodoSlicesDatabaseContext _databaseContext;

        public Handler(TodoSlicesDatabaseContext dataContext)
        {
            this._databaseContext = dataContext;
        }

        public async Task<Guid> Handle(CreateWorkspacesCommand request, CancellationToken cancellationToken)
        {
            Workspace newWorkspace = new Workspace
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                SubTitle = request.SubTitle,
                DateCreated = request.DateCreated,
            };

            await this._databaseContext.Workspaces.AddAsync(newWorkspace);
            await this._databaseContext.SaveChangesAsync(cancellationToken);

            return newWorkspace.Id;
        }
    }
}
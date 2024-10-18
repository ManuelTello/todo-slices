using Microsoft.EntityFrameworkCore;
using TodoSlices.API.Entities;

namespace TodoSlices.API.Data
{
    public class TodoSlicesDatabaseContext : DbContext
    {

        public TodoSlicesDatabaseContext(DbContextOptions<TodoSlicesDatabaseContext> options) : base(options) { }

        public DbSet<Workspace> Workspaces { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<EntryColumn> EntryColumns { get; set; }

        public DbSet<EntryRow> EntryRows { get; set; }
    }
}
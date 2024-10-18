namespace TodoSlices.API.Entities
{
    public class Board
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }

        public Workspace Workspace { get; set; } = null!;

        public ICollection<EntryColumn> EntryColumns { get; } = new List<EntryColumn>();

    }
}
namespace TodoSlices.API.Entities
{
    public class EntryColumn
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public Board Board { get; set; } = null!;

        public ICollection<EntryRow> EntryRows { get; } = new List<EntryRow>();
    }
}
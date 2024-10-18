namespace TodoSlices.API.Entities
{
    public class EntryRow
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }

        public EntryColumn EntryColumn { get; set; } = null!;
    }
}
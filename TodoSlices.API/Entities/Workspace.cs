namespace TodoSlices.API.Entities
{
    public class Workspace
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? SubTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Board> Boards { get; } = new List<Board>();
    }
}
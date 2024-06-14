namespace NetConferenceMediatR.Infrastructure
{
    public record Role
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Actions { get; set; } = new List<string>();
    }
}

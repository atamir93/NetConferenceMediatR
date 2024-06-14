namespace NetConferenceMediatR.Infrastructure
{
    public record User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required DateTime Birthdate { get; set; }
    }
}

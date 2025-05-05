namespace aiio.Contract.Processes.Dtos
{
    public record ResourceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

namespace aiio.Contract.Processes.Requests
{
    public record UpdateProcessRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
    }
}

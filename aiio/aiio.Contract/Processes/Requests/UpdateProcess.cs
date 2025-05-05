namespace aiio.Contract.Processes.Requests
{
    public record UpdateProcessRequest
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
    }
}

namespace aiio.Contract.Processes.Dtos
{
    public record LocationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

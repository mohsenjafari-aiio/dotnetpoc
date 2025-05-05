namespace aiio.Contract.Processes.Dtos
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

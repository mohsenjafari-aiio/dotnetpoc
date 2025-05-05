namespace aiio.Contract.Processes.Dtos
{
    public record RoleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

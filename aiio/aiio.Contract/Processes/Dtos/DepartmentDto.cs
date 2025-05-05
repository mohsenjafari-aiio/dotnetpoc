namespace aiio.Contract.Processes.Dtos
{
    public record DepartmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

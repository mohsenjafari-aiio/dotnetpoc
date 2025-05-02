namespace aiio.Framework.BaseModel
{
    public class BaseModel
    {
        public Guid Id { get; internal set; }
        public string Title { get; internal set; } = default!;
        public DateTime Created { get; internal set; }
    }
}
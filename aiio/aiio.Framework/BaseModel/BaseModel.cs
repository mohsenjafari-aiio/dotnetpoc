namespace aiio.Framework.BaseModel
{
    public class BaseModel
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; } = default!;
        public DateTime Created { get; protected set; }
    }
}
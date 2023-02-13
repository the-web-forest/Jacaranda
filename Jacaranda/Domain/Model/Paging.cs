namespace Jacaranda.Domain.Model
{
    public class Paging<T>
    {
        public IEnumerable<T> Data { get; set; }
        public long? TotalCount { get; set; }
    }
}

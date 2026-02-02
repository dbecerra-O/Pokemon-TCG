namespace TcgFront.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
    }
}

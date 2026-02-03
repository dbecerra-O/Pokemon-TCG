namespace TcgFront.Models.Requests
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
    }
}

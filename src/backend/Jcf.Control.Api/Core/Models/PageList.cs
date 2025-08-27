namespace Jcf.Control.Api.Core.Models
{
    public class PageList<T>(IEnumerable<T> list, int page, int pageSize, int total)
    {
        public int Total { get; set; } = total;
        public int Page { get; set; } = page;
        public int PageSize { get; set; } = pageSize;
        public IEnumerable<T> List { get; set; } = list;
    }
}

namespace Jcf.Control.Api.Core.Uteis
{
    public static class PaginationUtil
    {
        public static (int Offset, int PageSize) GetPagination(int page, int pageSize)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            int offset = (page - 1) * pageSize;

            return (offset, pageSize);
        }
    }
}

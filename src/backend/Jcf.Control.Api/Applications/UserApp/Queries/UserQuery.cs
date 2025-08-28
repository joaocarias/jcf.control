using Jcf.Control.Api.Core.Extensions;

namespace Jcf.Control.Api.Applications.UserApp.Queries
{
    public static class UserQuery
    {
        private static readonly string _table = "\"Users\"";
        
        public static readonly string GET_ALL = $" {QueryExtension._selectFromAll} {_table} WHERE {QueryExtension._isActiveRow} ORDER BY {QueryExtension._colName} ASC ";
        public static readonly string GET = $" {QueryExtension._selectFromAll} {_table} WHERE {QueryExtension._colId} = @Id AND {QueryExtension._isActiveRow} ";
        public static readonly string GET_PAGINATE = $"{GET_ALL} OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY ";
        public static readonly string GET_COUNT = $" {QueryExtension._selectCount} {_table} WHERE {QueryExtension._isActiveRow} " ;
    }
}

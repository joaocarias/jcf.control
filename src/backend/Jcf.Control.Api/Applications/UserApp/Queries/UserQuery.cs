using Jcf.Control.Api.Core.Extensions;

namespace Jcf.Control.Api.Applications.UserApp.Queries
{
    public static class UserQuery
    {
        private static readonly string _table = "\"Users\"";
        
        public static readonly string GET_ALL = $"SELECT * FROM {_table} WHERE {QueryExtension._isActiveRow} ORDER BY {QueryExtension._colName} ASC ";
        public static readonly string GET = $"SELECT * FROM {_table} WHERE {QueryExtension._colId} = @Id AND {QueryExtension._isActiveRow} ";
    }
}

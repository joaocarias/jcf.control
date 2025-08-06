using Jcf.Control.Api.Core.Extensions;

namespace Jcf.Control.Api.Applications.ClientApp.Queries
{
    public class ClientQuery
    {
        private static readonly string _table = "\"Clients\"";

        public static readonly string GET_ALL = $"SELECT * FROM {_table} WHERE {QueryExtension._isActiveRow}";
        public static readonly string GET = $"SELECT * FROM {_table} WHERE {QueryExtension._colId} = @Id AND {QueryExtension._isActiveRow}";
    }
}

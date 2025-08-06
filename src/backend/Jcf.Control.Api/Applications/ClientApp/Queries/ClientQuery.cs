using Jcf.Control.Api.Core.Extensions;

namespace Jcf.Control.Api.Applications.ClientApp.Queries
{
    public class ClientQuery
    {
        private static readonly string _table = "\"Clients\"";
        
        public static readonly string GET_ALL = $"SELECT * FROM {_table} WHERE {QueryExtension._isActiveRow}";
        public static readonly string GET = $"select * from {_table} client left join {QueryExtension._tableAddress} address on address.{QueryExtension._colId}  = client.{QueryExtension._colAddressId} and address.{QueryExtension._isActiveRow} where client.{QueryExtension._isActiveRow} ;";
    }
}

using Jcf.Control.Api.Core.Extensions;

namespace Jcf.Control.Api.Applications.ClientApp.Queries
{
    public class ClientQuery
    {
        private static readonly string _table = "\"Clients\"";

        private static readonly string _leftJoinAddressClient = $" left join {QueryExtension._tableAddress} address on address.{QueryExtension._colId}  = client.{QueryExtension._colAddressId} and address.{QueryExtension._isActiveRow} ";
        
        public static readonly string GET_ALL = $" {QueryExtension._selectFromAll} {_table} {_leftJoinAddressClient} WHERE {QueryExtension._isActiveRow} ;";
        public static readonly string GET = $" {QueryExtension._selectFromAll} {_table} client {_leftJoinAddressClient} WHERE client.{QueryExtension._isActiveRow} ;";
    }
}

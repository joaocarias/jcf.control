namespace Jcf.Control.Api.Core.Extensions
{
    public static class QueryExtension
    {
        public const string _tableAddress = "\"Addresses\"";
        public const string _colAddressId = "\"AddressId\"";

        public const string _isActiveRow = "\"IsActive\" ";
        public const string _colId = "\"Id\"";
        public const string _colName = "\"Name\"";

        public const string _selectFromAll = " SELECT * FROM ";
        public const string _selectCount = $"SELECT COUNT({_colId}) FROM ";

    }
}

namespace Jcf.Control.Api.Applications.UserApp.Queries
{
    public static class UserQuery
    {
        private static readonly string _table = "\"Users\"";
        private static readonly string _isActiveRow = "\"IsActive\" ";

        public static readonly string GET_ALL = $"SELECT * FROM {_table} WHERE {_isActiveRow}";
        public static readonly string GET = $"SELECT * FROM {_table} WHERE Id = @Id AND {_isActiveRow}";
    }
}

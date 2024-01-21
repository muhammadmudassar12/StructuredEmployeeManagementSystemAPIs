namespace StructuredEmployeeManagementSystemAPIs.Connection
{
    public class ConnectionString : IConnectionString
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("dbConnection");
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("dbConnection");
        }
    }
}

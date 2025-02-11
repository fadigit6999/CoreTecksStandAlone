namespace CoreTechs.Web.WebHelper
{
    public static class WebConfig
    {
        #region Database Config
        public static string DatabaseConnection()
        {
            string server = "PC-2\\SQLEXPRESS";
            string dbName = "EmployeeMSDB";
            string sqlConnection = $"Data Source={server};Initial Catalog={dbName};Integrated Security= True;TrustServerCertificate=True;";
            return sqlConnection;
        }
        #endregion
    }
}

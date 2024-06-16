using Dapper;
using System.Data.SqlClient;

namespace ExpensesManager.Infrastructure.Migrations
{
    public static class DataBase
    {
        public static void CreateDataBase(string connectionString, string databaseName)
        {
            try
            {
                using SqlConnection mySqlConnection = new SqlConnection(connectionString);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("name", databaseName);

                var results = mySqlConnection.Query("SELECT name FROM sys.databases WHERE name = @name", dynamicParameters);

                if (!results.Any())
                    mySqlConnection.Execute($"CREATE DATABASE {databaseName}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

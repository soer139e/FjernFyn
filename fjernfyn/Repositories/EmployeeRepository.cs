using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace fjernfyn.Repositories
{
    internal class EmployeeRepository
    {
        private readonly string conString;
        public EmployeeRepository() 
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            conString = config.GetConnectionString("DB_KEY");
        }

        public string HandleInformation(string userName, string passWord)
        {
            string infoString = "";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

            }
                //TODO: implement handling of information where we specifically communicate with the database

                return infoString;
        }
    }
}

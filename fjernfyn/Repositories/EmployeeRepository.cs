using Microsoft.Extensions.Configuration;

namespace fjernfyn.Repositories
{
    internal class EmployeeRepository
    {
        private readonly string con;
        public EmployeeRepository() 
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            con = config.GetConnectionString("DB_KEY");
        }

        public bool HandleInformation(string userName, string passWord)
        {
            bool success = false; // false by default
            //TODO: implement handling of information where we specifically communicate with the database

            return success;
        }
    }
}

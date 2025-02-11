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
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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

        public bool HandleInformation(Employee emp)
        {
            string infoString = "";

            bool valid = false;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                string query = "SELECT * FROM Employees WHERE userName = @userName AND passWord = @passWord;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", emp.Username);
                    cmd.Parameters.AddWithValue("@passWord", emp.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            valid = true;

                            reader.Read();
                            emp.Email = reader.GetString(3);
                            emp.Department = (Department)Enum.Parse(typeof(Department), reader.GetString(4));
                            emp.FullName = reader.GetString(5);
                        }
                    }
                }

            }
            return valid;
        }
    }
}

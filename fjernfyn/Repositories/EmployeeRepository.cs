using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace fjernfyn.Repositories
{
    internal class EmployeeRepository : IDatabaseConnection
    {

        public string ConString { get; set; }


        public EmployeeRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            ConString = config.GetConnectionString("DB_KEY");
        }

        public bool HandleInformation(Employee emp)
        {
            string infoString = "";

            bool valid = false;

            using (SqlConnection con = new SqlConnection(ConString))
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
                            emp.Id = reader.GetInt32(0);
                            emp.Email = reader.GetString(3);
                            emp.Department = (Department)Enum.Parse(typeof(Department), reader.GetString(4));
                            emp.FullName = reader.GetString(5);
                        }
                    }
                }

            }
            return valid;
        }

        public Employee GetByID(int id) // Bliver brugt i Feedbackrepo for at finde den tilhørende Employee i databasen for et givet Feedback
        {
            Employee result = new Employee();

            return result;
        }
    }
}

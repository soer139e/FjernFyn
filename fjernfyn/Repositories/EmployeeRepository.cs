using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;

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

        // TODO: rewrite to find a singular row using a singular query, then run another one, to fetch the rest of the info.
        public string HandleInformation(string userName, string passWord)
        {
            string infoString = "";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT userName FROM Employees WHERE userName = @userName", con))
                {
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Debug.WriteLine($"Employee found: {result.ToString()}");
                        // NESTED USING DIRECTIVES LETS FUCKING GOOOOOOO!!!!

                        using (SqlCommand cmdPass = new SqlCommand("SELECT passWord FROM Employees WHERE userName = @userName", con))
                        {
                            cmdPass.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;

                            object result2 = cmdPass.ExecuteScalar();
                            Debug.WriteLine($"{result2.ToString()}");
                            if (result2.ToString() == passWord)
                            {
                                Debug.WriteLine("Password is valid when matched with database");
                                using (SqlCommand fetchAll = new SqlCommand("SELECT email, department, Name FROM Employees WHERE userName = @userName", con))
                                {
                                    fetchAll.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;

                                    using (SqlDataReader reader = fetchAll.ExecuteReader())
                                    {
                                        if (reader.Read() && reader["email"].ToString() != "" && reader["department"].ToString() != "" && reader["Name"].ToString() != "") 
                                        {
                                            string email = reader["email"].ToString();
                                            string department = reader["department"].ToString();
                                            string name = reader["Name"].ToString();

                                            Debug.WriteLine($"Email: {email}, Department: {department}, Name: {name}");
                                            infoString = $"{userName}|{passWord}|{email}|{department}|{name}";
                                            
                                        }
                                        else
                                        {
                                            infoString = "Der skete en fejl under login\n\nFejlkode: (6x548)";
                                        }
                                    }
                                }
                            } else
                            {
                                infoString = "Brugernavn eller kodeord er forkert.";
                            }

                        }
                    }
                    else
                    {
                        infoString = $"Brugernavn eller kodeord er forkert.";
                    }
                }

            }
            return infoString;
        }
    }
}

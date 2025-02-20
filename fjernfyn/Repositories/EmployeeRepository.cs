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

        //public bool CheckIfMatch(User user)
        //{
        //    bool access = false;

        //    using (SHA512 sha512 = SHA512.Create())
        //    {
        //        byte[] passwordBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(user.PassWord));

        //        string query = "SELECT * FROM INFORMATION WHERE Username = @Username AND PasswordHash = @Password;";

        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();

        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@Username", user.UserName);
        //                cmd.Parameters.AddWithValue("@Password", passwordBytes);

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        access = true;

        //                        reader.Read(); // Move to the first row
        //                        user.UserID = reader.GetInt32(0);

        //                    }
        //                }
        //            }
        //        }

        //    }

        //    return access;

        //}

        // TODO: rewrite to find a singular row using a singular query, then run another one, to fetch the rest of the info.
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
                            //emp.Department = reader.GetEnumerator(4); // TODO: parse the enum

                        }
                    }

                    //object result = cmd.ExecuteScalar();

                    //if (result != null)
                    //{
                    //    Debug.WriteLine($"Employee found: {result.ToString()}");
                    //    // NESTED USING DIRECTIVES LETS FUCKING GOOOOOOO!!!!

                    //    using (SqlCommand cmdPass = new SqlCommand("SELECT passWord FROM Employees WHERE userName = @userName", con))
                    //    {
                    //        cmdPass.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;

                    //        object result2 = cmdPass.ExecuteScalar();
                    //        Debug.WriteLine($"{result2.ToString()}");
                    //        if (result2.ToString() == passWord)
                    //        {
                    //            Debug.WriteLine("Password is valid when matched with database");
                    //            using (SqlCommand fetchAll = new SqlCommand("SELECT email, department, Name FROM Employees WHERE userName = @userName", con))
                    //            {
                    //                fetchAll.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;

                    //                using (SqlDataReader reader = fetchAll.ExecuteReader())
                    //                {
                    //                    if (reader.Read() && reader["email"].ToString() != "" && reader["department"].ToString() != "" && reader["Name"].ToString() != "") 
                    //                    {
                    //                        string email = reader["email"].ToString();
                    //                        string department = reader["department"].ToString();
                    //                        string name = reader["Name"].ToString();

                    //                        Debug.WriteLine($"Email: {email}, Department: {department}, Name: {name}");
                    //                        infoString = $"{userName}|{passWord}|{email}|{department}|{name}";

                    //                    }
                    //                    else
                    //                    {
                    //                        infoString = "Der skete en fejl under login\n\nFejlkode: (6x548)";
                    //                    }
                    //                }
                    //            }
                    //        } else
                    //        {
                    //            infoString = "Brugernavn eller kodeord er forkert.";
                    //        }

                    //    }
                    //}
                    //else
                    //{
                    //    infoString = $"Brugernavn eller kodeord er forkert.";
                    //}
                }

            }
            return valid;
        }
    }
}

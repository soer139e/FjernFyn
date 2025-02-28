using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace fjernfyn.Repositories
{
    public class SoftwaresRepo
    {
        private readonly string conString;

        private List<Software> software;
        public SoftwaresRepo() 
        {    
            software = new List<Software>();
          
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            conString = config.GetConnectionString("DB_KEY");
        }
        public Software? Get(int id)
        {
            Software result = null;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * From Software Where Id = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read())
                        {
                            result = new Software()
                            {
                                ID = dr.GetInt32(0),
                                Name = dr.GetString(1)
                            };

                        }
                    }
                }

                
            }
            return result;
        }

        public List<Software>? GetAll()
        {
            software.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Software", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Software newSoftware = new Software()
                            {
                                ID = dr.GetInt32(0),
                                Name = dr.GetString(1)
                            }; software.Add(newSoftware);
                        };
                    }
                }
            }

                return software;
        }


    }
}

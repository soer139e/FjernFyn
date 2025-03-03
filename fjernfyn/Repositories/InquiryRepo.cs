using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace fjernfyn.Repositories
{
    public class InquiryRepo
    {
        private readonly string conString;
        private List<Inquiry> inquiries;
        public InquiryRepo()
        {
            inquiries = new List<Inquiry>();
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build();

            conString = config.GetConnectionString("DB_KEY");

        }
        public void CreateInquiry(Inquiry inquiry)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(1) FROM Employees WHERE id = @EmployeeID", con))
                {
                    checkCmd.Parameters.AddWithValue("@EmployeeID", inquiry.Employee.Id);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new InvalidOperationException($"Employee with ID {inquiry.Employee.Id} does not exist.");
                    }
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Feedback (Priority, Title, Description, Category, CreationDate, EmployeeID, SoftwareID, ErrorCode, Image) " +
            "VALUES (@Priority, @Title, @Description, @Category, @CreationDate, @EmployeeID, @SoftwareID, @ErrorCode, @Image)", con))
                {
                    cmd.Parameters.AddWithValue("@Priority", inquiry.Priority);
                    cmd.Parameters.AddWithValue("@Title", inquiry.Title);
                    cmd.Parameters.AddWithValue("@Description", inquiry.Description);
                    cmd.Parameters.AddWithValue("@Category", inquiry.Type);
                    //TODO: Databind the creation data, AKA MAKE EVERYTHING BE A DATETIME.
                    cmd.Parameters.AddWithValue("@CreationDate", "2025-02-25"); // Use fixed dummy date as string
                    cmd.Parameters.AddWithValue("@EmployeeID", inquiry.Employee.Id);
                    cmd.Parameters.AddWithValue("@SoftwareID", inquiry.SoftwareProp.ID);
                    //TODO: also databind these two little fellas.
                    cmd.Parameters.AddWithValue("@ErrorCode", "stupid");
                    cmd.Parameters.AddWithValue("@Image", "not real");

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Inquiry> GetAllInquiries()
        {
            inquiries.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                //Gets all feedbacks in database as well as the connected Employee and Software.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK JOIN EMPLOYEES ON (EmployeeID = ID) JOIN Software " +
                    "ON (SoftwareID = Software.ID)", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                                Inquiry inquiry = new Inquiry()
                            {
                                Id = dr.GetInt32(0),
                                Priority = (Priority)Enum.Parse(typeof(Priority), dr.GetString(1)),
                                Title = dr.GetString(2),
                                Description=dr.GetString(3),

                                //Midlertidlig udkommenteret fordi databasens rækker stemmer ikke overens med koden
                               // Type = (Category)Enum.Parse(typeof(Priority),dr.GetString(6)),
                               // CreationDate = dr.GetString(7),
                                ErrorCode = dr.GetString(8),
                                Image = dr.GetString(9),
                            };
                            inquiry.Employee.Username = dr.GetString(11);
                            if(!dr.IsDBNull(11))
                                 inquiry.Employee.Username = dr.GetString(11);

                            inquiry.Employee.Department = (Department)Enum.Parse(typeof(Department),dr.GetString(14));
                            inquiry.Employee.FullName = dr.GetString(15);

                            inquiry.SoftwareProp.ID = dr.GetInt32(4);
                            inquiry.SoftwareProp.Name = dr.GetString(17);

                            inquiries.Add(inquiry);
                        }
                    }
                }
            }
            return inquiries;
        }

    }
}

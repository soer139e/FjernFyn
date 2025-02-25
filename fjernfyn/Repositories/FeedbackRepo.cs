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
    public class FeedbackRepo
    {
        private readonly string conString;
        private List<Feedback> feedbacks;
        public FeedbackRepo() {
            feedbacks = new List<Feedback>();
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build();

            conString = config.GetConnectionString("DB_KEY");

        }
        public void CreateFeedback(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
             
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Feedback (FeedbackID, Priority, Title, Description,Category," +
                    "CreationDate,EmployeeID,SoftwareID" +
                    "ErrorCode,Image)"
                    + "Values(@Priority, @Title, @Description,@Category,@CreationDate,@EmployeeID,@SoftwareID,@ErrorCode,@Image)", con))
                {
                    cmd.Parameters.AddWithValue("@Criticality", feedback.Priority);
                    cmd.Parameters.AddWithValue("@Title", feedback.Title);
                    cmd.Parameters.AddWithValue("@Description",feedback.Description);
                    cmd.Parameters.AddWithValue("@Category", feedback.Type);
                    cmd.Parameters.AddWithValue("@CreationDate",feedback.CreationDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", feedback.Employee.Id);
                    cmd.Parameters.AddWithValue("@SoftwareID", feedback.SoftwareProp.ID);
                    cmd.Parameters.AddWithValue("@ErrorCode", feedback.ErrorCode);
                    cmd.Parameters.AddWithValue("@Image", feedback.Image);
                    cmd.ExecuteNonQuery();
                }

            }
            
        }
        public List<Feedback> GetAllFeedback() { 
           feedbacks.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open() ;
                //Gets all feedbacks in database as well as the connected Employee and Software.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK JOIN EMPLOYEES ON (EmployeeID = ID) JOIN Software " +
                    "ON (SoftwareID = Software.ID)", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read())
                        {
                            Feedback feedback = new Feedback()
                            {
                                Id = dr.GetInt32(0),
                                Priority=(Priority)Enum.Parse(typeof(Priority),dr.GetString(1)),
                                Title = dr.GetString(2),
                                Description=dr.GetString(3),
                                Type = (Category)Enum.Parse(typeof(Priority),dr.GetString(6)),
                                CreationDate = dr.GetString(7),
                                ErrorCode = dr.GetString(8),
                                Image = dr.GetString(9),
                            };
                            feedback.Employee.Username = dr.GetString(11);
                            feedback.Employee.Email = dr.GetString(13);
                            feedback.Employee.Department = (Department)Enum.Parse(typeof(Department),dr.GetString(14));
                            feedback.Employee.FullName = dr.GetString(15);

                            feedback.SoftwareProp.ID = dr.GetInt32(4);
                            feedback.SoftwareProp.Name = dr.GetString(17);

                            feedbacks.Add(feedback);
                        }
                    }
                }
            }
                return feedbacks;
        }

    }
}

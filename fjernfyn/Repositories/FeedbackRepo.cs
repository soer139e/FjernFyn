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
                //
                //
                //Tilføj alle værdier når database er opdateres
                //
                //
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Feedback (FeedbackID, Priority, Title, Description)"
                    + "Values(@Priority, @Title, @Description)", con))
                {
                    cmd.Parameters.AddWithValue("@Criticality", feedback.Priority);
                    cmd.Parameters.AddWithValue("@Title", feedback.Title);
                    cmd.Parameters.AddWithValue("@Description",feedback.Description);
                    cmd.ExecuteNonQuery();
                }

            }
            
        }
        public List<Feedback> GetFeedbacks() { 
           feedbacks.Clear();
            
           return feedbacks;
        }

    }
}

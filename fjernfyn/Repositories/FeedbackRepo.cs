using System;
using System.Collections;
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
        public FeedbackRepo()
        {
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

                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(1) FROM Employees WHERE id = @EmployeeID", con))
                {
                    checkCmd.Parameters.AddWithValue("@EmployeeID", feedback.Employee.Id);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new InvalidOperationException($"Employee with ID {feedback.Employee.Id} does not exist.");
                    }
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Feedback (Priority, Title, Description, Category, CreationDate, EmployeeID, SoftwareID, ErrorCode, Image) " +
            "VALUES (@Priority, @Title, @Description, @Category, @CreationDate, @EmployeeID, @SoftwareID, @ErrorCode, @Image)", con))
                {
                    cmd.Parameters.AddWithValue("@Priority", feedback.Priority);
                    cmd.Parameters.AddWithValue("@Title", feedback.Title);
                    cmd.Parameters.AddWithValue("@Description", feedback.Description);
                    cmd.Parameters.AddWithValue("@Category", feedback.Type);
                    //TODO: Databind the creation data, AKA MAKE EVERYTHING BE A DATETIME.
                    cmd.Parameters.AddWithValue("@CreationDate", "2025-02-25"); // Use fixed dummy date as string
                    cmd.Parameters.AddWithValue("@EmployeeID", feedback.Employee.Id);
                    cmd.Parameters.AddWithValue("@SoftwareID", feedback.SoftwareProp.ID);
                    //TODO: also databind these two little fellas.
                    cmd.Parameters.AddWithValue("@ErrorCode", "stupid");
                    cmd.Parameters.AddWithValue("@Image", "not real");

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Feedback> GetAllFeedback()
        {
            feedbacks.Clear();
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
                            Feedback feedback = new Feedback()
                            {
                                Id = dr.GetInt32(0),
                                Priority = (Priority)Enum.Parse(typeof(Priority), dr.GetString(1)),
                                Title = dr.GetString(2),
                                Description=dr.GetString(3),

                                //Midlertidlig udkommenteret fordi databasens rækker stemmer ikke overens med koden
                                Type = (Category)Enum.Parse(typeof(Category),dr.GetString(6)),
                                CreationDate = DateOnly.FromDateTime(dr.GetDateTime(7)),
                                ErrorCode = dr.GetString(8),
                                Image = dr.GetString(9),
                            };
                            feedback.Employee.Username = dr.GetString(11);
                            if(!dr.IsDBNull(11))
                                 feedback.Employee.Username = dr.GetString(11);

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

        public List<Feedback> SortInquirys (Software? software,Category? category, Priority? priority)
        {
            {
                var sortedList = feedbacks.AsQueryable();

                if (category != null)
                {
                    sortedList = sortedList.Where(f => f.Type == category.Value);
                    //sortedList = sortedList.Where(f => f.Type != null && f.Type.Equals(category.Value));
                }

                if (priority != null)
                {
                    sortedList = sortedList.Where(f => f.Priority == priority.Value);
                    //sortedList = sortedList.Where(f=> f.Priority != null &&  f.Priority.Equals(priority.Value));
                }
                     
                if (software != null)
                {
                    sortedList = sortedList.Where(f => f.SoftwareProp.Name == software.Name );
                }
                
                return sortedList.ToList(); 
            } 
        }
    }
}

using fjernfyn.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Win32;
using System.Data;
using System.Windows;

namespace fjernfyn.Repositories
{
    public class InquiryRepo
    {
        private readonly string conString;
        private List<Inquiry> inquirys;
        public InquiryRepo()
        {
            inquirys = new List<Inquiry>();
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build();

            conString = config.GetConnectionString("DB_KEY");
            inquirys = GetAllInquirys();

        }
        public void CreateFeedback(Inquiry inquiry)
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
                    cmd.Parameters.AddWithValue("@Priority", inquiry.Priority.ToString());
                    cmd.Parameters.AddWithValue("@Title", inquiry.Title);
                    cmd.Parameters.AddWithValue("@Description", inquiry.Description);
                    cmd.Parameters.AddWithValue("@Category", inquiry.Type.ToString());

                    cmd.Parameters.AddWithValue("@CreationDate", DateOnly.FromDateTime(DateTime.Now));
                    cmd.Parameters.AddWithValue("@EmployeeID", inquiry.Employee.Id);
                    cmd.Parameters.AddWithValue("@SoftwareID", inquiry.SoftwareProp.ID);

                    cmd.Parameters.AddWithValue("@ErrorCode", inquiry.ErrorCode);
                    var imageParam = cmd.Parameters.Add("@Image", SqlDbType.VarBinary, -1);
                    imageParam.Value = (object)inquiry.Image ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Inquiry> GetAllInquirys()
        {
            inquirys.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                //Gets all Inquirys in database as well as the connected Employee and Software.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK JOIN EMPLOYEES ON (EmployeeID = ID) JOIN Software " +
                    "ON (SoftwareID = Software.ID) WHERE IsMarkedAsDone = 0", con))
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
                                Description = dr.GetString(3),


                                Type = (Category)Enum.Parse(typeof(Category), dr.GetString(6)),
                                CreationDate = DateOnly.FromDateTime(dr.GetDateTime(7)),
                                ErrorCode = dr.GetString(8),
                                Image = dr.IsDBNull(9) ? null : (byte[])dr[9]
                            };
                            inquiry.Employee.Username = dr.GetString(12);
                            if (!dr.IsDBNull(12))
                                inquiry.Employee.Username = dr.GetString(12);

                            inquiry.Employee.Department = (Department)Enum.Parse(typeof(Department), dr.GetString(15));
                            inquiry.Employee.FullName = dr.GetString(16);

                            inquiry.SoftwareProp.ID = dr.GetInt32(4);
                            inquiry.SoftwareProp.Name = dr.GetString(18);

                            inquirys.Add(inquiry);
                        }
                    }
                }
            }
            return inquirys;
        }

        public List<Inquiry> SortInquirys(Software? software = null, Category? category = null, Priority? priority = null, string? DateFilter = null)
        {

            var sortedList = inquirys.AsQueryable();

            if (category != null)
            {
                if (category != Category.All)
                {
                    sortedList = sortedList.Where(i => i.Type == category.Value);
                    //sortedList = sortedList.Where(f => f.Type != null && f.Type.Equals(category.Value));
                }
            }

            if (priority != null)
            {
                if (priority != Priority.All)
                {
                    sortedList = sortedList.Where(i => i.Priority == priority.Value);
                    //sortedList = sortedList.Where(f=> f.Priority != null &&  f.Priority.Equals(priority.Value));
                }
            }

            if (software != null)
            {
                if (software.Name != "All")
                {
                    sortedList = sortedList.Where(i => i.SoftwareProp.Name == software.Name);
                }
            }
            if (DateFilter != null)
            {
                if (DateFilter == "Sorter Stigende")
                {
                    sortedList = sortedList.OrderBy(i => i.CreationDate);
                }
                if (DateFilter == "Sorter Faldende")
                {
                    sortedList = sortedList.OrderByDescending(i => i.CreationDate);
                }
            }

            return sortedList.ToList();
        }

        public List<Inquiry> DeleteInquiry(Inquiry inquiry)
        {
            try
            {
                if (inquiry != null)
                {

                    string messageBoxText = "Vil du slette forespørgsel?";
                    string caption = "Slet besked";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult answer;
                    answer = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                    if (answer == MessageBoxResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM Feedback WHERE FeedbackID = @Id", con))
                            {
                                cmd.Parameters.AddWithValue("@id", inquiry.Id);
                                cmd.ExecuteNonQuery();

                            }
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            inquirys = GetAllInquirys();
            return inquirys;
        }

        public List<Inquiry> MarkAsDone(Inquiry inquiry)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Feedback SET IsMarkedAsDone = 1 WHERE FeedbackID = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", inquiry.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            inquirys = GetAllInquirys();
            return inquirys;
        }

    }
}

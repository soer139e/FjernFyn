using System.Windows.Controls;

namespace fjernfyn.Classes
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string ErrorCode { get; set; }
        public Category Type { get; set; }

        public Employee Employee { get; set; }

        public System System { get; set; }
        public Priority Priority { get; set; }

        public Image Image { get; set; }
        public Feedback(int id, string title, string description, DateTime creationDate, string errorCode, Category type, Employee employee, System system, Image image) { 
        Id = id;
            Title = title;  
            Description = description;
            CreationDate = creationDate;
            ErrorCode = errorCode;
            Type = type;
            Employee = employee;
            System = system;
            Image = image;
            Priority = Priority;
            Image = image;

        }

    }
}

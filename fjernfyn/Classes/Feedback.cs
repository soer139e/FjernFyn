using System.Windows.Controls;

namespace fjernfyn.Classes
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Titel";
        public string Description { get; set; } = "Beskrivelse af problem";
        public string CreationDate { get; set; }
        public string ErrorCode { get; set; }
        public Category Type { get; set; }

        public Employee Employee { get; set; }

        public Software Software { get; set; }
        public Priority Priority { get; set; }

        public Image Image { get; set; }

        //public Feedback(int id, string title, string description, DateTime creationDate, string errorCode, Category type, Employee employee, Software software, Image image)
        //{
        //    Id = id;
        //    Title = title;
        //    Description = description;
        //    CreationDate = DateTime.Now.ToShortDateString();
        //    ErrorCode = errorCode;
        //    Type = type;
        //    Employee = employee;
        //    Software = software;
        //    Image = image;
        //    Priority = Priority;
        //    Image = image;

        //}

    }
}

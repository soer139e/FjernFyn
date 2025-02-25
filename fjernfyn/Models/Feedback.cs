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

        public Software SoftwareProp { get; set; }
        public Priority Priority { get; set; }

        public string Image { get; set; }

        public Feedback()
        {
            SoftwareProp = new Software();
        }
    }
}

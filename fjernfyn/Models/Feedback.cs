
using System.ComponentModel;
using System.Windows.Controls;

namespace fjernfyn.Classes
{
    public class Feedback : INotifyPropertyChanged
    {
        private bool _isMarkedAsDone = false;

        public bool IsMarkedAsDone
        {
            get { return _isMarkedAsDone; }
            set { _isMarkedAsDone = value; }

        }

        public int Id { get; set; }
        private string _title = "Titel";
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        public string Description { get; set; } = "Beskrivelse af problem";
        public DateOnly CreationDate { get; set; }
        public string ErrorCode { get; set; }
        public Category? Type { get; set; } = null;

        public Employee Employee { get; set; }

        public Software SoftwareProp { get; set; }
        public Priority? Priority { get; set; } = null;

        public byte[] Image { get; set; }

        public Feedback()
        {
            SoftwareProp = new Software();
            Employee = new Employee();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var value = this.GetType().GetProperty(propertyName)?.GetValue(this, null);
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

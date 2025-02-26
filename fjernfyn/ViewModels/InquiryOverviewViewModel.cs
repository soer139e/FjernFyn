using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Repositories;
using fjernfyn.Classes;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;
namespace fjernfyn
{
    public class InquiryOverviewViewModel : INotifyPropertyChanged
    {
        public List<Feedback> Feedbacks { get; set; }
        private FeedbackRepo feedbackRepo;


        private Feedback _selectedInquiry { get; set; } 
        public Feedback SelectedInquiry
        {
            get { return _selectedInquiry; }
            set { _selectedInquiry = value; OnPropertyChanged(nameof(SelectedInquiry)); }
        }


        public List<Category> Categorys { get; set; } = new List<Category>() { Category.Bug, Category.Feature, Category.Request }; 
        public List<Priority> Prioritys { get; set; } = new List<Priority> { Priority.High,Priority.Medium, Priority.Low }; 
        public List<Software> Softwares { get; set; }
        
        public InquiryOverviewViewModel()
        {
            Feedbacks = new List<Feedback>();
            feedbackRepo = new FeedbackRepo();

            //Feedbacks = feedbackRepo.GetAllFeedback();


            //dummy data
            Feedbacks.Add(new Feedback()
            {
                Title = "Hjælp der ild i lokumet",
                CreationDate = "01:12:1939",
                Type = 0,
                Priority = 0,
                SoftwareProp = new Software() { Name = "Excel"},
                
            });
            Feedbacks.Add(new Feedback()
            {
                Title = "Hjælp der ild i birk",
                CreationDate = "01:12:1939",
                Type = 0,
                Priority = Priority.Low,
                SoftwareProp = new Software() { Name = "janitor software" },

            });


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

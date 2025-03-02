using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Repositories;
using fjernfyn.Classes;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace fjernfyn
{
    public class InquiryOverviewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection <Feedback> Feedbacks { get; set; }
        private FeedbackRepo feedbackRepo;


        private Feedback _selectedInquiry { get; set; } 
        public Feedback SelectedInquiry
        {
            get { return _selectedInquiry; }
            set { _selectedInquiry = value; OnPropertyChanged(nameof(SelectedInquiry)); }
        }



        
        public List<Category> Categorys { get;  } = new List<Category>() {Category.Bug, Category.Feature,Category.Request,Category.None};
        public List<Priority> Prioritys { get; } = new List<Priority>() {Priority.High,Priority.Medium,Priority.Low,Priority.None};

        private Priority _selectedPriority;
        public Priority SelectedPriority
        {
            get { return _selectedPriority; }
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
                SortParametersChangedCommand.Execute(this);
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                SortParametersChangedCommand.Execute(this);
            }
        }
        public List<Software> Softwares { get; set; }
        
        public InquiryOverviewViewModel()
        {
            Feedbacks = new ObservableCollection<Feedback>();
            feedbackRepo = new FeedbackRepo();

            //Feedbacks = feedbackRepo.GetAllFeedback();
            SortParametersChangedCommand = new CommandHandler(SortParameterSelected);

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
        public ICommand SortParametersChangedCommand { get; }

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
        public void SortParameterSelected()
        {
            ObservableCollection< Feedback > sortedFeedback = new ObservableCollection<Feedback>(feedbackRepo.SortInquirys(null, SelectedCategory, SelectedPriority));
            Feedbacks.Clear();
            
           foreach(Feedback feedback in sortedFeedback)
           {
                Feedbacks.Add(feedback);
           }
        }
    }
}

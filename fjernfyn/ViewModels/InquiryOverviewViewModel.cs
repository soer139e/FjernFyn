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
        private SoftwaresRepo softwaresRepo;

        public List<string> DateFilters { get; set; } = new List<string>() { "Sorter Stigende", "Sorter Faldende" };
        private string _selectedDateFilter {  get; set; }
        public string SelectedDateFilter
        {
            get { return _selectedDateFilter; }
            set { _selectedDateFilter = value; OnPropertyChanged(nameof(SelectedDateFilter));
                SortParametersChangedCommand.Execute(this);
            }
        }

        private Feedback _selectedInquiry { get; set; } 
        public Feedback SelectedInquiry
        {
            get { return _selectedInquiry; }
            set { _selectedInquiry = value; OnPropertyChanged(nameof(SelectedInquiry)); }
        }

        private Software _selectedSoftware { get; set; }
        public Software SelectedSoftware
        {
            get { return _selectedSoftware; }
            set { _selectedSoftware = value; OnPropertyChanged(nameof(SelectedSoftware));
                SortParametersChangedCommand.Execute(this);
            }
        }


        
        public List<Category> Categorys { get;  } = new List<Category>() {Category.Bug, Category.Feature,Category.Request,Category.All};
        public List<Priority> Prioritys { get; } = new List<Priority>() {Priority.High,Priority.Medium,Priority.Low,Priority.All};

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
        public ICommand SortParametersChangedCommand { get; }
        public ICommand DeleteInquiryCommand { get; }
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
            
            feedbackRepo = new FeedbackRepo();
            Softwares = new List<Software>();
            softwaresRepo = new SoftwaresRepo();
            Softwares = softwaresRepo.GetAll();
            Feedbacks = new ObservableCollection<Feedback>(feedbackRepo.GetAllFeedback());
            SortParametersChangedCommand = new CommandHandler(SortParameterSelected);
            SelectedCategory = Category.All;
            SelectedPriority = Priority.All;
            DeleteInquiryCommand = new CommandHandler(DeleteInquiry);
            

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
        public void SortParameterSelected()
        {
            ObservableCollection< Feedback > sortedFeedback = new ObservableCollection<Feedback>(feedbackRepo.SortInquirys(SelectedSoftware, SelectedCategory, SelectedPriority,SelectedDateFilter));
            Feedbacks.Clear();
            
           foreach(Feedback feedback in sortedFeedback)
           {
                Feedbacks.Add(feedback);
           }
        }
        public void DeleteInquiry()
        {
            Feedbacks.Clear();
            ObservableCollection<Feedback> sortedFeedback = new ObservableCollection<Feedback>(feedbackRepo.DeleteInquiry(SelectedInquiry));
           
            foreach (Feedback f in sortedFeedback)
            {
                Feedbacks.Add(f);
            }


        }
    }
}

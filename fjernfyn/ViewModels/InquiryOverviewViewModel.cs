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
        public ObservableCollection <Inquiry> Inquirys { get; set; }
        private InquiryRepo inquiryRepo;
        private SoftwaresRepo softwaresRepo;

        public ICommand MarkedAsDoneCommand { get; }
        public List<string> DateFilters { get; set; } = new List<string>() { "Sorter Stigende", "Sorter Faldende" };
        private string _selectedDateFilter {  get; set; }
        public string SelectedDateFilter
        {
            get { return _selectedDateFilter; }
            set { _selectedDateFilter = value; OnPropertyChanged(nameof(SelectedDateFilter));
                SortParametersChangedCommand.Execute(this);
            }
        }

        private Inquiry _selectedInquiry { get; set; } 
        public Inquiry SelectedInquiry
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
            
            inquiryRepo = new InquiryRepo();
            Softwares = new List<Software>();
            softwaresRepo = new SoftwaresRepo();
            Softwares = softwaresRepo.GetAll();
            Inquirys = new ObservableCollection<Inquiry>(inquiryRepo.GetAllInquirys());
            SortParametersChangedCommand = new CommandHandler(SortParameterSelected);
            SelectedCategory = Category.All;
            SelectedPriority = Priority.All;
            DeleteInquiryCommand = new CommandHandler(DeleteInquiry);
            MarkedAsDoneCommand = new CommandHandler(MarkedAsDone);

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

        public void MarkedAsDone()
        {

            ObservableCollection<Inquiry> sortedInquirys = new ObservableCollection<Inquiry>(inquiryRepo.MarkAsDone(SelectedInquiry));
            Inquirys.Clear();

            foreach (Inquiry inquiry in sortedInquirys)
            {
                Inquirys.Add(inquiry);
            }
        }
        public void SortParameterSelected()
        {
            ObservableCollection< Inquiry > sortedInquirys = new ObservableCollection<Inquiry>( inquiryRepo.SortInquirys(SelectedSoftware, SelectedCategory, SelectedPriority,SelectedDateFilter));
            Inquirys.Clear();
            
           foreach(Inquiry inquiry in sortedInquirys)
           {
                Inquirys.Add(inquiry);
           }
        }
        public void DeleteInquiry()
        {
            
            ObservableCollection<Inquiry> sortedInquirys = new ObservableCollection<Inquiry>(inquiryRepo.DeleteInquiry(SelectedInquiry));
            Inquirys.Clear();
            foreach (Inquiry i in sortedInquirys)
            {
                Inquirys.Add(i);
            }


        }
    }
}

using fjernfyn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fjernfyn.Windows;

namespace fjernfyn.ViewModels
{
    public class AdmindashBoardViewModel
    {
        public AdminDashBoardWindow Window { get; set; }
        private Employee employee { get; set; }
        public ICommand CreateFeedbackCommand { get; }
        public ICommand ShowFeedbackCommand { get; }
        public ICommand AdminPanelCommand { get; }
        public ICommand ShowMarkedDoneCommand { get; }
        public AdmindashBoardViewModel(AdminDashBoardWindow window, Employee employee)
        {
            CreateFeedbackCommand = new CommandHandler(CreateFeedbackClicked);
            ShowFeedbackCommand = new CommandHandler(ShowFeedbackClicked);
            AdminPanelCommand = new CommandHandler(AdminPanelClicked);
            ShowMarkedDoneCommand = new CommandHandler(ShowMarkedDoneClicked);
            Window = window;
            this.employee = employee;
        }

        public void CreateFeedbackClicked()
        {

            
            FeedbackCreationWindow createFeedbackWindow = new FeedbackCreationWindow(employee);
            createFeedbackWindow.Show();
            Window.Close();
        }

        public void ShowFeedbackClicked()
        {

         
            InquiryOverview inquiryOverviewWindow = new InquiryOverview();
            inquiryOverviewWindow.Show();
            Window.Close();
        }

        public void ShowMarkedDoneClicked()
        {

        }

        public void AdminPanelClicked()
        {

        }
    }
}

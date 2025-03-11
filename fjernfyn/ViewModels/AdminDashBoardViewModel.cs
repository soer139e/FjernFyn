using fjernfyn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fjernfyn.ViewModels
{
    public class AdminDashBoardViewModel
    {
        public AdminDashBoardWindow Window { get; set; }
        private Employee employee { get; set; }
        public ICommand CreateFeedbackCommand { get; }
        public ICommand ShowFeedbackCommand { get; }
        public ICommand AdminPanelCommand { get; }
        public ICommand ShowMarkedDoneCommand { get; }
        public AdminDashBoardViewModel(AdminDashBoardWindow window, Employee employee)
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

            //Window.Hide();
            //CreateFeedbackWindow createFeedbackWindow = new CreateFeedbackWindow(employee);
            //createFeedbackWindow.Show();
        }

        public void ShowFeedbackClicked()
        {

            //Window.Hide();
            //InquiryOverviewWindow inquiryOverviewWindow = new InquiryOverviewWindow(employee);
            //inquiryOverviewWindow.Show();
        }

        public void ShowMarkedDoneClicked()
        {

            //Window.Hide();
            //MarkedDoneWindow markedDoneWindow = new MarkedDoneWindow(employee);
            //markedDoneWindow.Show();
        }

        public void AdminPanelClicked()
        {
            //Window.Hide();
            //AdminPanelWindow adminPanelWindow = new AdminPanelWindow(employee);
            //adminPanelWindow.Show();
        }
    }
}

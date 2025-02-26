using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Repositories;
using fjernfyn.Classes;
namespace fjernfyn.ViewModels
{
    public class InquiryOverviewViewModel
    {
        public List<Feedback> Feedbacks { get; set; }
        private FeedbackRepo feedbackRepo;
        public InquiryOverviewViewModel()
        {
            Feedbacks = new List<Feedback>();
            feedbackRepo = new FeedbackRepo();

            //Feedbacks = feedbackRepo.GetAllFeedback();

            Feedbacks.Add(new Feedback()
            {
                Title = "Hjælp der ild i lokumet",
                CreationDate = "01:12:1939",
                Type = 0,
                Priority = 0,
                SoftwareProp = new Software() { Name = "Excel"},
                
            });
            

        }
    }
}

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

            Feedbacks = feedbackRepo.GetAllFeedback();
        }
    }
}

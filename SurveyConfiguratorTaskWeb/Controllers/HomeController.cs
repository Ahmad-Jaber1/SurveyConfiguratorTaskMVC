using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Services;

namespace SurveyConfiguratorTaskWeb.Controllers
{
    public class HomeController : Controller
    {
        QuestionService mService = new QuestionService();
        public ActionResult Index()
        {
            mService.ChangeConnectionString("Data Source=.;Database=SurveyConfiguratorDatabase;Trusted_Connection=True;TrustServerCertificate=True;");

            var tQuestionList = mService.QuestionsLoad();
            return View(model: tQuestionList);

        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add()
        //{

        //


    }
    
}
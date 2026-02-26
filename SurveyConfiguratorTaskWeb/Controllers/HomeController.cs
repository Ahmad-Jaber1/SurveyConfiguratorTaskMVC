using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Models;
using Services;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTaskWeb.Models;

namespace SurveyConfiguratorTaskWeb.Controllers
{
    public class HomeController : Controller
    {
        QuestionService mService = new QuestionService();
        public HomeController()
        {
            mService.ChangeConnectionString("Data Source=.;Database=SurveyConfiguratorDatabase;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        public ActionResult Index()
        {

            var tQuestionList = mService.QuestionsLoad();
            return View(model: tQuestionList);

        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBasicQuestoinInfo(BasicQuestionViewModel pQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", pQuestion);
            }
            
            TempData["BasicQuestion"] = pQuestion;
            switch (pQuestion.QuestionType)
            {
                case TypeQuestionEnum.SliderQuestion:
                    TempData["QuestionType"] = TypeQuestionEnum.SliderQuestion;
                    return View("AddSpecificQuestion/SliderView" );
                    
                case TypeQuestionEnum.SmileyFacesQuestion:
                    TempData["QuestionType"] = TypeQuestionEnum.SmileyFacesQuestion;

                    return View("AddSpecificQuestion/SmileyView");
                case TypeQuestionEnum.StarsQuestion:
                    TempData["QuestionType"] = TypeQuestionEnum.StarsQuestion;

                    return View("AddSpecificQuestion/StarsView");

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSliderQuestion(SliderQuestionViewModel pSliderQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSpecificQuestion/SliderView");
            }
            if (TempData["BasicQuestion"] == null)
            {
                return View("Add");
            }
            var tBasicQuestion = (BasicQuestionViewModel)TempData["BasicQuestion"];
            AddQuestionDto tAddQuestionDto = new AddQuestionDto();
            tAddQuestionDto.StartValue = pSliderQuestion.StartValue;
            tAddQuestionDto.EndValue = pSliderQuestion.EndValue;
            tAddQuestionDto.StartCaption = pSliderQuestion.StartCaption;
            tAddQuestionDto.EndCaption = pSliderQuestion.EndCaption;
            tAddQuestionDto.Text = tBasicQuestion.Text;
            tAddQuestionDto.Order = tBasicQuestion.Order;


            mService.AddQuestion(TypeQuestionEnum.SliderQuestion, tAddQuestionDto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSmileyQuestion(SmileyQuestionViewModel pSmileyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSpecificQuestion/SmileyView");
            }
            if (TempData["BasicQuestion"] == null)
            {
                return View("Add");
            }
            var tBasicQuestion = (BasicQuestionViewModel)TempData["BasicQuestion"];
            AddQuestionDto tAddQuestionDto = new AddQuestionDto();
            tAddQuestionDto.SmileyCount = pSmileyQuestion.SmileyCount;
            
            tAddQuestionDto.Text = tBasicQuestion.Text;
            tAddQuestionDto.Order = tBasicQuestion.Order;


            mService.AddQuestion(TypeQuestionEnum.SmileyFacesQuestion, tAddQuestionDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStarsQuestion(StarsQuestionViewModel pStarsQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSpecificQuestion/StarsView");
            }
            if (TempData["BasicQuestion"] == null)
            {
                return View("Add");
            }
            var tBasicQuestion = (BasicQuestionViewModel)TempData["BasicQuestion"];
            AddQuestionDto tAddQuestionDto = new AddQuestionDto();
            tAddQuestionDto.SmileyCount = pStarsQuestion.StarsCount;

            tAddQuestionDto.Text = tBasicQuestion.Text;
            tAddQuestionDto.Order = tBasicQuestion.Order;


            mService.AddQuestion(TypeQuestionEnum.StarsQuestion, tAddQuestionDto);
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id)
        {
            TempData["TryDelete"] = 1;
            return RedirectToAction("Index");
        }

    }

}
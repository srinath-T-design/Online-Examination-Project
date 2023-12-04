
using Bussiness_Logic_Layer;
using Bussiness_Object_Layer.Model;
using Bussiness_Object_Layer.ViewModel;
using System.Web.Mvc;

namespace Online_Examination_System.Controllers
{
    public class subjectController : Controller
    {
        private subjectBL GetSubject;

        public subjectController()
        {
            GetSubject = new subjectBL();
        }
        public ActionResult Index()
        {
            var data = GetSubject.GetList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()                 //inga ae 2 dropdown na create nu oru page la rendu dropdown iruku aathunala tha onuthulae poturukum//
        {
            ViewBag.subjecttitle = GetSubject.Dropdownlistforsubject();
            ViewBag.optiontitle = GetSubject.Dropdownlistforoption();
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(QuestionAnswer ans)

        {
           var data= GetSubject.Create(ans);



            ViewBag.subjecttitle = GetSubject.Dropdownlistforsubject();
            ViewBag.optiontitle = GetSubject.Dropdownlistforoption();
           
          
            return RedirectToAction("Index", new { id = ans.question.ID });      //Getanswer// //Getoptin

        }
        public ActionResult Questionlist(Question que)
        {
            var data = GetSubject.GetQuestion(que);
           
            return View(data);
        }

       


        [HttpGet]
        public ActionResult Edit(int id, Question que)
        {
            var data = GetSubject.details(id);
            return View();

        }
        [HttpPost]
        public ActionResult Edit(Question que)
        {
            GetSubject.Edit(que);
            return RedirectToAction("Index");
        }


       

        public ActionResult delete(int id)
        {
            var data = GetSubject.delete(id);
            return RedirectToAction("Index");

        }
        



        public JsonResult Getanswer(int id)
        {
          var data=  GetSubject.GetAnswer(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult GetPartial(int Selected)           //displaying optiontype //
        {
            if (Selected == 1)
            {
                return PartialView("_yes_no");
            }

            else if (Selected == 2)
            {
                return PartialView("checkbox");
            }
            else if (Selected == 3)
            {
                return PartialView("radio");
            }

            else if (Selected == 4)
            {
                return PartialView("Text_box");
            }
            else
            {
                return View();
            }

           
        }

        [HttpGet]
        public ActionResult Getoptiontbl2()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Getoptiontbl2(QuestionAnswer ans)

        {
            var data = GetSubject.Getoptiontbl(ans);
            return View(data);
        }


        public ActionResult details(int id)               //display the question and answer//

        {

            return View(GetSubject.details(id));
        }


        public ActionResult getoptionpartial(int id)           //showing popup screen//
        {
            var data = GetSubject.getoption(id);
           
            return PartialView("getoptionpartial",data);
            
           // else if (data.optionID == 2)
           // {
           //     return PartialView("_getanswer_check", data);
           // }


           // else if (data.optionID == 3)
           // {
           //     return PartialView("_getanswer_radio2", data);
           // }


           //else if (data.optionID == 4)
           //{
           //     return PartialView("_getanswer_text", data);
           // }
            //return View();

        }





    }


}
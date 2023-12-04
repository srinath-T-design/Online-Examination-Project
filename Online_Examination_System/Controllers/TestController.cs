using Bussiness_Logic_Layer;
using Bussiness_Object_Layer.Model;
using Bussiness_Object_Layer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Online_Examination_System.Controllers
{
    public class TestController : Controller
    {
        private TestBL GetTestBL;
        private object online_;
        Online_examinationEntities db;
        public TestController()
        {
            GetTestBL = new TestBL();
            db = new Online_examinationEntities();
        }


        public ActionResult teststart()
        {

            var data = GetTestBL.GetList();

            return View(data);
        }

        [HttpGet]
        public ActionResult getquestion(int id)
        {

            test_detailtbl test = new test_detailtbl();

            test.subjectid = id;
            test.s_time = Convert.ToDateTime(DateTime.Now);   //start time //

            int userid = Convert.ToInt32(Session["Userid"]);
            test.userid = userid;
            db.test_detailtbl.Add(test);
            db.SaveChanges();

            ViewBag.tid = test.tid;

            var data = GetTestBL.teststart(id);


            return View(data);

        }


        [HttpPost]
        public ActionResult getquestion(IList<QuestionpaperVM> ques1, int tid)
        {

            ViewBag.tid = tid;
           

            var data2 = GetTestBL.checkanswer(ques1, tid);
            GetTestBL.testdetails(tid, ques1);
           

            var data1 = (from td in db.test_detailtbl  
                         join mk in db.Marktbls       
                         on td.tid equals mk.test_id   
                         where td.tid.Equals(tid)
                         select new testdetailVM
                         { // result selector 
                             Subject = td.subjectid,
                             Duration = td.duration,
                                
                             attend = td.attend_ques,
                             not_attend = td.not_attend_ques,
                             marks = mk.mark,
                         }).FirstOrDefault();

            return PartialView("finalresult", data1);

        }
        
    }
}
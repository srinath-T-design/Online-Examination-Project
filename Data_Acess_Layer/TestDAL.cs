
using Bussiness_Object_Layer.Model;
using Bussiness_Object_Layer.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer
{
    public class TestDAL
    {
        private static TestDAL test = null;
        Online_examinationEntities online_;
       

        public TestDAL()
        {
            online_ = new Online_examinationEntities();
        }

        public static TestDAL GetTest
        {
            get
            {
                if (test == null)
                    test = new TestDAL();
                return test;
            }
        }

        public List<QuestionAnswer> GetList()             //subject list katum//
        {
            var data = online_.subjects.ToList();
            List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();
            foreach (var item in data)
            {
                QuestionAnswer question = new QuestionAnswer();
                question._subjects.subjectname = item.subjectname;
                question._subjects.subjectID = item.subjectID;

                questionAnswers.Add(question);

            }

            return questionAnswers;
        }


        //public IEnumerable<QuestionpaperVM> teststart(int id)
        ////option list agum//

        //{

        //    var data = online_.Questions.Where(x => x.subjectID == id).ToList();
            
        //    List<QuestionpaperVM> questionAnswers = new List<QuestionpaperVM>();

        //        foreach (var item1 in data)
        //        {
        //            QuestionpaperVM questionpaperVM = new QuestionpaperVM();
        //            questionpaperVM.QuestionID = item1.ID;
        //            questionpaperVM.Question_name = item1.Question_name;
        //            questionpaperVM.optiontype = item1.optionID;
                  
        //            var option = online_.option_tb.Where(x => x.quesID == item1.ID).ToList();
        //            List<Options> optionss = new List<Options>();
        //            foreach (var item in option)
        //            {
        //                Options options = new Options();
        //                options.optionID = item.optionID;                 //four option irukula athoda id inga katum//
        //                options.optionsname = item.optionsname;         //antha four option inga katum //

        //                optionss.Add(options);
        //            }

           

        //        questionpaperVM.options = optionss;
          
        //        questionAnswers.Add(questionpaperVM);

                  
        //        }

        //    return questionAnswers;
          
        //}
        public IEnumerable<QuestionpaperVM> teststart(int id)
        //option list agum//

        {

            var data = online_.Questions.Where(x => x.subjectID == id).ToList();
            QuestionpaperVM questionpaperVM = new QuestionpaperVM();


            var newlist = data.Select(x => new QuestionpaperVM
            {
                QuestionID = x.ID,
                Question_name = x.Question_name,
                optiontype = x.optionID
            }).ToList();

            List<QuestionpaperVM> questionAnswers = new List<QuestionpaperVM>();
            questionAnswers.AddRange(newlist);


            var newlist2 = online_.option_tb.SelectMany(x => data.Where(u => u.optionID == x.quesID)
                                            .Select(p => new Options { optionID = x.optionID, optionsname = x.optionsname })).ToList();
                questionpaperVM.options = newlist2;


            //foreach (var item1 in data)
            //{
            //    QuestionpaperVM questionpaperVM = new QuestionpaperVM();
            //    questionpaperVM.QuestionID = item1.ID;
            //    questionpaperVM.Question_name = item1.Question_name;
            //    questionpaperVM.optiontype = item1.optionID;

            //    var option = online_.option_tb.Where(x => x.quesID == item1.ID).ToList();
            //    List<Options> optionss = new List<Options>();
            //    foreach (var item in option)
            //    {
            //        Options options = new Options();
            //        options.optionID = item.optionID;                 //four option irukula athoda id inga katum//
            //        options.optionsname = item.optionsname;         //antha four option inga katum //

            //        optionss.Add(options);
            //    }



            //    questionpaperVM.options = optionss;

            //    questionAnswers.Add(questionpaperVM);


            //}

            return questionAnswers;

        }

        public test_detailtbl testdetails(int tid, IList<QuestionpaperVM> ques1)    
        {
           

            var testid = online_.test_detailtbl.Where(x => x.tid == tid).FirstOrDefault();

            testid.e_time = Convert.ToDateTime(DateTime.Now);     //end time//
           
            

            var duration = (testid.e_time - testid.s_time).Value.TotalSeconds;    //durations//
            testid.duration = Convert.ToInt32(duration);

            online_.Entry(testid).State = EntityState.Modified;
            online_.SaveChanges();
            return testid;
            

        }


        public IEnumerable<QuestionpaperVM> checkanswer(IList<QuestionpaperVM> ques,int tid)   //answer checking//
        {
            Marktbl marktbl = new Marktbl();
            var testdetails = online_.test_detailtbl.Where(x => x.tid == tid).FirstOrDefault();
            int radio = 0;
            int marks = 0;
            foreach (var i in ques)
            {

                var optiondata = online_.Questions.Where(x => x.ID == i.QuestionID).FirstOrDefault();
                if (optiondata.optionID != 4)
                {
                    var data1 = online_.Answertbls.Where(x => x.QuestionID == i.QuestionID).FirstOrDefault();

                    if (i.Selected != null)
                    {
                        radio++;
                        if (data1.optionID==i.Selected)
                        {

                           
                            marks++;
                        }
                       

                    }
                    if (optiondata.optionID == 2)
                    {

                        int?[] data = online_.Answertbls.Where(x => x.QuestionID == i.QuestionID).OrderBy(a => a.optionID).Select(y => y.optionID).ToArray();
                        int?[] checkData = i.options.Where(x => x.Checked == true).OrderBy(a => a.optionID).Select(y => (int?)y.optionID).ToArray();

                        if (i.options.Where(x => x.Checked == true).Any())
                        {
                            radio++;
                            if (data.SequenceEqual(checkData))
                            {
                               
                                marks++;
                            }
                       
                        }

                    }
                }
                else
                {

                    var ondata = online_.option_tb.Where(x => x.quesID == i.QuestionID).Select(y => y.optionsname).FirstOrDefault();
                    if (!string.IsNullOrEmpty(i.TextField))
                    {
                        radio++;
                        if (ondata == i.TextField)
                        {
                           
                            marks++;
                        }
                       
                    }

                }


            }
                var que = ques.Count;
                testdetails.attend_ques = radio;
                testdetails.not_attend_ques = que - radio;
            //online_.Entry(testdetails).State = EntityState.Modified;
            marktbl.mark = marks;
            marktbl.test_id = tid;
            online_.Marktbls.Add(marktbl);
            online_.SaveChanges();

            
            return ques;
        }



   
       

    }
}
































































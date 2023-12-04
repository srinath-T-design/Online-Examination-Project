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
    public class subjectDAL
    {
        private static subjectDAL subject = null;
        Online_examinationEntities online;

        public subjectDAL()
        {
            online = new Online_examinationEntities();
        }

        public static subjectDAL getsubject
        {
            get
            {
                if (subject == null)
                    subject = new subjectDAL();
                return subject;
            }
        }


        public IEnumerable<subject> GetList()
        {
            return online.subjects.ToList();
        }

        public Question Create(QuestionAnswer ans)                             //View model using displaying question and answer //
        {
            var question = new Question();



            try
            {


                question.Question_name = ans.question.Question_name;     //question//
                question.subjectID = ans.question.subjectID;
                question.optionID = ans.question.optionID;
                online.Questions.Add(question);
                online.SaveChanges();




                if (ans.question.optionID == 1)                        //yes or no//
                {
                    var option_tbYES = new option_tb();  
                    option_tbYES.quesID = question.ID;         
                    option_tbYES.optionsname = "YES";                    //option display agum yes or no//
                    online.option_tb.Add(option_tbYES);                   // answer yes nu irutha matum tha selected kula pogum//
                    online.SaveChanges();

                    if (ans.Selected == 1)
                    {
                        Answertbl answer = new Answertbl();
                        answer.QuestionID = question.ID;
                        answer.optionID = option_tbYES.optionID;
                        online.Answertbls.Add(answer);
                        online.SaveChanges();
                    }

                    var option_tbNO = new option_tb();                       
                    option_tbNO.quesID = question.ID;
                    option_tbNO.optionsname = "NO";                    //option display agum yes or no//
                    online.option_tb.Add(option_tbNO);                  // answer no nu iurtha ethukula poedum//
                    online.SaveChanges();

                    if (ans.Selected == 2)
                    {
                        Answertbl answer = new Answertbl();
                        answer.QuestionID = question.ID;
                        answer.optionID = option_tbNO.optionID;
                        online.Answertbls.Add(answer);
                        online.SaveChanges();
                    }

                }

                //checkbox//
                if (ans.question.optionID == 2)                                                
                {
                    foreach (var item in ans.option_Tb)
                    {
                        var option_tb = new option_tb();
                        option_tb.quesID = question.ID;                                       //checkbox four option varum aathula selected matum tha //
                        option_tb.optionsname = item.optionsname;                                    // nambo selected matum tha checked kula pogum//
                        online.option_tb.Add(option_tb);
                        online.SaveChanges();



                        if (item.Checked)
                        {
                            Answertbl answer = new Answertbl();
                            answer.QuestionID = question.ID;
                            answer.optionID = option_tb.optionID;
                            online.Answertbls.Add(answer);
                            online.SaveChanges();

                        }

                    }

                }

                //radiobutton//

                int count = 0;                  //count aethuku na,view la na count kuduthukura automatic ha ++ aedum//
                if (ans.question.optionID == 3)     
                {
                    foreach (var item in ans.option_Tb)

                    {
                        var option_tb = new option_tb();
                        option_tb.quesID = question.ID;
                        option_tb.optionsname = item.optionsname;    //four options inga save aedum//
                        online.option_tb.Add(option_tb);
                        online.SaveChanges();
             

                        if (ans.Selected == count)         //selected==count 4 option la naa click pnra onu matum tha correct answer aathu matum tha answertbl kula pogum,balance la return ku poedum//
                        {
                            Answertbl answer = new Answertbl();
                            answer.QuestionID = question.ID;
                            answer.optionID = option_tb.optionID;
                            online.Answertbls.Add(answer);
                            online.SaveChanges();

                        }

                        count++;           // count++ na continue aenu irukum//

                    }

                }

                //text area//
            
                if (ans.question.optionID == 4)
                {
                    foreach (var item in ans.option_Tb)

                    {
                        var option_tb = new option_tb();
                        option_tb.quesID = question.ID;
                        option_tb.optionsname = item.optionsname;    //text-fill in the blank//
                        online.option_tb.Add(option_tb);
                        online.SaveChanges();


                      
                        Answertbl answer = new Answertbl();
                        answer.QuestionID = question.ID;            //textbox la oryae answer tha //
                        answer.optionID = option_tb.optionID;
                        online.Answertbls.Add(answer);
                        online.SaveChanges();

              
                    }

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return question;

        }

        public Question Edit(Question que)
        {

            online.Entry(que).State = System.Data.Entity.EntityState.Modified;
            online.SaveChanges();

            return null;
        }

        public List<Question> details(int id)

        {
            var data = online.Questions.Where(x => x.subjectID == id).Include("subject").ToList();   // include is used to related the data in database its means join the values//
            return data;

        }

        public List<option_tb> getoption(int id)
        {
            var data = online.option_tb.Where(x => x.quesID == id).ToList();
            return data;
        }


        //public option_tb GetOption(int id)
        //{
        //    var data = online.option_tb.Where(x => x.optionID == id).FirstOrDefault();
        //    return data;
        //}
        public Question delete(int id)
        {
            var data = online.subjects.Where(x => x.subjectID == id).FirstOrDefault();
            online.subjects.Remove(data);
            online.SaveChanges();

            return null;
        }


        public List<subject> Dropdownlistforsubject()                 //subject dropdownlist aagum apo subject show pannum//
        {
            return online.subjects.ToList();
        }

        public List<optiontbl> Dropdownlistforoption()                 //option dropdownlist options show agum 4 different options//
        {
            return online.optiontbls.ToList();

        }

        public List<Question> GetQuestion(Question que)
        {

            return online.Questions.ToList();
        }


        public Answertbl GetAnswer(int id)
        {
            return online.Answertbls.Where(x => x.QuestionID == id).FirstOrDefault();

        }


        public List<option_tb> Getoptiontbl2(QuestionAnswer ans)
        {
            return online.option_tb.ToList();


        }

    }
}
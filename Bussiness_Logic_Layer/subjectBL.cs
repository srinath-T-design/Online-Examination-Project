using Bussiness_Object_Layer.Model;
using Bussiness_Object_Layer.ViewModel;
using Data_Acess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic_Layer
{
    public class subjectBL
    {
        private static subjectBL BL = null;
        private subjectDAL dAL = null;

        public subjectBL()
        {
            dAL = subjectDAL.getsubject;

        }

        public static subjectBL bL
        {
            get
            {
                if (BL == null)
                    BL = new subjectBL();
                return BL;

            }
        }
        public IEnumerable<subject> GetList()
        {
            return dAL.GetList();
        }
        public Question Create(QuestionAnswer ans)
        {
            return dAL.Create(ans);

        }
        public Question Edit(Question que)
        {
            return dAL.Edit(que);
        }
        public List<Question> details(int id)
        {
            return dAL.details(id);
        }
        public Question delete(int id)
        {
            return dAL.delete(id);
        }
        public List<subject> Dropdownlistforsubject()
        {
            return dAL.Dropdownlistforsubject();
        }
        public List<optiontbl> Dropdownlistforoption()
        {
            return dAL.Dropdownlistforoption();
        }

        public List<Question> GetQuestion(Question que)
        {
            return dAL.GetQuestion(que);
        }

        public Answertbl GetAnswer(int id)
        {

            return dAL.GetAnswer(id);
        }
 
        public List<option_tb> Getoptiontbl(QuestionAnswer ans)
        {
            return dAL.Getoptiontbl2(ans);

        }

        public List<option_tb> getoption(int id)
        {
            return dAL.getoption(id); 
        }


        //public option_tb GetOption(int id)
        //{
        //    return dAL.GetOption(id);
        //}

    }
}
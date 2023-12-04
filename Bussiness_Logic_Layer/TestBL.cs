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
    public class TestBL
    {
        private static TestBL testBL = null;
        private TestDAL testDAL = null;

        public TestBL()
        {
            testDAL = TestDAL.GetTest;
        }

        public static TestBL GetBL
        {
            get
            {
                if (testBL == null)
                    testBL = new TestBL();
                return testBL;
            }
        }

        public List<QuestionAnswer> GetList()
        {
            return testDAL.GetList();
        }

        public IEnumerable<QuestionpaperVM> teststart(int id)
        {
            return testDAL.teststart(id);
        }
        public IEnumerable<QuestionpaperVM> checkanswer(IList<QuestionpaperVM> ques,int tid)
        {
            return testDAL.checkanswer(ques,tid);
        }

        public test_detailtbl testdetails(int tid, IList<QuestionpaperVM> ques1)
        {
            return testDAL.testdetails(tid, ques1);
        }

        }
}

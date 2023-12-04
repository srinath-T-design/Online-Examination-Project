using Bussiness_Object_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Object_Layer.ViewModel
{
    public class QuestionpaperVM
    {
        public int QuestionID { get; set; }


        public string Question_name { get; set; }
        public List<Options> options { get; set; }

    
        public int optiontype { get; set; }

        public int? Selected { set; get; }

        public int Testid { get; set; }
        public string TextField { set; get; }

        //public int optionID { get; set; }

        public bool Checked { get; set; }

    

    }

    public class Options
    {
        public string optionsname { get; set; }

        public int optionID { get; set; }

        public bool Checked { get; set; }
    }



    public class Time_testVM
    {
        public int tid { get; set; }

        public int subjectid { get; set; }

        public int questionid { get; set; }
        public DateTime s_time { get; set; }

        public DateTime e_time { get; set; }

        public int duration { get; set; }
        public int ques_attend { get; set; }

        public int not_attend { get; set; }
    }
}

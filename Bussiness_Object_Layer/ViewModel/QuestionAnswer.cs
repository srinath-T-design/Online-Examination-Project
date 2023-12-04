using Bussiness_Object_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Object_Layer.ViewModel
{
    public class QuestionAnswer
    {
        public Question question { get; set; }
        public subject _subjects { get; set; } = new subject();
        public Answertbl answertbl { get; set; }

        public List<option_tb> option_Tb { get; set; }

        public option_tb option_Tb1 { get; set; }

        public int? Selected { set; get; }

        public bool checkeds {get;set;}

    }
}

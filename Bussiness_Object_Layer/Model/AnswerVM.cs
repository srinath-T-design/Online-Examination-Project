using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Object_Layer.Model
{
    public class AnswerVM
    {
        public int ID { get; set; }
        public string Question_name { get; set; }

        public Nullable<int> subjectID { get; set; }
      


    }
}

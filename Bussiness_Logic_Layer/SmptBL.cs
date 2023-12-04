using Bussiness_Object_Layer;
using Bussiness_Object_Layer.Common_user;
using Bussiness_Object_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic_Layer
{
    public class SmptBL
    {
        private static SmptBL smptBL = null;

        private Smptservice smptservice = null;

        public SmptBL()
        {
            smptservice = Smptservice.getInstance;
        }
        public static SmptBL smpt
        {
            get
            { 
            if (smptBL == null)
            
                smptBL = new SmptBL();
                return smptBL;
            }
           
        }
        public User Getopt(User user)
        {
            return smptservice.Getotp(user);
        }

        public User otpscreen(User user)
        {
            return smptservice.otpscreen(user);
        }
        public User resetpassword(User user)
        {
            return smptservice.resetpassword(user);
        }






    }
}

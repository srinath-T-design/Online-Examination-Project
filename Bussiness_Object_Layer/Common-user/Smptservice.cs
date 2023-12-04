using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Bussiness_Object_Layer;
using Bussiness_Object_Layer.Model;

namespace Bussiness_Object_Layer.Common_user
{
    public class Smptservice
    {
        private static Smptservice smptservice = null;
        Online_examinationEntities db;
        public Smptservice()
        {
            db = new Online_examinationEntities();
        }

        public static Smptservice getInstance
        {
            get
            {

                if (smptservice == null)

                    smptservice = new Smptservice();

                return smptservice;
            }
        }



        public User Getotp(User user)
        {
            //var email = db.Users.Where(x => x.email == user.email && x.ID == user.ID).FirstOrDefault();
            var data = db.Users.Where(x => x.email == user.email ).FirstOrDefault();
            if (data != null)
            {
                Random rnd = new Random();
                int otp = rnd.Next(1000, 9999);
                var Data = "your otp " + Convert.ToString(otp);

                //string data=""+otp+"";

                MailMessage msg = new MailMessage("srinath.Colan@gmail.com", user.email);
                {


                    msg.Body = Data;
                    msg.IsBodyHtml = false;







                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential("srinath.Colan@gmail.com", "Colan123");

                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = nc;
                    smtp.Port = 587;
                    smtp.Send(msg);



                   


                    data.otp = otp;

                }
                db.SaveChanges();
            }
            return data;
        }
         
       


        public User otpscreen(User user)
        {
            var data = db.Users.Where(x => x.otp == user.otp).FirstOrDefault();
            return data;
        }

        //public User resetpassword(User user)
        //{
        //    var data = db.Users.Where(x => x.email == user.email).FirstOrDefault();
        //    if (data != null)
        //    {
        //        //    resetpassword db = new resetpassword();
        //        //    db.
        //        data.email = "successfully changed";
        //    }
        //    else
        //    {
        //        data.email = "not changed";
        //    }
        //    return data;
        //}
       
        public User resetpassword(User user)
        {
            var data = db.Users.Where(x => x.email == user.email).FirstOrDefault();
            if (data != null)
            {
                data.password = user.password;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return data;
            
        }
        
    }




}
 
      


    
     
      
       
    


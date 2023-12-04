using Bussiness_Logic_Layer;
using Bussiness_Object_Layer.Model;
using System;
using System.Web.Mvc;

namespace Online_Examination_System.Controllers
{
    public class UserController : Controller
    {
        private UserService usercontroller;
        private RoleBL rolecontroller;
        private SmptBL smptBLcontroller;
        Online_examinationEntities online_;

        public UserController()
        {
            usercontroller = UserService.instance;
            rolecontroller = RoleBL.instance;
            smptBLcontroller = SmptBL.smpt;
            online_ = new Online_examinationEntities();

        }
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
       
        public ActionResult Signup()
        {

            return View();
        }

        [HttpPost]
      
        public ActionResult Signup(User  register)      //sign up page new registration page//
        {

            var data = usercontroller.AddUser(register);     


            if (data != null && ModelState.IsValid)
            {
                return RedirectToAction("Login");  
            }
            else
            {
                ModelState.AddModelError(" ", "Please Fill the Details");
            }
            return View(register);


        }
        public ActionResult Result()
        {
            return View();
        }


        [HttpGet]
      
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
      
        public ActionResult Login(User user)    
        {
            var data = usercontroller.Login(user);
            if (data != null&& data.RoleId==1)                   
            {
              
                return RedirectToAction("Create","subject");
            }
            if( data.email!= null && data.password!=null && data.RoleId==2)                   
            {
                Session["Userid"] = data.ID;          
                return RedirectToAction("teststart", "Test");     
            }
            else
           

                ModelState.AddModelError(" ", "please enter the correct pin");
            return View(user);

        }


        [HttpGet]

        public ActionResult Getotp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Getotp(User user)                
        {
            var data = smptBLcontroller.Getopt(user);
            if (data != null)
            {
                return RedirectToAction("otpscreen");
            }
            return View();
        }


        [HttpGet]
        public ActionResult otpscreen()
        {
            return View();
        }


        [HttpPost]


        public ActionResult otpscreen(User user)
        {
            var data = smptBLcontroller.otpscreen(user);
            if (data != null)
            {
                return RedirectToAction("resetpassword", new { email = data.email});
            }
            else
            {
                ModelState.AddModelError("","Invalid OTP");
            }

            return View();
        }


        [HttpGet]
        public ActionResult resetpassword(string email)
        {
            User data = new User(); 
            data.email = email;
            return View(data);
        }


            

            [HttpPost]
            public ActionResult resetpassword(User user)
            {
                smptBLcontroller.resetpassword(user);
                return View("Login");
            }

          

            public ActionResult testpage()
            {
               return View();
            }
        }
    }



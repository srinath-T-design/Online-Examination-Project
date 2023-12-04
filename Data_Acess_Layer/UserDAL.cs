using Bussiness_Object_Layer;
using Bussiness_Object_Layer.Model;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace Data_Acess_Layer
{


    public class UserDAL
        {

        private static UserDAL _instance = null;
        Online_examinationEntities db;
        public UserDAL()
        {
            db = new Online_examinationEntities();
        }


        public static UserDAL instance
        {
            get
            {

                if (_instance == null)

                    _instance = new UserDAL();

                return _instance;
            }
        }
        
        public User AddUser(User user)                      //role id  if roleid=1 admin and roleid=2 student login//
        {

            
            try
            {
                user.RoleId = 2;

                db.Users.Add(user);
                db.SaveChanges();

                return user;
            }
            catch (Exception ex)
            
            {
                Console.WriteLine(ex);
                return user;
            }



        }


        public User Login(User user)                           //naa kuda email kum naa kuda password same ha irukanum  apo tha pogum//
        {
            var data = db.Users.Where(x => x.email == user.email && x.password == user.password).FirstOrDefault();
            return data;
        }
  
      


    }
    }


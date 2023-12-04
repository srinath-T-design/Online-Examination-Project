using Bussiness_Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Acess_Layer;
using Bussiness_Object_Layer.Model;

namespace Bussiness_Logic_Layer
{
    public class UserService
    {

        private static UserService _instance = null;

        private UserDAL _taskDb = null;
        public UserService()
        {
            _taskDb = UserDAL.instance;
        }
        public static UserService instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserService();
                return _instance;
            }
        }

        public User AddUser(User user)
        {
            return _taskDb.AddUser(user);
        }
        public User Login(User user)
        {

            return _taskDb.Login(user);

        }
    }

    }


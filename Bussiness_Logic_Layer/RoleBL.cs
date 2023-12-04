using Data_Acess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Object_Layer;
using Bussiness_Object_Layer.Model;

namespace Bussiness_Logic_Layer
{
    public class RoleBL
    {
        private static RoleBL _instance = null;

        private RoleDAL _roleDb = null;
        public RoleBL()
        {

            _roleDb = RoleDAL.instance;
        }
        public static RoleBL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RoleBL();
                return _instance;
            }
        }
        public List<Role> GetRoles()
       {
            return _roleDb.Getlistrole();
        }



    }
}

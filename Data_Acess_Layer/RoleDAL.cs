using Bussiness_Object_Layer;
using Bussiness_Object_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer
{
    public class RoleDAL
    {
        private static RoleDAL _instance = null;
        Online_examinationEntities db;
        public RoleDAL()
        {
            db = new Online_examinationEntities();
        }
        public static RoleDAL instance
        {
            get
            {

                if (_instance == null)

                    _instance = new RoleDAL();

                return _instance;
            }
        }



        public List<Role> Getlistrole()

        {
            var data = db.Roles.ToList();
            return data;

        }

       


    }
}

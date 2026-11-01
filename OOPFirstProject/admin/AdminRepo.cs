using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.admin
{
    internal class AdminRepo
    {
        private AdminModel admin = new AdminModel("admin", "123");

        public AdminRepo() { }

        public AdminModel GetAdmin()
        {
            return admin;
        }
    }
}


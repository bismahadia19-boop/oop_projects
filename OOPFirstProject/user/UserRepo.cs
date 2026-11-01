using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.user
{
    internal class UserRepo
    {
        private string file = "feedback.txt";

        public UserRepo() { }

        public void SaveFeedback(UserModel user)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(user.ToString());
            }
        }

       }
}


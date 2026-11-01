using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.user
{
    internal class UserModel
    {
        private string feedback;

        public UserModel(string feedback)
        {
            this.feedback = feedback;
        }

        public string SetFeedback(string feedback)
        {
            this.feedback = feedback;
            return feedback;
        }

        public string GetFeedback()
        {
            return feedback;
        }

        public override string ToString()
        {
            return feedback;
        }
    }
}


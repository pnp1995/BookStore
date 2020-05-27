using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreModel.Model
{
   public  class LoginModel
    {
        private string emailid;
        public string Emailid
        {
            set { this.emailid = value; }
            get { return this.emailid; }
        }
        private string password;

        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }


   }
}

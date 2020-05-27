using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace BookstoreModel.Model
{
    public class UserModel
    {
        private string firstName;

        public string FirstName
        {
            set { this.firstName = value; }
            get { return this.firstName; }
        }

        private string lastName;
        
        public string LastName
        {
            set { this.lastName = value; }
            get { return this.lastName; }
        }
        private string emailid;
        [Key]
        public string Emailid
        {
            set { this.emailid = value; }
            get { return this.emailid; }
        }


        private string password;

        public string Password
        {
            set { this.password = value;}
            get { return this.password;}
        }
    
    }


}

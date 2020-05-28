using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace BookstoreModel.Model
{
    public class UserModel
    {
        [Key]
        public int Userid { get; set; } 

        private string firstName;

        public string FirstName
        {
            set { this.firstName = value;}
            get { return this.firstName; }
        }

        private string lastName;
        
        public string LastName
        {
            set { this.lastName = value; }
            get { return this.lastName; }
        }
        private string emailid;
        
        public string Emailid
        {
            set { this.emailid = value; }
            get { return this.emailid; }
        }

        private string password;

        [DataType(DataType.Password)]
        public string Password
        {
            set { this.password = value;}
            get { return this.password;}
        }
    
    }


}

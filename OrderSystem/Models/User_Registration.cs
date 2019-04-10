using System;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models

{
    public class User_Registration
    {
        [Key]
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Address { get; set; }
        public string Email_ID { get; set; }
        public string User_Password { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string City_Name { get; set; }
        public string Zip_Code { get; set; }
        public string State_Name { get; set; }
        public bool User_Status { get; set; }

    }
}

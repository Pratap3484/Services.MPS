using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.MPS.Models
{
    public class PesrsonalUser
    {
        public string Rec_ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string zipcode { get; set; }
        public string Designation { get; set; }
        public string YearsOfExp { get; set; }
        public string Experience { get; set; }
        public string PresentCompanyName { get; set; }
        public string PeriodOfWorking { get; set; }
        public string Work_Sector { get; set; }
        public string Last_Salary { get; set; }
        public string Altenative_mobile { get; set; }
        public string AboutMe { get; set; }
        public string Resume { get; set; }
        public string UserType { get; set; }
        public string CurrencyType { get; set; }
        public string ImgPath { get; set; }
        public string LastLogedin { get; set; }

    }

    public class PesrsonalUserRes
    {
       
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string LastLoginDateTime { get; set; }

        public string UserType { get; set; }
    

    }
}
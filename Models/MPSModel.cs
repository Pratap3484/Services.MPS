using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.MPS.Models
{
    public class MPSModel
    {
    }
    public class UserReg
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emailid { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string devicetype { get; set; }
        public string branch { get; set; }
        public string ipaddress { get; set; }
        public string regtype { get; set; }
        public string Status { get; set; }
        public string UserTyeDesc { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }

    public class SignCls
    {
      
        public string emailid { get; set; }
    
        public string password { get; set; }
        public string usertype { get; set; }
    
    }

    public class ForgetCls
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string newpassword { get; set; }
        public string UUID { get; set; }
    }


    public class Country_class
    {

        public string id { get; set; }
        public string CountryName { get; set; }
        public string PhoneCode { get; set; }

    }

    public class State_class
    {

        public string id { get; set; }
        public string StateName { get; set; }
        public string CountryID { get; set; }

    }

    public class City_class
    {

        public string id { get; set; }
        public string CityName { get; set; }
        public string StateID { get; set; }

    }




    public class RegResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }

        public string Country { get; set; }
    }

    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public dynamic ResponseList { get; set; }
      
    }
    public class APIResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public dynamic ResponseList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.MPS.Models
{
    public class JobDeatilsModel
    {

    }
    public class JobDeatils
    {
        public string Rec_ID { get; set; }
        public string Post_Category { get; set; }
        public string Post_SubCategory { get; set; }
        public string CompanyName { get; set; }

        public string NoOfEmp { get; set; }
        public string Emp_experince { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string shifttimings { get; set; }
        public string ContractPeriod { get; set; }
        public string ContractType { get; set; }
        public string PaymentType { get; set; }
        public string PayMode { get; set; }
        public string CurrencyType { get; set; }
        public string Amount { get; set; }
        public string WorkLocation { get; set; }
        public string TransaposrtFacility { get; set; }
        public string UserID { get; set; }
        public string RecordType { get; set; }
        public string Recd_status { get; set; }
        public string Access_status { get; set; }
        public string Entdt { get; set; }
        public string post_explanation { get; set; }
        public string post_comments { get; set; }

        public string RequestType { get; set; }

        public string Country { get; set; }
        public string State { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Post_Title { get; set; }
        public string Other { get; set; }

    }

    public class JobApplyModel
    {
        public string RecID { get; set; }
        public string JobID { get; set; }

        public string NoOfEmp { get; set; }
        public string Emp_experince { get; set; }
        public string UserID { get; set; }
        public string Recd_status { get; set; }
        public string Access_status { get; set; }
        public string Entdt { get; set; }
        public string post_comments { get; set; }
        public string Other { get; set; }

        public string UserType { get; set; }

    }
    public class AppliedJobDetails
    {
        public string JobAplliedRecID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string CompanyName { get; set; }

        public string PostReqNoOfEmp { get; set; }
        public string NoOfEmp { get; set; }
        public string Emp_experince { get; set; }

        public string shifttimings { get; set; }
        public string ContractPeriod { get; set; }
        public string ContractType { get; set; }
        public string PaymentType { get; set; }
        public string PayMode { get; set; }
        public string CurrencyType { get; set; }
        public string Amount { get; set; }
        public string WorkLocation { get; set; }
        public string TransaposrtFacility { get; set; }


        public string Access_status { get; set; }
        public string JobPostEntdt { get; set; }
        public string post_explanation { get; set; }
        public string post_comments { get; set; }
        public string RequestType { get; set; }

        public string Country { get; set; }
        public string State { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Post_Title { get; set; }
        public string Other { get; set; }


        public string JobID { get; set; }

        public string JobAppliedDate { get; set; }


    }

}
using ManPowerSolsAPI.Models;
using Services.MPS.BusLogics;
using Services.MPS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.MPS.Controllers
{
    public class JobDeatilsController : ApiController
    {
        BusinessLogic blObj = new BusinessLogic();

        public Response InsertJobDeatails(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                if (model.RequestType.ToString() == "Insert")
                    ds = blObj.InsertJobDetails(model);
                else if (model.RequestType.ToString() == "View")
                    ds = blObj.GetJobDetails(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.Recd_status = dr["Recd_status"].ToString();
                                data.RecordType = dr["RecordType"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }

                }

                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }


        [HttpPost]
        public Response GetJobDeatailsByAccessStatus(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.GetJobDetailsByAccess(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();

                                data.Recd_status = dr["Recd_status"].ToString();
                                data.RecordType = dr["RecordType"].ToString();



                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();


                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }

        [HttpPost]
        public Response UpdateJobDetailsAccessStatus(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.UpdateJobDetailsAccessStatus(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.Recd_status = dr["Recd_status"].ToString();
                                data.RecordType = dr["RecordType"].ToString();



                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();

                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }

        [HttpPost]
        public Response UpdateJobRecordStatus(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.UpdateJobDetailsRecordStatus(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    response = new Response
                    {
                        ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                        ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                    };

                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }



        [HttpPost]
        public Response GetJobDetailsByJobID(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.GetJobDetailsByID(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.RecordType = dr["RecordType"].ToString();
                                data.Recd_status = dr["Recd_status"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }


        [HttpPost]
        public Response GetJobDetailsByJobID_edit(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.GetJobDetailsByIDForEdit(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.RecordType = dr["RecordType"].ToString();
                                data.Recd_status = dr["Recd_status"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }


        [HttpPost]
        public Response UpdateJobDeatails(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.UpdateJobDetails(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<JobDeatils> joblist = new List<JobDeatils>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                JobDeatils data = new JobDeatils();
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Post_Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["Access_status"].ToString();
                                data.Post_SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.Entdt = dr["Entdt"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.Recd_status = dr["Recd_status"].ToString();
                                data.RecordType = dr["RecordType"].ToString();

                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();
                                data.FromTime = dr["FromTime"].ToString();
                                data.ToTime = dr["ToTime"].ToString();
                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                        else
                        {
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }

                }

                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }

        [HttpPost]
        public Response InsertJobApplyDeatails(JobApplyModel model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;

                ds = blObj.InsertJobApplyDetails(model);
                if (ds != null && ds.Tables.Count > 0)
                {
                    response = new Response
                    {
                        ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                        ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                    };
                }

                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }

        [HttpPost]
        public Response GetAppliedJobDetailsByUserID(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.GetAppliedJobDetailsByUSERID(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AppliedJobDetails> joblist = new List<AppliedJobDetails>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                AppliedJobDetails data = new AppliedJobDetails();
                                data.JobAplliedRecID = dr["JobAplliedRecID"].ToString();
                                data.JobID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["ReqAccess_status"].ToString();
                                data.SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.JobPostEntdt = dr["Entdt"].ToString();
                                data.JobAppliedDate = dr["JobAppliedDate"].ToString();

                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.PostReqNoOfEmp = dr["PostReqNoOfEmp"].ToString();

                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();

                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }
        [HttpPost]
        public Response GetAppliedJobDetailsByUSERIDWithRecordType(JobDeatils model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.GetAppliedJobDetailsByUSERIDWithRecordType(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AppliedJobDetails> joblist = new List<AppliedJobDetails>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                AppliedJobDetails data = new AppliedJobDetails();
                                data.JobAplliedRecID = dr["JobAplliedRecID"].ToString();
                                data.JobID = dr["Rec_ID"].ToString();
                                data.shifttimings = dr["shifttimings"].ToString();
                                data.Category = dr["Post_Category"].ToString();
                                data.Access_status = dr["ReqAccess_status"].ToString();
                                data.SubCategory = dr["Post_SubCategory"].ToString();
                                data.ContractPeriod = dr["ContractPeriod"].ToString();
                                data.JobPostEntdt = dr["Entdt"].ToString();
                                data.JobAppliedDate = dr["JobAppliedDate"].ToString();

                                data.WorkLocation = dr["WorkLocation"].ToString();
                                data.Emp_experince = dr["Emp_experince"].ToString();
                                data.CompanyName = dr["CompanyName"].ToString();
                                data.NoOfEmp = dr["NoOfEmp"].ToString();
                                data.PostReqNoOfEmp = dr["PostReqNoOfEmp"].ToString();

                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.ZipCode = dr["ZipCode"].ToString();
                                data.PaymentType = dr["PaymentType"].ToString();
                                data.PayMode = dr["PayMode"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.Amount = dr["Amount"].ToString();
                                data.post_comments = dr["post_comments"].ToString();
                                data.Post_Title = dr["post_title"].ToString();
                                data.Other = dr["other_category"].ToString();
                                data.TransaposrtFacility = dr["TransaposrtFacility"].ToString();
                                data.post_explanation = dr["post_explanation"].ToString();

                                joblist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    joblist
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }
        [HttpPost]
        public Response GetUserDeatailsByJobID(PesrsonalUser model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;

                ds = blObj.GetUserDetailsByJobID(model);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<PesrsonalUser> userdetails = new List<PesrsonalUser>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                PesrsonalUser data = new PesrsonalUser();

                                data.UserID = dr["UserID"].ToString();
                                data.FirstName = dr["FirstName"].ToString();
                                data.LastName = dr["LastName"].ToString();
                                data.Mobile = dr["Mobile"].ToString();
                                data.Email = dr["Email"].ToString();
                                data.UserType = dr["UserType"].ToString();
                                userdetails.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    userdetails
                                }
                            };
                        }
                    }
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),

                        };
                    }
                }

                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }



        [HttpPost]
        public Response UpdateJobApplyDeatails(JobApplyModel model)
        {
            try
            {
                var response = new Response();

                DataSet ds = null;

                ds = blObj.UpdateJobApplyDetails(model);
                if (ds != null && ds.Tables.Count > 0)
                {
                    response = new Response
                    {
                        ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                        ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                    };
                }

                else
                {
                    response = new Response
                    {
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }
                return response;
            }
            catch (Exception ex)
            {

                return new Response
                {
                    ResponseCode = Common.ReturnCode("ErrorCode"),
                    ResponseMessage = Common.ReturnCode("ErrorMessage")
                };
            }
        }
    }
}

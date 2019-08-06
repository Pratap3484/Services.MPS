using ManPowerSolsAPI.Models;
using Services.MPS.BusLogics;
using Services.MPS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Services.MPS.Controllers
{
    public class UserDetailsController : ApiController
    {
        BusinessLogic blObj = new BusinessLogic();

        [System.Web.Http.HttpPost]
        public Response InsertUserPersonalDeatails(PesrsonalUser model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                if (model.ImgPath != null && model.ImgPath != "")
                    model.ImgPath = "http://mps.manpowersupplier.net/img/admin.png";
                ds = blObj.InsertPersonalUser(model);
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
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.FirstName = dr["FirstName"].ToString();
                                data.LastName = dr["LastName"].ToString();
                                data.Mobile = dr["Mobile"].ToString();
                                data.Email = dr["Email"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.zipcode = dr["zipcode"].ToString();
                                data.Designation = dr["Designation"].ToString();
                                data.YearsOfExp = dr["YearsOfExp"].ToString();
                                data.Experience = dr["Experience"].ToString();
                                data.PresentCompanyName = dr["PresentCompanyName"].ToString();


                                data.PeriodOfWorking = dr["PeriodOfWorking"].ToString();
                                data.Work_Sector = dr["Work_Sector"].ToString();
                                data.Last_Salary = dr["Last_Salary"].ToString();
                                data.Altenative_mobile = dr["Altenative_mobile"].ToString();
                                data.AboutMe = dr["AboutMe"].ToString();
                                data.Resume = dr["Resume"].ToString();
                                data.UserType = dr["UserType"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.ImgPath = dr["ImgPath"].ToString();

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

        [System.Web.Http.HttpPost]
        public Response GetUserPersonalDeatails(PesrsonalUser model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                model.ImgPath = "http://mps.manpowersupplier.net/img/admin.png";
                ds = blObj.GetPersonalUser(model);
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
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.FirstName = dr["FirstName"].ToString();
                                data.LastName = dr["LastName"].ToString();
                                data.Mobile = dr["Mobile"].ToString();
                                data.Email = dr["Email"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.zipcode = dr["zipcode"].ToString();
                                data.Designation = dr["Designation"].ToString();
                                data.YearsOfExp = dr["YearsOfExp"].ToString();
                                data.Experience = dr["Experience"].ToString();
                                data.PresentCompanyName = dr["PresentCompanyName"].ToString();
                                data.PeriodOfWorking = dr["PeriodOfWorking"].ToString();
                                data.Work_Sector = dr["Work_Sector"].ToString();
                                data.Last_Salary = dr["Last_Salary"].ToString();
                                data.Altenative_mobile = dr["Altenative_mobile"].ToString();
                                data.AboutMe = dr["AboutMe"].ToString();
                                data.Resume = dr["Resume"].ToString();
                                data.UserType = dr["UserType"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.ImgPath = dr["ImgPath"].ToString();

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
                    else if (ds.Tables[0].Rows[0][0].ToString() == "201")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                PesrsonalUser data = new PesrsonalUser();
                                data.FirstName = dr["FirstName"].ToString();
                                data.LastName = dr["LastName"].ToString();
                                data.Mobile = dr["Mobile"].ToString();
                                data.Email = dr["Email"].ToString();
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

        public Response UpdateUserPersonalDeatails(PesrsonalUser model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.UpdatePersonalUser(model);
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
                                data.Rec_ID = dr["Rec_ID"].ToString();
                                data.UserID = dr["UserID"].ToString();
                                data.FirstName = dr["FirstName"].ToString();
                                data.LastName = dr["LastName"].ToString();
                                data.Mobile = dr["Mobile"].ToString();
                                data.Email = dr["Email"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["State"].ToString();
                                data.City = dr["City"].ToString();
                                data.zipcode = dr["zipcode"].ToString();
                                data.Designation = dr["Designation"].ToString();
                                data.YearsOfExp = dr["YearsOfExp"].ToString();
                                data.Experience = dr["Experience"].ToString();
                                data.PresentCompanyName = dr["PresentCompanyName"].ToString();


                                data.PeriodOfWorking = dr["PeriodOfWorking"].ToString();
                                data.Work_Sector = dr["Work_Sector"].ToString();
                                data.Last_Salary = dr["Last_Salary"].ToString();
                                data.Altenative_mobile = dr["Altenative_mobile"].ToString();
                                data.AboutMe = dr["AboutMe"].ToString();
                                data.Resume = dr["Resume"].ToString();
                                data.UserType = dr["UserType"].ToString();
                                data.CurrencyType = dr["CurrencyType"].ToString();
                                data.ImgPath = dr["ImgPath"].ToString();

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


    }
}
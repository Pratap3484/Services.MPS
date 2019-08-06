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
    public class AdminController : ApiController
    {
        BusinessLogic blObj = new BusinessLogic();

        [HttpPost]
        public Response GetPendingUserDetails()
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.GetPendingUsers();
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<UserReg> joblist = new List<UserReg>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                UserReg data = new UserReg();
                                data.emailid = dr["userid"].ToString();
                                data.firstname = dr["firstname"].ToString();
                                data.lastname = dr["lastname"].ToString();
                                data.mobile = dr["mobile"].ToString();
                                data.usertype = dr["usertype"].ToString();
                                data.UserTyeDesc = dr["Userdesc"].ToString();
                                data.Status = dr["active"].ToString() == "P" ? "Pending" : dr["active"].ToString();
                                data.Country = dr["Country"].ToString();
                                data.State = dr["state"].ToString();
                                data.City = dr["City"].ToString();
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
        public Response UpdateUserStatus(UserReg model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.UpdateUserStatus(model);
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

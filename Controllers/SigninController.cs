using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.MPS.BusLogics;
using ManPowerSolsAPI.Models;
using Services.MPS.Models;
using System.Data;

namespace Services.MPS.Controllers
{
    public class SigninController : ApiController
    {
        BusinessLogic blObj = new BusinessLogic();
        MailRepository mail = new MailRepository();

        [System.Web.Http.HttpPost]
        public Response SignIn_with_Password(SignCls model)
        {

            try
            {
                var response = new Response();

                DataSet ds = null;
                ds = blObj.SignWithPassword(model);
                List<PesrsonalUserRes> userdetails = new List<PesrsonalUserRes>();
                if (ds.Tables[0].Rows[0][0].ToString() == "200")
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            PesrsonalUserRes data = new PesrsonalUserRes();
                            data.FirstName = dr["FirstName"].ToString();
                            data.LastName = dr["LastName"].ToString();
                            data.Mobile = dr["Mobile"].ToString();
                            data.Email = dr["Email"].ToString();
                            data.UserType = dr["UserType"].ToString();
                            data.LastLoginDateTime = dr["LastLoginTime"].ToString();
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
                    else
                    {
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString()
                        };
                    }
                }
                else
                {
                    response = new Response
                    {
                        ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                        ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString()
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
        public HttpResponseMessage ChangePassword(ForgetCls model)
        {
            try
            {
                DataSet ds = null;
                ds = blObj.ChangePassword(model);
                APIResponse response = new APIResponse();
                response.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                response.ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex);
            }
        }

        public HttpResponseMessage UpdatePassword(ForgetCls model)
        {
            try
            {
                DataSet ds = null;
                ds = blObj.UpdatePassword(model);
                APIResponse response = new APIResponse();
                if (ds.Tables[0].Rows[0]["StatusCode"].ToString() == "200")
                {
                    mail.UpdatePasswordMail(model.userid);
                }
                response.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                response.ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex);
            }
        }
        public HttpResponseMessage ForgetPassword(ForgetCls model)
        {
            try
            {
                DataSet ds = null;
               
                ds = blObj.ForgetPassword(model);
                APIResponse response = new APIResponse();
                if (ds.Tables[0].Rows[0]["StatusCode"].ToString() == "200")
                {
                    string linkdata = ds.Tables[0].Rows[0]["UUID"].ToString();
                    mail.forgetmail(linkdata, model.userid, ds.Tables[0].Rows[0]["ID"].ToString());
                }
                response.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                response.ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex);
            }
        }

        public HttpResponseMessage CheckForgetLink(ForgetCls model)
        {
            try
            {
                DataSet ds = null;
                MailRepository mail = new MailRepository();

                ds = blObj.LinkCheck(model);
                APIResponse response = new APIResponse();

                response.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                if (ds.Tables[0].Rows[0]["StatusCode"].ToString() == "200")
                    response.ResponseMessage = ds.Tables[0].Rows[0]["EmailID"].ToString();
                else
                    response.ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString();

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex);
            }
        }

    }
}

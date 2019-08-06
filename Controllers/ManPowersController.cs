using Services.MPS.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using Services.MPS;
using Services.MPS.BusLogics;
using Newtonsoft.Json;
using System;

using ManPowerSolsAPI.Models;
using System.Web.Script.Serialization;
using System.Web.Http;

namespace Services.MPS.Controllers
{
    public class ManPowersController : ApiController
    {
        BusinessLogic blObj = new BusinessLogic();


        [System.Web.Http.HttpPost]
        public Response RegisterUser(UserReg model)
        {

            try
            {
                var response = new Response();
                string jsonResult = "";

                DataSet ds = null;
                ds = blObj.ResgerUser(model);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Statuscode"].ToString() == "200")
                    {
                        blObj.mail(ds.Tables[0].Rows[0]["UserId"].ToString(), "Reg");
                        RegResponse usrreg = new RegResponse();
                        usrreg.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                        usrreg.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        usrreg.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                        usrreg.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                        usrreg.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                        usrreg.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                        response = new Response
                        {
                            ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                            ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                            ResponseList = new
                            {
                                usrreg
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
                        ResponseCode = Common.ReturnCode("ErrorCode"),
                        ResponseMessage = Common.ReturnCode("ErrorMessage")
                    };
                }

                //var JSS = new JavaScriptSerializer();
                //jsonResult = JSS.Serialize(response);

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
        public Response GetCountryList()
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.GetCountryList();
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<Country_class> countrylist = new List<Country_class>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                Country_class data = new Country_class();
                                data.id = dr["id"].ToString();
                                data.CountryName = dr["countrtname"].ToString();
                                data.PhoneCode = dr["phonecode"].ToString();
                                countrylist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    countrylist
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
        public Response GetStateList(State_class model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.GetStatesList(model);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<State_class> statelist = new List<State_class>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                State_class data = new State_class();
                                data.id = dr["id"].ToString();
                                data.StateName = dr["statename"].ToString();
                                data.CountryID = dr["countryid"].ToString();
                                statelist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    statelist
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
        public Response GetCityList(City_class model)
        {
            try
            {
                var response = new Response();
                DataSet ds = null;
                ds = blObj.GetCityList(model);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<City_class> citylist = new List<City_class>();
                    if (ds.Tables[0].Rows[0][0].ToString() == "200")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                City_class data = new City_class();
                                data.id = dr["id"].ToString();
                                data.CityName = dr["cityname"].ToString();
                                data.StateID = dr["state_id"].ToString();
                                citylist.Add(data);
                            }
                            response = new Response
                            {
                                ResponseCode = ds.Tables[0].Rows[0]["Statuscode"].ToString(),
                                ResponseMessage = ds.Tables[0].Rows[0]["Message"].ToString(),
                                ResponseList = new
                                {
                                    citylist
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



        public class UserModel
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Company { get; set; }
        }
        [System.Web.Http.HttpGet]
        public List<UserModel> GetData()
        {
            var usersList = new List<UserModel>
            {
                new UserModel
                {
                    UserId = 1,
                    UserName = "Ram",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "chand",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "Abc",
                    Company = "Abc Solutions"
                }
            };

            return usersList;
        }
    }
}

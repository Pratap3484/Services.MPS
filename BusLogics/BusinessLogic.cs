using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Services.MPS.Models;
using System.Text;
using System.Net.Mail;

namespace Services.MPS.BusLogics
{
    public class BusinessLogic
    {
        string conStr = ConfigurationManager.AppSettings["ClientServer"].ToString();
        public DataSet ResgerUser(UserReg _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_userregistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_firstname", _ur.firstname);
                cmd.Parameters.AddWithValue("@i_lastname", _ur.lastname);
                cmd.Parameters.AddWithValue("@i_emailid", _ur.emailid);
                cmd.Parameters.AddWithValue("@i_mobile", _ur.mobile);
                cmd.Parameters.AddWithValue("@i_password", _ur.password);
                cmd.Parameters.AddWithValue("@i_usertype", _ur.usertype);
                cmd.Parameters.AddWithValue("@i_devicetype", _ur.devicetype);
                cmd.Parameters.AddWithValue("@i_branch", _ur.branch);
                cmd.Parameters.AddWithValue("@i_ipaddress", _ur.ipaddress);
                cmd.Parameters.AddWithValue("@i_regtype", _ur.regtype);

                cmd.Parameters.AddWithValue("@state", _ur.State);
                cmd.Parameters.AddWithValue("@Country", _ur.Country);
                cmd.Parameters.AddWithValue("@City", _ur.City);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }



        public DataSet SignWithPassword(SignCls _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_check_LoginStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_userid", _ur.emailid);
                cmd.Parameters.AddWithValue("@i_pwd", _ur.password);
                cmd.Parameters.AddWithValue("@i_type", _ur.usertype);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet ChangePassword(ForgetCls _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_forgetpassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_userid", _ur.userid);
                cmd.Parameters.AddWithValue("@i_pwd", _ur.password);
                cmd.Parameters.AddWithValue("@i_type", _ur.usertype);
                cmd.Parameters.AddWithValue("@i_newpwd", _ur.newpassword);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet UpdatePassword(ForgetCls _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_updatepassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_userid", _ur.userid);
                cmd.Parameters.AddWithValue("@i_pwd", _ur.password);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet ForgetPassword(ForgetCls _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_CHECKUSERID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_emailid", _ur.userid);
                cmd.Parameters.AddWithValue("@i_usertype", _ur.usertype);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet LinkCheck(ForgetCls _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_CheckLink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_id", _ur.userid);
                cmd.Parameters.AddWithValue("@i_uuid", _ur.UUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet InsertJobDetails(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_insert_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_Category", _ur.Post_Category);
                cmd.Parameters.AddWithValue("@Post_SubCategory", _ur.Post_SubCategory);
                cmd.Parameters.AddWithValue("@NoOfEmp", _ur.NoOfEmp);
                cmd.Parameters.AddWithValue("@Emp_experince", _ur.Emp_experince);
                cmd.Parameters.AddWithValue("@shifttimings", _ur.shifttimings);
                cmd.Parameters.AddWithValue("@ContractPeriod", _ur.ContractPeriod);
                cmd.Parameters.AddWithValue("@WorkLocation", _ur.WorkLocation);
                cmd.Parameters.AddWithValue("@TransaposrtFacility", _ur.TransaposrtFacility);
                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);
                cmd.Parameters.AddWithValue("@post_explanation", _ur.post_explanation);
                cmd.Parameters.AddWithValue("@CompanyName", _ur.CompanyName);
                /////////////////////////////////

                cmd.Parameters.AddWithValue("@Country", _ur.Country);
                cmd.Parameters.AddWithValue("@State", _ur.State);
                cmd.Parameters.AddWithValue("@City", _ur.City);
                cmd.Parameters.AddWithValue("@ZipCode", _ur.ZipCode);
                cmd.Parameters.AddWithValue("@PaymentType", _ur.PaymentType);
                cmd.Parameters.AddWithValue("@PayMode", _ur.PayMode);
                cmd.Parameters.AddWithValue("@CurrencyType", _ur.CurrencyType);
                cmd.Parameters.AddWithValue("@Amount", _ur.Amount);
                cmd.Parameters.AddWithValue("@post_comments", _ur.post_comments);
                cmd.Parameters.AddWithValue("@post_title", _ur.Post_Title);
                cmd.Parameters.AddWithValue("@other_category", _ur.Other);
                cmd.Parameters.AddWithValue("@FromTime", _ur.FromTime);
                cmd.Parameters.AddWithValue("@ToTime", _ur.ToTime);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet InsertJobApplyDetails(JobApplyModel _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_insert_jobdApplyetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@JobID", _ur.JobID);
                cmd.Parameters.AddWithValue("@NoOfEmp", _ur.NoOfEmp);
                cmd.Parameters.AddWithValue("@Emp_experince", _ur.Emp_experince);
                cmd.Parameters.AddWithValue("@Post_comments", _ur.post_comments);
                cmd.Parameters.AddWithValue("@Other", _ur.Other);
                cmd.Parameters.AddWithValue("@UserType", _ur.UserType);
                cmd.Parameters.AddWithValue("@Access_status", _ur.Access_status);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet UpdateJobApplyDetails(JobApplyModel _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_update_jobdApplyetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecID", _ur.RecID);
                cmd.Parameters.AddWithValue("@NoOfEmp", _ur.NoOfEmp);
                cmd.Parameters.AddWithValue("@Emp_experince", _ur.Emp_experince);
                cmd.Parameters.AddWithValue("@Post_comments", _ur.post_comments);
                cmd.Parameters.AddWithValue("@Other", _ur.Other);
                cmd.Parameters.AddWithValue("@Access_status", _ur.Access_status);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet InsertPersonalUser(PesrsonalUser _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_insert_UserType_PersonalDeatils", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@FirstName", _ur.FirstName);
                cmd.Parameters.AddWithValue("@LastName", _ur.LastName);
                cmd.Parameters.AddWithValue("@Mobile", _ur.Mobile);
                cmd.Parameters.AddWithValue("@Email", _ur.Email);
                cmd.Parameters.AddWithValue("@Country", _ur.Country);
                cmd.Parameters.AddWithValue("@State", _ur.State);
                cmd.Parameters.AddWithValue("@City", _ur.City);
                cmd.Parameters.AddWithValue("@zipcode", _ur.zipcode);
                cmd.Parameters.AddWithValue("@Designation", _ur.Designation);
                cmd.Parameters.AddWithValue("@YearsOfExp", _ur.YearsOfExp);
                cmd.Parameters.AddWithValue("@Experience", _ur.Experience);

                /////////////////////////////////

                cmd.Parameters.AddWithValue("@PresentCompanyName", _ur.PresentCompanyName);
                cmd.Parameters.AddWithValue("@PeriodOfWorking", _ur.PeriodOfWorking);
                cmd.Parameters.AddWithValue("@Work_Sector", _ur.Work_Sector);
                cmd.Parameters.AddWithValue("@Last_Salary", _ur.Last_Salary);
                cmd.Parameters.AddWithValue("@Altenative_mobile", _ur.Altenative_mobile);
                cmd.Parameters.AddWithValue("@AboutMe", _ur.AboutMe);
                cmd.Parameters.AddWithValue("@Resume", _ur.Resume);
                cmd.Parameters.AddWithValue("@UserType", _ur.UserType);
                cmd.Parameters.AddWithValue("@CurrencyType", _ur.CurrencyType);
                cmd.Parameters.AddWithValue("@ImgPath", _ur.ImgPath);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetPersonalUser(PesrsonalUser _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_UserType_PersonalDeatils", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetUserDetailsByJobID(PesrsonalUser _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_UserDeatilsByJobID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobID", _ur.Rec_ID);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet UpdatePersonalUser(PesrsonalUser _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_update_UserType_PersonalDeatils", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rec_ID", _ur.Rec_ID);
                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@FirstName", _ur.FirstName);
                cmd.Parameters.AddWithValue("@LastName", _ur.LastName);
                cmd.Parameters.AddWithValue("@Mobile", _ur.Mobile);
                cmd.Parameters.AddWithValue("@Email", _ur.Email);
                cmd.Parameters.AddWithValue("@Country", _ur.Country);
                cmd.Parameters.AddWithValue("@State", _ur.State);
                cmd.Parameters.AddWithValue("@City", _ur.City);
                cmd.Parameters.AddWithValue("@zipcode", _ur.zipcode);
                cmd.Parameters.AddWithValue("@Designation", _ur.Designation);
                cmd.Parameters.AddWithValue("@YearsOfExp", _ur.YearsOfExp);
                cmd.Parameters.AddWithValue("@Experience", _ur.Experience);

                /////////////////////////////////

                cmd.Parameters.AddWithValue("@PresentCompanyName", _ur.PresentCompanyName);
                cmd.Parameters.AddWithValue("@PeriodOfWorking", _ur.PeriodOfWorking);
                cmd.Parameters.AddWithValue("@Work_Sector", _ur.Work_Sector);
                cmd.Parameters.AddWithValue("@Last_Salary", _ur.Last_Salary);
                cmd.Parameters.AddWithValue("@Altenative_mobile", _ur.Altenative_mobile);
                cmd.Parameters.AddWithValue("@AboutMe", _ur.AboutMe);
                cmd.Parameters.AddWithValue("@Resume", _ur.Resume);
                cmd.Parameters.AddWithValue("@UserType", _ur.UserType);
                cmd.Parameters.AddWithValue("@CurrencyType", _ur.CurrencyType);
                cmd.Parameters.AddWithValue("@ImgPath", _ur.ImgPath);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet UpdateJobDetails(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_update_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecID", _ur.Rec_ID);
                cmd.Parameters.AddWithValue("@Post_Category", _ur.Post_Category);
                cmd.Parameters.AddWithValue("@Post_SubCategory", _ur.Post_SubCategory);
                cmd.Parameters.AddWithValue("@NoOfEmp", _ur.NoOfEmp);
                cmd.Parameters.AddWithValue("@Emp_experince", _ur.Emp_experince);
                cmd.Parameters.AddWithValue("@shifttimings", _ur.shifttimings);
                cmd.Parameters.AddWithValue("@ContractPeriod", _ur.ContractPeriod);
                cmd.Parameters.AddWithValue("@WorkLocation", _ur.WorkLocation);
                cmd.Parameters.AddWithValue("@TransaposrtFacility", _ur.TransaposrtFacility);
                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);
                cmd.Parameters.AddWithValue("@post_explanation", _ur.post_explanation);
                cmd.Parameters.AddWithValue("@CompanyName", _ur.CompanyName);

                /////////////////////////////////

                cmd.Parameters.AddWithValue("@Country", _ur.Country);
                cmd.Parameters.AddWithValue("@State", _ur.State);
                cmd.Parameters.AddWithValue("@City", _ur.City);
                cmd.Parameters.AddWithValue("@ZipCode", _ur.ZipCode);
                cmd.Parameters.AddWithValue("@PaymentType", _ur.PaymentType);
                cmd.Parameters.AddWithValue("@PayMode", _ur.PayMode);
                cmd.Parameters.AddWithValue("@CurrencyType", _ur.CurrencyType);
                cmd.Parameters.AddWithValue("@Amount", _ur.Amount);
                cmd.Parameters.AddWithValue("@post_comments", _ur.post_comments);
                cmd.Parameters.AddWithValue("@post_title", _ur.Post_Title);
                cmd.Parameters.AddWithValue("@other_category", _ur.Other);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetJobDetails(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet GetJobDetailsByAccess(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_PublicPrivate_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);
                cmd.Parameters.AddWithValue("@access_status", _ur.Access_status);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet UpdateJobDetailsAccessStatus(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_Update_AccessStatus_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecID", _ur.Rec_ID);
                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);
                cmd.Parameters.AddWithValue("@access_status", _ur.Access_status);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet UpdateJobDetailsRecordStatus(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_update_recdStatus_jobdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecID", _ur.Rec_ID);

                cmd.Parameters.AddWithValue("@Recd_status", _ur.Recd_status);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet GetJobDetailsByID(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_GETJobDeatailsByJobID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobID", _ur.Rec_ID);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetAppliedJobDetailsByUSERID(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_GETAppliedJobDeatailsByUserIDID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet GetAppliedJobDetailsByUSERIDWithRecordType(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_GETAppliedJobDeatailsByUserIDIDWithRecordType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", _ur.UserID);
                cmd.Parameters.AddWithValue("@RecordType", _ur.RecordType);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataSet GetJobDetailsByIDForEdit(JobDeatils _ur)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_GETJobDeatailsByJobID_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobID", _ur.Rec_ID);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet GetPendingUsers()
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_pendingUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }


        public DataSet GetCountryList()
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_country", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetStatesList(State_class model)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_states", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@countryID", model.CountryID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet GetCityList(City_class model)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_get_cityies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stateID", model.StateID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataSet UpdateUserStatus(UserReg model)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("sp_update_userstatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", model.emailid);
                cmd.Parameters.AddWithValue("@Status", model.Status);
                cmd.Parameters.AddWithValue("@UserType", model.usertype);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                mail(model.emailid.ToString(), "UserStatus", model.Status);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public void mail(string toemail, string type, string Status = "")
        {
            try
            {

                string strEmail, strSubject;//manpowersupplier.net
                StringBuilder emailstr;
                emailstr = new StringBuilder();
                MailMessage myMessage = new MailMessage();
                myMessage.From = new MailAddress("info@manpowersupplier.net");  //  new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
                myMessage.To.Add(toemail);

                myMessage.IsBodyHtml = true;
                switch (type)
                {
                    case "Feedback":
                        myMessage.Subject = "Feedback details";
                        emailstr.Append("<body style=\"margin: 0px; padding: 0px; background-color: #f4fcfe;\"><div align=\"center\"><table width=\"60%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"><tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Name</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Company</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Address</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">City</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Telephone</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Email</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">:</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"> </td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\">Additional comments</td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"></td><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\"></td></tr>");
                        emailstr.Append("<tr><td style=\"font-family: Arial; color: #666666; font-size: 11px; font-weight: normal;\" colspan=\"3\"></td></tr></table></div></body>");
                        break;
                    case "Reg":
                        myMessage.Subject = "Thank you for Registartion with Manpower Suppliers";
                        emailstr.Append("<h1>Thank you for regester</h1><br /><h3>Admin Will approve your request</h3>");
                        break;
                    case "UserStatus":
                        myMessage.Subject = "Status Update";
                        emailstr.Append("<h3>Welcome to Gitti, you're an approved agent now. <br /> Proceed to Login by click <a href=' http://mps.manpowersupplier.net' traget='_blank'>here</a> </h3><br /><h4>If you have any queries please contact hello@getit.com.sg</h4>");
                        break;
                }
                myMessage.Body = emailstr.ToString();
                SmtpClient mySmtpClient = new SmtpClient();
                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@manpowersupplier.net", "Rao@123");
                //mySmtpClient.Host = "info@manpowersupplier.net"; 
                mySmtpClient.Host = "manpowersupplier.net";
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Credentials = myCredential;
                mySmtpClient.Send(myMessage);
                //  WriteLog("Mail check", myMessage.To.ToString(), myMessage.From.ToString(), "mail()", "mailer.cs");
            }
            catch (Exception ex)
            {
                var res = ex.Message.ToString();
                // WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "mail()", "mailer.cs");
            }
        }
    }
}
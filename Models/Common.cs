using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Text;



namespace ManPowerSolsAPI.Models
{
    public class Common
    {
        public static Dictionary<string, string> CommonErrors;

        #region Get DataSet

        public DataSet ExecuteDataSet(String SPName, List<SqlParameter> paramlist, String DBConnectionString)
        {
            DataSet ds = null;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = DBConnectionString;
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SPName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Connection = con;
                        if (paramlist != null && paramlist.Count > 0)
                        {
                            foreach (SqlParameter p in paramlist)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            ds = new DataSet();
                            da.Fill(ds);
                            ds.DataSetName = "Dataset1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //throw ex;
            }

            return ds;
        }

        public DataSet ExecuteDataSetFromSelect(String SelectQuery, List<SqlParameter> paramlist, String DBConnectionString)
        {
            DataSet ds = null;
            SqlConnection conn = new SqlConnection(DBConnectionString);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(SelectQuery, conn);
                if (paramlist != null && paramlist.Count > 0)
                {
                    foreach (SqlParameter p in paramlist)
                    {
                        command.Parameters.Add(p);
                    }
                }
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = command;
                    ds = new DataSet();
                    da.Fill(ds);
                    ds.DataSetName = "Dataset1";
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        #endregion

        public static string ReturnCode(string strkey)
        {
            if (CommonErrors == null)
            {
                CommonErrors = new Dictionary<string, string>();
                CommonErrors.Add("SuccessCode", "0");
                CommonErrors.Add("SuccessMessage", "Success");
                CommonErrors.Add("ErrorCode", "-1");
                CommonErrors.Add("ErrorMessage", "Internal Server Error.");
                CommonErrors.Add("StringDataType", "Not an string.");
                CommonErrors.Add("IntDataType", "Not an int.");
                CommonErrors.Add("ValueDoesNotExist", "Value does not exist.");
            }

            string strvalue;
            CommonErrors.TryGetValue(strkey, out strvalue);
            return strvalue;
        }

        #region DateFormat

        public static string DateFormat(string date)
        {
            string MMddyyyy = null;
            if (date != "" && date != null)
            {

                if (date != "")
                {
                    var dates = date.Split('/');
                    MMddyyyy = dates[1] + "/" + dates[0] + "/" + dates[2];
                }
            }
            return MMddyyyy;
        }

        #endregion

        #region getInserlogrequest

        public DataSet getInserlogrequest(string URL, string Screen, string APPVersion, string SourceDetails, string DeviceDetails)
        {
            try
            {
                var Request = HttpContext.Current.Request;

                DataSet ds = new DataSet();
                List<SqlParameter> plist = new List<SqlParameter>();
                SqlParameter p;

                p = new SqlParameter("@RequestParameter", SqlDbType.VarChar, -1);
                p.Value = URL;
                plist.Add(p);

                p = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
                p.Value = Request.ServerVariables["REMOTE_ADDR"];
                plist.Add(p);

                p = new SqlParameter("@Screen", SqlDbType.VarChar, 50);
                p.Value = Screen;
                plist.Add(p);

                p = new SqlParameter("@APIVersion", SqlDbType.VarChar, 50);
                p.Value = APPVersion;
                plist.Add(p);

                p = new SqlParameter("@SourceDetails", SqlDbType.VarChar, 255);
                p.Value = SourceDetails;
                plist.Add(p);

                p = new SqlParameter("@DeviceDetails", SqlDbType.VarChar, 50);
                p.Value = DeviceDetails;
                plist.Add(p);



                ds = ExecuteDataSet("crmfdit_requesturl_logs_insert_update", plist, ConfigurationManager.AppSettings["ClientServer"].ToString());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion getInserlogrequest

        #region updatelogrequest

        public void updatelogrequest(int id, string request)
        {
            try
            {
                DataSet ds = new DataSet();
                List<SqlParameter> plist = new List<SqlParameter>();
                SqlParameter p;

                p = new SqlParameter("@Slno", SqlDbType.Int, 20);
                p.Value = id;
                plist.Add(p);

                p = new SqlParameter("@ResponseXML", SqlDbType.VarChar, -1);
                p.Value = request;
                plist.Add(p);

                ds = ExecuteDataSet("crmfdit_requesturl_logs_insert_update", plist, ConfigurationManager.AppSettings["ClientServer"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MAILER_InsertFeedsdetailaudit(string Fund, string Schemecode, string SchemePlan, string Acno, string Ihno, string Emailid, string Subject, string trtype)
        {
            try
            {
                List<SqlParameter> plist = new List<SqlParameter>();
                SqlParameter p;
                //string dt = String.Format("{0:dddd, dd MMMM yyyy, HH:mm}", DateTime.Now);
                plist = new List<SqlParameter>();
                p = null;
                p = new SqlParameter("@i_Fund", SqlDbType.VarChar, 10);
                p.Value = Fund;
                plist.Add(p);
                p = new SqlParameter("@i_Scheme", SqlDbType.VarChar, 10);
                p.Value = Schemecode;
                plist.Add(p);
                p = new SqlParameter("@i_Plan", SqlDbType.VarChar, 10);
                p.Value = SchemePlan;
                plist.Add(p);
                p = new SqlParameter("@i_Acno", SqlDbType.Decimal, 20);
                p.Value = Acno;
                plist.Add(p);
                p = new SqlParameter("@i_Ihno", SqlDbType.Decimal, 20);
                p.Value = Ihno;
                plist.Add(p);
                p = new SqlParameter("@i_Emailid", SqlDbType.VarChar, 100);
                p.Value = Emailid;
                plist.Add(p);
                p = new SqlParameter("@i_Subject", SqlDbType.VarChar, 100);
                p.Value = Subject;
                plist.Add(p);
                p = new SqlParameter("@i_Source", SqlDbType.VarChar, 20);
                p.Value = "Website DIT API";
                plist.Add(p);
                p = new SqlParameter("@i_trtype", SqlDbType.VarChar, 10);
                p.Value = trtype;
                plist.Add(p);

                ExecuteDataSet("MAILER_InsertFeedsdetailaudit", plist, ConfigurationManager.AppSettings["ClientServer"].ToString());
            }
            catch (Exception ex)
            {
               //rrorLogger.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), "Mailers Feed Error");
            }
        }




        #endregion updatelogrequest
    }
}
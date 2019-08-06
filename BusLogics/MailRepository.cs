using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Services.MPS.BusLogics
{
    public class MailRepository
    {
        public void forgetmail(string UUID, string toemail, string ID)
        {
            try
            {

                string strEmail, strSubject;//manpowersupplier.net
                StringBuilder emailstr;
                emailstr = new StringBuilder();
                MailMessage myMessage = new MailMessage();
                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());  //  new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
                myMessage.To.Add(toemail);
                //myMessage.Bcc.Add(ConfigurationManager.AppSettings["FromMail"].ToString());

                myMessage.IsBodyHtml = true;
                myMessage.Subject = "ForgetMail Manpower Suppliers";
                emailstr.Append("<h1>Man Power Solutions</h1> <br/> We have received your password change request. Please click <a href=' http://mps.manpowersupplier.net/Start/Start/ForgotPassword?q=" + UUID + "&u=" + ID + "' traget='_blank'>here</a> to enter your new password.");

                myMessage.Body = emailstr.ToString();
                SmtpClient mySmtpClient = new SmtpClient();
                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
                //mySmtpClient.Host = "info@manpowersupplier.net"; 
                mySmtpClient.Host = ConfigurationManager.AppSettings["HostAddress"].ToString();
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
        public void UpdatePasswordMail(string toemail)
        {
            try
            {

                string strEmail, strSubject;//manpowersupplier.net
                StringBuilder emailstr;
                emailstr = new StringBuilder();
                MailMessage myMessage = new MailMessage();
                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());  //  new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
                myMessage.To.Add(toemail);

                myMessage.IsBodyHtml = true;
                myMessage.Subject = "Update PasswordManpower Suppliers";
                emailstr.Append("<h1>Man Power Solutions</h1> <br/> Your successfully updated your Password");

                myMessage.Body = emailstr.ToString();
                SmtpClient mySmtpClient = new SmtpClient();
                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
                mySmtpClient.Host = ConfigurationManager.AppSettings["HostAddress"].ToString();
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
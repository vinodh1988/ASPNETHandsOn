using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FirstApplication.Mailer
{
    public static class Mailer
    {
        public static Boolean SendMail(String subject, String Message) {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("vinodhsample@gmail.com");
                mail.To.Add("k.c.vinodh@hotmail.com");
                mail.Subject = subject;
                mail.Body = Message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("vinodhsample", "tvslucas");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
               
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public static Boolean SendTemplateMail(String subject, String message) {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.IsBodyHtml = true;

                string FilePath ="D:\\Templates\\Template.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();

                MailText=MailText.Replace("[Message]",message);
                System.Diagnostics.Debug.WriteLine(MailText);
                mail.From = new MailAddress("vinodhsample@gmail.com");
                mail.To.Add("k.c.vinodh@hotmail.com");
                mail.Subject = subject;
                mail.Body = MailText;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("vinodhsample", "tvslucas");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
    }
}
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailService
    {
        public static bool SendEmail(int Id)
        {
            Random rnd = new Random();

            string randomNumber = "Your Password Has Been Change Successfully ";
            //int randomNumber = rnd.Next(100000, 1000000);
            var data = DataAccessFactory.ModeratorData().Read(Id);

            if (data == null)
            {
                return false;
            }

            string email = data.Email;
            var fromAddress = new MailAddress("sumayajahankanta@gmail.com", "ComputerShope");
            var toAddress = new MailAddress(email, data.Ename);
            const string fromPassword = "lkxr lbsx eflf idlr";
            const string subject = "Change Password ";
            //string body = "Your OTP is : " + randomNumber;
            string body = randomNumber;


            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = subject;
                    message.Body = body;

                    smtp.Send(message);
                }
            }

            return true;
        }




    }
}

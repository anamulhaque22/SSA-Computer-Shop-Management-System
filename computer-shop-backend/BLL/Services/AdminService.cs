using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.IO;
using System.Net.Mail;
using System.Net;
using DAL.EF;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BLL.Services
{
    public class AdminService
    {
        public static bool Signup(AdminSingupDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminSingupDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Admin>(data);
            return DataAccessFactory.AdminData().Create(cData);
        }
        public static string GetUsernameFromToken(string token)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            if(pUsername == null)
            {
                return null;
            }
            return pUsername;
        }
        public static string GetPictureNameFromToken(string token)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return null;
            }
            return pData.PictureName;
        }
        public static AdminDTO Get(string username) 
        {
            var data = DataAccessFactory.AdminData().Get(username);
            if(data == null)
            {
                return null;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            data.Password = null;
            data.OtpVerified = 0;
            return mapper.Map<AdminDTO>(data);
        }
        public static bool isUsernameUnique(string username)
        {
            return DataAccessFactory.AdminData().Get(username) == null;
        }
        public static bool isEmailUnique(string email)
        {
            return DataAccessFactory.AdminData().isUniqueEmail(email);
        }
        public static bool Update(AdminUpdateDTO uData, string token) 
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if(pData == null)
            {
                return false;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminUpdateDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Admin>(uData);
            cData.Username = pUsername;
            return DataAccessFactory.AdminData().Update(cData);
        }
        public static bool UpdateProfilePicture(string token, string newfileName)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return false;
            }
            pData.Username = pUsername;
            string exFileName = pData.PictureName;
            pData.PictureName = newfileName;
            if (DataAccessFactory.AdminData().Update(pData))
            {
                // Delete the old profile picture file
                DeleteProfilePicture(exFileName);
                return true;
            }
            return false;
        }
        private static void DeleteProfilePicture(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "AdminPictures");
                string filePath = Path.Combine(folderPath, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
        public static bool UpdateOtpVerificationStatus(string username)
        {
            var pData = DataAccessFactory.AdminData().Get(username);
            if (pData == null)
            {
                return false;
            }
            pData.OtpVerified = 1;
            return DataAccessFactory.AdminData().UpdateSpecificField(pData);
        }
        public static bool UpdatePassword(string token, string password)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return false;
            }
            pData.Password = password;
            return DataAccessFactory.AdminData().UpdateSpecificField(pData);
        }
        public static bool UpdateEmail(string token, string email)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return false;
            }
            pData.Email = email;
            return DataAccessFactory.AdminData().UpdateSpecificField(pData);
        }
        public static bool isCurrPassExist(string token, string password)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            return DataAccessFactory.AdminData().Get(pUsername).Password.Equals(password);
        }
        public static bool SendOTPEmail(string email, string otp)
        {
            try
            {
                // Read email and password from JSON file
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AdminMailInfo", "info.json");
                string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                JObject json = JObject.Parse(jsonContent);

                // Configure the SMTP client for Outlook
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(json["Email"].ToString(), json["Password"].ToString()),
                    EnableSsl = true,
                };

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("authenticator.smt@outlook.com"),
                    Subject = "SSA Computer Shop - OTP verification",
                    Body = $"Your OTP is: {otp}",
                    IsBodyHtml = false,
                };

                // Add recipient
                mailMessage.To.Add(email);

                // Send the email
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
        public static string GenerateOTP()
        {
            // Generate a 6-digit OTP
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }
        public static bool SaveOTP(string username, string otp)
        {
            AdminOTP adminOTP = new AdminOTP();
            adminOTP.Username = username;
            adminOTP.Otp = otp;
            return DataAccessFactory.AdminOtpData().Create(adminOTP);
        }
        public static bool otpMatched(string username, string otp)
        {
            return DataAccessFactory.AdminOtpData().Get(username).Otp.Equals(otp);
        }
        public static bool DeleteOtp(string username)
        {
            return DataAccessFactory.AdminOtpData().Delete(username);
        }
        public static bool GenerateReport(string token)
        {
            try
            {
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AdminMailInfo", "info.json");
                string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                JObject json = JObject.Parse(jsonContent);

                var top3Cus = CustomerProfitService.GetTop3Customers();
                var mostSoldProduct = ProductService.GetMostSoldProduct();
                var empOfTheMonth = EmployeeService.GetEmployeeOfTheMonth();
                var empWage = EmployeeService.GetTotalEmployeeWage();
                var activeCusCount = CustomerProfitService.GetActiveCustomerCount();
                var totalRev = TotalRevenuesService.Get(DateTime.Now.Year);
                var totalSales = TotalSaleService.Get(DateTime.Now.Year);

                var reportData = new
                {
                    Top3Customers = top3Cus,
                    MostSoldProduct = mostSoldProduct,
                    EmployeeOfTheMonth = empOfTheMonth,
                    TotalEmployeeWage = empWage,
                    ActiveCustomerCount = activeCusCount,
                    TotalRevenues = totalRev,
                    TotalSales = totalSales
                };

                // Serialize the data to JSON
                string reportContent = JsonConvert.SerializeObject(reportData, Formatting.Indented);

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(json["Email"].ToString(), json["Password"].ToString()),
                    EnableSsl = true,
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(json["Email"].ToString()),
                    Subject = "Generated Report",
                    Body = reportContent,
                    IsBodyHtml = true,  
                };
                string AdminMail = DataAccessFactory.AdminData().Get(GetUsernameFromToken(token)).Email;
                
                mailMessage.To.Add(AdminMail); 

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending report: {ex.Message}");
                return false;
            }
        }
    }
}

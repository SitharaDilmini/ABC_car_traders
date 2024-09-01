using System;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace ABC_Car_Traders.Utils
{
    internal class MailSender
    {
        public enum EmailType
        {
            Verification,
            OrderAcceptance,
            OrderRejection
        }

        public string SendMail(string email, string name, EmailType emailType, string itemName = null, DateTime? orderedDate = null, string reason = null, string description = null)
        {
            try
            {
                // Generate a random 6-digit number
                Random random = new Random();
                int token = random.Next(100000, 999999);

                // Create a new SmtpClient object
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("librarylkactivation@gmail.com", "ocma xovk fjdn hfhc"),
                    EnableSsl = true
                };

                // Load the appropriate email template
                string htmlTemplate = LoadTemplate(emailType);

                // Replace placeholders in the template
                string body = htmlTemplate
                    .Replace("{{TOKEN}}", token.ToString())
                    .Replace("[Customer Name]", name)
                    .Replace("[Item Name]", itemName)
                    .Replace("[Ordered Date]", orderedDate?.ToShortDateString())
                    .Replace("[Rejection Reason]", reason)
                    .Replace("[Rejection Description]", description); 

                

                // Determine the subject based on the email type
                string subject;

                if (emailType == EmailType.Verification)
                {
                    subject = "ABC Car Traders - Verification Code";
                }
                else if (emailType == EmailType.OrderAcceptance)
                {
                    subject = "ABC Car Traders - Order Accepted";
                }
                else if (emailType == EmailType.OrderRejection)
                {
                    subject = "ABC Car Traders - Order Rejected";
                }
                else
                {
                    throw new ArgumentException("Invalid email type");
                }

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("librarylkactivation@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully.", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return token.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        private string LoadTemplate(EmailType emailType)
        {
            string templatePath;

            if (emailType == EmailType.Verification)
            {
                templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates", "VerificationTemplate.html");
            }
            else if (emailType == EmailType.OrderAcceptance)
            {
                templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates", "OrderAcceptanceTemplate.html");
            }
            else if (emailType == EmailType.OrderRejection)
            {
                templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates", "OrderRejectionTemplate.html");
            }
            else
            {
                throw new ArgumentException("Invalid email type");
            }

            return File.ReadAllText(templatePath);
        }


    }
}

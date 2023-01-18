using POS_Accessories.Models.Response;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace POS_Accessories.Business.Helper
{
    public static class Utility
    {
        
        public class SendMail
        {

            public static string sendMail(String toAddress, string body, string subject)
            {
                return sendMail(toAddress, body, subject, null);
            }
            public static string sendMail(String toAddress, string body, string subject, string bcc)
            {
                return sendMail(toAddress, body, subject, bcc, null);
            }
            public static string sendMail(String toAddress, string body, string subject, string bcc, string cc)
            {
                return sendMail(toAddress, body, subject, bcc, cc, null);
            }


            public static string sendMail(String toAddress, string body, string subject, string bcc, string cc, List<Attachment> attachments)
            {
                String fromAddress = ApplicationSettings.MailSettings.fromMail;
                String fromPassword = ApplicationSettings.MailSettings.fromPassword;
                String smtpHost = ApplicationSettings.MailSettings.smtpHost;
                String smtpPort = ApplicationSettings.MailSettings.smtpPort;
                bool useSSL = ApplicationSettings.MailSettings.useSSL == "True";
                bool isTest = ApplicationSettings.MailSettings.IsTest == "True";

                if (isTest)
                {
                    toAddress = ApplicationSettings.MailSettings.testMail;
                    bcc = "";
                    cc = "";
                }
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Port = Convert.ToInt32(smtpPort);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = smtpHost;
                if (useSSL)
                {
                    client.EnableSsl = true;
                }

                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);

                using (var mail = new MailMessage(fromAddress, toAddress))
                {
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    if (attachments != null && attachments.Any())
                    {
                        foreach (var attach in attachments)
                        {
                            mail.Attachments.Add(attach);
                        }
                    }

                    if (!string.IsNullOrEmpty(bcc))
                        mail.Bcc.Add(bcc);
                    if (!string.IsNullOrEmpty(cc))
                        mail.CC.Add(cc);
                    try
                    {
                        client.Send(mail);
                    }
                    catch (SmtpException exception)
                    {
                        return "Mail Sending Failed" + exception.Message;
                    }
                }
                return "Success";
            }

        }

        public static CommonResponse CreateResponse<T>(List<T> result)
        {
            CommonResponse response = new CommonResponse();
            if (result != null && result.Count > 0)
            {
                response.data = result;
                response.message = "Success";
                response.statusCode = HttpStatusCode.OK;
                response.status = true;
                response.count = result.Count;
            }
            else
            {
                response.message = "No data found";
                response.statusCode = HttpStatusCode.NoContent;
                response.status = false;
            }
            return response;
        }

    }
    public static class ApplicationSettings
    {
        public const string dbConnection = "ConnectionStrings";
        public const string mailSettings = "MailSettings";

        public static ConnectionStrings ConnectionString { get; set; } = new ConnectionStrings();
        public static MailSettings MailSettings { get; set; } = new MailSettings();

        // other options here...
    }
}

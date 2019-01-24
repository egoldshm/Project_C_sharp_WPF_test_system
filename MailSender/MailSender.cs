using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    /// <summary>
    /// able to send mail in Async by google mail.
    /// </summary>
    public static class MailSender
    {
        /// <summary>
        /// mail's who send the mails
        /// </summary>
        const string MAIL_ADDRESS = "purivision19@gmail.com";
        /// <summary>
        /// name's who send the mails
        /// </summary>
        const string MAIL_NAME = "Driving system";
        /// <summary>
        /// password of who send the mails.
        /// </summary>
        const string PASSWORD = "purim57782018";
        static Action runWorkerCompleted;

        /// <summary>
        /// Action that start when the mail send over.
        /// </summary>
        static public Action RunWorkerCompleted { get => runWorkerCompleted; set => runWorkerCompleted = value; }

        /// <summary>
        /// function that send mail by using yatmal19 mail in thread in the background.
        /// </summary>
        /// <param name="targetMail">the mail address of the taget</param>
        /// <param name="targetName">the name that will apear to the reciver</param>
        /// <param name="subject">subject of the message</param>
        /// <param name="body">body of the message</param>
        public static void sendMail(string targetMail, string targetName, string subject, string body)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += sendMailInBackground;
            mailDate mailDate;
            mailDate.targetMail = targetMail;
            mailDate.targetName = targetName;
            mailDate.subject = subject;
            mailDate.body = body;
            backgroundWorker.RunWorkerAsync(mailDate);
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// event that start when the send over.
        /// </summary>
        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            runWorkerCompleted?.Invoke();
        }

        /// <summary>
        /// struct for tarnsmise the data.
        /// </summary>
        struct mailDate
        {
            public string targetMail;
            public string targetName;
            public string subject;
            public string body;
        }

        /// <summary>
        /// the function that realy send the mail. 
        /// </summary>
        private static void sendMailInBackground(object sender, DoWorkEventArgs e)
        {
            mailDate mailDate = (mailDate)e.Argument;
            string targetMail = mailDate.targetMail;
            string targetName = mailDate.targetName;
            string subject = mailDate.subject;
            string body = mailDate.body;

            var fromAddress = new System.Net.Mail.MailAddress(MAIL_ADDRESS,MAIL_NAME);
            var toAddress = new System.Net.Mail.MailAddress(targetMail, targetName);
            const string fromPassword = PASSWORD;

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}

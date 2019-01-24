using System;
using System.Security.Cryptography;
using System.Text;

namespace BE
{
    public class User
    {

        public static string GetSha512FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public enum RoleTypes
        {
            Trainee,
            Teacher,
            Tester,
            School,
            Admin
        }

        private RoleTypes _role;
        private string emailAddress;
        private object connectTo;

        public RoleTypes role { get => _role; }
        public string Username { get => username; }
        public string Password { get => password; }
        public object ConnectTo { get => connectTo; set
            {
                if (role == RoleTypes.Admin)
                    connectTo = value;
            }
        }

        public string EmailAddress { get => emailAddress; set => emailAddress = value; }

        private readonly string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username ?? throw new ArgumentNullException(nameof(username));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public User(User user)
        {
            this.connectTo = user.connectTo;
            this.username = user.username;
            this.password = user.password;
            this._role = user.role;
            this.emailAddress = user.emailAddress;
        }


        public User(RoleTypes role, object connectTo, string username, string password, string email)
        {
            _role = role;
            this.connectTo = connectTo;
            this.username = username;
            this.password = password;
            this.emailAddress = email;
        }

        public bool changePassword(string oldPassowrd, string newPassword)
        {
            if (GetSha512FromString(oldPassowrd) == password)
            {
                password = GetSha512FromString(newPassword);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// generate new password in lenght and with some letters.
        /// </summary>
        /// <param name="length">int that set the lenght of the new password</param>
        /// <returns>new random password</returns>
        public static string createNewPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        /// <summary>
        /// function that create new randmon password and change the password and send by the mail the new password to the user.
        /// </summary>
        /// <returns>the new password</returns>
        public void CreateNewPasswordAndChange()
        {
            string newPassword = createNewPassword(12);
            password = User.GetSha512FromString(newPassword);
            string subject = "Your new password in the driving system";
            string body = $"Hello, {username}." +
                $"\n" +
                $"We got request to reset your password.\n" +
                $"your new password it {newPassword}. please change your password early!" +
                $"\n here for you!. \n. The new Driving system. \n Eitan and Ariel.";
            MailSender.MailSender.sendMail(EmailAddress, username, subject, body);
        }
    }
}
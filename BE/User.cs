using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace BE
{
    public class User
    {
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
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

        public RoleTypes role { get => _role; }
        public string Username { get => username; }
        public string Password { get => password; }
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username ?? throw new ArgumentNullException(nameof(username));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }
        public User(User user)
        {
            this.username = user.username;
            this.password = user.password;
            this._role = this.role;
        }
        public void changePassword(string _username, string oldPassowrd, string newPassword)
        {
            if()
        }
    }
}

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

        private readonly object connectTo;

        public RoleTypes role { get => _role; }
        public string Username { get => username; }
        public string Password { get => password; }
        public object ConnectTo { get => connectTo; }

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
            this._role = this.role;
        }

        public User(RoleTypes role, object connectTo, string username, string password)
        {
            _role = role;
            this.connectTo = connectTo;
            this.username = username;
            this.password = password;
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
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;
namespace DAL
{
    class imp_XML_Dal : IDal
    {
        XElement usersRoot;
        public imp_XML_Dal()
        {
            if (!File.Exists(Configuration.FILE_USERS))
                CreateUsersFiles();
            else
                LoadUsersData();
            DataSource.testers = Xml_files.LoadFromXML<List<Tester>>(Configuration.FILE_TESTERS);
            DataSource.tests = Xml_files.LoadFromXML<List<Test>>(Configuration.FILE_TESTS);
            DataSource.trainees = Xml_files.LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEES);            
        }

        private void CreateUsersFiles()
        {
            usersRoot = new XElement("users");
            usersRoot.Save(Configuration.FILE_USERS);
        }

        private void LoadUsersData()
        {
            try
            {
                usersRoot = XElement.Load(Configuration.FILE_USERS);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        #region TraineeFunctions

      public void AddTrainee(Trainee trainee)
        {
            if (DS.DataSource.trainees.Any(item => item.Id == trainee.Id))
                throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
            DS.DataSource.trainees.Add(trainee);
            Xml_files.SaveToXML(DataSource.trainees, Configuration.FILE_TRAINEES);

        }

        #endregion TraineeFunctions

        #region TestersFunctions


        public void AddTester(Tester tester)
        {
            if (DS.DataSource.testers.Any(item => item.Id == tester.Id))
                throw new Exception("The tester already exists!");
            DS.DataSource.testers.Add(tester);
            Xml_files.SaveToXML(DataSource.testers, Configuration.FILE_TESTERS);

        }


        #endregion TestersFunctions

        #region UsersFunctions
        public bool ChangePassword(User user, string OldPassword, string NewPassword)
        {
            User old_user = GetUser(user.Username, OldPassword);
            return old_user.changePassword(OldPassword, NewPassword);
        }

        public bool CreateUser(string username, string password, User.RoleTypes roleTypes, object obj)
        {
            string hashPassword = User.GetSha512FromString(password);
            User user = new User(roleTypes, obj, username, hashPassword);
            if (DataSource.users.Any(_user => _user.Username == username))
                return false;
            DataSource.users.Add(user);
            XElement usernameElement = new XElement("user", user.Username);
            XElement passswordElement = new XElement("user", user.Password);
            XElement roleElement = new XElement("user", user.role);
            XElement objElement = new XElement("user", user.ConnectTo);

            usersRoot.Add();
            return true;
        }

        #endregion UsersFunctions



        public void deleteTest(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTester(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrainee(int id)
        {
            throw new NotImplementedException();
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            throw new NotImplementedException();
        }

        public List<Tester> GetAllTesters()
        {
            throw new NotImplementedException();
        }

        public List<Test> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public List<Trainee> GetAllTrainees()
        {
            throw new NotImplementedException();
        }

        public Test GetTestByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Tester GetTesterByID(int id)
        {
            throw new NotImplementedException();
        }

        public Trainee GetTraineeById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateTester(int id, Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UpdateTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrainee(int id, Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        #region test_functions

        public void AddFutureTest(Test test)
        {

        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {

        }
        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            throw new NotImplementedException();
        }

        #endregion test_functions

    }
}

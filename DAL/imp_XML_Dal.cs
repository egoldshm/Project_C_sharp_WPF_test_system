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
    public class imp_XML_Dal : IDal
    {
        XElement usersRoot;

        /// <summary>
        /// constracor of this Dal. bring the data from the DB (xml) to the Lists.
        /// </summary>

        public imp_XML_Dal()
        {
            if (!File.Exists(Configuration.FILE_USERS))
                CreateUsersFiles();
            else
                LoadUsersData();
            try
            {
                DataSource.testers = Xml_files.LoadFromXML<List<Tester>>(Configuration.FILE_TESTERS);
                DataSource.tests = Xml_files.LoadFromXML<List<Test>>(Configuration.FILE_TESTS);
                DataSource.trainees = Xml_files.LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEES);
            }
            catch (Exception ex) { }

        }
        /// <summary>
        /// Create new file of users data. if the file not exist.
        /// </summary>
        private void CreateUsersFiles()
        {
            usersRoot = new XElement("users");
            usersRoot.Save(Configuration.FILE_USERS);
        }

        /// <summary>
        /// load the data of the users out.
        /// </summary>
        private void LoadUsersData()
        {
            try
            {
                usersRoot = XElement.Load(Configuration.FILE_USERS);
                //problem here
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        #region TraineeFunctions


        public void UpdateTrainee(int id, Trainee trainee)
        {
            Trainee trainee_old = GetTraineeById(trainee.Id);
            if (trainee_old == null)
                throw new Exception(string.Format("not found trainee {0}", trainee.Id));
            DS.DataSource.trainees.RemoveAll(t => t.Id == id);
            DS.DataSource.trainees.Add(trainee);
            Xml_files.SaveToXML(DataSource.trainees, Configuration.FILE_TRAINEES);
        }

        public void UpdateTrainee(Trainee trainee)
        {
            if (GetTraineeById(trainee.Id) == null)
                throw new Exception(string.Format("not found trainee {0}", trainee.Id));
            UpdateTrainee(trainee.Id, trainee);
        }


        public Trainee GetTraineeById(int id)
        {
            List<Trainee> list = new List<Trainee>(from s in DS.DataSource.trainees where s.Id == id select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one trainee owns ID: {0}. Check your data source", id));

            if (list.Count == 0)
                return null;

            return new Trainee(list[0]);
        }


        public List<Trainee> GetAllTrainees()
        {
            List<Trainee> ret = new List<Trainee>(DS.DataSource.trainees.Count);

            DS.DataSource.trainees.ForEach((item) =>
            {
                ret.Add(new Trainee(item));
            });
            return ret;
        }

        public void AddTrainee(Trainee trainee)
        {
            if (DS.DataSource.trainees.Any(item => item.Id == trainee.Id))
                throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
            DS.DataSource.trainees.Add(trainee);
            Xml_files.SaveToXML(DataSource.trainees, Configuration.FILE_TRAINEES);

        }

        public void DeleteTrainee(int id)
        {
            if (DS.DataSource.tests.Any(item => item.TraineeId == id))
                throw new Exception("The trainee you attempted to delete has tests scheduled. please make sure the trainee is free before deleting!");
            if (!DS.DataSource.trainees.Any(item => item.Id == id))
                throw new Exception("Attempted to delete an unexistent trainee");
            DS.DataSource.trainees.RemoveAll(item => item.Id == id);
            Xml_files.SaveToXML(DataSource.trainees, Configuration.FILE_TRAINEES);
        }

        #endregion TraineeFunctions

        #region TestersFunctions

        public void UpdateTester(Tester tester)
        {
            UpdateTester(tester.Id, tester);
        }

        public void UpdateTester(int id, Tester tester)
        {
            int before = DS.DataSource.testers.Count();
            DS.DataSource.testers = new List<Tester>(from tester1 in DS.DataSource.testers where id != tester1.Id select tester1);
            if (before == DS.DataSource.testers.Count())
            {
                throw new Exception($"Wasnn't able to remove {tester.ToString()}");
            }
            DS.DataSource.testers.Add(tester);
            Xml_files.SaveToXML(DataSource.testers, Configuration.FILE_TESTERS);
        }

        public Tester GetTesterByID(int id)
        {
            List<Tester> list = new List<Tester>(from s in DS.DataSource.testers where s.Id == id select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one tester owns ID: {0}. Check your data source", id));

            if (list.Count == 0)
                return null;

            return new Tester(list[0]);

        }

        public List<Tester> GetAllTesters()
        {
            List<Tester> ret = new List<Tester>(DS.DataSource.testers.Count);

            DS.DataSource.testers.ForEach((item) =>
            {
                ret.Add(new Tester(item));
            });
            return ret;
        }

        public void AddTester(Tester tester)
        {
            if (DS.DataSource.testers.Any(item => item.Id == tester.Id))
                throw new Exception("The tester already exists!");
            DS.DataSource.testers.Add(tester);
            Xml_files.SaveToXML(DataSource.testers, Configuration.FILE_TESTERS);

        }

        public void DeleteTester(int id)
        {
            if (DS.DataSource.tests.Any((test) => test.TesterId == id))
            {
                throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
            }
            DS.DataSource.testers.RemoveAll(tester => tester.Id == id);
            if (!DS.DataSource.testers.Any(tester => tester.Id == id))
                throw new Exception("Attempted to delete an unexistent tester");
            Xml_files.SaveToXML(DataSource.testers, Configuration.FILE_TESTERS);
        }


        #endregion TestersFunctions

        #region UsersFunctions

        public bool CreateUser(string username, string password, User.RoleTypes roleTypes, object obj)
        {
            string hashPassword = User.GetSha512FromString(password);
            User user = new User(roleTypes, obj, username, hashPassword);
            if (DataSource.users.Any(_user => _user.Username == username))
                return false;
            DataSource.users.Add(user);
            XElement usernameElement = new XElement("username", user.Username);
            XElement passswordElement = new XElement("password", user.Password);
            XElement roleElement = new XElement("role", user.role);
            XElement objElement = null;
            switch (user.role)
            {
                case User.RoleTypes.Trainee:
                    objElement = new XElement("ConnectTo", (user.ConnectTo as Trainee).Id);
                    break;
                case User.RoleTypes.Teacher:
                case User.RoleTypes.School:
                    objElement = new XElement("ConnectTo", user.ConnectTo.ToString());
                    break;
                case User.RoleTypes.Tester:
                    objElement = new XElement("ConnectTo", (user.ConnectTo as Tester).Id);
                    break;
                case User.RoleTypes.Admin:
                    objElement = new XElement("ConnectTo", null);
                    break;
            }
            usersRoot.Add(new XElement("user", usernameElement, passswordElement, roleElement, objElement));
            usersRoot.Save(Configuration.FILE_USERS);
            return true;
        }

        public User GetUser(string username, string password)
        {
            if (!DataSource.users.Any(user => user.Password == BE.User.GetSha512FromString(password) && user.Username == username))
                return null;
            return DataSource.users.Find(user => user.Password == BE.User.GetSha512FromString(password) && user.Username == username);
        }

        public bool ChangePassword(User user, string OldPassword, string NewPassword)
        {
            User old_user = GetUser(user.Username, OldPassword);
            XElement userElement = (from u in usersRoot.Elements()
                                    where u.Element("username").Value == user.Username
                                       select u).FirstOrDefault();
            bool worked = old_user.changePassword(OldPassword, NewPassword);
            userElement.Element("password").Value = old_user.Password;
            usersRoot.Save(Configuration.FILE_USERS);
            return worked;
        }

        #endregion UsersFunctions

        #region test_functions

        public void AddFutureTest(Test test)
        {
            DataSource.tests.Add(test);
            Xml_files.SaveToXML(DataSource.tests, Configuration.FILE_TESTS);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            AddFutureTest(new Test(tester.Id, trainee.Id, time, address));
        }
        public void deleteTest(int id)
        {
            if (GetTestByNumber(id) == null)
                throw new Exception(string.Format("test {0} not exist", id));
            DS.DataSource.tests.RemoveAll(test => test.TestNumber == id);
            Xml_files.SaveToXML(DataSource.tests, Configuration.FILE_TESTS);
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            Test test = GetTestByNumber(id);
            if (test == null)
                throw new Exception("Attempted to finish an unexistent test");
            test.Criterions = criterions ?? throw new Exception("You have to insert criterions to finish test");
            test.Pass = pass;
            test.TesterNote = note;
            DataSource.tests.RemoveAll(t => t.TestNumber == id);
            DataSource.tests.Add(test);
            Xml_files.SaveToXML(DataSource.tests, Configuration.FILE_TESTS);

        }

        public List<Test> GetAllTests()
        {
            List<Test> ret = new List<Test>(DS.DataSource.tests.Count);
            DS.DataSource.tests.ForEach((item) =>
            {
                ret.Add(new Test(item));
            });
            return ret;

        }

        public Test GetTestByNumber(int number)
        {
            List<Test> list = new List<Test>(from s in DS.DataSource.tests where s.TestNumber == number select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one test owns number: {0}. Check your data source", number));

            if (list.Count == 0)
                return null;

            return new Test(list[0]);
        }
        #endregion test_functions


        




       


    }
}

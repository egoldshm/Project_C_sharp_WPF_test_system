using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imp_Dal
{
    public class Imp_Dal : IDal
    {
        #region Trainee

        public void AddTrainee(Trainee trainee)
        {
            if (DS.DataSource.trainees.Any(item => item.Id == trainee.Id))
                throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
            DS.DataSource.trainees.Add(trainee);
        }

        public void DeleteTrainee(int id)
        {
            if(DS.DataSource.tests.Any(item => item.TraineeId == id))
                throw new Exception("The trainee you attempted to delete has tests scheduled. please make sure the trainee is free before deleting!");
            if (!DS.DataSource.trainees.Any(item => item.Id == id))
                throw new Exception("Attempted to delete an unexistent trainee");
            DS.DataSource.trainees.RemoveAll(item => item.Id == id);
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

        public void UpdateTrainee(int id, Trainee trainee)
        {
            Trainee trainee_old = GetTraineeById(trainee.Id);
            if (trainee_old == null)
                throw new Exception(string.Format("not found trainee {0}", trainee.Id));
            DS.DataSource.trainees.RemoveAll(t => t.Id == id);
            DS.DataSource.trainees.Add(trainee);
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

        #endregion Trainee

        #region Tester

        public void AddTester(Tester tester)
        {
            if(DS.DataSource.testers.Any(item => item.Id == tester.Id))
                throw new Exception("The tester already exists!");
            DS.DataSource.testers.Add(tester);
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

        public void UpdateTester(int id, Tester tester)
        {
            Tester item = GetTesterByID(id);
            DS.DataSource.testers.Add(tester);
            DS.DataSource.testers.Remove(item);
        }

        public void UpdateTester(Tester tester)
        {
            UpdateTester(tester.Id, tester);
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

        #endregion Tester

        #region Test

        public void AddFutureTest(Test test)
        {
            DS.DataSource.tests.Add(test);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            DS.DataSource.tests.Add(new Test(tester.Id, trainee.Id, time, address));
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            Test test = GetTestByNumber(id);
            if (test == null)
                throw new Exception("Attempted to finish an unexistent test");
            test.Criterions = criterions ?? throw new Exception("You have to insert criterions to finish test");
            test.Pass = pass;
            test.TesterNote = note;
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

        #endregion Test

        #region User
        public bool CreateUser(string username, string password, BE.User.RoleTypes roleTypes, object obj)
        {
            string hashPassword = User.GetSha512FromString(password);
            User user = new User(roleTypes, obj, username, hashPassword);
            if (DS.DataSource.users.Any(_user => _user.Username == username))
                return false;
            DS.DataSource.users.Add(user);
            return true;
        }
        public BE.User GetUser(string username, string password)
        {
            if(!DS.DataSource.users.Any(user => user.Password == BE.User.GetSha512FromString(password) && user.Username == username))
                return null;
            return DS.DataSource.users.Find(user => user.Password == BE.User.GetSha512FromString(password) && user.Username == username);
        }

        public bool ChangePassword(BE.User user, string OldPassword, string NewPassword)
        {
            BE.User old_user = GetUser(user.Username, OldPassword);
            return old_user.changePassword(OldPassword, NewPassword);
        }


        #endregion User
    }
}
using BE;
using DAL;
using Ibl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class BL : IBL
    {
        private IDal dal;

        public BL()
        {
            dal = imp_Dal.Imp_Dal.GetDal();
            Init();
        }

        private void Init()
        {
            throw new NotImplementedException();
        }

        #region Trainee

        public void AddTrainee(Trainee trainee)
        {
            if (dal.GetTraineeById(trainee.Id) != null)
                throw new Exception(string.Format("The trainee {0} already exists", trainee.ToString()));
            dal.AddTrainee(trainee);
        }

        public void DeleteTrainee(int id)
        {
            if (dal.GetTraineeById(id) == null)
                throw new Exception(string.Format("The trainee {0} doesn't exist", id));
            dal.DeleteTrainee(id);
        }

        public bool EntitledToDrivingLicense(Trainee trainee)
        {
            List<Test> testPassed = new List<Test>(GetTestsByTrainee(trainee).Where((t) => { return t.Pass; }));
            if (testPassed.Count >= 1)
                return true;
            return false;
        }

        public List<Trainee> GetAllTrainees()
        {
            return dal.GetAllTrainees();
        }

        public void UploadTrainee(int id, Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void UploadTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<string, Trainee>> GetTraineesBySchoolName(bool sorted = false)
        {
            if (sorted)
                throw new NotImplementedException();

            return from item in dal.GetAllTrainees()
                   group item by item.SchoolName into g
                   select g;
        }

        public IEnumerable<IGrouping<string, Trainee>> GetTraineesByTeacher(bool sorted = false)
        {
            if (sorted)
                throw new NotImplementedException();

            return from item in dal.GetAllTrainees()
                   group item by item.TeacherName into g
                   select g;
        }

        public IEnumerable<IGrouping<int, Trainee>> GetTraineseByNumOfTesters(bool sorted = false)//what do you mean by "number of testers"? there is no such field
        {
            throw new NotImplementedException();
        }

        #endregion Trainee

        #region Tester

        public void AddTester(Tester tester)
        {
            if (dal.GetTesterByID(tester.Id) != null)
                throw new Exception(String.Format("The tester {0} already exists", tester.ToString()));
            dal.AddTester(tester);
        }

        public void DeleteTester(int id)
        {
            if (dal.GetTesterByID(id) == null)
                throw new Exception(String.Format("No tester with the id {0} exists", id));
            dal.DeleteTester(id);
        }

        public List<Tester> GetAllTesters()
        {
            return dal.GetAllTesters();
        }

        public IEnumerable<IGrouping<CarType, Tester>> GetTestersByCarType(bool sorted = false)
        {
            if (sorted)
                throw new NotImplementedException();
            return from item in dal.GetAllTesters()
                   group item by item.CarType into g
                   select g;
        }

        public List<Tester> GetTestersByAvailableTime(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Tester> GetTestersWhoLiveInDistantsOfX(Address address, int x)
        {
            throw new NotImplementedException();
        }

        public void UploadTester(int id, Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UploadTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        #endregion Tester

        #region Test

        public void AddFutureTest(Test test)
        {
            if (dal.GetTestByNumber(test.TestNumber) != null)
                throw new Exception(String.Format("Test number {0} already exists", test.TestNumber));
            dal.AddFutureTest(test);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            throw new NotImplementedException();
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            throw new NotImplementedException();
        }

        public List<Test> GetAllTests()
        {
            return dal.GetAllTests();
        }

        public List<Test> GetTestsByConditon(Func<Test, bool> checkFunction)
        {
            return new List<Test>(from test in GetAllTests() where checkFunction(test) select test);
        }

        public List<Test> GetTestsByDay(DateTime date)
        {
            return GetTestsByConditon((test) => { return test.DateOfTest.ToShortDateString() == date.ToShortDateString(); });
        }

        public List<Test> GetTestsByTrainee(Trainee trainee)
        {
            return GetTestsByConditon((test) => { return test.TraineeId == trainee.Id; });
        }


        #endregion Test
    }
}
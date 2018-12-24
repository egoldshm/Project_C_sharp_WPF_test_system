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
            if (trainee.LessonsNumber < 0)
                throw new Exception("A negative number of classes is impossible");
            if (trainee.PhoneNumber.ToString().StartsWith("05") && trainee.PhoneNumber.ToString().Length == 10)
                throw new Exception("The number phone have to be valid israeli number");
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int traineeBirthdayINT = int.Parse(trainee.Birthday.ToString("yyyyMMdd"));
            int age = (now - traineeBirthdayINT) / 10000;
            if (age < Configuration.MIN_STUDENT_AGE)
                throw new Exception(string.Format("The trainee {0} is two young to driving test, The minimum is {1} and the trainee only {2}.", trainee.ToString(), Configuration.MIN_STUDENT_AGE, age));
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
                return from item in dal.GetAllTrainees()
                       orderby item.Id 
                       group item by item.SchoolName;

            return from item in dal.GetAllTrainees()
                   group item by item.SchoolName;
        }

        public IEnumerable<IGrouping<string, Trainee>> GetTraineesByTeacher(bool sorted = false)
        {
            return sorted ?
                from item in dal.GetAllTrainees() orderby item.Id group item by item.TeacherName
                : from item in dal.GetAllTrainees() group item by item.TeacherName;
        }

        public IEnumerable<IGrouping<int, Trainee>> GetTraineseByNumOfTesters(bool sorted = false)
        {
            return sorted ?
                from item in dal.GetAllTrainees() orderby item.Id group item by GetTestsByTrainee(item).Count
                : from item in dal.GetAllTrainees() group item by GetTestsByTrainee(item).Count;
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

        public List<Tester> GetAllTesters(Func<Tester, bool> checkFunction = null)
        {
            if (checkFunction != null)
                return new List<Tester>(from tester in dal.GetAllTesters() where checkFunction(tester) select tester);
            return new List<Tester>(dal.GetAllTesters());
        }

        public IEnumerable<IGrouping<CarType, Tester>> GetTestersByCarType(bool sorted = false)
        {
            return sorted ?
                from item in dal.GetAllTesters() orderby item.Id group item by item.CarType
                : from item in dal.GetAllTesters() group item by item.CarType;
        }

        public List<Tester> GetTestersByAvailableTime(DateTime date)
        {
            //TODO: Make time management more flexible
            int hourByArr;
            if (date.DayOfWeek > DayOfWeek.Thursday)
                throw new Exception(string.Format("There are no tests in {0}", date.DayOfWeek));
            if (date.Hour >= 9 && date.Hour <= 15)
                hourByArr = date.Hour - 9;
            else throw new Exception(string.Format("You can not insert a test at {0} o'clock, it is an inactive hour", date.Hour));
            return new List<Tester>(GetAllTesters((tester) =>
            {
                return tester.WorkDays[(int)date.DayOfWeek, hourByArr] &&
               !GetTestsByTesters(tester).Any((test) => { return test.DateOfTest.Hour == date.Hour; })
                 ;  }));
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
            var tests = new List<Test>(from test in GetTestsByTrainee(trainee) where (test.DateOfTest > DateTime.Now || test.RealDateOfTest != null) select test);
            if (tests.Count > 0)
                throw new Exception(string.Format("You can not set a test for a student {0} because in the system already have a future test", trainee.Id));
            //todo: to finish.
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            if (dal.GetTestByNumber(id) == null)
                throw new Exception(string.Format("The test with number {0} is not found", id));
            //TODO: work with criterions to think when is impotisble that trainee pass and when not.
            if (false/*TODO:*/)
                throw new Exception(string.Format("Hsdfsdjfnbjdfncbktsdjfmbkdfc", criterions));
            dal.FinishTest(id, criterions, pass, note);
        }

        public List<Test> GetTestsByDay(DateTime date)
        {
            return GetAllTests((test) => { return test.DateOfTest.ToShortDateString() == date.ToShortDateString(); });
        }

        public List<Test> GetTestsByTrainee(Trainee trainee)
        {
            return GetAllTests((test) => { return test.TraineeId == trainee.Id; });
        }

        public List<Trainee> GetAllTrainees(Func<Trainee, bool> checkFunction = null)
        {
            if (checkFunction != null)
                return new List<Trainee>(from trainee in dal.GetAllTrainees() where checkFunction(trainee) select trainee);
            return new List<Trainee>(dal.GetAllTrainees());
        }

        public List<Test> GetAllTests(Func<Test, bool> checkFunction = null)
        {
            if(checkFunction != null)
                return new List<Test>(from test in GetAllTests() where checkFunction(test) select test);
            return new List<Test>(dal.GetAllTests());
        }

        public List<Test> GetTestsByTesters(Tester tester)
        {
                return GetAllTests((test) => { return test.TesterId == tester.Id; });
        }


        #endregion Test
    }
}
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
        private static IDal dal;

        public BL()
        {
            dal = factoryDal.FactoryDal.GetDal();
            Init();
        }

        private void Init()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// function that get a ID and return if is valid israeli number or not.
        /// Exception:
        ///     if the ID hasn't 9 digits
        /// </summary>
        /// <param name="id">israeli ID number</param>
        /// <returns>True: this ID is valid israeli ID. False: isn't </returns>
        private static bool CheckIfIDisValid(int id)
        {
            if (id.ToString().Length != 9)
                throw new Exception(string.Format("id {0} is invalid. because it has {1} digits and valid id has 9.", id, id.ToString().Length));
            int lessId = id / 10;
            int sum = 0;
            for (int i = 1; lessId > 0; i++)
            {
                int number1;
                number1 = (i % 2 + 1) * (lessId % 10);
                int number2 = number1 % 10 + number1 / 10;
                sum += number2;
                lessId /= 10;
            }
            int check_digit = (10 - sum % 10) % 10;
            return check_digit == id % 10;
        }
        
        /// <summary>
        /// function that get Birthday in DateTime type and return age of the men who born there.
        /// </summary>
        /// <param name="birthday">the Birthday of the humen. type: DateTime</param>
        /// <returns>age of the men (float) </returns>
        private static float GetAgeByBirthday(DateTime birthday)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int birthdayINT = int.Parse(birthday.ToString("yyyyMMdd"));
            float age = (now - birthdayINT) / 10000;
            return age;
        }
        #region Trainee

        public void AddTrainee(Trainee trainee)
        {
            if(trainee.Id.ToString().Length != 9)
                throw new Exception(string.Format("id {0} is invalid. because it has {1} digits and normal id has 9.", trainee.Id, trainee.Id.ToString().Length));
            if (!CheckIfIDisValid(trainee.Id))
                throw new Exception(string.Format("id {0} is invalid israeli number. by the rules of ID numbers", trainee.Id));
            if (dal.GetTraineeById(trainee.Id) != null)
                throw new Exception(string.Format("The trainee {0} already exists", trainee.ToString()));
            if (trainee.LessonsNumber < 0)
                throw new Exception("A negative number of lessons is impossible");
            if (trainee.PhoneNumber.ToString().StartsWith("05") && trainee.PhoneNumber.ToString().Length == 10)
                throw new Exception("The number phone has to be valid israeli number");
            if (GetAgeByBirthday(trainee.Birthday) < Configuration.MIN_STUDENT_AGE)
                throw new Exception(string.Format("The trainee {0} is too young to driving test, The minimum is {1} and the trainee only {2}.", trainee.ToString(), Configuration.MIN_STUDENT_AGE, age));
            dal.AddTrainee(trainee);
            
        }

        public void DeleteTrainee(int id)
        {
            if (!CheckIfIDisValid(id))
                throw new Exception(string.Format("id {0} is invalid israeli number. by the rules of ID numbers", id));
            if (dal.GetTraineeById(id) == null)
                throw new Exception(string.Format("The trainee {0} doesn't exist", id));
            int countOfTestsForThisTrainee = GetTestsByTrainee(dal.GetTraineeById(id)).Count;
            if (countOfTestsForThisTrainee > 0)
                throw new Exception(string.Format("The trainee {0} register to {1} driving test(s). it's illigal to delete him.", id, countOfTestsForThisTrainee));
            dal.DeleteTrainee(id);
        }

        public bool EntitledToDrivingLicense(Trainee trainee)
        {
            List<Test> testPassed = new List<Test>(GetTestsByTrainee(trainee).Where(t =>  t.Pass));
            if (testPassed.Count >= 1)
                return true;
            return false;
        }

      

        public void UpdateTrainee(int id, Trainee trainee)
        {
            if (id != trainee.Id)
                throw new Exception(string.Format("It is impossible to change a trainee's ID (from {0} to {1})", id, trainee.Id));
            Trainee oldTrainee = dal.GetTraineeById(id);
            if (GetAgeByBirthday(trainee.Birthday) < Configuration.MIN_STUDENT_AGE)
                throw new Exception(string.Format("you cant change birthday of trainee {0}, this make him to be too young to do driving test", id));
            if (GetTestsByTrainee(trainee).Any(test => dal.GetTesterByID(test.TesterId).CarType != trainee.TypeCarLearned))
                throw new Exception(string.Format("It is not possible to change the type of vehicle of the trainee {0} because he is registered for the test with the old vehicle type", id));
            dal.UpdateTrainee(id, trainee);
        }

        public void UpdateTrainee(Trainee trainee)
        {
            UpdateTrainee(trainee.Id, trainee);
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
            if (!CheckIfIDisValid(tester.Id))
                throw new Exception(string.Format("id {0} is invalid israeli number. by the rules of ID numbers", tester.Id));
            if (dal.GetTesterByID(tester.Id) != null)
                throw new Exception(String.Format("The tester {0} already exists", tester.ToString()));
            float age = GetAgeByBirthday(tester.DateOfBirth);
            if (age > Configuration.MAX_TESTER_AGE)
                throw new Exception(string.Format("Tester {0} is too old to be a tester. he {1} years old, and the the max age is {2}", tester.Id, age, Configuration.MAX_TESTER_AGE));
            if (age < Configuration.MIN_TESTER_AGE)
                throw new Exception(string.Format("Tester {0} is too young to be a tester. he only {1} years old, and the the min age is {2}", tester.Id, age, Configuration.MIN_TESTER_AGE));
            dal.AddTester(tester);
        }

        public void DeleteTester(int id)
        {
            if (!CheckIfIDisValid(id))
                throw new Exception(string.Format("id {0} is invalid israeli number. by the rules of ID numbers", id));
            if (dal.GetTesterByID(id) == null)
                throw new Exception(String.Format("No tester with the id {0} exists", id));
            int countOftestsForTester = GetTestsByTesters(dal.GetTesterByID(id)).Count;
            if (countOftestsForTester > 0)
                throw new Exception(String.Format("Tester {0} is registered to {1} test(s), than we can delete him", id, countOftestsForTester));
            dal.DeleteTester(id);
        }
        
        public List<Tester> GetAllTesters(Predicate<Tester> checkFunction = null)
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
            return new List<Tester>(GetAllTesters(tester =>
            tester.WorkDays[(int)date.DayOfWeek, hourByArr] && !GetTestsByTesters(tester).Any(test => test.DateOfTest.Hour == date.Hour)));
        }

        public List<Tester> GetTestersWhoLiveInDistantsOfX(Address address, int x)
        {
            //TODO: to implement the function realy. (now it fake)
            Random random = new Random();
            return new List<Tester>(from tester in GetAllTesters() where random.Next(1000) < x select tester);
        }

        public void UpdateTester(int id, Tester tester)
        {
            if (id != tester.Id)
                throw new Exception(string.Format("It is impossible to change a tester's ID (from {0} to {1})", id, tester.Id));
            if (GetAgeByBirthday(tester.DateOfBirth) < Configuration.MIN_TESTER_AGE)
                throw new Exception(string.Format("you cant change birthday of tester {0}, this make him to be too young to do be tester", id));
            if (GetAgeByBirthday(tester.DateOfBirth) > Configuration.MAX_TESTER_AGE)
                throw new Exception(string.Format("you cant change birthday of tester {0}, this make him to be too old to do be tester", id));
            if (GetTestsByTesters(tester).Any(test => dal.GetTraineeById(tester.Id).TypeCarLearned != tester.CarType))
                throw new Exception(string.Format("It is not possible to change the type of vehicle of the tester {0} because he is registered for the test with the old vehicle type", id));
            //TODO: check if the tester still available when the tests fixed. and if he dont pass the max hour in week. help pleas!!
            if (GetTestsByTesters(tester).Count > tester.MaxWeeklyTests)//TODO: fix it, how we find the weekly tests?
                throw new Exception(string.Format("You tried to change the max weekly tester. but tester {0} already registered to {1} tests, that it more from {2}", tester.Id, tester.MaxWeeklyTests, tester.MaxWeeklyTests));
            dal.UpdateTester(id, tester);
        }

        public void UpdateTester(Tester tester)
        {
            dal.UpdateTester(tester.Id, tester);
        }

        #endregion Tester

        #region Test

        public void AddFutureTest(Test test)
        {
            if (dal.GetTesterByID(test.TesterId) == null)
                throw new Exception(string.Format("tester {0} not exists in the DB.", test.TesterId));
            if (dal.GetTraineeById(test.TraineeId) == null)
                throw new Exception(string.Format("trainee {0} not exists in the DB.", test.TraineeId));
            if (dal.GetTestByNumber(test.TestNumber) != null)
                throw new Exception(String.Format("Test number {0} already exists", test.TestNumber));
            AddFutureTest(dal.GetTesterByID(test.TesterId), dal.GetTraineeById(test.TraineeId), test.DateOfTest, test.AddressOfBegining);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            if (dal.GetTesterByID(tester.Id) == null)
                throw new Exception(string.Format("tester {0} not exists in the DB.", tester.Id));
            if (dal.GetTraineeById(trainee.Id) == null)
                throw new Exception(string.Format("trainee {0} not exists in the DB.", trainee.Id));
            if (DateTime.Now > time)
                throw new Exception("you cant set future test for the past.");
            //TODO: check the tester dont pass the max weekly tests, i have no idea how to do it. help.
            //TODO: צריך לבדוק שהטסטר פנוי בזמן הזה
            if (GetTestsByTrainee(trainee).Any(test => test.DateOfTest > DateTime.Now || test.RealDateOfTest != null)) ;
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
            return GetAllTests(test => test.DateOfTest.ToShortDateString() == date.ToShortDateString());
        }

        public List<Test> GetTestsByTrainee(Trainee trainee)
        {
            return GetAllTests(test => test.TraineeId == trainee.Id );
        }

        public List<Trainee> GetAllTrainees(Predicate<Trainee> checkFunction = null)
        {
            if (checkFunction != null)
                return new List<Trainee>(from trainee in dal.GetAllTrainees() where checkFunction(trainee) select trainee);
            return new List<Trainee>(dal.GetAllTrainees());
        }

        public List<Test> GetAllTests(Predicate<Test> checkFunction = null)
        {
            if(checkFunction != null)
                return new List<Test>(from test in GetAllTests() where checkFunction(test) select test);
            return new List<Test>(dal.GetAllTests());
        }

        public List<Test> GetTestsByTesters(Tester tester)
        {
                return GetAllTests(test => test.TesterId == tester.Id);
        }

        public List<Trainee> GetAllTraineesByLicense(bool hasLicense = true)
        {
            return new List<Trainee>(from trainee in GetAllTrainees() where hasLicense ? EntitledToDrivingLicense(trainee) : !EntitledToDrivingLicense(trainee) select trainee);
        }
        

        public List<Test> GetAllSuccessfullTestsByTester(Tester tester, bool successful = true)
        {
            return new List<Test>(from test in GetTestsByTesters(tester) where successful ? test.Pass : !test.Pass select test);
        }


        #endregion Test
    }
}
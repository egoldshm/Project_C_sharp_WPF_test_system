using BE;
using DAL;
using Ibl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BL
{

    public class BL : IBL
    {
        private static IDal dal;

        public BL()
        {
            dal = factoryDal.FactoryDal.GetDal();
            //Init();
        }

        //private void Init()
        //{
        //    try
        //    {
        //        CreateUser("eitan", "4545", User.RoleTypes.Admin, null);
        //        CreateUser("Ariel", "hello world", User.RoleTypes.Admin, null);
        //        AddTrainee(new Trainee(324218544, "Darshan", "Ariel", Gender.Male, 0584007353, new Address(), DateTime.Parse("16.10.2000"), CarType.Private_Car, TransmissionType.Manual, "a", "b", 30));
        //        CreateUser("ariel", "4545", User.RoleTypes.Trainee, new Trainee(324218544, "Darshan", "Ariel", Gender.Male, 0584007353, new Address(), DateTime.Parse("16.10.2000"), CarType.Private_Car, TransmissionType.Manual, "a", "b", 30));
        //        AddTester(new Tester(324218544, "Coren", "Eyal", DateTime.Parse("16.10.1970"), Gender.Male, 0581234567, new Address(), 15, 3, CarType.Private_Car, new bool[5, 6], 100));
        //        AddFutureTest(new Test(324218544, 324218544, DateTime.Parse("1.2.2019"), new Address()));
        //        AddTrainee(new Trainee(322521303, "eitan", "goldshmidt", Gender.Male, 0584007354, new Address(), DateTime.Parse("26.11.2000"), CarType.Private_Car, TransmissionType.Manual, "yatmal", "doron", 30));
        //        AddTester(new Tester(324218544));
        //        AddTrainee(new Trainee(123456789));
        //        AddFutureTest(new Test(new Tester(0), new Trainee(0)));
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

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
            if (trainee.Id.ToString().Length != 9)
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
                throw new Exception(string.Format("The trainee {0} is too young to driving test, The minimum is {1} and the trainee only {2}.", trainee.ToString(), Configuration.MIN_STUDENT_AGE, GetAgeByBirthday(trainee.Birthday)));
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
            List<Test> testPassed = new List<Test>(GetTestsByTrainee(trainee).Where(t => t.Pass));
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
            return sorted ?
                from item in dal.GetAllTrainees() orderby item.Id group item by item.SchoolName
                : from item in dal.GetAllTrainees() group item by item.SchoolName;
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

        public Trainee GetTraineeById(int num)
        {
            return dal.GetTraineeById(num);
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
                throw new Exception(string.Format("No tester with the id {0} exists", id));
            int countOftestsForTester = GetTestsByTesters(dal.GetTesterByID(id)).Count;
            if (countOftestsForTester > 0)
                throw new Exception(string.Format("Tester {0} is registered to {1} test(s), than we can delete him", id, countOftestsForTester));
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
            //TODO: Make time management more flexible REPLY: What do you mean by "more flexible"? it seems prety flexible to me...
            int hourByArr;
            if (date.DayOfWeek > DayOfWeek.Thursday)
                throw new Exception(string.Format("There are no tests on {0}", date.DayOfWeek));
            if (date.Hour >= 9 && date.Hour <= 15)
                hourByArr = date.Hour - 9;
            else throw new Exception(string.Format("You can not insert a test at {0} o'clock, it is an inactive hour", date.Hour));
            return new List<Tester>(GetAllTesters(tester =>
            tester.WorkDays[(int)date.DayOfWeek, hourByArr] && !GetTestsByTesters(tester).Any(test => test.DateOfTest.AddMinutes(Configuration.DURATION_OF_TEST) < date || test.DateOfTest > date)));
        }

        public List<Tester> GetTestersWhoLiveInDistanceOfX(Address address)
        {
            return new List<Tester>(from tester in GetAllTesters() where addressDistants.distanceBetweenAddresses(address, tester.Address) < tester.MaxDistance select tester);
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
            var WeeklyTests = new List<IGrouping<DateTime, Test>>(from test in GetTestsByTesters(tester)
                                                                  let diff = (7 + test.DateOfTest.DayOfWeek - DayOfWeek.Sunday) % 7
                                                                  group test by test.DateOfTest.AddDays(diff * -1).Date);
            if (WeeklyTests.Any(Week => Week.ToList().Count > tester.MaxWeeklyTests))
                throw new Exception(string.Format("You tried to change the max weekly tester. but tester {0} already registered to {1} tests, that it more from {2}", tester.Id, tester.MaxWeeklyTests, tester.MaxWeeklyTests));

            foreach (var test1 in GetTestsByTesters(tester))
                foreach (var test2 in GetTestsByTesters(tester))
                {
                    if (test1 == test2)
                        break;
                    if ((test1.DateOfTest - test2.DateOfTest).Duration().Minutes < BE.Configuration.DURATION_OF_TEST)
                        throw new Exception(string.Format("Can't update Tester {0} because it has overlaping scheduled tests", tester.ToString()));
                }

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
                throw new Exception(string.Format("Test number {0} already exists", test.TestNumber));
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
            var WeeklyTests = new List<Test>(from test in GetTestsByTesters(tester)
                                             let TestDiff = (7 + test.RealDateOfTest.DayOfWeek - DayOfWeek.Sunday) % 7
                                             let TimeDiff = (7 + time.DayOfWeek - DayOfWeek.Sunday) % 7
                                             where time.AddDays(TimeDiff * -1).Date == test.DateOfTest.AddDays(TestDiff * -1).Date
                                             select test);
            if (WeeklyTests.Count > tester.MaxWeeklyTests)
                throw new Exception(string.Format("The tester {0} can't have a test at {1} due to hte fact he exceded the maximum amount of tests that week", tester.ToString(), time.ToString()));
            if (GetTestsByTrainee(trainee).Any(test => test.DateOfTest > DateTime.Now || test.RealDateOfTest != null))
                throw new Exception(string.Format("You can not set a test for a student {0} because in the system already have a future test", trainee.Id));

            var NumberOfTestsInTimeSpan = new List<Test>(from test in GetTestsByTesters(tester)
                                                         let timespan = test.RealDateOfTest - time
                                                         where timespan.Duration().Minutes < 30
                                                         select test);

            foreach (var test in GetTestsByTesters(tester))
                if ((test.DateOfTest - time).Duration().Minutes < BE.Configuration.DURATION_OF_TEST)
                    throw new Exception(string.Format("The tester {0} has no time on {1} at {2}", tester.ToString(), time.ToString("dddd, MMMM dd yyyy"), time.ToString("t")));

            dal.AddFutureTest(new Test(tester.Id, trainee.Id, time, address));
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            if (criterions.Criterions.Any(criterion => criterion.Mode == CriterionMode.NotDetermined))
                throw new Exception("It is impossible that one of the criteria will not enter a value");
            if (dal.GetTestByNumber(id) == null)
                throw new Exception(string.Format("The test with number {0} is not found", id));
            //TODO: work with criterions to think when is impotisble that trainee pass and when not.
            var distribution = new List<IGrouping<BE.CriterionMode, string>>(from criterion in criterions.Criterions group criterion.Name by criterion.Mode);

            List<string> passed = new List<string>(0);
            List<string> failed = new List<string>(0);
            List<string> NotDetermind = new List<string>(0);
            foreach (var mode in distribution)
            {
                if (mode.Key == BE.CriterionMode.passed)
                    passed = mode.ToList<string>();
                if (mode.Key == BE.CriterionMode.Fails)
                    failed = mode.ToList<string>();
                if (mode.Key == BE.CriterionMode.NotDetermined)
                    NotDetermind = mode.ToList<string>();
            }
            float grade = 100;
            if (failed.Count + NotDetermind.Count != 0)
                grade = passed.Count / (failed.Count + NotDetermind.Count);
            if (pass && grade < (((float)BE.Configuration.PERCETAGE_REQUIRED_FOR_PASSING) / 100))
                throw new Exception(string.Format("Test number {0} couldn't have been passed, since not enough criteria have been met", id));
            if (!pass && grade > BE.Configuration.PERCETAGE_REQUIRED_FOR_PASSING)
                throw new Exception(string.Format("Test number {0} couldn't have been failed, since enough criteria have been met for the trainee to pass", id));
            dal.FinishTest(id, criterions, pass, note);
        }

        public List<Test> GetTestsByDay(DateTime date)
        {
            return GetAllTests(test => test.DateOfTest.ToShortDateString() == date.ToShortDateString());
        }

        public List<Test> GetTestsByTrainee(Trainee trainee)
        {
            return GetAllTests(test => test.TraineeId == trainee.Id);
        }

        public List<Trainee> GetAllTrainees(Predicate<Trainee> checkFunction = null)
        {
            if (checkFunction != null)
                return new List<Trainee>(from trainee in dal.GetAllTrainees() where checkFunction(trainee) select trainee);
            return new List<Trainee>(dal.GetAllTrainees());
        }

        public List<Test> GetAllTests(Predicate<Test> checkFunction = null)
        {
            if (checkFunction != null)
                return new List<Test>(from test in dal.GetAllTests() where checkFunction(test) select test);
            return new List<Test>(dal.GetAllTests());
        }

        public List<Test> GetTestsByTesters(Tester tester)
        {
            if (GetTesterById(tester.Id) == null)
                throw new Exception(string.Format("tester {0} not exist in the system", tester.Id));
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

        public Test GetTestByNumber(int number)
        {
            return dal.GetTestByNumber(number);
        }

        public Tester GetTesterById(int id)
        {
            return dal.GetTesterByID(id);
        }

        public bool isTestFinished(Test test)
        {
            return !test.Criterions.Criterions.Any(c => c.Mode == CriterionMode.NotDetermined);
        }

        public void deleteTest(int id)
        {
            if (GetTesterById(id) == null)
                throw new Exception(string.Format("Test {0} not exist", id));
            dal.deleteTest(id);
        }
        public Test createTest(int TraineeId, Address address, DateTime time)
        {
            Trainee trainee = GetTraineeById(TraineeId);
            if (trainee == null)
                throw new Exception(string.Format("Trainee {0} not exist, so you can set for him test", TraineeId));
            var listOfTestersByDistance = GetTestersWhoLiveInDistanceOfX(address);
            var listOfTestersByTime = GetTestersByAvailableTime(time);
            List<int> testers = new List<int>(
                listOfTestersByDistance.Select(t => t.Id).Intersect(listOfTestersByTime.Select(t => t.Id)));
            Random random = new Random();
            if(testers.Count == 0)
            {
                throw new Exception("Not found testers in the wanted time and loctaion");
            }
            Test test = new Test(testers[random.Next(testers.Count)], TraineeId, time, address);
            AddFutureTest(test);
            return test;
        }
        #endregion Test

        #region User

        public static bool IsValidEmailAddress(string s)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        public bool CreateUser(string username, string password, BE.User.RoleTypes roleTypes, object obj, string email)
        {
            if (username == string.Empty)
                throw new Exception("username is empty");
            if (email == string.Empty)
                throw new Exception("email is empty");
            if (!IsValidEmailAddress(email))
                throw new Exception("email is not valid email address");
            if (password == string.Empty)
                throw new Exception("password is empty");
            if (roleTypes == User.RoleTypes.School && !(obj is string))
                throw new Exception("to user as School should be connect to string");
            if (roleTypes == User.RoleTypes.Teacher && !(obj is string))
                throw new Exception("to user as Teacher should be connect to string");
            if (roleTypes == User.RoleTypes.Trainee && !(obj is Trainee))
                throw new Exception("to user as trainee should be connect to Trainee");
            if (roleTypes == User.RoleTypes.Tester && !(obj is Tester))
                throw new Exception("to user as Tester should be connect to Tester");
            return dal.CreateUser(username, password, roleTypes, obj, email);
        }

        public BE.User GetUser(string username, string password)
        {
            return dal.GetUser(username, password);
        }

        public bool ChangePassword(BE.User user, string OldPassword, string NewPassword)
        {
            return dal.ChangePassword(user, OldPassword, NewPassword);
        }

        public bool resetPassword(string username, string email)
        {
            return dal.resetPassword(username, email);
        }

        
        #endregion User
    }
}
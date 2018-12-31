using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ibl;
using BE;
namespace SimpleUI
{
    class Program
    {
        private static IBL bl = factoryBL.FactoryBL.GetBL();
        static void Main(string[] args)
        {
            int num;
            do
            {
                num = inputNum();
                switch (num)
                {
                    case 0:
                        Console.WriteLine("bye!");
                        break;
                    case 1:
                        DoActionWithCheck(addTrainee);
                        break;
                    case 2:
                        DoActionWithCheck(addTester);
                        break;
                    case 3:
                        DoActionWithCheck(AddTest);
                        break;
                    case 4:
                        DoActionWithCheck(updateTrainee);
                        break;
                    case 5:
                        DoActionWithCheck(updateTester);
                        break;
                    case 6:
                        DoActionWithCheck(finishTest);
                        break;
                    case 7:
                        foreach (var item in bl.GetAllTrainees())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 8:
                        foreach (var item in bl.GetAllTesters())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 9:
                        foreach (var item in bl.GetAllTests())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 10:
                        try
                        {
                            List<Test> list = bl.GetTestsByTesters(bl.GetTesterById(int.Parse(input("id"))));
                            list.ForEach(test => Console.WriteLine(test));
                                
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("ERROR!! {0}", e.Message);
                        }
                        break;
                    case 11:
                        DoActionWithCheck(deleteTrainee);
                        break;
                    case 12:
                        DoActionWithCheck(deleteTester);
                        break;
                    case 13:
                        DoActionWithCheck(GetllTraineesByLicense);
                        break;
                    case 14:
                        DoActionWithCheck(GetTraineesBySchoolName);
                        break;
                    case 15:
                        DoActionWithCheck(GetTraineesByTeacher);
                        break;
                    case 16:
                        DoActionWithCheck(GetTestersByCarType);
                        break;
                    case 17:
                        DoActionWithCheck(GetTraineseByNumOfTesters);
                        break;
                    case 18:
                        DoActionWithCheck(GetAllSuccessfullTestsByTester);
                        break;
                    default:
                        break;
                }
            }
            while (num != 0);
        }

        private static void GetTraineseByNumOfTesters()
        {
            foreach (IGrouping<int, Trainee> group in bl.GetTraineseByNumOfTesters(true))
            {
                bool first = true;
                foreach(Trainee item in group)
                {
                    if (first)
                    {
                        Console.WriteLine("{0}: ", bl.GetTestsByTrainee(item).Count);
                        first = false;
                    }
                    Console.WriteLine(item);
                }
            }
        }

        private static void GetAllSuccessfullTestsByTester()
        {
            string id = input("id of the Tester for search Successfull Tests");
            int count = 1;
            bl.GetAllSuccessfullTestsByTester(bl.GetTesterById(int.Parse(id))).ForEach(test => { Console.WriteLine("{0}: {1}", count, test); count++; });

        }

        private static void GetllTraineesByLicense()
        {
            string forLicense = input("0 for Trainee who haven't License and else for who have License");
            int count = 1;
            bl.GetAllTraineesByLicense(forLicense != "0").ForEach(trinee => { Console.WriteLine("{0}: {1}", count, trinee); count++; });
        }

        private static void GetTestersByCarType()
        {
            foreach (IGrouping<CarType, Tester> group in bl.GetTestersByCarType(true))
            {
                bool first = true;
                foreach (Tester item in group)
                {
                    if(first)
                    {
                        Console.WriteLine("{0}:  ",item.CarType);
                        first = false;
                    }
                    Console.WriteLine(item);
                }
            }
        }

        private static void GetTraineesByTeacher()
        {
            foreach (IGrouping<string, Trainee> group in bl.GetTraineesByTeacher(true))
            {
                bool first = true;
                foreach (Trainee item in group)
                {
                    if (first)
                    {
                        Console.WriteLine("{0}:  ", item.TeacherName);
                        first = false;
                    }
                    Console.WriteLine(item);
                }
            }
        }

        private static void GetTraineesBySchoolName()
        {
            foreach (IGrouping<string, Trainee> group in bl.GetTraineesBySchoolName())
            {
                bool first = true;
                foreach (Trainee item in group)
                {
                    if (first)
                    {
                        Console.WriteLine("{0}:  ", item.SchoolName);
                        first = false;
                    }
                    Console.WriteLine(item);
                }
            }
        }

        private static void deleteTester()
        {
            string id = input("id");
            bl.DeleteTester(int.Parse(id));
        }

        private static void deleteTrainee()
        {
            string id = input("id");
            bl.DeleteTrainee(int.Parse(id));
            
        }
        
        private static void DoActionWithCheck(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!! {0}", e.Message);
            }
        }
        private static string input(string message)
        {
            Console.WriteLine("Enter {0}:", message);
            return Console.ReadLine();
        }
        private static void updateTester()
        {
            string firstName;
            string lastName;
            string id;
            string gender, address, phone, birthday, carType, maxDistanse;
            string maxWeekly, teacherName, yearsOfexp;
            Console.WriteLine("enter id:");
            id = Console.ReadLine();
            Console.WriteLine("enter first name:");
            firstName = Console.ReadLine();
            Console.WriteLine("enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("enter gender:");
            gender = Console.ReadLine();
            Console.WriteLine("enter address:");
            address = Console.ReadLine();
            Console.WriteLine("enter phone number:");
            phone = Console.ReadLine();
            Console.WriteLine("enter birthday:");
            birthday = Console.ReadLine();
            Console.WriteLine("enter carType (1 for Heavy_truck, 2 for Medium_truck, 3 for Private_Car,4 for Two_wheeled_vehicles");
            carType = Console.ReadLine();
            Console.WriteLine("enter max distans:");
            maxDistanse = Console.ReadLine();
            Console.WriteLine("enter max weeky hours:");
            maxWeekly = Console.ReadLine();
            Console.WriteLine("enter years of ניסיון:");
            yearsOfexp = Console.ReadLine();
            Console.WriteLine("enter for every hour if the tester work then or not");
            bool[,] arr = new bool[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine("day: {0}, hour: {1}", i, j);
                    if (Console.ReadLine() != "0")
                        arr[i, j] = true;
                    else arr[i, j] = false;
                }
            }
            Console.WriteLine("enter the hour when the tester work");

            if (gender.ToUpper() != "Male".ToUpper() && gender.ToUpper() != "feMale".ToUpper()) throw new Exception("gender not found");
            Gender _gender = (gender.ToUpper() == "Male".ToUpper() ? Gender.Male : Gender.Female);
            Address _address = new Address();
            _address.building_number = 0;
            _address.city = address;

            Tester tester = new Tester(int.Parse(id), lastName, firstName, DateTime.Parse(birthday), (Gender)int.Parse(gender), long.Parse(phone), _address, int.Parse(yearsOfexp), int.Parse(maxWeekly), (CarType)int.Parse(carType), arr, float.Parse(maxDistanse));
            bl.UpdateTester(tester);
        }
        private static void updateTrainee()
        {
            string firstName;
            string lastName;
            string id;
            string gender, address, phone, birthday, carType, transmissionType;
            string schoolName, teacherName, numberOfLessons;
            id = input("id");
            firstName = input("first name");
            Console.WriteLine("enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("enter gender:");
            gender = Console.ReadLine();
            Console.WriteLine("enter address:");
            address = Console.ReadLine();
            Console.WriteLine("enter phone number:");
            phone = Console.ReadLine();
            Console.WriteLine("enter birthday:");
            birthday = Console.ReadLine();
            Console.WriteLine("enter carType (1 for Heavy_truck, 2 for Medium_truck, 3 for Private_Car,4 for Two_wheeled_vehicles");
            carType = Console.ReadLine();
            Console.WriteLine("enter transmissionType (1 for Automatic, 2 for Manual):");
            transmissionType = Console.ReadLine();
            Console.WriteLine("enter school name:");
            schoolName = Console.ReadLine();
            Console.WriteLine("enter teacher Name:");
            teacherName = Console.ReadLine();
            Console.WriteLine("enter number of lessons:");
            numberOfLessons = Console.ReadLine();
            if (gender.ToUpper() != "Male".ToUpper() && gender.ToUpper() != "feMale".ToUpper()) throw new Exception("gender not found");
            Gender _gender = (gender.ToUpper() == "Male".ToUpper() ? Gender.Male : Gender.Female);
            Address _address = new Address();
            _address.building_number = 0;
            _address.city = address;
            Trainee trainee = new Trainee(int.Parse(id), firstName, lastName, _gender, long.Parse(phone), _address, DateTime.Parse(birthday), (CarType)int.Parse(carType), (TransmissionType)int.Parse(transmissionType), schoolName, teacherName, int.Parse(numberOfLessons));
            bl.UpdateTrainee(trainee);
        }
        private static void AddTest()
        {
            string TesterId, traineeId, date;
            TesterId = input("tester id");
            traineeId = input("trainee id");
            date = input("date of the test");
            Address _address = new Address();
            _address.street_name = input(input("address"));
            bl.AddFutureTest(new Test(int.Parse(TesterId), int.Parse(traineeId), DateTime.Parse(date), _address));
        }
        private static void addTrainee()
        {
            string firstName;
            string lastName;
            string id;
            string gender, address, phone, birthday, carType, transmissionType;
            string schoolName, teacherName, numberOfLessons;
            id = input("id");
            firstName = input("first name");
            Console.WriteLine("enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("enter gender:");
            gender = Console.ReadLine();
            Console.WriteLine("enter address:");
            address = Console.ReadLine();
            Console.WriteLine("enter phone number:");
            phone = Console.ReadLine();
            Console.WriteLine("enter birthday:");
            birthday = Console.ReadLine();
            Console.WriteLine("enter carType (1 for Heavy_truck, 2 for Medium_truck, 3 for Private_Car,4 for Two_wheeled_vehicles");
            carType = Console.ReadLine();
            Console.WriteLine("enter transmissionType (1 for Automatic, 2 for Manual):");
            transmissionType = Console.ReadLine();
            Console.WriteLine("enter school name:");
            schoolName = Console.ReadLine();
            Console.WriteLine("enter teacher Name:");
            teacherName = Console.ReadLine();
            Console.WriteLine("enter number of lessons:");
            numberOfLessons = Console.ReadLine();
            if (gender.ToUpper() != "Male".ToUpper() && gender.ToUpper() != "feMale".ToUpper()) throw new Exception("gender not found");
            Gender _gender = (gender.ToUpper() == "Male".ToUpper() ? Gender.Male : Gender.Female);
            Address _address = new Address();
            _address.building_number = 0;
            _address.city = address;
            Trainee trainee = new Trainee(int.Parse(id), firstName, lastName, _gender, long.Parse(phone), _address, DateTime.Parse(birthday), (CarType)int.Parse(carType), (TransmissionType)int.Parse(transmissionType), schoolName, teacherName, int.Parse(numberOfLessons));
            bl.AddTrainee(trainee);
        }
        private static void addTester()
        {
            string firstName;
            string lastName;
            string id;
            string gender, address, phone, birthday, carType, maxDistanse;
            string maxWeekly, teacherName, yearsOfexp;
            Console.WriteLine("enter id:");
            id = Console.ReadLine();
            Console.WriteLine("enter first name:");
            firstName = Console.ReadLine();
            Console.WriteLine("enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("enter gender:");
            gender = Console.ReadLine();
            Console.WriteLine("enter address:");
            address = Console.ReadLine();
            Console.WriteLine("enter phone number:");
            phone = Console.ReadLine();
            Console.WriteLine("enter birthday:");
            birthday = Console.ReadLine();
            Console.WriteLine("enter carType (1 for Heavy_truck, 2 for Medium_truck, 3 for Private_Car,4 for Two_wheeled_vehicles");
            carType = Console.ReadLine();
            Console.WriteLine("enter max distans:");
            maxDistanse = Console.ReadLine();
            Console.WriteLine("enter max weeky hours:");
            maxWeekly = Console.ReadLine();
            Console.WriteLine("enter years of experience:");
            yearsOfexp = Console.ReadLine();
            Console.WriteLine("enter for every hour if the tester work then or not");
            bool[,] arr = new bool[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine("day: {0}, hour: {1}", i, j);
                    if (Console.ReadLine() != "0")
                        arr[i, j] = true;
                    else arr[i, j] = false;
                }
            }
            Console.WriteLine("enter the hour when the tester work");

            if (gender.ToUpper() != "Male".ToUpper() && gender.ToUpper() != "feMale".ToUpper()) throw new Exception("gender not found");
            Gender _gender = (gender.ToUpper() == "Male".ToUpper() ? Gender.Male : Gender.Female);
            Address _address = new Address();
            _address.building_number = 0;
            _address.city = address;

            Tester tester = new Tester(int.Parse(id), lastName, firstName, DateTime.Parse(birthday), _gender, long.Parse(phone), _address, int.Parse(yearsOfexp), int.Parse(maxWeekly), (CarType)int.Parse(carType), arr, float.Parse(maxDistanse));
            bl.AddTester(tester);
        }
        private static int inputNum()
        {
            int num;
            string input;
            Console.WriteLine("Menu:");
            Console.WriteLine("1: add trainee");
            Console.WriteLine("2: add tester");
            Console.WriteLine("3: add test");
            Console.WriteLine("4: update trainee");
            Console.WriteLine("5: update tester");
            Console.WriteLine("6: finish test");
            Console.WriteLine("7: show all trainee");
            Console.WriteLine("8: show all testers");
            Console.WriteLine("9: show all tests");
            Console.WriteLine("10: show all tests by tester");
            Console.WriteLine("11: delete trainee");
            Console.WriteLine("12: delete tester");
            Console.WriteLine("13: Get All Trainees By License");
            Console.WriteLine("14: Get Trainees By School Name");
            Console.WriteLine("15: Get Trainees By Teacher");
            Console.WriteLine("16: Get Testers By CarType");
            Console.WriteLine("17: Get Trainese By Num Of Testers"); 
            Console.WriteLine("18: Get All Successfull Tests By Tester");
            Console.WriteLine("0: exit.");
            do
            {
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out num));
            return num;
        }

        private static void finishTest()
        {
            string id = input("id");
            Test test = bl.GetTestByNumber(int.Parse(id));
            if (test == null)
                throw new Exception("test not found");
            List<Criterion> list = new List<Criterion>(test.Criterions.Criterions);
            List<Criterion> Newlist = new List<Criterion>();
            for (int i = 0; i < list.Count; i++)
            {
                string mode = input(string.Format("mode for {0} (0 or else)", list[i].Name));
                if (mode != "0")
                    Newlist.Add(new Criterion(list[i].Name, CriterionMode.passed));
                else
                    Newlist.Add(new Criterion(list[i].Name, CriterionMode.Fails));
            }
            string passed = input("wheater he passed");
            bool _passed;
            if (passed == "0")
                _passed = false;
            else _passed = true;
            string note = input("note of tester");
            CriterionsOfTest criterions = new CriterionsOfTest(Newlist);
            bl.FinishTest(int.Parse(id), criterions, _passed, note);
        }
    }
    }
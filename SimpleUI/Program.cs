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
                    default:
                        break;
                }
            }
            while (num != 0);
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

        private static void addTrainee()
        {
            string firstName;
            string lastName;
            string id;
            string gender, address, phone, birthday, carType, transmissionType;
            string schoolName, teacherName, numberOfLessons;
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
            Console.WriteLine("enter teacher Name:");
            teacherName = Console.ReadLine();
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
            Console.WriteLine("10: show all tests by tests");
            Console.WriteLine("11: delete trainee");
            Console.WriteLine("12: delete tester");
            Console.WriteLine("13: delete test");
            Console.WriteLine("14: Get All Trainees By License");
            Console.WriteLine("15:....");
            Console.WriteLine("0: exit.");
            do
            {
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out num));
            return num;
        }
    }

using System;
namespace BE{
    public class Tester
    {
        private int id;//has to appear
        private string lastName;
        private string firstName;
        private DateTime dateOfBirth;
        private Gender gender;
        private long phoneNumber;
        private string address;
        private int yearsOfExperience;
        private int maxWeeklyTests;
        private CarType carType;
        private bool [,] workDays = new bool [5, 6];
        private float maxDistance;
        

        public Tester()
        {
            
        }

        
        public int Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
        public int MaxWeeklyTests { get => maxWeeklyTests; set => maxWeeklyTests = value; }
        public CarType CarType { get => carType; set => carType = value; }
        public bool[,] WorkDays { get => workDays; set => workDays = value; }
        public float MaxDistance { get => maxDistance; set => maxDistance = value; }
        
        public override string ToString()
        {
                return firstName + " " + familyName;
        }
    }

}

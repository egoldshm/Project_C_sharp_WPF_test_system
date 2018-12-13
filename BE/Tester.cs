using System;
namespace BE
{
    public class Tester
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private DateTime _dateOfBirth;
        private Gender _gender;
        private long _phoneNumber;
        private string _address;
        private int _yearsOfExperience;
        private int _maxWeeklyTests;
        private CarType _carType;
        private bool [,] _workDays = new bool [5, 6];
        private float _maxDistance;

        public Tester(int id)
        {
            this.id = id;
        }

        public Tester(int id, string lastName, string firstName) : this(id)
        {
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        }

        public Tester(int id, string lastName, string firstName, DateTime dateOfBirth, Gender gender, long phoneNumber, string address, int yearsOfExperience, int maxWeeklyTests, CarType carType, bool[,] workDays, float maxDistance) : this(id)
        {
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            this.yearsOfExperience = yearsOfExperience;
            this.maxWeeklyTests = maxWeeklyTests;
            this.carType = carType;
            this.workDays = workDays ?? throw new ArgumentNullException(nameof(workDays));
            this.maxDistance = maxDistance;
        }

        public int id { get => _id; set => _id = value; }
        public string lastName { get => _lastName; set => _lastName = value; }
        public string firstName { get => _firstName; set => _firstName = value; }
        public DateTime dateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender gender { get => _gender; set => _gender = value; }
        public long phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string address { get => _address; set => _address = value; }
        public int yearsOfExperience { get => _yearsOfExperience; set => _yearsOfExperience = value; }
        public int maxWeeklyTests { get => _maxWeeklyTests; set => _maxWeeklyTests = value; }
        public CarType carType { get => _carType; set => _carType = value; }
        public bool[,] workDays { get => _workDays; set => _workDays = value; }
        public float maxDistance { get => _maxDistance; set => _maxDistance = value; }
        
        public override string ToString()
        {
                return firstName + " " + lastName;
        }
    }

}

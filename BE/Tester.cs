using System;
namespace BE{
    public class Tester
    {
        private int _id;//has to appear
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
        

        public Tester()
        {
            
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
                return _firstName + " " + _familyName;
        }
    }

}

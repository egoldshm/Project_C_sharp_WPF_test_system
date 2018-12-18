using System;
namespace BE
{
    public class Trainee
    {
        #region Private variables
        private int _id;
        private string _firstName;
        private string _familyName;
        private Gender _gender;
        private long _phoneNumber;
        private Address _TraineeAddress;
        private DateTime _birthday;
        private CarType _typeCarLearned;
        private giltBoxType _giltBoxTypeLearned;
        private string _schoolName;
        private string _teacherName;
        private int _lessonsNumber;

        #endregion

        #region CTORs

        public Trainee(int id)
        {
            this.id = id;
        }

        public Trainee(int id, string firstName, string familyName) :this(id)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.familyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
        }

        public Trainee(int id, string firstName, string familyName
            , Gender gender, long phoneNumber
            , Address address, DateTime birthday
            , CarType typeCarLearned, giltBoxType giltBoxTypeLearned
            , string schoolName, string teacherName, int lessonsNumber) : this(id, firstName, familyName)
        {
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.birthday = birthday;
            this.typeCarLearned = typeCarLearned;
            this.giltBoxTypeLearned = giltBoxTypeLearned;
            this.schoolName = schoolName ?? throw new ArgumentNullException(nameof(schoolName));
            this.teacherName = teacherName ?? throw new ArgumentNullException(nameof(teacherName));
            this.lessonsNumber = lessonsNumber;
        }

        #endregion

        #region Properties

        public int id { get => _id; set => _id = value; }
        public string firstName { get => _firstName; set => _firstName = value; }
        public string familyName { get => _familyName; set => _familyName = value; }
        public Gender gender { get => _gender; set => _gender = value; }
        public long phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public Address address { get => _TraineeAddress; set => _TraineeAddress = value; }
        public DateTime birthday { get => _birthday; set => _birthday = value; }
        public CarType typeCarLearned { get => _typeCarLearned; set => _typeCarLearned = value; }
        public giltBoxType giltBoxTypeLearned { get => _giltBoxTypeLearned; set => _giltBoxTypeLearned = value; }
        public string schoolName { get => _schoolName; set => _schoolName = value; }
        public string teacherName { get => _teacherName; set => _teacherName = value; }
        public int lessonsNumber { get => _lessonsNumber; set => _lessonsNumber = value; }

        #endregion

        public override string ToString()
        {
            return firstName + " " + familyName;
        }
    }
}
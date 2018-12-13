using System;
namespace BE
{
    public class Trainee
    {
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

        public Trainee(int id)
        {
            Id = id;
        }

        public Trainee(int id, string firstName, string familyName) :this(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
        }

        public Trainee(int id, string firstName, string familyName
            , Gender gender, long phoneNumber
            , Address traineeAddress, DateTime birthday
            , CarType typeCarLearned, giltBoxType giltBoxTypeLearned
            , string schoolName, string teacherName, int lessonsNumber) : this(id, firstName, familyName)
        {
            Gender = gender;
            PhoneNumber = phoneNumber;
            TraineeAddress = traineeAddress;
            Birthday = birthday;
            TypeCarLearned = typeCarLearned;
            GiltBoxTypeLearned = giltBoxTypeLearned;
            SchoolName = schoolName ?? throw new ArgumentNullException(nameof(schoolName));
            TeacherName = teacherName ?? throw new ArgumentNullException(nameof(teacherName));
            LessonsNumber = lessonsNumber;
        }

        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string FamilyName { get => _familyName; set => _familyName = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public long PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public Address TraineeAddress { get => _TraineeAddress; set => _TraineeAddress = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public CarType TypeCarLearned { get => _typeCarLearned; set => _typeCarLearned = value; }
        public giltBoxType GiltBoxTypeLearned { get => _giltBoxTypeLearned; set => _giltBoxTypeLearned = value; }
        public string SchoolName { get => _schoolName; set => _schoolName = value; }
        public string TeacherName { get => _teacherName; set => _teacherName = value; }
        public int LessonsNumber { get => _lessonsNumber; set => _lessonsNumber = value; }

        public override string ToString()
        {
            return FirstName + " " + FamilyName;
        }
    }
}
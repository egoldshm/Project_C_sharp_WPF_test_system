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
        private TransmissionType _giltBoxTypeLearned;
        private string _schoolName;
        private string _teacherName;
        private int _lessonsNumber;

        #endregion Private variables

        #region CTORs

        public Trainee(int id)
        {
            this.Id = id;
        }

        public Trainee(int id, string firstName, string familyName) : this(id)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
        }

        public Trainee(int id, string firstName, string familyName
            , Gender gender, long phoneNumber
            , Address address, DateTime birthday
            , CarType typeCarLearned, TransmissionType giltBoxTypeLearned
            , string schoolName, string teacherName, int lessonsNumber) : this(id, firstName, familyName)
        {
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Birthday = birthday;
            this.TypeCarLearned = typeCarLearned;
            this.TransmissionLearned = giltBoxTypeLearned;
            this.SchoolName = schoolName ?? throw new ArgumentNullException(nameof(schoolName));
            this.TeacherName = teacherName ?? throw new ArgumentNullException(nameof(teacherName));
            this.LessonsNumber = lessonsNumber;
        }

        //copy CTOR for get_all
        public Trainee(Trainee trainee)
        {
            this.Gender = trainee.Gender;
            this.PhoneNumber = trainee.PhoneNumber;
            this.Address = trainee.Address;
            this.Birthday = trainee.Birthday;
            this.TypeCarLearned = trainee.TypeCarLearned;
            this.TransmissionLearned = trainee.TransmissionLearned;
            this.SchoolName = trainee.SchoolName ?? throw new ArgumentNullException(nameof(SchoolName));
            this.TeacherName = trainee.TeacherName ?? throw new ArgumentNullException(nameof(TeacherName));
            this.LessonsNumber = trainee.LessonsNumber;
        }

        #endregion CTORs

        #region Properties

        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string FamilyName { get => _familyName; set => _familyName = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public long PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public Address Address { get => _TraineeAddress; set => _TraineeAddress = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public CarType TypeCarLearned { get => _typeCarLearned; set => _typeCarLearned = value; }
        public TransmissionType TransmissionLearned { get => _giltBoxTypeLearned; set => _giltBoxTypeLearned = value; }
        public string SchoolName { get => _schoolName; set => _schoolName = value; }
        public string TeacherName { get => _teacherName; set => _teacherName = value; }
        public int LessonsNumber { get => _lessonsNumber; set => _lessonsNumber = value; }

        #endregion Properties

        public override string ToString()
        {
            return Id + "(" + FirstName + " " + FamilyName + ")";
        }

        public static implicit operator Trainee(Trainee v)
        {
            throw new NotImplementedException();
        }
    }
}
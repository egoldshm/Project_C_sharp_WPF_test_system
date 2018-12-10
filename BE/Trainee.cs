using System;
namespace BE
{
    public class Trainee
    {
        private int id;
        private string firstName;
        private string familyName;
        private Gender gender;
        private long phoneNumber;
        private Address TraineeAddress;
        private DateTime birthday;
        private CarType typeCarLearned;
        private giltBoxType giltBoxTypeLearned;
        private string schoolName;
        private string teacherName;
        private int lessonsNumber;

        public override string ToString()
        {
            return firstName + " " + familyName;
        }
    }
}
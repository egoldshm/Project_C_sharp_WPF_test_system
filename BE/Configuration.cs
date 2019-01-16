
namespace BE
{
    public static class Configuration
    {
        public const string FILE_TRAINEES = "/dataBases/trainees.xml";
        public const string FILE_TESTERS = "/dataBases/testers.xml";
        public const string FILE_TESTS = "/dataBases/tests.xml";
        public const string FILE_USERS = "/dataBases/users.xml";
        public const string FILE_CONFIG = "/dataBases/config.xml";
        public const int MIN_LESSONS = 27;
        public const double MAX_TESTER_AGE = 80;
        public const double MIN_STUDENT_AGE = 17;
        public const int MIN_DAYS_BETWEEN_TESTS = 7;
        public const int MIN_LESSON_BEFORE_TEST = 27;
        public const int MIN_TESTER_AGE = 30;
        public const int DURATION_OF_TEST = 30;
        public const float PERCETAGE_REQUIRED_FOR_PASSING = 80;
        public const int LENGHT_OF_RAND_PASSWORD = 8;
        public static readonly string[] TYPE_OF_CRITERIONS = new string[] { "keeping distance"
            ,"reverse parking","looking at The mirror"
                ,"Indecating","Right of way" };
    }
}
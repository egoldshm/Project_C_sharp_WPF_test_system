
namespace BE
{
    public static class Configuration
    {
        /// <summary>
        /// key for map request from the servier
        /// </summary>
        public const string KEY_FOR_MAPS = @"GmtHnHRTUGnEc3kUAIJrMgU9EWNy4SSB";
        /// <summary>
        /// address of the XML file of the trainee.
        /// </summary>
        public const string FILE_TRAINEES = "..//..//..//dataBases/trainees.xml";
        /// <summary>
        /// address of the XML file of the testers.
        /// </summary>
        public const string FILE_TESTERS = "..//..//..//dataBases/testers.xml";
        /// <summary>
        /// address of the XML file of the tests.
        /// </summary>
        public const string FILE_TESTS = "..//..//..//dataBases/tests.xml";
        /// <summary>
        /// address of the XML file of the users.
        /// </summary>
        public const string FILE_USERS = "..//..//..//dataBases/users.xml";
        /// <summary>
        /// address of the XML file of the config.
        /// </summary>
        public const string FILE_CONFIG = "..//..//..//dataBases/config.xml";
        /// <summary>
        /// 
        /// </summary>
        public const int MIN_LESSONS = 27;
        /// <summary>
        /// 
        /// </summary>
        public const double MAX_TESTER_AGE = 80;
        /// <summary>
        /// 
        /// </summary>
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
namespace BE
{
    public static class Configuration
    {
        public const int MIN_LESSONS = 27;
        public const double MAX_TESTER_AGE = 80;
        public const double MIN_STUDENT_AGE = 17;
        public const int MIN_DAYS_BETWEEN_TESTS = 7;
        public const int MIN_LESSON_BEFORE_TEST = 27;


        public static readonly string[] TYPE_OF_CRITERIONS = new string[] { "keeping distance"
            ,"reverse parking","looking at The mirror"
                ,"Indecating","Right of way" };
    }
}
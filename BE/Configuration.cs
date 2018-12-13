using System;

namespace BE
{
    public static class Configuration
    {
        public const int MIN_LESSONS = 27;
        public const int MAX_TESTER_AGE = 80;
        public const int MIN_STUDENT_AGE = 17;
        public const int MIN_DAYS_BETWEEN_TESTS = 7;
        public static readonly string[] TYPE_OF_CRITERIONS =  new string[] { "keeping distants"
            ,"reverse parking","looking at The mirror"
                ,"semaphors","Give way" };
    }
}
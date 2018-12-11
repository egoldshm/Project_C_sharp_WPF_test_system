using System;
namespace BE
{
    enum CriterionMode
    {
        passed, Fails
    }
    struct Criterion
        {
        string name;
        CriterionMode mode;
        }
    public class CriterionsOfTest
    {
        private Criterion[] Criterions;
        public CriterionsOfTest()
            {
}


    }
}
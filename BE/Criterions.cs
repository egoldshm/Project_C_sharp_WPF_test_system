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
        private List<Criterion> criterions;
        public CriterionsOfTest()
        {
            criterions = new Criterion();
         }
    }
}
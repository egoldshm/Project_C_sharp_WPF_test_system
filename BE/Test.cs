using System;
namespace BE
{
    public class Test
    {
        private int TestNumber;
        private int TesterNumber;
        private int TraineeNumber;
        private DateTime dateOfTest;
        private DateTime realDateOfTest;
        private Address addressOfBegining;
        private CriterionsOfTest criterions;
        private bool pass;
        private string testerNote;

        public override string ToString()
        {
            return TestNumber.ToString();
        }
    }
}

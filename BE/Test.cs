using System;
namespace BE
{
    /// <summary>
    /// class for driving test. the connect between Tester and Trainee.
    /// </summary>
    public class Test
    {
        private int _TestNumber;
        private int _TesterNumber;
        private int _TraineeNumber;
        private DateTime _dateOfTest;
        private DateTime _realDateOfTest;
        private Address _addressOfBegining;
        private CriterionsOfTest _criterions;
        private bool pass;
        private string testerNote;

        public override string ToString()
        {
            return TestNumber.ToString();
        }
    }
}

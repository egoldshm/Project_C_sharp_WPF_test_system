using System;
namespace BE
{
    /// <summary>
    /// class for driving test. the connect between Tester and Trainee.
    /// </summary>
    public class Test
    {
        
        private static int _testIdTotal = 10000000;
        private readonly int _TestNumber;
        private int _TesterNumber;
        private int _TraineeNumber;
        private DateTime _dateOfTest;
        private DateTime _realDateOfTest;
        private Address _addressOfBegining;
        private CriterionsOfTest _criterions;
        private bool pass;
        private string testerNote;

        public Test(int testerNumber, int traineeNumber)
        {
            _TestNumber = TestIdTotal++;
            TesterNumber = testerNumber;
            TraineeNumber = traineeNumber;
        }

        public Test(int testerNumber, int traineeNumber
            , DateTime dateOfTest, DateTime realDateOfTest
            , Address addressOfBegining) : this(testerNumber, traineeNumber)
        {
            DateOfTest = dateOfTest;
            RealDateOfTest = realDateOfTest;
            AddressOfBegining = addressOfBegining;
        }

        public Test(Tester tester, Trainee trainee) : this(tester.id, trainee.Id) { }

        public static int TestIdTotal { get => _testIdTotal; private set => _testIdTotal = value; }

        public int TestNumber { get => _TestNumber;}
        public int TesterNumber { get => _TesterNumber; set => _TesterNumber = value; }
        public int TraineeNumber { get => _TraineeNumber; set => _TraineeNumber = value; }
        public DateTime DateOfTest { get => _dateOfTest; set => _dateOfTest = value; }
        public DateTime RealDateOfTest { get => _realDateOfTest; set => _realDateOfTest = value; }
        public Address AddressOfBegining { get => _addressOfBegining; set => _addressOfBegining = value; }
        public CriterionsOfTest Criterions { get => _criterions; set => _criterions = value; }
        public bool Pass { get => pass; set => pass = value; }
        public string TesterNote { get => testerNote; set => testerNote = value; }

        public override string ToString()
        {
            return TestNumber.ToString();
        }
    }
}

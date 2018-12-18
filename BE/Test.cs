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
        private int _TesterId;
        private int _TraineeId;
        private DateTime _dateOfTest;
        private DateTime _realDateOfTest;
        private Address _addressOfBegining;
        private CriterionsOfTest _criterions;
        private bool pass;
        private string testerNote;

        public Test(int testerNumber, int traineeNumber)
        {
            _TestNumber = TestIdTotal++;
            TesterId = testerNumber;
            TraineeId = traineeNumber;
        }

        public Test(int testerNumber, int traineeNumber
            , DateTime dateOfTest, DateTime realDateOfTest
            , Address addressOfBegining) : this(testerNumber, traineeNumber)
        {
            DateOfTest = dateOfTest;
            RealDateOfTest = realDateOfTest;
            AddressOfBegining = addressOfBegining;
        }
        //constructor for father test.
        public Test(int testerId, int traineeId
            , DateTime dateOfTest, Address addressOfBegining)
            : this(testerId, traineeId)
        {
            DateOfTest = dateOfTest;
            AddressOfBegining = addressOfBegining;
        }
        public Test(Tester tester, Trainee trainee) : this(tester.id, trainee.id) { }

        public static int TestIdTotal { get => _testIdTotal; private set => _testIdTotal = value; }

        public int TestNumber { get => _TestNumber;}
        public int TesterId { get => _TesterId; set => _TesterId = value; }
        public int TraineeId { get => _TraineeId; set => _TraineeId = value; }
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

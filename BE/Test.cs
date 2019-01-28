using System;

namespace BE
{
    /// <summary>
    /// class for driving test. the connect between Tester and Trainee.
    /// </summary>
    public class Test
    {
        #region Private variables

        private static int _testIdTotal = 10000000;
        private int _TestNumber;
        private int _TesterId;
        private int _TraineeId;
        private DateTime _dateOfTest;
        private DateTime _realDateOfTest;
        private Address _addressOfBegining;
        private CriterionsOfTest _criterions;
        private bool pass;
        private string testerNote;

        #endregion Private variables

        #region CTORs

        public Test()
        {
            TesterId = 0;
            TraineeId = 0;
        }

        public Test(int testerNumber, int traineeNumber)
        {
            Criterions = new CriterionsOfTest();
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

        public Test(Tester tester, Trainee trainee) : this(tester.Id, trainee.Id)
        {
        }

        //copy CTOR for get_all
        public Test(Test test) 
        {
            //this.TestNumber = test.TestNumber; need to see if needed by get_all, because otherwise, I don't see a possible way to have it read only
            this._TestNumber = test.TestNumber;
            this.TesterId = test.TesterId;
            this.TraineeId = test.TraineeId;
            this.DateOfTest = test.DateOfTest;
            this.RealDateOfTest = test.RealDateOfTest;
            this.AddressOfBegining = test.AddressOfBegining;
            this.Criterions = test.Criterions;
            this.Pass = test.Pass;
            this.TesterNote = test.TesterNote;
            this.Criterions = new CriterionsOfTest(test.Criterions);
            
        }

        #endregion CTORs

        public static int TestIdTotal { get => _testIdTotal; set => _testIdTotal = value; }

        #region Properties

        public int TestNumber { get => _TestNumber; set => _TestNumber = value; }
        public int TesterId { get => _TesterId; set => _TesterId = value; }
        public int TraineeId { get => _TraineeId; set => _TraineeId = value; }
        public DateTime DateOfTest { get => _dateOfTest; set => _dateOfTest = value; }
        public DateTime RealDateOfTest { get => _realDateOfTest; set => _realDateOfTest = value; }
        public Address AddressOfBegining { get => _addressOfBegining; set => _addressOfBegining = value; }
        public CriterionsOfTest Criterions { get => _criterions; set => _criterions = value; }
        public bool Pass { get => pass; set => pass = value; }
        public string TesterNote { get => testerNote; set => testerNote = value; }

        #endregion Properties

        public override string ToString()
        {
            return TestNumber + ". tester: " + TesterId + ". trainee: " + TraineeId;
        }
    }
}
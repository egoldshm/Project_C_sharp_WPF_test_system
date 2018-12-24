using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imp_Dal
{
    public class Imp_Dal : IDal
    {
        #region Trainee

        public void AddTrainee(Trainee trainee)
        {
            foreach (var item in DS.DataSource.trainees)
            {
                if (item.Id == trainee.Id)
                {
                    throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
                }
            }
            DS.DataSource.trainees.Add(trainee);
        }

        public void DeleteTrainee(int id)
        {
            foreach (var item in DS.DataSource.tests)
            {
                if (item.TraineeId == id)
                {
                    throw new Exception("The trainee you attempted to delete has tests scheduled. please make sure the trainee is free before deleting!");
                }
            }

            foreach (var item in DS.DataSource.trainees)
            {
                if (item.Id == id)
                {
                    DS.DataSource.trainees.Remove(item);
                    return;
                }
            }
            throw new Exception("Attempted to delete an unexistent trainee");
        }

        public List<Trainee> GetAllTrainees()
        {
            List<Trainee> ret = new List<Trainee>(DS.DataSource.trainees.Count);

            DS.DataSource.trainees.ForEach((item) =>
            {
                ret.Add(new Trainee(item));
            });
            return ret;
        }

        public void UploadTrainee(int id, Trainee trainee)//what is the difference between the two?
        {
            throw new NotImplementedException();
        }

        public void UploadTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public Trainee GetTraineeById(int id)
        {
            List<Trainee> list = new List<Trainee>(from s in DS.DataSource.trainees where s.Id == id select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one trainee owns ID: {0}. Check your data source", id));

            if (list.Count == 0)
                return null;

            return new Trainee(list[0]);
        }

        #endregion Trainee

        #region Tester

        public void AddTester(Tester tester)
        {
            foreach (var item in DS.DataSource.testers)
            {
                if (item.Id == tester.Id)
                {
                    throw new Exception("The tester already exists!");
                }
            }
            DS.DataSource.testers.Add(tester);
        }

        public void DeleteTester(int id)
        {
            
            if (DS.DataSource.tests.Any((test) => { return test.TesterId == id; }))
            {
                throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
            }
            DS.DataSource.testers.RemoveAll((tester) => { return tester.Id == id; });
            if (!DS.DataSource.testers.Any((tester) => { return tester.Id == id; }))
                throw new Exception("Attempted to delete an unexistent tester");
        }

        public List<Tester> GetAllTesters()
        {
            List<Tester> ret = new List<Tester>(DS.DataSource.testers.Count);

            DS.DataSource.testers.ForEach((item) =>
            {
                ret.Add(new Tester(item));
            });
            return ret;
        }

        public void UploadTester(int id, Tester tester)
        {
            foreach (var item in DS.DataSource.testers)
            {
                if (item.Id == id)
                {
                    DS.DataSource.testers.Add(tester);
                    DS.DataSource.testers.Remove(item);
                }
            }
        }

        public void UploadTester(Tester tester)
        {
            UploadTester(tester.Id, tester);
        }

        public Tester GetTesterByID(int id)
        {
            List<Tester> list = new List<Tester>(from s in DS.DataSource.testers where s.Id == id select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one tester owns ID: {0}. Check your data source", id));

            if (list.Count == 0)
                return null;

            return new Tester(list[0]);
        }

        #endregion Tester

        #region Test

        public void AddFutureTest(Test test)
        {
            DS.DataSource.tests.Add(test);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            DS.DataSource.tests.Add(new Test(tester.Id, trainee.Id, time, address));
        }

        public void FinishTest(int id, CriterionsOfTest criterions, bool pass, string note)
        {
            foreach (var item in DS.DataSource.tests)
            {
                if (item.TestNumber == id)
                {
                    item.Criterions = criterions;
                    item.Pass = pass;
                    item.TesterNote = note;
                    return;
                }
            }
            throw new Exception("Attempted to finish an unexistent test");
        }

        public List<Test> GetAllTests()
        {
            List<Test> ret = new List<Test>(DS.DataSource.tests.Count);

            DS.DataSource.tests.ForEach((item) =>
            {
                ret.Add(new Test(item));
            });
            return ret;
        }

        public Test GetTestByNumber(int number)
        {
            List<Test> list = new List<Test>(from s in DS.DataSource.tests where s.TestNumber == number select s);

            if (list.Count > 1)
                throw new Exception(String.Format("More than one test owns number: {0}. Check your data source", number));

            if (list.Count == 0)
                return null;

            return new Test(list[0]);
        }

        #endregion Test

        public static IDal GetDal()
        {
            return new Imp_Dal();
        }
    }
}
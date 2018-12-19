using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace imp_Dal
{
    public class imp_Dal : IDal
    {
        #region Trainee

        public void addTrainee(Trainee trainee)
        {
            foreach (var item in DS.DataSource.trainees)
            {
                if (item.id == trainee.id)
                {
                    throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
                }
            }
            DS.DataSource.trainees.Add(trainee);
        }

        public void deleteTrainee(int id)
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
                if (item.id == id)
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

        public void uploadTrainee(int id, Trainee trainee)//what is the difference between the two?
        {
            throw new NotImplementedException();
        }

        public void uploadTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        #endregion Trainee

        #region Tester

        public void AddTester(Tester tester)
        {
            foreach (var item in DS.DataSource.testers)
            {
                if (item.id == tester.id)
                {
                    throw new Exception("The tester already exists!");
                }
            }
            DS.DataSource.testers.Add(tester);
        }

        public void DeleteTester(int id)
        {
            foreach (var item in DS.DataSource.tests)
            {
                if (item.TesterId == id)
                {
                    throw new Exception("The tester you attempted to delete has tests scheduled. please make sure the tester is free before deleting!");
                }
            }

            foreach (var item in DS.DataSource.testers)
            {
                if (item.id == id)
                {
                    DS.DataSource.testers.Remove(item);
                    return;
                }
            }
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
            foreach(var item in DS.DataSource.testers)
            {
                if(item.id == id)
                {
                    DS.DataSource.testers.Add(tester);
                    DS.DataSource.testers.Remove(item);
                }
            }
        }

        public void UploadTester(Tester tester)
        {
            UploadTester(tester.id, tester);
        }

        #endregion Tester

        #region Test

        public void AddFutureTest(Test test)
        {
            DS.DataSource.tests.Add(test);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            DS.DataSource.tests.Add(new Test(tester.id, trainee.id, time, address));
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

        #endregion Test
    }
}
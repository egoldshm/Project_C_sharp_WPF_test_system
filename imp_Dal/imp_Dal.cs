//I have some questions in general about some of the implementation of this class.
//It seems like we're not allowed to treat the data structure storing our data as a list necessarily (e.g. in the remove functions), rather we must use a generic of some sort
//Where should we be doing the exception handling for this bit of code?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
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
            //TODO: need to send copy. how to do it?
            return DS.DataSource.trainees;
        }

        public void uploadTrainee(int id, Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void uploadTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        #endregion

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
                throw new Exception("Attempted to delete an unexistent tester");
            }
        }

        public List<Tester> GetAllTesters()
        {
            //TODO: need to send copy. how to do it?
            throw new NotImplementedException();
            return DS.DataSource.testers;
        }

        public void UploadTester(int id, Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UploadTester(Tester tester)
        {
            throw new NotImplementedException();
        }
        #endregion

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
                if(item.TestNumber == id)
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
            //TODO: need to send copy. how to do it?
            throw new NotImplementedException();
            return DS.DataSource.tests;
        }

        #endregion
        
    }
}

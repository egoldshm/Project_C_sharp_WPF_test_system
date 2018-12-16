using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace imp_Dal 
{
    public class imp_Dal : Idal
    {
        public void AddFutureTest(Test test)
        {
            DS.DataSource.tests.Add(test);
        }

        public void AddFutureTest(Tester tester, Trainee trainee, DateTime time, Address address)
        {
            DS.DataSource.tests.Add(new Test(tester.id, trainee.Id, time, address));
        }

        public void addStudent(Trainee trainee)
        {
            DS.DataSource.trainees.Add(trainee);
        }

        public void AddTester(Tester tester)
        {
            DS.DataSource.testers.Add(tester);
        }

        public void deleteStudent(int id)
        {
            foreach (var item in DS.DataSource.trainees)
            {
                if (item.Id == id)
                    DS.DataSource.trainees.Remove(item);
            }
        }


        public void DeleteTester(int id)
        {
            foreach (var item in DS.DataSource.testers)
            {
                if(item.id == id)
                    DS.DataSource.testers.Remove(item);
            }
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

        }

        public List<Tester> GetAllTesters()
        {
            //TODO: need to send copy. how to do it?
            return DS.DataSource.testers;
        }

        public List<Test> GetAllTests()
        {
            //TODO: need to send copy. how to do it?
            return DS.DataSource.tests;
        }

        public List<Trainee> GetAllTrainees()
        {
            //TODO: need to send copy. how to do it?
            return DS.DataSource.trainees;
        }

        public void uploadStudent(int id, Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void uploadStudent(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void UploadTester(int id, Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UploadTester(Tester tester)
        {
            throw new NotImplementedException();
        }
    }
}

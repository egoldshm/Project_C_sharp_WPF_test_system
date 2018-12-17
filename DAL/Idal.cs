using System;
using System.Collections.Generic;
namespace DAL
{
     
    public interface IDal
    {
        
        void AddTester(BE.Tester tester);
        void DeleteTester(int id);
        void UploadTester(int id, BE.Tester tester);
        void UploadTester(BE.Tester tester);

        void addStudent(BE.Trainee trainee);
        void deleteStudent(int id);
        void uploadStudent(int id, BE.Trainee trainee);
        void uploadStudent(BE.Trainee trainee);

        void AddFutureTest(BE.Test test);
        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        List<BE.Test> GetAllTests();
        List<BE.Tester> GetAllTesters();
        List<BE.Trainee> GetAllTrainees();
    }
}



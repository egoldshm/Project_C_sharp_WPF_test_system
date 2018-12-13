using System;

namespace DAL
{
     
    public interface Idal
    {
        
        void AddTester(BE.Tester tester);
        void DeleteTester(BE.Tester tester);
        void UploadTester(int id, BE.Tester tester);
        void UploadTester(BE.Tester tester);

        void addStudent(BE.Trainee trainee);
        void deleteStudent(BE.Trainee trainee);
        void uploadStudent(int id, BE.Trainee trainee);
        void uploadStudent(BE.Trainee trainee);

        void AddFutureTest(BE.Test test);
        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

    }
}



using System;
using System.Collections.Generic;
namespace DAL
{
     
    public interface IDal
    {
        #region Tester

        void AddTester(BE.Tester tester);
        void DeleteTester(int id);
        void UploadTester(int id, BE.Tester tester);
        void UploadTester(BE.Tester tester);
        List<BE.Tester> GetAllTesters();

        #endregion

        #region Trainee

        void addTrainee(BE.Trainee trainee);
        void deleteTrainee(int id);
        void uploadTrainee(int id, BE.Trainee trainee);
        void uploadTrainee(BE.Trainee trainee);
        List<BE.Trainee> GetAllTrainees();

        #endregion

        #region Test

        void AddFutureTest(BE.Test test);
        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);
        List<BE.Test> GetAllTests();
        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        #endregion
    }
}



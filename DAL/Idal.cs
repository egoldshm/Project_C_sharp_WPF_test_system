using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IDal
    {
        #region Trainee

        void addTrainee(BE.Trainee trainee);

        void deleteTrainee(int id);

        void uploadTrainee(int id, BE.Trainee trainee);

        void uploadTrainee(BE.Trainee trainee);

        List<BE.Trainee> GetAllTrainees();

        BE.Trainee GetTraineeById(int id);

        #endregion Trainee

        #region Tester

        void AddTester(BE.Tester tester);

        void DeleteTester(int id);

        void UploadTester(int id, BE.Tester tester);

        void UploadTester(BE.Tester tester);

        List<BE.Tester> GetAllTesters();

        BE.Tester GetTesterByID(int id);

        #endregion Tester

        #region Test

        void AddFutureTest(BE.Test test);

        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

        List<BE.Test> GetAllTests();

        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        BE.Test GetTestByNumber(int number);

        #endregion Test
    }
}
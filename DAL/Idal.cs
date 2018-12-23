using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IDal
    {
        #region Trainee
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainee"></param>
        void AddTrainee(BE.Trainee trainee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteTrainee(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trainee"></param>
        void UploadTrainee(int id, BE.Trainee trainee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainee"></param>
        void UploadTrainee(BE.Trainee trainee);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<BE.Trainee> GetAllTrainees();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BE.Trainee GetTraineeById(int id);

        #endregion Trainee

        #region Tester
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tester"></param>
        void AddTester(BE.Tester tester);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteTester(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tester"></param>
        void UploadTester(int id, BE.Tester tester);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tester"></param>
        void UploadTester(BE.Tester tester);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<BE.Tester> GetAllTesters();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BE.Tester GetTesterByID(int id);

        #endregion Tester

        #region Test
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        void AddFutureTest(BE.Test test);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tester"></param>
        /// <param name="trainee"></param>
        /// <param name="time"></param>
        /// <param name="address"></param>
        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<BE.Test> GetAllTests();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criterions"></param>
        /// <param name="pass"></param>
        /// <param name="note"></param>
        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        BE.Test GetTestByNumber(int number);

        #endregion Test
    }
}
using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ibl
{
    public interface IBL
    {
        #region Trainee
        /// <summary>
        /// Function that get a trainee and add him to the DB
        /// </summary>
        /// <param name="trainee"> the new trainee we add </param>
        void AddTrainee(BE.Trainee trainee);

        /// <summary>
        /// delete trainee by id.
        /// </summary>
        /// <param name="id">id of trainee to delete</param>
        void DeleteTrainee(int id);

        /// <summary>
        /// function that get id of trainee and change the details of the trainee by the trainee that it get.
        /// </summary>
        /// <param name="id">id of trainee to change</param>
        /// <param name="trainee">the details we changes</param>
        void UploadTrainee(int id, BE.Trainee trainee);

        /// <summary>
        /// function the use the first "UploadTrainee" and change the trainee
        /// </summary>
        /// <param name="trainee">the trainee we changes</param>
        void UploadTrainee(BE.Trainee trainee);

        /// <summary>
        /// function that get all the trainees in the DB
        /// </summary>
        /// <returns> return all the trainees</returns>
        List<BE.Trainee> GetAllTrainees(Func<Test, bool> checkFunction = null);

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
        List<BE.Tester> GetAllTesters(Func<Tester, bool> checkFunction = null);

        #endregion Tester

        #region Test

        void AddFutureTest(BE.Test test);

        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

        List<BE.Test> GetAllTests(Func<Test, bool> checkFunction = null);

        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        #endregion Test

        #region getters

        List<Tester> GetTestersWhoLiveInDistantsOfX(Address address, int x);

        List<Tester> GetTestersByAvailableTime(DateTime date);

        List<Test> GetTestsByTrainee(Trainee trainee);

        List<Test> GetTestsByDay(DateTime date);

        IEnumerable<IGrouping<CarType, Tester>> GetTestersByCarType(bool sorted = false);

        IEnumerable<IGrouping<string, Trainee>> GetTraineesBySchoolName(bool sorted = false);

        IEnumerable<IGrouping<string, Trainee>> GetTraineesByTeacher(bool sorted = false);

        IEnumerable<IGrouping<int, Trainee>> GetTraineseByNumOfTesters(bool sorted = false);

        #endregion getters
    }
}
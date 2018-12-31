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
        void AddTrainee(Trainee trainee);

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
        void UpdateTrainee(int id, Trainee trainee);

        /// <summary>
        /// function the use the first "UpdateTrainee" and change the trainee
        /// </summary>
        /// <param name="trainee">the trainee we changes</param>
        void UpdateTrainee(BE.Trainee trainee);

        /// <summary>
        /// function that get all the trainees in the DB
        /// </summary>
        /// <returns> return all the trainees</returns>
        List<Trainee> GetAllTrainees(Predicate<Trainee> checkFunction = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="hasLicense"></param>
        /// <returns></returns>
        List<Trainee> GetAllTraineesByLicense(bool hasLicense = true);

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
        void UpdateTester(int id, Tester tester);

        /// <summary>
        ///
        /// </summary>
        /// <param name="tester"></param>
        void UpdateTester(Tester tester);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        List<Tester> GetAllTesters(Predicate<Tester> checkFunction = null);

        Tester GetTesterById(int id);
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
        /// <param name="checkFunction"></param>
        /// <returns></returns>
        List<BE.Test> GetAllTests(Predicate<Test> checkFunction = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        List<Test> GetTestsByTesters(Tester tester);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criterions"></param>
        /// <param name="pass"></param>
        /// <param name="note"></param>
        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        Test GetTestByNumber(int number);
        #endregion Test


        #region User

        bool CreateUser(string username, string password, BE.User.RoleTypes roleTypes, object obj);

        BE.User GetUser(string username, string password);

        bool ChangePassword(BE.User user, string OldPassword, string NewPassword);

        #endregion User

        #region getters

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        List<Tester> GetTestersWhoLiveInDistantsOfX(Address address, int x);

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<Tester> GetTestersByAvailableTime(DateTime date);

        /// <summary>
        ///
        /// </summary>
        /// <param name="trainee"></param>
        /// <returns></returns>
        List<Test> GetTestsByTrainee(Trainee trainee);

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<Test> GetTestsByDay(DateTime date);

        /// <summary>
        ///
        /// </summary>
        /// <param name="tester"></param>
        /// <param name="successful">flag for singal if we looking for successful or unsuccessful tests</param>
        /// <returns></returns>
        List<Test> GetAllSuccessfullTestsByTester(Tester tester, bool successful = true);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<CarType, Tester>> GetTestersByCarType(bool sorted = false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Trainee>> GetTraineesBySchoolName(bool sorted = false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Trainee>> GetTraineesByTeacher(bool sorted = false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Trainee>> GetTraineseByNumOfTesters(bool sorted = false);

        #endregion getters
    }
}
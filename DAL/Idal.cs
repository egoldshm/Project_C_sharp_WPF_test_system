using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IDal
    {
        #region Trainee

        /// <summary>
        /// Function that add trainee to the DB.
        /// </summary>
        /// <param name="trainee"> The trainee to add.</param>
        void AddTrainee(BE.Trainee trainee);

        /// <summary>
        /// Function that delete trainee from the DB by id number.
        /// </summary>
        /// <param name="id">The id for delete</param>
        void DeleteTrainee(int id);

        /// <summary>
        /// Function that get id and detail of trainee and Update the the detail.
        /// </summary>
        /// <param name="id">the id of trainee</param>
        /// <param name="trainee">the detail of trainee</param>
        void UpdateTrainee(int id, BE.Trainee trainee);

        /// <summary>
        /// Function that get detail of trainee and Update the the detail.
        /// </summary>
        /// <param name="trainee">the trainee to Update</param>
        void UpdateTrainee(BE.Trainee trainee);

        /// <summary>
        /// Function that return all the trainee in the DB.
        /// </summary>
        /// <returns>Eeturn copy of all the trainee</returns>
        List<BE.Trainee> GetAllTrainees();

        /// <summary>
        /// Function that get id and return the trainee by this id in the DB.
        /// </summary>
        /// <param name="id">the id of the trainee</param>
        /// <returns>trainee by id</returns>
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
        void UpdateTester(int id, BE.Tester tester);

        /// <summary>
        ///
        /// </summary>
        /// <param name="tester"></param>
        void UpdateTester(BE.Tester tester);

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
        /// <param name="id"></param>
        void deleteTest(int id);
 
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

        #region User

        bool CreateUser(string username, string password, BE.User.RoleTypes roleTypes, object obj);

        BE.User GetUser(string username, string password);

        bool ChangePassword(BE.User user, string OldPassword, string NewPassword);

        #endregion User
    }
}
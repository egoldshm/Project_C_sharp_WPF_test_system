using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace Ibl
{
    public interface IBL
    {

        #region Trainee

        void addTrainee(BE.Trainee trainee);

        void deleteTrainee(int id);

        void uploadTrainee(int id, BE.Trainee trainee);

        void uploadTrainee(BE.Trainee trainee);

        List<BE.Trainee> GetAllTrainees();

        #endregion Trainee

        #region Tester

        void AddTester(BE.Tester tester);

        void DeleteTester(int id);

        void UploadTester(int id, BE.Tester tester);

        void UploadTester(BE.Tester tester);

        List<BE.Tester> GetAllTesters();

        #endregion Tester

        #region Test

        void AddFutureTest(BE.Test test);

        void AddFutureTest(BE.Tester tester, BE.Trainee trainee, DateTime time, BE.Address address);

        List<BE.Test> GetAllTests();

        void FinishTest(int id, BE.CriterionsOfTest criterions, bool pass, string note);

        #endregion Test

        #region getters
        List<Tester> GetTestersWhoLiveInDistantsOfX(Address address, int x);

        List<Tester> GetTestersWhoFreeInTime(DateTime date);

        List<Test> GetTestsByConditon(Func<Test, bool> checkFunction);

        List<Test> GetTestsByTrainee(Trainee trainee);

        List<Test> GetTestsByDay(DateTime date);

        IEnumerable<IGrouping<CarType, Tester>> GetTestersByCarType(bool sorted = false);

        IEnumerable<IGrouping<string, Trainee>> GetTraineesBySchoolName(bool sorted = false);
      
        IEnumerable<IGrouping<string, Trainee>> GetTraineesByTeacher(bool sorted = false);

        IEnumerable<IGrouping<int, Trainee>> GetTraineseByNumOfTesters(bool sorted = false);

        #endregion getters
    }
}

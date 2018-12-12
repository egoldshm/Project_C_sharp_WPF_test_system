using System;

namespace DAL
{
    public interface Idal
    {
        
        public void addTester(Tester tester);
        public void deleteTester(Tester tester);
        public void deleteTester(int id);

        public void addStudent();
    }
}

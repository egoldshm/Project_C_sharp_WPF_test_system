using BE;
using System;

namespace DAL
{
     
    public interface Idal
    {
        
        void addTester(Tester tester);
        void deleteTester(Tester tester);
        void deleteTester(int id);

        void addStudent();
    }
}

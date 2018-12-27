using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factoryDal
{
    public class FactoryDal
    {
        protected FactoryDal() { }
        protected static DAL.IDal dal = null;
        public static DAL.IDal GetDal()
        {
            if (dal == null)
                dal = new imp_Dal.Imp_Dal();
            return dal;
        }
    }
}

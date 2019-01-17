namespace factoryDal
{
    public class FactoryDal
    {
        protected FactoryDal()
        {
        }

        protected static DAL.IDal dal = null;

        public static DAL.IDal GetDal()
        {
            if (dal == null)
                dal = new DAL.imp_XML_Dal();
            return dal;
        }
    }
}
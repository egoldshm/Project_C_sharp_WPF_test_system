namespace factoryBL
{
    public class FactoryBL
    {
        protected FactoryBL()
        {
        }

        protected static Ibl.IBL bl = null;

        public static Ibl.IBL GetBL()
        {
            if (bl == null)
                bl = new BL.BL();
            return bl;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factoryBL
{
    public class FactoryBL
    {
        protected FactoryBL() { }
        protected static Ibl.IBL bl = null;
        public static Ibl.IBL GetBL()
        {
            if (bl == null)
                bl = new BL.BL();
            return bl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Model;

namespace MainOffice
{
    public static class GlobalHelper
    {
        public static DistributedDataBaseContainer MainOffice { get; set; }
        public static DistributedDataBaseContainer Store { get; set; }
        public static DistributedDataBaseContainer Factory { get; set; }

        public  static User User { get; set; }

        static GlobalHelper()
        {
        }
    }
}

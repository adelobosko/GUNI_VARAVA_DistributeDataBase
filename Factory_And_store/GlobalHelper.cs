using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Model;

namespace Factory_And_store
{
    public static class GlobalHelper
    {
        public static User User { get; set; }

        public static AuthorizationForm AuthorizationForm { get; set; }

        static GlobalHelper()
        {
        }
    }
}

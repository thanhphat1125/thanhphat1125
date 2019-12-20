using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe
{
    class Globals
    {
        public static int GlobalsUserId { get; private set; }
        public static void setGlobalsUserId(int id)
        {
            GlobalsUserId = id;
        }
        public static string GlobalsUserName { get; private set; }
        public static void setGlobalsUserName(string username)
        {
            GlobalsUserName =username;
        }
    }
}

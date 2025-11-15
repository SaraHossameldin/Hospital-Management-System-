using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Helpers
{
    public static class Validation
    {
        public static bool IsPasswordStrong(string pwd)
        {
            if (pwd == null) return false;
            return pwd.Length >= 6;
        }
    }
}

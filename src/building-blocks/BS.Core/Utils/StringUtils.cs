using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Core.Utils
{
    public static class StringUtils
    {
        public static string ApenasNumeros(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
    }
}

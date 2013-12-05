using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PariClasses
{
    public static class Constants
    {
        static public readonly bool isDemo = false;
        public static readonly string ConnectionStringPari = "Data Source=" + System.Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\PARI.sdf";
    }
}

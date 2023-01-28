using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_MCPlayerStats
{
    internal class MojangApi
    {
        public string? id;
        public string? name;
        public List<Cape>? Properties;
    }

    public class Cape
    {
        public string? name;

        public dynamic? value;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_MCPlayerStats
{
    internal class Stats_Internal
    {
#pragma warning disable CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.
        public Stats stats;
#pragma warning restore CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.

        public int DataVersion;
    }

    internal class Stats
    {

        public SortedList<string, int>? picked_up;


        public SortedList<string, int>? mined;


        public SortedList<string, int>? crafted;


        public SortedList<string, int>? broken;


        public SortedList<string, int>? killed;


        public SortedList<string, int>? dropped;


        public SortedList<string, int>? custom;


        public SortedList<string, int>? used;


        public SortedList<string, int>? killed_by;
    }


}

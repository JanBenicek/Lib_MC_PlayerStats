using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_MCPlayerStats
{
    public class Player_Stats
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

        public string? Username;
    
    }
}

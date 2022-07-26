using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plan3.Data
{
    public class OccupiedList
    { 

        public OccupiedList(List<string> list)
        {
            Occupied = list;
        }

        public List<string> Occupied { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_AStars_BFS
{
    public class Evristicknow
    {
        public int Cost { get; set; }
        public int[] steps { get; set; }
        public int[,] root { get; set; }
        public bool visit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_AStars_BFS
{
    public interface IAlgoritm
    {
        void GetResult(ref int[,] mas);
        List<int[]> Steps();
    }
}

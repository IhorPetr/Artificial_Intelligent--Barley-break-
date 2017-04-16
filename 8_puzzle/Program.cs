#define GitPart
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algoritm_AStars_BFS;
using System.Diagnostics;

namespace _8_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
#if(!GitPart)
#else
            Puzzle_board test1 = new Puzzle_board(new BFS());
            //test1.SetNumber();
            Puzzle_board test2 = test1.Clone() as Puzzle_board;
            test2.currentAlgoritm = new A_stars();
            test2.ShowResult();
            test1.ShowResult();
           // Console.ReadLine();
            Console.WriteLine("-------------Solve------------------");
            test1.SwitchAlgoritms();
            test2.SwitchAlgoritms();
            test1.GraphConditions();
            test1.ShowResult();
            test1.GetTimeProgram();
            test1.TotalMemoryUse();
            test1.CountSteps();
            Console.WriteLine("-------------Solve------------------");
            test2.GraphConditions();
            test2.ShowResult();
            test2.GetTimeProgram();
            test2.TotalMemoryUse();
            test2.CountSteps();
            Console.WriteLine("End.");
            Console.ReadLine();
#endif
        }
    }
}

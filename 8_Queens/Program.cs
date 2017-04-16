using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algoritm_AStars_BFS;
using System.Diagnostics;

namespace _8_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chess board
         //   Recur(6,6,7,0);
            //BFS algoritm

            Chess_board test1 = new Chess_board(new BFS());
            //test.SwitchAlgoritms();
            test1.SetQueen();
            Chess_board test2 = test1.Clone() as Chess_board;
            test2.currentAlgoritm = new A_stars();
            //Chess_board test2 = new Chess_board(new A_stars());
           // test2.CloneMass(test1);
            try
            {
                var pr = Process.GetCurrentProcess();
                var mem0 = pr.PeakVirtualMemorySize64;
                test1.SwitchAlgoritms();
                var memuse = pr.PeakVirtualMemorySize64 - mem0;
                Console.WriteLine("Method got {0} additional Mb", memuse / 1024.0 / 1024.0);
            }
            catch(StackOverflowException ex)
            {
                Console.WriteLine("Can`t find solve");
            }
            test2.SwitchAlgoritms();
            test2.ShowResult();
            test1.ShowResult();
            //A_stars Algoritm
            //test2.currentAlgoritm = new A_stars();
            Console.ReadLine();
        }
        static void Recur(int n,int a,int b,int c)
        {
            if(n>1)
            {
                Recur(n-1,a,c,b);
                Console.WriteLine("{0}->{1}",a,b);
                Recur(n-1,c,b,a);
            }
            else
            {
                Console.WriteLine("{0}->{1}", a, b);
            }
        }
    }
   
}

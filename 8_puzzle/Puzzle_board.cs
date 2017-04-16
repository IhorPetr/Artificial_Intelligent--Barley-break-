using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Algoritm_AStars_BFS;

namespace _8_puzzle
{
    class Puzzle_board : ICloneable
    {
        private int[,] board;
        private long CountMemory = 0;
        private Stopwatch stopwat;
        public IAlgoritm currentAlgoritm { private get; set; }
        public Puzzle_board(IAlgoritm currentAlgoritm)
        {
             //this.board= new int[3,3];
            this.board = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 0,7,8 } };
            this.currentAlgoritm = currentAlgoritm;
            this.stopwat = new Stopwatch();
        }
        private Puzzle_board(Puzzle_board gh)
        {
            this.board = new int[gh.board.GetLength(0), gh.board.GetLength(1)];
            for (int i = 0; i < gh.board.GetLength(0); i++)
            {
                for (int j = 0; j < gh.board.GetLength(1); j++)
                {
                    this.board[i, j] = gh.board[i, j];
                }
            }
            this.currentAlgoritm = gh.currentAlgoritm;
            this.stopwat = new Stopwatch();
        }
        public void SwitchAlgoritms()
        {
            var MemoryStart = GC.GetTotalMemory(true);
            stopwat.Start();
            //Start Argoritm
            //....
            currentAlgoritm.GetResult(ref board);
            stopwat.Stop();
            var MemoryEnd = GC.GetTotalMemory(true);
            CountMemory = MemoryEnd - MemoryStart;
        }
        public void ShowResult()
        {
            Console.WriteLine("Current {0} status:", currentAlgoritm.ToString());
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.Write("\n");
            }
        }
        public void SetNumber()
        {
            var number = 1;
            bool uniq = false;
            Random point = new Random();
            while (number != 9)
            {
                while(uniq!=true)
                {
                 var x = point.Next(0, 3);
                 var y = point.Next(0, 3);
                 if(board[x,y]==0)
                 {
                   board[x, y] = number;
                   uniq = true;
                 }
                }
                uniq = false;
                number++;
            }
        }
        public void GetTimeProgram()
        {
            TimeSpan th = stopwat.Elapsed;
            Console.Write("CurrentTimeAlgoritmUsed: ");
            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}.{3:00}", th.Hours, th.Minutes, th.Seconds, th.Milliseconds));
        }
        public object Clone()
        {
            return new Puzzle_board(this);
        }
        public void TotalMemoryUse()
        {
            Console.WriteLine("Total {0}, use memory: {1:N0}",currentAlgoritm.ToString(),CountMemory);
        }
        public void GraphConditions()
        { 
          var steps = 1;
          foreach (int[] x in currentAlgoritm.Steps())
          {
              Console.WriteLine("Step {0}",steps);
              for (int i = 0; i < x.GetLength(0);i++)
              {
                  Console.Write(" " + x[i]);
              }
              Console.WriteLine();
              steps++;
          }
        }
        public void CountSteps()
        {
            Console.WriteLine("Count Steps {0}, is {1}", currentAlgoritm.ToString(),currentAlgoritm.Steps().Count);
        }
    }
}

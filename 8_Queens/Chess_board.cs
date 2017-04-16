using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Algoritm_AStars_BFS;

namespace _8_Queens
{
    class Chess_board : ICloneable
    {
        private int[,] board;

        private Stopwatch stopwat;
        public IAlgoritm currentAlgoritm {private get; set; }

        public Chess_board(IAlgoritm currentAlgoritm)
        {
            this.board= new int[8,8];
            this.currentAlgoritm = currentAlgoritm;
            this.stopwat = new Stopwatch();
        }
        private Chess_board(Chess_board gh)
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
            this.stopwat = gh.stopwat;
        }


        public void SwitchAlgoritms()
         {
            stopwat.Start();
           //Start Argoritm
           //....
           currentAlgoritm.GetResult(ref board);
            stopwat.Stop();
        }
        public void ShowResult()
        {
            Console.WriteLine("Current {0} status:", currentAlgoritm.ToString());
            var BoardHeight = 65;
            Console.CursorLeft =3;
            while(BoardHeight!=73)
            {
                Console.Write(" "+Convert.ToChar(BoardHeight));
                BoardHeight++;
            }
            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0);i++ )
            {
                Console.Write(" {0}|",i+1);
                for (int j = 0; j < board.GetLength(1);j++ )
                {
                    Console.Write(" "+board[i,j]);
                }
                Console.Write("\n");
            }
        }
        public void SetQueen()
        {
            var Queens = 1;
            var cols = 0;
            Random point = new Random();
            while(cols!=8)
            {
                var x = point.Next(0, 7);
                board[x, cols] = Queens;
                Queens++;
                cols++;
            }
        }
        public void GetTimeProgram()
        {
            TimeSpan th = stopwat.Elapsed;
            Console.Write("CurrentTimeAlgoritmUsed: ");
            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}.{3:00}",th.Hours,th.Minutes,th.Seconds,th.Milliseconds));
        }
        public object Clone()
        {
            return new Chess_board(this);
        }
        
    }
}

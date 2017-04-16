using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_AStars_BFS
{
    public class BFS : IAlgoritm
    {
        private readonly int[] status;
        private Queue<int[,]> way;
        private List<int[]> story;

        public BFS()
        {
            this.status = new int[]{1,2,3,4,5,6,7,8,0};
            this.way = new Queue<int[,]>();
            this.story = new List<int[]>();
        }
        public void GetResult(ref int[,] mass)
        {
            way.Enqueue(mass);
            story.Add(mass.Cast<int>().ToArray());
            SeeTree(ref mass);
        }
        #region Main_BFS_Methods
        private bool IsFinalposition(int[,] mass)
        {
            int[] u = mass.Cast<int>().ToArray();
            if (this.status.SequenceEqual(u))
            {
                return true;
            }
            //Console.WriteLine("Count {0}  of BFS", story.Count);
            return false;
        }
        private void SeeTree(ref int[,] mass)
        {
            while(way.Count!=0)
            {
            int[,] root = way.Dequeue();
            if (IsFinalposition(root))
            {
                mass = Copy(root);
                return;
            }
            AddLeaf(root);
            }
        }
        private void AddLeaf(int[,] mass)
        {
            var ty = 0;
            var currmass= new int[3,3];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] == 0)
                    {
                        if(i+1 < mass.GetLength(0))
                        {
                            currmass = Copy(mass);
                            ty = currmass[i + 1, j];
                            currmass[i, j] = ty;
                            currmass[i + 1, j] = 0;
                            if (FindSimilarRoot(currmass.Cast<int>().ToArray()))
                            {
                                this.story.Add(currmass.Cast<int>().ToArray());
                                this.way.Enqueue(currmass);
                            }
                        }
                        if (j + 1 < mass.GetLength(1))
                        {
                            currmass = Copy(mass);
                            ty = currmass[i, j + 1];
                            currmass[i, j] = ty;
                            currmass[i, j + 1] = 0;
                            if (FindSimilarRoot(currmass.Cast<int>().ToArray()))
                            {
                                this.story.Add(currmass.Cast<int>().ToArray());
                                this.way.Enqueue(currmass);
                            }
                        }
                        if (i - 1 >= 0)
                        {
                            currmass = Copy(mass);
                            ty = currmass[i - 1, j];
                            currmass[i, j] = ty;
                            currmass[i - 1, j] = 0;
                            if (FindSimilarRoot(currmass.Cast<int>().ToArray()))
                            {
                                this.story.Add(currmass.Cast<int>().ToArray());
                                this.way.Enqueue(currmass);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            currmass = Copy(mass);
                            ty = currmass[i, j - 1];
                            currmass[i, j] = ty;
                            currmass[i, j - 1] = 0;
                            if (FindSimilarRoot(currmass.Cast<int>().ToArray()))
                            {
                                this.story.Add(currmass.Cast<int>().ToArray());
                                this.way.Enqueue(currmass);
                            }
                        }
                        return;
                    }
                }
            }
        }
        #endregion
        #region Service_Method
        private int[,] Copy(int[,] array)
        {
            int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    newArray[i, j] = array[i, j];
            return newArray;
        }
        private bool FindSimilarRoot(int[] curr)
        {
            foreach(int[] x in this.story)
            {
                if(curr.SequenceEqual(x))
                {
                    return false;
                }
            }
            return true;
        }
        public List<int[]> Steps()
        {
            return story;
        }
        #endregion
    }
}

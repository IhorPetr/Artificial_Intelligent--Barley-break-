using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_AStars_BFS
{
    public class A_stars : IAlgoritm
    {
        private readonly int[] status;
        private List<Evristicknow> story;

        public A_stars()
        {
            this.status = new int[]{1,2,3,4,5,6,7,8,0};
            this.story = new List<Evristicknow>();
        }
        public void GetResult(ref int[,] mas)
        {
            story.Add(new Evristicknow { Cost = EvristicFunction(mas.Cast<int>().ToArray()), 
                steps = mas.Cast<int>().ToArray(),root=Copy(mas),visit=false});
            SeeTree(ref mas);
        }
        #region Main_A_stars_Methods
        private void SeeTree(ref int[,] mass)
        {
            while (true)
            {
                var t = story.Where(x => x.visit == false).ToList();
                foreach (var h in t.Where(y => y.Cost == t.Min(u => u.Cost)).ToList())
                {
                        h.visit = true;
                        if (IsFinalposition(h.root))
                        {
                            mass = Copy(h.root);
                            return;
                        }
                       // Console.WriteLine("Count {0}  of A_stars", story.Count);
                        AddLeaf(h.root);
                    
                }
            }
        }
        private bool IsFinalposition(int[,] mass)
        {
            int[] u = mass.Cast<int>().ToArray();
            if (this.status.SequenceEqual(u))
            {
                return true;
            }
            return false;
        }
        private int EvristicFunction(int[] mass)
        {
            int sum = 0;
            int[] u = mass.Cast<int>().ToArray();
            for(int i=0;i<this.status.Length;i++)
            {
                if(this.status[i]!=u[i])
                {
                    sum+=1;
                }
            }
            return sum;
        }
        private void AddLeaf(int[,] mass)
        {
            var ty = 0;
            var currmass = new int[3, 3];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] == 0)
                    {
                        if (i + 1 < mass.GetLength(0))
                        {
                            currmass = Copy(mass);
                            ty = currmass[i + 1, j];
                            currmass[i, j] = ty;
                            currmass[i + 1, j] = 0;
                            if (FindSimilarRoot(currmass.Cast<int>().ToArray()))
                            {
                                this.story.Add(new Evristicknow
                                {
                                    Cost = EvristicFunction(currmass.Cast<int>().ToArray()),
                                    steps = currmass.Cast<int>().ToArray(),
                                    root = Copy(currmass),
                                    visit = false
                                });
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
                                this.story.Add(new Evristicknow
                                {
                                    Cost = EvristicFunction(currmass.Cast<int>().ToArray()),
                                    steps = currmass.Cast<int>().ToArray(),
                                    root = Copy(currmass),
                                    visit = false
                                });
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
                                this.story.Add(new Evristicknow
                                {
                                    Cost = EvristicFunction(currmass.Cast<int>().ToArray()),
                                    steps = currmass.Cast<int>().ToArray(),
                                    root = Copy(currmass),
                                    visit = false
                                });
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
                                this.story.Add(new Evristicknow
                                {
                                    Cost = EvristicFunction(currmass.Cast<int>().ToArray()),
                                    steps = currmass.Cast<int>().ToArray(),
                                    root = Copy(currmass),
                                    visit = false
                                });
                            }
                        }
                        return;
                    }
                }
            }
        }
        #endregion
        #region Service_Method
        public List<int[]> Steps()
        {
            return story.Select(x=>x.steps).ToList();
        }
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
            foreach (int[] x in this.story.Select(y=>y.steps))
            {
                if (curr.SequenceEqual(x))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}

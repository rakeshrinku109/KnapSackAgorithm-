using System;
using System.Collections.Generic;

namespace TravellingSalesManAlgorithm
{
    class Program
    {
        static List<string> Items = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] Weights = new int[] {10,20,30 };
            int[] Value = new int[] { 60,100,120 };
            int KnapSackCapacity = 50;
            int numberOfElements = 3;
            Console.WriteLine(Knapsack(Weights, Value, numberOfElements, KnapSackCapacity));
        }

        static int Knapsack(int[] Weights, int[] Values, int NumberOfElements, int knapsackCapacity)
        {
            //Dp - 1 Algorithm. Bottom up approach. 

            //Construct the table.
            //Consider when no elements and knapsack capacity 0 is considerd.
            // Row are items and Columns are Knapsack capacity leading to 50.
            int[,] KnapSackMatrix = new int[NumberOfElements + 1, knapsackCapacity + 1];

             

            for (int i = 0; i <=NumberOfElements ; i++)
            {
                for (int w = 0; w <=knapsackCapacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        KnapSackMatrix[i, w] = 0;
                    }else
                    {
                        //If weight is more then knapsack capacity - put the previous elemts weight as value.
                        if (Weights[i - 1] > w)
                        {
                            KnapSackMatrix[i, w] = KnapSackMatrix[i - 1, w];
                        }
                        // If item is included and excluded, cosider the max
                        else
                        {
                            KnapSackMatrix[i, w] = Math.Max(Values[i-1] + KnapSackMatrix[i - 1, w - Weights[i-1]], KnapSackMatrix[i - 1, w]);
                        }
                    }

                }
            }

            // take the i*w element. 
            // Check if i-1,w element is same -> then, this element is not considered.
            //else go on a recursive loop.
             FindMaxValueRoute(KnapSackMatrix, NumberOfElements, knapsackCapacity, knapsackCapacity);

            return KnapSackMatrix[NumberOfElements , knapsackCapacity];
        }


        static void FindMaxValueRoute(int[,] Matrix,int i, int w,int MaxWeight)
        {
            int MaxValue = Matrix[i,w];
            if (i==0)
            {
                return;
            }
            if (MaxValue == Matrix [i-1,w])
            {
                //this value is not considered.
                FindMaxValueRoute(Matrix, i - 1, w,MaxWeight);
            }
            else
            {
                Items.Add($"{i} th Element");
                FindMaxValueRoute(Matrix, i - 1, w, MaxWeight);
            }
        }
    }
}

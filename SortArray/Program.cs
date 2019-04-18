using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = GetArray(50, 200);
            int compares = 0;
            int swaps = 0;
            int[] arrBubble = BubbleSort(myArray, ref compares, ref swaps);
            BubbleWrite(arrBubble, compares, swaps);
            compares = 0;
            swaps = 0;
            int[] arrQuick = QuickSort(myArray, 0, myArray.Length - 1, ref compares, ref swaps);
            QuickSortWrite(arrQuick, compares, swaps);
            int[,] myMatrix = GetMatrix(5, 10);
            PrintMatrix(myMatrix);
            int[,] mySnakeMatrix = GetMatrixSnake(5, 10);
            PrintMatrix(mySnakeMatrix);
            Console.ReadKey();
        }


        public static int[] GetArray(int sizemin, int sizemax)
        {
            Random rnd = new Random();
            int size = rnd.Next(sizemin, sizemax);

            int[] arr = new int[size];
            Console.WriteLine("Array length: {0}", arr.Length);

            Console.WriteLine("Array (before sorting): ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-1000, 1000);
                Console.Write("{0}\t", arr[i]);
            }
            return arr;
        }

        public static int[,] GetMatrix(int sizemin, int sizemax)
        {
            Random rnd = new Random();
            int size = rnd.Next(sizemin, sizemax);

            int[,] mat = new int[size, size];
           for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = rnd.Next(-1000, 1000);
                }
            }
            return mat;
        }

        public static int[,] GetMatrixSnake(int sizemin, int sizemax)
        {
            Random rnd = new Random();
            int size = rnd.Next(sizemin, sizemax);

            int[,] mat = new int[size, size];
            int value = 1;
            int row;
            int column;



            for (int diag = 0; diag < size; diag++)
            {
                if (diag % 2 == 0)
                {
                    row = 0;
                    column = diag;

                    while (column >= 0)
                    {
                        mat[row, column] = value;
                        value++;
                        row++;
                        column--;
                    }
                }
                else
                {
                    row = diag;
                    column = 0;

                    while (row >= 0)
                    {
                        mat[row, column] = value;
                        value++;
                        row--;
                        column++;
                    }
                }
            }
            if(size % 2 == 0) { 
                for (int diag = 1; diag < size; diag++)
                {
                    if (diag % 2 == 0)
                    {
                        row = size - 1;
                        column = diag;

                        while (column <= size - 1)
                        {
                            mat[row, column] = value;
                            value++;
                            row--;
                            column++;
                        }
                    }
                    else
                    {
                        row = diag;
                        column = size - 1;

                        while (row <= size - 1)
                        {
                            mat[row, column] = value;
                            value++;
                            row++;
                            column--;
                        }
                    }
                }
            }
            else {
                for (int diag = 1; diag < size; diag++)
                {
                    if (diag % 2 == 0)
                    {
                        row = diag;
                        column = size - 1;

                        while (row <= size - 1)
                        {
                            mat[row, column] = value;
                            value++;
                            row++;
                            column--;
                        }
                    }
                    else
                    {
                        row = size - 1;
                        column = diag;

                        while (column <= size - 1)
                        {
                            mat[row, column] = value;
                            value++;
                            row--;
                            column++;
                        }
                    }
                }
            }
            return mat;
            
        }
        public static int[,] PrintMatrix(int[,] mat)
        { 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Matrix");
            Console.WriteLine();
            Console.WriteLine("Matrix rows: {0}", mat.GetLength(0));
            Console.WriteLine("Matrix columns: {0}", mat.GetLength(1));
            Console.WriteLine();
            Console.WriteLine("Matrix (before sorting): ");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0}\t", mat[i, j]);
                }
                Console.Write("\n");
            }
            return mat;
        }

        public static int[] BubbleSort(int[] arr, ref int compares, ref int swaps)
        {

            int i, j;
            int[] arrBubble = arr;
            for (i = 0; i < arrBubble.Length; i++)
            {
                for (j = 0; j < arrBubble.Length; j++)
                {
                    if (arrBubble[i] < arrBubble[j])
                    {
                        compares++;
                        swaps++;
                        Swap(arrBubble, i, j);
                    }
                    else
                    {
                        compares++;
                    }
                }
                
            }

            return arrBubble;
        }
        public static int[] BubbleWrite(int[] arrBubble, int compares, int swaps)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BubbleSort");
            Console.WriteLine();
            Console.WriteLine("Compares: {0}", compares);
            Console.WriteLine("Swaps: {0}", swaps);
            Console.WriteLine();
            Console.WriteLine("Array (after sorting): ");
            for (int i = 0; i < arrBubble.Length; i++)
            {
                Console.Write("{0}\t", arrBubble[i]);
            }

            return arrBubble;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        public static int[] QuickSort(int[] arr, int low, int high, ref int compares, ref int swaps)
        {
            int[] arrQuick = arr;
            Random pivotRange = new Random();
            if (low < high)
            {
                compares++;

                int pivotIndex = pivotRange.Next(low, high);
                int newPivot = Partition(arrQuick, low, high, pivotIndex, ref compares, ref swaps);

                QuickSort(arrQuick, low, newPivot - 1, ref compares, ref swaps);
                QuickSort(arrQuick, newPivot + 1, high, ref compares, ref swaps);
            }


            return arrQuick;
            
        }

        private static int Partition(int[] arr, int low, int high, int pivotIndex, ref int compares, ref int swaps)
        {
            int pivotValue = arr[pivotIndex];

            Swap(arr, pivotIndex, high);
            swaps++;

            int storeIndex = low;

            for (int i = low; i < high; i++)
            {
                if (arr[i].CompareTo(pivotValue) < 0)
                {
                    Swap(arr, i, storeIndex);
                    storeIndex++;
                    compares++;
                    swaps++;
                }
                else
                {
                    compares++;
                }
            }

            Swap(arr, storeIndex, high);
            swaps++;
            return storeIndex;
        }

        public static void QuickSortWrite(int[] arrQuick, int compares, int swaps)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("QuickSort");
            Console.WriteLine();
            Console.WriteLine("Compares: {0}", compares);
            Console.WriteLine("Swaps: {0}", swaps);
            Console.WriteLine();
            Console.WriteLine("Array (after sorting): ");
            for (int i = 0; i < arrQuick.Length; i++)
            {
                Console.Write("{0}\t", arrQuick[i]);
            }
        }
        





}
}

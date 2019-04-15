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
            int[] myArray = GetArray();
            BubbleSort(myArray);
            int compares = 0;
            int swaps = 0;
            int[] arrQuick = QuickSort(myArray, 0, myArray.Length - 1, ref compares, ref swaps);
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
            Console.ReadKey();
        }


        public static int[] GetArray()
        {
            Random rnd = new Random();
            int size = rnd.Next(50, 200);

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

        public static int[] BubbleSort(int[] arr)
        {
            int compares = 0;
            int swaps = 0;
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BubbleSort");
            Console.WriteLine();
            Console.WriteLine("Compares: {0}", compares);
            Console.WriteLine("Swaps: {0}", swaps);
            Console.WriteLine();
            Console.WriteLine("Array (after sorting): ");
            for (i = 0; i < arrBubble.Length; i++)
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
            int i, j;
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

        public static int Partition(int[] arr, int low, int high, int pivotIndex, ref int compares, ref int swaps)
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






    }
}

using System;

namespace Heapsort {
    class Heap {
        private static int GetParent(int[] a, int i) { return i / 2 - 1; }
        private static int GetLeft(int i) { return i * 2 + 1; }
        private static int GetRight(int i) { return i * 2 + 2; }

        public static void MaxHeapify(int[] a, int i, int size) {
            if (a.Length <= 1) return;
            int l = GetLeft(i);       //Get the index of the left child
            int r = GetRight(i);      //Get the index of the right child
            int largest = i;

            /*Determine the largest element out of the parent, left child, and right child*/
            if (l < size && a[l] > a[largest]) largest = l;
            if (r < size && a[r] > a[largest]) largest = r;
            
            /*Make proper swaps if necessary*/
            if(largest != i) {
                int temp = a[largest];
                a[largest] = a[i];
                a[i] = temp;
                MaxHeapify(a, largest, size);
            }
        }

        public static void BuildMaxHeap(int[] a) {
            int start = a.Length / 2 - 1;
            for (int i = start; i >= 0; --i) MaxHeapify(a, i, a.Length);
        }

        public static void HeapSort(int[] a) {
            BuildMaxHeap(a);
            for(int i = a.Length - 1; i >= 0; --i) {
                int temp = a[0];
                a[0] = a[i];
                a[i] = temp;
                MaxHeapify(a, 0, i);
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Enter an array size");
                String userInput = Console.ReadLine();
                int arraySize;
                if (Int32.TryParse(userInput, out arraySize) && arraySize > 0) {
                    int[] arr = new int[arraySize];
                    Random r = new Random();
                    for (int i = 0; i < arr.Length; ++i) arr[i] = r.Next(1000);
                    Console.WriteLine("Original Array");
                    PrintArray(arr);
                    Heap.HeapSort(arr);
                    Console.WriteLine("Sorted Array");
                    PrintArray(arr);
                } else {
                    Console.WriteLine("Invalid array size");
                }
            }
        }

        private static void PrintArray(int[] arr) {
            Console.Write("[");
            for (int i = 0; i < arr.Length - 1; ++i) Console.Write("{0}, ", arr[i]);
            Console.WriteLine("{0}]", arr[arr.Length - 1]);
        }
    }
}

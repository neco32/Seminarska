using System;
using System.Threading;

namespace WindowsFormsApp1
{
    class Quick_Sort
    {
        public static void izpis(int[] tabela)
        {
            Console.WriteLine("izpis: ");
            for (int i = 0; i < tabela.Length; i++)
            {
                Console.Write(tabela[i] + "\t");
            }
            Console.WriteLine();
        }

        public static int[] QuickSort(int[] tabela, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(tabela, left, right);
                QuickSort(tabela, left, pivotIndex - 1);
                QuickSort(tabela, pivotIndex + 1, right);
            }
            return tabela;
        }

        

        private static int Partition(int[] tabela, int left, int right)
        {
            int pivot = tabela[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (tabela[j] <= pivot)
                {
                    i++;
                    Swap(tabela, i, j);
                    
                    
                }
            }
            Swap(tabela, i + 1, right);
            
            
            return i + 1;
        }

        private static void Swap(int[] tabela, int i, int j)
        {
            int temp = tabela[i];
            tabela[i] = tabela[j];
            tabela[j] = temp;
        }
        public static int[] QuickSort2(int[] tabela, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition2(tabela, left, right);
                QuickSort2(tabela, left, pivotIndex - 1);
                QuickSort2(tabela, pivotIndex + 1, right);
            }
            return tabela;
        }

        private static void medianofthree(int[] tabela, int start, int max)
        {
            int mid = (start + max) / 2;
            if (tabela[start] > tabela[mid])
            {
                Swap(tabela, start, mid);
                
                
            }
            if (tabela[start] > tabela[max])
            {
                Swap(tabela, start, max);
                
                
            }
            if (tabela[mid] > tabela[max])
            {
                Swap(tabela, mid, max);
                
                
            }
            Swap(tabela, mid, max - 1);
            
            
        }

        private static int Partition2(int[] tabela, int left, int right)
        {
            medianofthree(tabela, left, right);
            int pivot = tabela[right - 1];
            int i = left;
            for (int j = left; j < right - 1; j++)
            {
                if (tabela[j] <= pivot)
                {
                    Swap(tabela, i, j);
                    i++;
                    
                    
                }
            }
            Swap(tabela, i, right - 1);
            
            
            return i;
        }
    }
}
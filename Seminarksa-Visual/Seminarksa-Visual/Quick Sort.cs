using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        /*public async Task Zapis2(int[] podatki,Form form)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int[]>(async (data) => await Zapis2(data)), new object[] { podatki });
                return;
            }

            // Throttle updates to avoid performance issues
            updateCounter++;
            if (updateCounter % updateThreshold != 0)
            {
                return;
            }

            // Počistimo prejšnje podatke iz grafa
            chart2.Series.Clear();

            // Ustvarimo novo serijo
            Series series = new Series("Sortirani Podatki")
            {
                ChartType = SeriesChartType.Column // Lahko zamenjaš z Line, Pie, itd.
            };

            // Dodamo podatke v serijo (X = indeks, Y = vrednost)
            for (int i = 0; i < podatki.Length; i++)
            {
                series.Points.AddXY(i, podatki[i]);
            }

            // Dodamo serijo v graf
            chart2.Series.Add(series);

            // Pause for 5 seconds
            await Task.Delay(100);
        }*/

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
                    izpis(tabela);
                    Thread.Sleep(1000);
                }
            }
            Swap(tabela, i + 1, right);
            izpis(tabela);
            Thread.Sleep(1000);
            return i + 1;
        }

        private static void Swap(int[] tabela, int i, int j)
        {
            int temp = tabela[i];
            tabela[i] = tabela[j];
            tabela[j] = temp;
        }

        private static void medianofthree(int[] tabela, int start, int max)
        {
            int mid = (start + max) / 2;
            if (tabela[start] > tabela[mid])
            {
                Swap(tabela, start, mid);
                izpis(tabela);
                Thread.Sleep(1000);
            }
            if (tabela[start] > tabela[max])
            {
                Swap(tabela, start, max);
                izpis(tabela);
                Thread.Sleep(1000);
            }
            if (tabela[mid] > tabela[max])
            {
                Swap(tabela, mid, max);
                izpis(tabela);
                Thread.Sleep(1000);
            }
            Swap(tabela, mid, max - 1);
            izpis(tabela);
            Thread.Sleep(1000);
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
                    izpis(tabela);
                    Thread.Sleep(1000);
                }
            }
            Swap(tabela, i, right - 1);
            izpis(tabela);
            Thread.Sleep(1000);
            return i;
        }
    }
}
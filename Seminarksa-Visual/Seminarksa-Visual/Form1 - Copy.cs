using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int updateCounter = 0;
        private const int updateThreshold = 100; // Adjust this value to control update frequency

        public Form1()
        {
            InitializeComponent();
            /*int[] tabela1 = new int[100];
            int[] tabela2 = new int[100];
            Random rnd = new Random();
            for (int j = 0; j < tabela2.Length - 1; j++)
            {
                int value = rnd.Next(0, 10000);
                tabela2[j] = value;
                tabela1[j] = value;
            }
            _ = QuickSort(tabela1, 0, tabela1.Length - 1, this);
            _ = QuickSort2(tabela2, 0, tabela2.Length - 1, this);
            Zapis(tabela1);
            Zapis2(tabela2);*/
            int[] tabela = { 7, 8, 10, 2, 26, 4, 19, 5, 3, 16, 11, 6, 13, 12 };
            Console.WriteLine(tabela.Length - 1);
            tabela = Quick_Sort.QuickSort2(tabela, 0, tabela.Length - 1);

        }

        public async Task Zapis(int[] podatki)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int[]>(async (data) => await Zapis(data)), new object[] { podatki });
                return;
            }

            // Throttle updates to avoid performance issues
            updateCounter++;
            if (updateCounter % updateThreshold != 0)
            {
                return;
            }

            // Počistimo prejšnje podatke iz grafa
            chart1.Series.Clear();

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
            chart1.Series.Add(series);

            // Pause for 5 seconds
            await Task.Delay(100);
        }

        public async Task Zapis2(int[] podatki)
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
        }

        public static async Task<int[]> QuickSort(int[] tabela, int left, int right, Form1 form)
        {
            if (left < right)
            {
                int pivotIndex = await Partition(tabela, left, right, form);
                await QuickSort(tabela, left, pivotIndex - 1, form);
                await QuickSort(tabela, pivotIndex + 1, right, form);
                
            }
            return tabela;
        }

        public static async Task<int[]> QuickSort2(int[] tabela, int left, int right, Form1 form)
        {
            if (left < right)
            {
                int pivotIndex = await Partition2(tabela, left, right, form);
                await QuickSort2(tabela, left, pivotIndex - 1, form);
                await QuickSort2(tabela, pivotIndex + 1, right, form);
            }
            return tabela;
        }

        private static async Task<int> Partition(int[] tabela, int left, int right, Form1 form)
        {
            int pivot = tabela[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (tabela[j] <= pivot)
                {
                    i++;
                    await Swap2(tabela, i, j, form);
                }
            }
            await Swap2(tabela, i + 1, right, form);
            return i + 1;
        }

        private static async Task Swap(int[] tabela, int i, int j, Form1 form)
        {
            int temp = tabela[i];
            tabela[i] = tabela[j];
            tabela[j] = temp;
            await form.Zapis(tabela); // Update the chart after each swap
        }

        private static async Task Swap2(int[] tabela, int i, int j, Form1 form)
        {
            int temp = tabela[i];
            tabela[i] = tabela[j];
            tabela[j] = temp;
            await form.Zapis2(tabela); // Update the chart after each swap
        }

        private static async Task medianofthree(int[] tabela, int start, int max, Form1 form)
        {
            int mid = (start + max) / 2;
            if (tabela[start] > tabela[mid])
            {
                await Swap(tabela, start, mid, form);
            }
            if (tabela[start] > tabela[max])
            {
                await Swap(tabela, start, max, form);
            }
            if (tabela[mid] > tabela[max])
            {
                await Swap(tabela, mid, max, form);
            }
            await Swap(tabela, mid, max - 1, form);
        }

        private static async Task<int> Partition2(int[] tabela, int left, int right, Form1 form)
        {
            await medianofthree(tabela, left, right, form);
            int pivot = tabela[right - 1];
            int i = left;
            for (int j = left; j < right - 1; j++)
            {
                if (tabela[j] <= pivot)
                {
                    await Swap(tabela, i, j, form);
                    i++;
                }
            }
            await Swap(tabela, i, right - 1, form);
            return i;
        }
    }
}

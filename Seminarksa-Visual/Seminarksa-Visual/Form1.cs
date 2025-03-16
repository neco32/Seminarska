using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int ms = 1000; // Delay for visualization
        int[] tabela1 = new int[30];
        int[] tabela2 = new int[30];

        public Form1()
        {
            InitializeComponent();

            Random rnd = new Random();
            for (int j = 0; j < tabela2.Length; j++)
            {
                int i = rnd.Next(1, 100);
                tabela1[j] = i;
                tabela2[j] = i;
            }
            Zapis(tabela1);
            Zapis2(tabela2);
        }

        public void Zapis(int[] podatki, int x = -1, int y = -1, int start = -1, int end = -1, int pivot = -1)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int[], int, int, int, int, int>(Zapis2), podatki, x, y, start, end, pivot);
                return;
            }

            chart1.Series.Clear();
            Series series = new Series("Sortirani Podatki")
            {
                ChartType = SeriesChartType.Column
            };

            for (int i = 0; i < podatki.Length; i++)
            {
                var point = series.Points.AddXY(i, podatki[i]);

                // Označi obseg, ki se trenutno obdeluje, v rumeno
                if (start != -1 && end != -1 && i >= start && i <= end)
                    series.Points[i].Color = Color.Yellow;

                // Označi pivot točko v vijolično
                if (i == pivot)
                    series.Points[i].Color = Color.Purple;

                // Označi elemente, ki se trenutno menjajo, v rdeče
                if (i == x || i == y)
                    series.Points[i].Color = Color.Red;
            }

            chart1.Series.Add(series);
        }

        public void Zapis2(int[] podatki, int x = -1, int y = -1, int start = -1, int end = -1, int pivot = -1)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int[], int, int, int, int, int>(Zapis2), podatki, x, y, start, end, pivot);
                return;
            }

            chart2.Series.Clear();
            Series series = new Series("Sortirani Podatki")
            {
                ChartType = SeriesChartType.Column
            };

            for (int i = 0; i < podatki.Length; i++)
            {
                var point = series.Points.AddXY(i, podatki[i]);

                // Označi obseg, ki se trenutno obdeluje, v rumeno
                if (start != -1 && end != -1 && i >= start && i <= end)
                    series.Points[i].Color = Color.Yellow;

                // Označi pivot točko v vijolično
                if (i == pivot)
                    series.Points[i].Color = Color.Purple;

                // Označi elemente, ki se trenutno menjajo, v rdeče
                if (i == x || i == y)
                    series.Points[i].Color = Color.Red;
            }

            chart2.Series.Add(series);
        }


        public async Task QuickSort(int[] tabela, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = await Partition(tabela, left, right);
                await QuickSort(tabela, left, pivotIndex - 1);
                await QuickSort(tabela, pivotIndex + 1, right);
            }
        }

        private async Task<int> Partition(int[] tabela, int left, int right)
        {
            int pivot = tabela[right]; // Pivot is now at right

            int i = left - 1;

            // Highlight the range being processed and pivot
            Invoke((Action)(() => Zapis(tabela, -1, -1, left, right, right)));

            for (int j = left; j < right; j++)
            {
                if (tabela[j] <= pivot)
                {
                    i++;
                    Invoke((Action)(() => Zapis(tabela, i, j, left, right, right))); // Refresh display
                    await Task.Delay(ms);
                    await Swap(tabela, i, j);
                    Invoke((Action)(() => Zapis(tabela, i, j, left, right, right))); // Refresh display
                    await Task.Delay(ms);
                }
            }
            await Swap(tabela, i + 1, right);
            Invoke((Action)(() => Zapis(tabela, i + 1, right, left, right, right))); // Refresh display
            await Task.Delay(ms);

            // Refresh the table to remove yellow highlight
            Invoke((Action)(() => Zapis(tabela)));

            return i + 1;
        }



        private async Task Swap(int[] tabela, int i, int j)
        {
            

            // Swap elements
            int temp = tabela[i];
            tabela[i] = tabela[j];
            tabela[j] = temp;

            
        }

        private async Task QuickSort2(int[] tabela, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = await Partition2(tabela, left, right);
                await QuickSort2(tabela, left, pivotIndex - 1);
                await QuickSort2(tabela, pivotIndex + 1, right);
            }
        }

        private async Task<int> Partition2(int[] tabela, int left, int right)
        {
            await medianofthree(tabela, left, right);
            int pivot = tabela[right - 1]; // Pivot is now at right - 1

            int i = left-1;

            // Highlight the range being processed and pivot
            Invoke((Action)(() => Zapis2(tabela, -1, -1, left, right, right - 1)));

            for (int j = left; j < right - 1; j++)
            {
                if (tabela[j] <= pivot)
                {

                    i++;
                    Invoke((Action)(() => Zapis2(tabela, i, j, left, right, right - 1))); // Refresh display
                    await Task.Delay(ms);
                    await Swap(tabela, i, j);
                    Invoke((Action)(() => Zapis2(tabela, i, j, left, right, right - 1))); // Refresh display
                    await Task.Delay(ms);
                }
            }
            await Swap(tabela, i + 1, right - 1);
            Invoke((Action)(() => Zapis2(tabela, i + 1, right - 1, left, right, right - 1))); // Refresh display
            await Task.Delay(ms);

            // Refresh the table to remove yellow highlight
            Invoke((Action)(() => Zapis2(tabela)));

            return i + 1;
        }

        private async Task medianofthree(int[] tabela, int start, int max)
        {
            int mid = (start + max) / 2;

            if (tabela[start] > tabela[mid])
                await Swap(tabela, start, mid);

            if (tabela[start] > tabela[max])
                await Swap(tabela, start, max);

            if (tabela[mid] > tabela[max])
                await Swap(tabela, mid, max);

            // Move median to right - 1
            await Swap(tabela, mid, max - 1);

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Sorting for both tables
            await Task.WhenAll(
                Task.Run(() => QuickSort(tabela1, 0, tabela1.Length - 1)),
                Task.Run(() => QuickSort2(tabela2, 0, tabela2.Length - 1))
            );

            // After sorting is done, refresh the charts
            Invoke((Action)(() => Zapis(tabela1)));
            Invoke((Action)(() => Zapis2(tabela2)));
        }
    }
}

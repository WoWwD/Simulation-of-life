using SimulatorOfLive.View.Chart;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form2 : Form
    {
        private string SelectedItems;
        private Charts chart;
        private ListsForCharts listsForCharts;
        public Form2(ListsForCharts list)
        {
            InitializeComponent();
            AddDataInListbox();
            listsForCharts = list;
            chart = new Charts();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Maximum = chart.cycles;
            chart1.ChartAreas[0].AxisX.Minimum = chart.a;
            chart1.ChartAreas[0].AxisX.Title = "Циклы";
        }
        private void CreateChart(int cycles, List<int> mas)
        {
            int a = 0, x = a, y;
            chart1.Series[0].Points.Clear();
            while (x <= cycles)
            {
                y = chart.GetDataFromArray(x, mas);
                chart1.Series[0].Points.AddXY(x * 1, y);
                x += 50;
            }
        }
        private void AddDataInListbox()
        {
            string[] charts = { "График смертей", "График эволюций", "График делений"};
            listBox1.Items.AddRange(charts);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItems = listBox1.SelectedItem.ToString();
            if (SelectedItems == "График смертей")
            {
                CreateChart(chart.cycles, listsForCharts.AmountDeaths);
            }
            if (SelectedItems == "График эволюций")
            {
                CreateChart(chart.cycles, listsForCharts.AmountEvolution);
            }
            if (SelectedItems == "График делений")
            {
                CreateChart(chart.cycles, listsForCharts.AmountDivision);
            }
        }
    }
}
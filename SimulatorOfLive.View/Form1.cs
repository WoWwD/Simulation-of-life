using SimulationOfLife.Logic.Controller;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Cell;
using SimulatorOfLive.Logic.Services;
using SimulatorOfLive.View;
using SimulatorOfLive.View.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimulationOfLife.View
{
    public partial class Form1 : Form
    {
        private MainController controller;
        private static int MaxWidthField { get; set; }
        private static int MaxHeightField { get; set; }
        private Graphics graphics;
        private ListsForCharts listsForCharts;
        public Form1()
        {
            InitializeComponent();
            GameZonePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            MaxHeightField = GameZonePictureBox.Height;
            MaxWidthField = GameZonePictureBox.Width;
            StartGameButton.Enabled = false;
            PauseGameButton.Enabled = false;
            SaveGameButton.Enabled = false;
            GameZonePictureBox.Image = new Bitmap(MaxWidthField,MaxHeightField);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.WhiteSmoke);
            timer1.Interval = 500;
            GetChart.Enabled = false;
        }
        #region Кнопки
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            PauseGameButton.Enabled = true;
            SaveGameButton.Enabled = false;
            LoadGameButton.Enabled = false;
            NewGameButton.Enabled = false;
            StartGameButton.Enabled = false;
        }
        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGameButton.Enabled = true;
            SaveGameButton.Enabled = true;
            LoadGameButton.Enabled = true;
            NewGameButton.Enabled = true;
            PauseGameButton.Enabled = false;
        }
        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            var result = controller.serializationService.Serialization(controller.cells, controller.food);
            if (result == null)
            {
                Show("Ошибка при сохранении игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Игра сохранена: {result}");
            }
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            controller = new MainController();
            var OpenFile = openFileDialog1;
            OpenFile.Filter = "Documents (*.xml)|*.xml"; 
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                SavedGame savedGame = controller.serializationService.DeSerialization(OpenFile.FileName);
                if (savedGame == null)
                {
                    Show("Ошибка при загрузке игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    controller.cells = savedGame.cells;
                    controller.food = savedGame.food;
                    graphics.Clear(Color.WhiteSmoke);
                    RefreshData();
                    GameZonePictureBox.Refresh();
                    StartGameButton.Enabled = true;
                }
            }
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MaxHeightField = GameZonePictureBox.Height;
            MaxWidthField = GameZonePictureBox.Width;
            NewImg(0, 0);
            graphics.Clear(Color.WhiteSmoke);
            listsForCharts = new ListsForCharts();
            listsForCharts.AmountDeaths = new List<int>();
            listsForCharts.AmountEvolution = new List<int>();
            listsForCharts.AmountDivision = new List<int>();
            controller = new MainController();
            controller.AddFirstCells(SettingsGame.AmountOfCells, MaxWidthField, MaxHeightField);
            RefreshData();
            GameZonePictureBox.Refresh();
            StartGameButton.Enabled = true;
            GetChart.Enabled = false;
        }
        #endregion
        private void RefreshData()
        {
            double c = 0, h = 0, o = 0;
            foreach (var cell in controller.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    graphics.FillEllipse(Brushes.Crimson, cell.X, cell.Y, cell.Width, cell.Height);
                    c++;
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
                    h++;
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                    o++;
                }
            }
            foreach (var f in controller.food)
            {
                graphics.FillRectangle(Brushes.Green, f.X, f.Y, f.Width, f.Height);
            }
            if (controller.AmountOfCycles % SettingsGame.UpdateRate == 0)
            {
                label1.Text = $"Количество клеток: {controller.cells.Count}";
                carni.Text = controller.statistics.AmountCells(c, controller.cells.Count, "Плотоядные");
                herbi.Text = controller.statistics.AmountCells(h, controller.cells.Count, "Травоядные");
                omni.Text = controller.statistics.AmountCells(o, controller.cells.Count, "Всеядные");
                IdCellLabel.Text = controller.statistics.LivingAncestors(controller.cells);      
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (controller.AmountOfCycles < SettingsGame.AmountOfCycles)
            {
                graphics.Clear(Color.WhiteSmoke);
                RefreshData();
                controller.Cycle(MaxWidthField, MaxHeightField);
                GameZonePictureBox.Refresh();
                if (controller.AmountOfCycles % SettingsGame.UpdateRate == 0 && controller.AmountOfCycles != 0)
                {
                    listsForCharts.AmountDeaths.Add(controller.AmountOfDeaths);
                    listsForCharts.AmountEvolution.Add(controller.AmountOfEvolution);
                    listsForCharts.AmountDivision.Add(controller.AmountOfDivision);
                    controller.AmountOfDeaths = 0;
                    controller.AmountOfEvolution = 0;
                    controller.AmountOfDivision = 0;
                }
                amountCycles.Text = $"Количество циклов: {controller.AmountOfCycles} из {SettingsGame.AmountOfCycles}";
            }
            else
            {
                timer1.Stop();
                StartGameButton.Enabled = true;
                SaveGameButton.Enabled = true;
                LoadGameButton.Enabled = true;
                NewGameButton.Enabled = true;
                PauseGameButton.Enabled = false;
                GetChart.Enabled = true;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                timer1.Interval = 500;
                SpeedOfGamesLabel.Text = "Speed of game: very low";
            }
            if (trackBar1.Value == 2)
            {
                timer1.Interval = 300;
                SpeedOfGamesLabel.Text = "Speed of game: low";
            }
            if (trackBar1.Value == 3)
            {
                timer1.Interval = 100;
                SpeedOfGamesLabel.Text = "Speed of game: medium";
            }
            if (trackBar1.Value == 4)
            {
                timer1.Interval = 50;
                SpeedOfGamesLabel.Text = "Speed of game: high";
            }
            if (trackBar1.Value == 5)
            {
                timer1.Interval = 10;
                SpeedOfGamesLabel.Text = "Speed of game: very high";
            }
        }
        private void NewImg(int SizeWidthMinus, int SizeHeightMinus)
        {
            graphics.Clear(Color.WhiteSmoke);
            MaxWidthField -= SizeWidthMinus;
            MaxHeightField -= SizeHeightMinus;
            GameZonePictureBox.Image = new Bitmap(MaxWidthField, MaxHeightField);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
        private void GetChart_Click(object sender, EventArgs e)
        {
            if (controller.AmountOfCycles != SettingsGame.AmountOfCycles)
            {
                Show("Необходимо дождаться конца симуляции!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form2 frm2 = new Form2(listsForCharts);
                frm2.Show();
            }
        }
    }
}
using SimulationOfLife.Logic.Controller;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Cell;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulationOfLife.View
{
    public partial class Form1 : Form
    {
        private static Controller controller = new Controller();
        private static Pen pen = new Pen(Color.Black, 1);
        private Graphics graphics;
        private int Tick;
        private int CountOfDivision = 0;
        public Form1()
        {
            InitializeComponent();
            StartGameButton.Enabled = false;
            PauseGameButton.Enabled = false;
            SaveGameButton.Enabled = false;
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.WhiteSmoke);
            timer1.Interval = 100;
        }
        private void RefreshData()
        {
            foreach (var cell in controller.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    graphics.FillEllipse(Brushes.Crimson, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
                    //graphics.DrawEllipse(pen, cell.X - (cell.Overview / 2), cell.Y - (cell.Overview / 2), cell.Overview, cell.Overview);
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                }
            }
            foreach (var f in controller.food)
            {
                graphics.FillRectangle(Brushes.Green, f.X, f.Y, f.Width, f.Height);
            }
        }
        private void CountCells()
        {
            double c = 0, h = 0, o = 0;
            for (int i = 0; i < controller.cells.Count; i++)
            {
                if (controller.cells[i] is CarnivorousLowCell || controller.cells[i] is CarnivorousMediumCell || controller.cells[i] is CarnivorousHighCell)
                {
                    c++;
                }
                if (controller.cells[i] is HerbivoreLowCell || controller.cells[i] is HerbivoreMediumCell || controller.cells[i] is HerbivoreHighCell)
                {
                    h++;
                }
                if (controller.cells[i] is OmnivoreLowCell || controller.cells[i] is OmnivoreMediumCell || controller.cells[i] is OmnivoreHighCell)
                {
                    o++;
                }
            }
            carni.Text = $"Плотоядные: {Math.Round(c / controller.cells.Count, 3) * 100}%";
            herbi.Text = $"Травоядные: {Math.Round(h / controller.cells.Count, 3) * 100}%";
            omni.Text = $"Всеядные: {Math.Round(o / controller.cells.Count, 3) * 100}%";
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            PauseGameButton.Enabled = true;
            SaveGameButton.Enabled = false;
            LoadGameButton.Enabled = false;
            NewGameButton.Enabled = false;
            StartGameButton.Enabled = false;
            timer1.Start();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            RefreshData();
            controller.AddFood(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Move(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Eating();
            controller.Evolution();
            var r = controller.Division();
            label1.Text = $"Количество клеток {controller.cells.Count} из {SettingsGame.CountOfCells}";
            if ((Tick % 2000) == 0)
            {
                CountCells();
            }
            if (r == true)
            {
                CountOfDivision++;
                CountOfDivisionLabel.Text = $"Количество делений: {CountOfDivision}";
            }
            Tick += timer1.Interval;
            GameZonePictureBox.Refresh();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                timer1.Interval = 100;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 2)
            {
                timer1.Interval = 75;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 3)
            {
                timer1.Interval = 50;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 4)
            {
                timer1.Interval = 25;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
        }
        private void GameZonePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.AddCellsThroughMouse(e.Location.X, e.Location.Y);
                    RefreshData();
                }
                if (e.Button == MouseButtons.Right)
                {
                    controller.AddEatThroughMouse(e.Location.X, e.Location.Y);
                    RefreshData();
                }
            }
        }
        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            controller.Serializable();
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            controller.DeSerializable();
            RefreshData();
            GameZonePictureBox.Refresh();
            StartGameButton.Enabled = true;
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            controller.StartNewGame();
            controller.AddFirstCells(SettingsGame.CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            RefreshData();
            GameZonePictureBox.Refresh();
            StartGameButton.Enabled = true;
        }
    }
}
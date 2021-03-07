using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorOfLive.View
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
            PauseGameButton.Enabled = false;
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            timer1.Interval = 500;
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
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                }
            }
            foreach (var e in controller.eat)
            {
                graphics.FillRectangle(Brushes.Green, e.X, e.Y, e.Width, e.Height);
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
                carni.Text = $"Плотоядные: {Math.Round(c / controller.cells.Count, 3) * 100}%";
                herbi.Text = $"Травоядные: {Math.Round(h / controller.cells.Count, 3) * 100}%";
                omni.Text = $"Всеядные: {Math.Round(o / controller.cells.Count, 3) * 100}%";
            }
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            PauseGameButton.Enabled = true;
            StartGameButton.Enabled = false;
            timer1.Start();
        }
        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGameButton.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.LightGray);
            RefreshData();
            controller.AddEat(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.MoveCells(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Run(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Eating(GameZonePictureBox.Width, GameZonePictureBox.Height);
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
                timer1.Interval = 500;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 2)
            {
                timer1.Interval = 200;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 3)
            {
                timer1.Interval = 100;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 4)
            {
                timer1.Interval = 10;
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
            controller.DeSerializable();
            graphics.Clear(Color.LightGray);
            RefreshData();
            GameZonePictureBox.Refresh();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.LightGray);
            controller.StartNewGame();
            controller.AddFirstCells(SettingsGame.CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            RefreshData();
            GameZonePictureBox.Refresh();
        }
    }
}
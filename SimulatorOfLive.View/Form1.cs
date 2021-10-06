using SimulationOfLife.Logic.Controller;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Cell;
using SimulatorOfLive.Logic.Controller;
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
        private Controller controller;
        private static int MaxWidthField { get; set; }
        private static int MaxHeightField { get; set; }
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            GameZonePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            MaxHeightField = GameZonePictureBox.Height;
            MaxWidthField = GameZonePictureBox.Width;
            StartGameButton.Enabled = false;
            PauseGameButton.Enabled = false;
            SaveGameButton.Enabled = false;
            OnShowingInformationRButton.Checked = true;
            GameZonePictureBox.Image = new Bitmap(MaxWidthField,MaxHeightField);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.WhiteSmoke);
            timer1.Interval = 500;
            GetChart.Enabled = false;
        }
        #region Кнопки
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
        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            var result = controller.Serializable();
            if (result == null)
            {
                //throw new Exception("Какое-то исключение");
                Show("Ошибка при сохранении игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Игра сохранена: {result}");
            }
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            controller = new Controller();
            var OpenFile = openFileDialog1;
            OpenFile.Filter = "Documents (*.xml)|*.xml"; 
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (controller.DeSerializable(OpenFile.FileName) == false)
                {
                    Show("Ошибка при загрузке игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    controller.DeSerializable(OpenFile.FileName);
                    graphics.Clear(Color.WhiteSmoke);
                    RefreshData();
                    GameZonePictureBox.Refresh();
                    StartGameButton.Enabled = true;
                }
            }
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            if (CheckOfConditions.Check() != true)
            {
                Show("Ошибка в условиях игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MaxHeightField = GameZonePictureBox.Height;
                MaxWidthField = GameZonePictureBox.Width;
                NewImg(0, 0);
                graphics.Clear(Color.WhiteSmoke);
                controller = new Controller();
                controller.AddFirstCells(SettingsGame.CountOfCells, MaxWidthField, MaxHeightField);
                RefreshData();
                GameZonePictureBox.Refresh();
                StartGameButton.Enabled = true;
                GetChart.Enabled = false;
            }
        }
        private void OnShowingInformationRButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }
        private void OffShowingInformationRButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
        #endregion
        private void RefreshData()
        {
            /*Красные границы вокруг поля, чтобы было видно, как оно уменьшается*/
            //graphics.DrawLine(pen, new Point(0, 0), new Point(0, MaxHeightField));
            //graphics.DrawLine(pen, new Point(0, MaxHeightField - 1), new Point(MaxWidthField, MaxHeightField - 1));
            //graphics.DrawLine(pen, new Point(MaxWidthField - 1, MaxHeightField), new Point(MaxWidthField - 1, 0));
            //graphics.DrawLine(pen, new Point(MaxWidthField - 1, 0), new Point(0, 0));
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
            #region Текстовая информация
            if (controller.AmountOfCycles % 50 == 0)
            {
                label1.Text = $"Количество клеток: {controller.cells.Count}";
                carni.Text = $"Плотоядные: {c} ({Math.Round(c / controller.cells.Count, 3) * 100}%) клеток";
                herbi.Text = $"Травоядные: {h} ({Math.Round(h / controller.cells.Count, 3) * 100}%) клеток";
                omni.Text = $"Всеядные: {o} ({Math.Round(o / controller.cells.Count, 3) * 100}%) клеток";
                IdCellLabel.Text = controller.CountingCells();      
            }
            #endregion
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (controller.AmountOfCycles < SettingsGame.AmountOfCycles)
            {
                graphics.Clear(Color.WhiteSmoke);
                RefreshData();
                controller.Cycle(MaxWidthField, MaxHeightField);
                GameZonePictureBox.Refresh();
                if (controller.AmountOfCycles % 50 == 0 && controller.AmountOfCycles != 0) // каждые 50 циклов в списки добавляются данные
                {
                    ListsForCharts.AmountDeaths.Add(controller.AmountOfDeaths);
                    ListsForCharts.AmountEvolution.Add(controller.AmountOfEvolution);
                    ListsForCharts.AmountDivision.Add(controller.AmountOfDivision);
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
                SettingsButton.Enabled = true;
                GetChart.Enabled = true;
            }
            /*изменение границ карты с определённой вероятностью (exp.)*/
            //if (SettingsGame.RndNumber(50) == 1)
            //{
            //    controller.IsInZone(MaxWidthField, MaxHeightField);
            //    NewImg(10, 5);
            //}
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
            //if (trackBar1.Value == 1)
            //{
            //    timer1.Interval = 100;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 2)
            //{
            //    timer1.Interval = 75;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 3)
            //{
            //    timer1.Interval = 50;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 4)
            //{
            //    timer1.Interval = 25;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
        }
        private void GameZonePictureBox_MouseClick(object sender, MouseEventArgs e) //exp
        {
            //if (timer1.Enabled)
            //{
            //    if (e.Button == MouseButtons.Left)
            //    {
            //        controller.AddCellsThroughMouse(e.Location.X, e.Location.Y);
            //        RefreshData();
            //    }
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        controller.AddEatThroughMouse(e.Location.X, e.Location.Y);
            //        RefreshData();
            //    }
            //}
        }
        private void NewImg(int SizeWidthMinus, int SizeHeightMinus)
        {
            graphics.Clear(Color.WhiteSmoke);
            MaxWidthField -= SizeWidthMinus;
            MaxHeightField -= SizeHeightMinus;
            GameZonePictureBox.Image = new Bitmap(MaxWidthField, MaxHeightField);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) //функция для вызова сообщений
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
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }
    }
}
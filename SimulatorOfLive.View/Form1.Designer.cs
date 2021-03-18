namespace SimulationOfLife.View
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PauseGameButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GameZonePictureBox = new System.Windows.Forms.PictureBox();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.carni = new System.Windows.Forms.Label();
            this.herbi = new System.Windows.Forms.Label();
            this.CountOfDivisionLabel = new System.Windows.Forms.Label();
            this.IdCellLabel = new System.Windows.Forms.Label();
            this.omni = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.SaveGameButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.SpeedOfGamesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameZonePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // PauseGameButton
            // 
            this.PauseGameButton.Location = new System.Drawing.Point(294, 12);
            this.PauseGameButton.Name = "PauseGameButton";
            this.PauseGameButton.Size = new System.Drawing.Size(80, 40);
            this.PauseGameButton.TabIndex = 3;
            this.PauseGameButton.Text = "Pause";
            this.PauseGameButton.UseVisualStyleBackColor = true;
            this.PauseGameButton.Click += new System.EventHandler(this.PauseGameButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(208, 12);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(80, 40);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.GameZonePictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.NewGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.LoadGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.SaveGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedOfGamesLabel);
            this.splitContainer1.Panel2.Controls.Add(this.PauseGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.StartGameButton);
            this.splitContainer1.Size = new System.Drawing.Size(1582, 853);
            this.splitContainer1.SplitterDistance = 696;
            this.splitContainer1.TabIndex = 4;
            // 
            // GameZonePictureBox
            // 
            this.GameZonePictureBox.BackColor = System.Drawing.Color.White;
            this.GameZonePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameZonePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GameZonePictureBox.Name = "GameZonePictureBox";
            this.GameZonePictureBox.Size = new System.Drawing.Size(1582, 696);
            this.GameZonePictureBox.TabIndex = 0;
            this.GameZonePictureBox.TabStop = false;
            this.GameZonePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameZonePictureBox_MouseClick);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(12, 12);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(130, 40);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "New game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.carni);
            this.groupBox1.Controls.Add(this.herbi);
            this.groupBox1.Controls.Add(this.CountOfDivisionLabel);
            this.groupBox1.Controls.Add(this.IdCellLabel);
            this.groupBox1.Controls.Add(this.omni);
            this.groupBox1.Location = new System.Drawing.Point(430, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 129);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "text";
            // 
            // carni
            // 
            this.carni.AutoSize = true;
            this.carni.Location = new System.Drawing.Point(6, 35);
            this.carni.Name = "carni";
            this.carni.Size = new System.Drawing.Size(30, 17);
            this.carni.TabIndex = 9;
            this.carni.Text = "text";
            // 
            // herbi
            // 
            this.herbi.AutoSize = true;
            this.herbi.Location = new System.Drawing.Point(6, 52);
            this.herbi.Name = "herbi";
            this.herbi.Size = new System.Drawing.Size(30, 17);
            this.herbi.TabIndex = 7;
            this.herbi.Text = "text";
            // 
            // CountOfDivisionLabel
            // 
            this.CountOfDivisionLabel.AutoSize = true;
            this.CountOfDivisionLabel.Location = new System.Drawing.Point(6, 103);
            this.CountOfDivisionLabel.Name = "CountOfDivisionLabel";
            this.CountOfDivisionLabel.Size = new System.Drawing.Size(87, 17);
            this.CountOfDivisionLabel.TabIndex = 10;
            this.CountOfDivisionLabel.Text = "text will soon";
            // 
            // IdCellLabel
            // 
            this.IdCellLabel.AutoSize = true;
            this.IdCellLabel.Location = new System.Drawing.Point(6, 86);
            this.IdCellLabel.Name = "IdCellLabel";
            this.IdCellLabel.Size = new System.Drawing.Size(87, 17);
            this.IdCellLabel.TabIndex = 11;
            this.IdCellLabel.Text = "text will soon";
            // 
            // omni
            // 
            this.omni.AutoSize = true;
            this.omni.Location = new System.Drawing.Point(6, 69);
            this.omni.Name = "omni";
            this.omni.Size = new System.Drawing.Size(30, 17);
            this.omni.TabIndex = 8;
            this.omni.Text = "text";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(12, 104);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(130, 40);
            this.LoadGameButton.TabIndex = 13;
            this.LoadGameButton.Text = "Load game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // SaveGameButton
            // 
            this.SaveGameButton.Location = new System.Drawing.Point(12, 58);
            this.SaveGameButton.Name = "SaveGameButton";
            this.SaveGameButton.Size = new System.Drawing.Size(130, 40);
            this.SaveGameButton.TabIndex = 12;
            this.SaveGameButton.Text = "Save game";
            this.SaveGameButton.UseVisualStyleBackColor = true;
            this.SaveGameButton.Click += new System.EventHandler(this.SaveGameButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(1230, 18);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(176, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // SpeedOfGamesLabel
            // 
            this.SpeedOfGamesLabel.AutoSize = true;
            this.SpeedOfGamesLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SpeedOfGamesLabel.Location = new System.Drawing.Point(1235, 77);
            this.SpeedOfGamesLabel.Name = "SpeedOfGamesLabel";
            this.SpeedOfGamesLabel.Size = new System.Drawing.Size(163, 17);
            this.SpeedOfGamesLabel.TabIndex = 4;
            this.SpeedOfGamesLabel.Text = "Speed of game: very low";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simulation of life";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameZonePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button PauseGameButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox GameZonePictureBox;
        private System.Windows.Forms.Label SpeedOfGamesLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label carni;
        private System.Windows.Forms.Label omni;
        private System.Windows.Forms.Label herbi;
        private System.Windows.Forms.Label CountOfDivisionLabel;
        private System.Windows.Forms.Label IdCellLabel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button SaveGameButton;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


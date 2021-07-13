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
            this.ShowingInformationLabel = new System.Windows.Forms.Label();
            this.OnShowingInformationRButton = new System.Windows.Forms.RadioButton();
            this.OffShowingInformationRButton = new System.Windows.Forms.RadioButton();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countingdeathspersomesecond = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.carni = new System.Windows.Forms.Label();
            this.herbi = new System.Windows.Forms.Label();
            this.IdCellLabel = new System.Windows.Forms.Label();
            this.omni = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.SaveGameButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.SpeedOfGamesLabel = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.PauseGameButton.Location = new System.Drawing.Point(270, 12);
            this.PauseGameButton.Name = "PauseGameButton";
            this.PauseGameButton.Size = new System.Drawing.Size(60, 40);
            this.PauseGameButton.TabIndex = 3;
            this.PauseGameButton.Text = "Pause";
            this.PauseGameButton.UseVisualStyleBackColor = true;
            this.PauseGameButton.Click += new System.EventHandler(this.PauseGameButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(200, 12);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(60, 40);
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
            this.splitContainer1.Panel2.Controls.Add(this.ShowingInformationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.OnShowingInformationRButton);
            this.splitContainer1.Panel2.Controls.Add(this.OffShowingInformationRButton);
            this.splitContainer1.Panel2.Controls.Add(this.SettingsButton);
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
            this.GameZonePictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GameZonePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameZonePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GameZonePictureBox.Name = "GameZonePictureBox";
            this.GameZonePictureBox.Size = new System.Drawing.Size(1582, 696);
            this.GameZonePictureBox.TabIndex = 0;
            this.GameZonePictureBox.TabStop = false;
            this.GameZonePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameZonePictureBox_MouseClick);
            // 
            // ShowingInformationLabel
            // 
            this.ShowingInformationLabel.AutoSize = true;
            this.ShowingInformationLabel.Location = new System.Drawing.Point(1139, 24);
            this.ShowingInformationLabel.Name = "ShowingInformationLabel";
            this.ShowingInformationLabel.Size = new System.Drawing.Size(135, 17);
            this.ShowingInformationLabel.TabIndex = 19;
            this.ShowingInformationLabel.Text = "Showing information";
            // 
            // OnShowingInformationRButton
            // 
            this.OnShowingInformationRButton.AutoSize = true;
            this.OnShowingInformationRButton.Location = new System.Drawing.Point(1142, 58);
            this.OnShowingInformationRButton.Name = "OnShowingInformationRButton";
            this.OnShowingInformationRButton.Size = new System.Drawing.Size(48, 21);
            this.OnShowingInformationRButton.TabIndex = 18;
            this.OnShowingInformationRButton.TabStop = true;
            this.OnShowingInformationRButton.Text = "On";
            this.OnShowingInformationRButton.UseVisualStyleBackColor = true;
            this.OnShowingInformationRButton.CheckedChanged += new System.EventHandler(this.OnShowingInformationRButton_CheckedChanged);
            // 
            // OffShowingInformationRButton
            // 
            this.OffShowingInformationRButton.AutoSize = true;
            this.OffShowingInformationRButton.Location = new System.Drawing.Point(1226, 58);
            this.OffShowingInformationRButton.Name = "OffShowingInformationRButton";
            this.OffShowingInformationRButton.Size = new System.Drawing.Size(48, 21);
            this.OffShowingInformationRButton.TabIndex = 17;
            this.OffShowingInformationRButton.TabStop = true;
            this.OffShowingInformationRButton.Text = "Off";
            this.OffShowingInformationRButton.UseVisualStyleBackColor = true;
            this.OffShowingInformationRButton.CheckedChanged += new System.EventHandler(this.OffShowingInformationRButton_CheckedChanged);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsButton.Location = new System.Drawing.Point(200, 58);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(130, 40);
            this.SettingsButton.TabIndex = 16;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.countingdeathspersomesecond);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.carni);
            this.groupBox1.Controls.Add(this.herbi);
            this.groupBox1.Controls.Add(this.IdCellLabel);
            this.groupBox1.Controls.Add(this.omni);
            this.groupBox1.Location = new System.Drawing.Point(387, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 129);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // countingdeathspersomesecond
            // 
            this.countingdeathspersomesecond.AutoSize = true;
            this.countingdeathspersomesecond.Location = new System.Drawing.Point(9, 106);
            this.countingdeathspersomesecond.Name = "countingdeathspersomesecond";
            this.countingdeathspersomesecond.Size = new System.Drawing.Size(30, 17);
            this.countingdeathspersomesecond.TabIndex = 12;
            this.countingdeathspersomesecond.Text = "text";
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
            this.trackBar1.Location = new System.Drawing.Point(1308, 18);
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
            this.SpeedOfGamesLabel.Location = new System.Drawing.Point(1318, 77);
            this.SpeedOfGamesLabel.Name = "SpeedOfGamesLabel";
            this.SpeedOfGamesLabel.Size = new System.Drawing.Size(163, 17);
            this.SpeedOfGamesLabel.TabIndex = 4;
            this.SpeedOfGamesLabel.Text = "Speed of game: very low";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
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
        private System.Windows.Forms.Label IdCellLabel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button SaveGameButton;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Label ShowingInformationLabel;
        private System.Windows.Forms.RadioButton OnShowingInformationRButton;
        private System.Windows.Forms.RadioButton OffShowingInformationRButton;
        private System.Windows.Forms.Label countingdeathspersomesecond;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


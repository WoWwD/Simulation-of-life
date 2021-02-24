
namespace SimulatorOfLive.View
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
            this.ResetGameButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GameZonePictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.SpeedOfGamesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameZonePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // PauseGameButton
            // 
            this.PauseGameButton.Location = new System.Drawing.Point(98, 17);
            this.PauseGameButton.Name = "PauseGameButton";
            this.PauseGameButton.Size = new System.Drawing.Size(80, 40);
            this.PauseGameButton.TabIndex = 3;
            this.PauseGameButton.Text = "Pause";
            this.PauseGameButton.UseVisualStyleBackColor = true;
            this.PauseGameButton.Click += new System.EventHandler(this.PauseGameButton_Click);
            // 
            // ResetGameButton
            // 
            this.ResetGameButton.Location = new System.Drawing.Point(184, 17);
            this.ResetGameButton.Name = "ResetGameButton";
            this.ResetGameButton.Size = new System.Drawing.Size(80, 40);
            this.ResetGameButton.TabIndex = 2;
            this.ResetGameButton.Text = "Reset";
            this.ResetGameButton.UseVisualStyleBackColor = true;
            this.ResetGameButton.Click += new System.EventHandler(this.ResetGameButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(12, 17);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(80, 40);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
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
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedOfGamesLabel);
            this.splitContainer1.Panel2.Controls.Add(this.ResetGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.StartGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.PauseGameButton);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 673);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 4;
            // 
            // GameZonePictureBox
            // 
            this.GameZonePictureBox.BackColor = System.Drawing.Color.White;
            this.GameZonePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameZonePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GameZonePictureBox.Name = "GameZonePictureBox";
            this.GameZonePictureBox.Size = new System.Drawing.Size(1262, 550);
            this.GameZonePictureBox.TabIndex = 0;
            this.GameZonePictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Вышло за границу: 0 из 0 ";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1058, 17);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(176, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // SpeedOfGamesLabel
            // 
            this.SpeedOfGamesLabel.AutoSize = true;
            this.SpeedOfGamesLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SpeedOfGamesLabel.Location = new System.Drawing.Point(1087, 76);
            this.SpeedOfGamesLabel.Name = "SpeedOfGamesLabel";
            this.SpeedOfGamesLabel.Size = new System.Drawing.Size(126, 17);
            this.SpeedOfGamesLabel.TabIndex = 4;
            this.SpeedOfGamesLabel.Text = "Скорость игры: 1x";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simulator of live";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameZonePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button ResetGameButton;
        private System.Windows.Forms.Button PauseGameButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox GameZonePictureBox;
        private System.Windows.Forms.Label SpeedOfGamesLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
    }
}


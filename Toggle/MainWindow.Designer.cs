namespace Toggle
{
    partial class MainWindow
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.BassTrackBar = new System.Windows.Forms.TrackBar();
            this.MiddleTrackBar = new System.Windows.Forms.TrackBar();
            this.TrebleTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BassPitchIntencity = new System.Windows.Forms.Label();
            this.MiddlePitchIntencity = new System.Windows.Forms.Label();
            this.TreblePitchIntencity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BassTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrebleTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartBtn.Location = new System.Drawing.Point(455, 40);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 63);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopBtn.Location = new System.Drawing.Point(455, 120);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 63);
            this.StopBtn.TabIndex = 1;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // BassTrackBar
            // 
            this.BassTrackBar.Location = new System.Drawing.Point(69, 40);
            this.BassTrackBar.Maximum = 20;
            this.BassTrackBar.Minimum = 5;
            this.BassTrackBar.Name = "BassTrackBar";
            this.BassTrackBar.Size = new System.Drawing.Size(380, 45);
            this.BassTrackBar.TabIndex = 2;
            this.BassTrackBar.Value = 10;
            this.BassTrackBar.Scroll += new System.EventHandler(this.Bass_Scroll);
            // 
            // MiddleTrackBar
            // 
            this.MiddleTrackBar.Location = new System.Drawing.Point(69, 91);
            this.MiddleTrackBar.Maximum = 20;
            this.MiddleTrackBar.Minimum = 5;
            this.MiddleTrackBar.Name = "MiddleTrackBar";
            this.MiddleTrackBar.Size = new System.Drawing.Size(380, 45);
            this.MiddleTrackBar.TabIndex = 3;
            this.MiddleTrackBar.Value = 10;
            this.MiddleTrackBar.Scroll += new System.EventHandler(this.Middle_Scroll);
            // 
            // TrebleTrackBar
            // 
            this.TrebleTrackBar.Location = new System.Drawing.Point(69, 142);
            this.TrebleTrackBar.Maximum = 20;
            this.TrebleTrackBar.Minimum = 5;
            this.TrebleTrackBar.Name = "TrebleTrackBar";
            this.TrebleTrackBar.Size = new System.Drawing.Size(380, 45);
            this.TrebleTrackBar.TabIndex = 4;
            this.TrebleTrackBar.Value = 10;
            this.TrebleTrackBar.Scroll += new System.EventHandler(this.Treble_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pitch Effect";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bass";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 46);
            this.label3.TabIndex = 7;
            this.label3.Text = "Middle";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 46);
            this.label4.TabIndex = 8;
            this.label4.Text = "Treble";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BassPitchIntencity
            // 
            this.BassPitchIntencity.Location = new System.Drawing.Point(73, 71);
            this.BassPitchIntencity.Name = "BassPitchIntencity";
            this.BassPitchIntencity.Size = new System.Drawing.Size(376, 15);
            this.BassPitchIntencity.TabIndex = 9;
            this.BassPitchIntencity.Text = "1";
            this.BassPitchIntencity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiddlePitchIntencity
            // 
            this.MiddlePitchIntencity.Location = new System.Drawing.Point(73, 121);
            this.MiddlePitchIntencity.Name = "MiddlePitchIntencity";
            this.MiddlePitchIntencity.Size = new System.Drawing.Size(376, 15);
            this.MiddlePitchIntencity.TabIndex = 10;
            this.MiddlePitchIntencity.Text = "1";
            this.MiddlePitchIntencity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreblePitchIntencity
            // 
            this.TreblePitchIntencity.Location = new System.Drawing.Point(73, 168);
            this.TreblePitchIntencity.Name = "TreblePitchIntencity";
            this.TreblePitchIntencity.Size = new System.Drawing.Size(376, 15);
            this.TreblePitchIntencity.TabIndex = 11;
            this.TreblePitchIntencity.Text = "1";
            this.TreblePitchIntencity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 195);
            this.Controls.Add(this.TreblePitchIntencity);
            this.Controls.Add(this.MiddlePitchIntencity);
            this.Controls.Add(this.BassPitchIntencity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrebleTrackBar);
            this.Controls.Add(this.MiddleTrackBar);
            this.Controls.Add(this.BassTrackBar);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Toggle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.BassTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrebleTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TrackBar BassTrackBar;
        private System.Windows.Forms.TrackBar MiddleTrackBar;
        private System.Windows.Forms.TrackBar TrebleTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BassPitchIntencity;
        private System.Windows.Forms.Label MiddlePitchIntencity;
        private System.Windows.Forms.Label TreblePitchIntencity;
    }
}


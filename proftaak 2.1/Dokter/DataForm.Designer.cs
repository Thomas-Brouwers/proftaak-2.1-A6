namespace Dokter
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.SpeedLB = new System.Windows.Forms.Label();
            this.SpeedTextLB = new System.Windows.Forms.Label();
            this.SpeedPN = new System.Windows.Forms.Panel();
            this.DistanceLB = new System.Windows.Forms.Label();
            this.DistanceTextLB = new System.Windows.Forms.Label();
            this.DistancePN = new System.Windows.Forms.Panel();
            this.PulseLB = new System.Windows.Forms.Label();
            this.PulseTextLB = new System.Windows.Forms.Label();
            this.PulsePN = new System.Windows.Forms.Panel();
            this.RPMLB = new System.Windows.Forms.Label();
            this.RPMTextLB = new System.Windows.Forms.Label();
            this.RPMPN = new System.Windows.Forms.Panel();
            this.ElapsedTimeLB = new System.Windows.Forms.Label();
            this.ElepsedTimeTextLB = new System.Windows.Forms.Label();
            this.TimePN = new System.Windows.Forms.Panel();
            this.EnergyLB = new System.Windows.Forms.Label();
            this.EnergyTextLB = new System.Windows.Forms.Label();
            this.EnergyPN = new System.Windows.Forms.Panel();
            this.RequestedPowerLB = new System.Windows.Forms.Label();
            this.RequestedPowerTextLB = new System.Windows.Forms.Label();
            this.RequestedPowerPN = new System.Windows.Forms.Panel();
            this.ActualPowerLB = new System.Windows.Forms.Label();
            this.ActualPowerTextLB = new System.Windows.Forms.Label();
            this.ActualPowerPN = new System.Windows.Forms.Panel();
            this.SpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EmergencyBreakBT = new System.Windows.Forms.Button();
            this.PowerPN = new System.Windows.Forms.Panel();
            this.PowerDownBT = new System.Windows.Forms.Button();
            this.PowerUpBT = new System.Windows.Forms.Button();
            this.PowerLN = new System.Windows.Forms.Label();
            this.ChatBT = new System.Windows.Forms.Button();
            this.SessionStartBT = new System.Windows.Forms.Button();
            this.SessionStopBT = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SpeedPN.SuspendLayout();
            this.DistancePN.SuspendLayout();
            this.PulsePN.SuspendLayout();
            this.RPMPN.SuspendLayout();
            this.TimePN.SuspendLayout();
            this.EnergyPN.SuspendLayout();
            this.RequestedPowerPN.SuspendLayout();
            this.ActualPowerPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).BeginInit();
            this.PowerPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpeedLB
            // 
            this.SpeedLB.AutoSize = true;
            this.SpeedLB.Location = new System.Drawing.Point(118, 9);
            this.SpeedLB.Name = "SpeedLB";
            this.SpeedLB.Size = new System.Drawing.Size(13, 13);
            this.SpeedLB.TabIndex = 3;
            this.SpeedLB.Text = "0";
            // 
            // SpeedTextLB
            // 
            this.SpeedTextLB.AutoSize = true;
            this.SpeedTextLB.Location = new System.Drawing.Point(3, 9);
            this.SpeedTextLB.Name = "SpeedTextLB";
            this.SpeedTextLB.Size = new System.Drawing.Size(41, 13);
            this.SpeedTextLB.TabIndex = 2;
            this.SpeedTextLB.Text = "Speed:";
            // 
            // SpeedPN
            // 
            this.SpeedPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SpeedPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpeedPN.Controls.Add(this.SpeedTextLB);
            this.SpeedPN.Controls.Add(this.SpeedLB);
            this.SpeedPN.Location = new System.Drawing.Point(12, 48);
            this.SpeedPN.Name = "SpeedPN";
            this.SpeedPN.Size = new System.Drawing.Size(155, 32);
            this.SpeedPN.TabIndex = 4;
            // 
            // DistanceLB
            // 
            this.DistanceLB.AutoSize = true;
            this.DistanceLB.Location = new System.Drawing.Point(114, 9);
            this.DistanceLB.Name = "DistanceLB";
            this.DistanceLB.Size = new System.Drawing.Size(13, 13);
            this.DistanceLB.TabIndex = 3;
            this.DistanceLB.Text = "0";
            // 
            // DistanceTextLB
            // 
            this.DistanceTextLB.AutoSize = true;
            this.DistanceTextLB.Location = new System.Drawing.Point(3, 9);
            this.DistanceTextLB.Name = "DistanceTextLB";
            this.DistanceTextLB.Size = new System.Drawing.Size(52, 13);
            this.DistanceTextLB.TabIndex = 2;
            this.DistanceTextLB.Text = "Distance:";
            // 
            // DistancePN
            // 
            this.DistancePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DistancePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DistancePN.Controls.Add(this.DistanceTextLB);
            this.DistancePN.Controls.Add(this.DistanceLB);
            this.DistancePN.Location = new System.Drawing.Point(173, 48);
            this.DistancePN.Name = "DistancePN";
            this.DistancePN.Size = new System.Drawing.Size(155, 32);
            this.DistancePN.TabIndex = 5;
            // 
            // PulseLB
            // 
            this.PulseLB.AutoSize = true;
            this.PulseLB.Location = new System.Drawing.Point(106, 9);
            this.PulseLB.Name = "PulseLB";
            this.PulseLB.Size = new System.Drawing.Size(13, 13);
            this.PulseLB.TabIndex = 3;
            this.PulseLB.Text = "0";
            // 
            // PulseTextLB
            // 
            this.PulseTextLB.AutoSize = true;
            this.PulseTextLB.Location = new System.Drawing.Point(3, 9);
            this.PulseTextLB.Name = "PulseTextLB";
            this.PulseTextLB.Size = new System.Drawing.Size(36, 13);
            this.PulseTextLB.TabIndex = 2;
            this.PulseTextLB.Text = "Pulse:";
            // 
            // PulsePN
            // 
            this.PulsePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PulsePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PulsePN.Controls.Add(this.PulseTextLB);
            this.PulsePN.Controls.Add(this.PulseLB);
            this.PulsePN.Location = new System.Drawing.Point(334, 48);
            this.PulsePN.Name = "PulsePN";
            this.PulsePN.Size = new System.Drawing.Size(155, 32);
            this.PulsePN.TabIndex = 6;
            // 
            // RPMLB
            // 
            this.RPMLB.AutoSize = true;
            this.RPMLB.Location = new System.Drawing.Point(110, 9);
            this.RPMLB.Name = "RPMLB";
            this.RPMLB.Size = new System.Drawing.Size(13, 13);
            this.RPMLB.TabIndex = 3;
            this.RPMLB.Text = "0";
            // 
            // RPMTextLB
            // 
            this.RPMTextLB.AutoSize = true;
            this.RPMTextLB.Location = new System.Drawing.Point(3, 9);
            this.RPMTextLB.Name = "RPMTextLB";
            this.RPMTextLB.Size = new System.Drawing.Size(34, 13);
            this.RPMTextLB.TabIndex = 2;
            this.RPMTextLB.Text = "RPM:";
            // 
            // RPMPN
            // 
            this.RPMPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RPMPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPMPN.Controls.Add(this.RPMTextLB);
            this.RPMPN.Controls.Add(this.RPMLB);
            this.RPMPN.Location = new System.Drawing.Point(495, 48);
            this.RPMPN.Name = "RPMPN";
            this.RPMPN.Size = new System.Drawing.Size(155, 32);
            this.RPMPN.TabIndex = 7;
            // 
            // ElapsedTimeLB
            // 
            this.ElapsedTimeLB.AutoSize = true;
            this.ElapsedTimeLB.Location = new System.Drawing.Point(118, 9);
            this.ElapsedTimeLB.Name = "ElapsedTimeLB";
            this.ElapsedTimeLB.Size = new System.Drawing.Size(13, 13);
            this.ElapsedTimeLB.TabIndex = 3;
            this.ElapsedTimeLB.Text = "0";
            // 
            // ElepsedTimeTextLB
            // 
            this.ElepsedTimeTextLB.AutoSize = true;
            this.ElepsedTimeTextLB.Location = new System.Drawing.Point(3, 9);
            this.ElepsedTimeTextLB.Name = "ElepsedTimeTextLB";
            this.ElepsedTimeTextLB.Size = new System.Drawing.Size(74, 13);
            this.ElepsedTimeTextLB.TabIndex = 2;
            this.ElepsedTimeTextLB.Text = "Elapsed Time:";
            // 
            // TimePN
            // 
            this.TimePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TimePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimePN.Controls.Add(this.ElepsedTimeTextLB);
            this.TimePN.Controls.Add(this.ElapsedTimeLB);
            this.TimePN.Location = new System.Drawing.Point(12, 86);
            this.TimePN.Name = "TimePN";
            this.TimePN.Size = new System.Drawing.Size(155, 32);
            this.TimePN.TabIndex = 8;
            // 
            // EnergyLB
            // 
            this.EnergyLB.AutoSize = true;
            this.EnergyLB.Location = new System.Drawing.Point(114, 9);
            this.EnergyLB.Name = "EnergyLB";
            this.EnergyLB.Size = new System.Drawing.Size(13, 13);
            this.EnergyLB.TabIndex = 3;
            this.EnergyLB.Text = "0";
            // 
            // EnergyTextLB
            // 
            this.EnergyTextLB.AutoSize = true;
            this.EnergyTextLB.Location = new System.Drawing.Point(3, 9);
            this.EnergyTextLB.Name = "EnergyTextLB";
            this.EnergyTextLB.Size = new System.Drawing.Size(43, 13);
            this.EnergyTextLB.TabIndex = 2;
            this.EnergyTextLB.Text = "Energy:";
            // 
            // EnergyPN
            // 
            this.EnergyPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EnergyPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnergyPN.Controls.Add(this.EnergyTextLB);
            this.EnergyPN.Controls.Add(this.EnergyLB);
            this.EnergyPN.Location = new System.Drawing.Point(173, 86);
            this.EnergyPN.Name = "EnergyPN";
            this.EnergyPN.Size = new System.Drawing.Size(155, 32);
            this.EnergyPN.TabIndex = 9;
            // 
            // RequestedPowerLB
            // 
            this.RequestedPowerLB.AutoSize = true;
            this.RequestedPowerLB.Location = new System.Drawing.Point(106, 9);
            this.RequestedPowerLB.Name = "RequestedPowerLB";
            this.RequestedPowerLB.Size = new System.Drawing.Size(13, 13);
            this.RequestedPowerLB.TabIndex = 3;
            this.RequestedPowerLB.Text = "0";
            // 
            // RequestedPowerTextLB
            // 
            this.RequestedPowerTextLB.AutoSize = true;
            this.RequestedPowerTextLB.Location = new System.Drawing.Point(3, 9);
            this.RequestedPowerTextLB.Name = "RequestedPowerTextLB";
            this.RequestedPowerTextLB.Size = new System.Drawing.Size(92, 13);
            this.RequestedPowerTextLB.TabIndex = 2;
            this.RequestedPowerTextLB.Text = "RequestedPower:";
            // 
            // RequestedPowerPN
            // 
            this.RequestedPowerPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RequestedPowerPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestedPowerPN.Controls.Add(this.RequestedPowerTextLB);
            this.RequestedPowerPN.Controls.Add(this.RequestedPowerLB);
            this.RequestedPowerPN.Location = new System.Drawing.Point(334, 86);
            this.RequestedPowerPN.Name = "RequestedPowerPN";
            this.RequestedPowerPN.Size = new System.Drawing.Size(156, 32);
            this.RequestedPowerPN.TabIndex = 10;
            // 
            // ActualPowerLB
            // 
            this.ActualPowerLB.AutoSize = true;
            this.ActualPowerLB.Location = new System.Drawing.Point(110, 9);
            this.ActualPowerLB.Name = "ActualPowerLB";
            this.ActualPowerLB.Size = new System.Drawing.Size(13, 13);
            this.ActualPowerLB.TabIndex = 3;
            this.ActualPowerLB.Text = "0";
            // 
            // ActualPowerTextLB
            // 
            this.ActualPowerTextLB.AutoSize = true;
            this.ActualPowerTextLB.Location = new System.Drawing.Point(3, 9);
            this.ActualPowerTextLB.Name = "ActualPowerTextLB";
            this.ActualPowerTextLB.Size = new System.Drawing.Size(73, 13);
            this.ActualPowerTextLB.TabIndex = 2;
            this.ActualPowerTextLB.Text = "Actual Power:";
            // 
            // ActualPowerPN
            // 
            this.ActualPowerPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ActualPowerPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActualPowerPN.Controls.Add(this.ActualPowerTextLB);
            this.ActualPowerPN.Controls.Add(this.ActualPowerLB);
            this.ActualPowerPN.Location = new System.Drawing.Point(495, 86);
            this.ActualPowerPN.Name = "ActualPowerPN";
            this.ActualPowerPN.Size = new System.Drawing.Size(156, 32);
            this.ActualPowerPN.TabIndex = 11;
            // 
            // SpeedChart
            // 
            this.SpeedChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SpeedChart.BorderlineColor = System.Drawing.Color.Black;
            this.SpeedChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.SpeedChart.ChartAreas.Add(chartArea1);
            this.SpeedChart.Location = new System.Drawing.Point(12, 136);
            this.SpeedChart.Name = "SpeedChart";
            this.SpeedChart.Size = new System.Drawing.Size(639, 191);
            this.SpeedChart.TabIndex = 12;
            this.SpeedChart.Text = "chart1";
            // 
            // EmergencyBreakBT
            // 
            this.EmergencyBreakBT.BackColor = System.Drawing.Color.Red;
            this.EmergencyBreakBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmergencyBreakBT.ForeColor = System.Drawing.Color.White;
            this.EmergencyBreakBT.Location = new System.Drawing.Point(15, 355);
            this.EmergencyBreakBT.Name = "EmergencyBreakBT";
            this.EmergencyBreakBT.Size = new System.Drawing.Size(101, 37);
            this.EmergencyBreakBT.TabIndex = 13;
            this.EmergencyBreakBT.Text = "Noodstop";
            this.EmergencyBreakBT.UseVisualStyleBackColor = false;
            this.EmergencyBreakBT.Click += new System.EventHandler(this.EmergencyBreakBT_Click);
            // 
            // PowerPN
            // 
            this.PowerPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PowerPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PowerPN.Controls.Add(this.PowerDownBT);
            this.PowerPN.Controls.Add(this.PowerUpBT);
            this.PowerPN.Controls.Add(this.PowerLN);
            this.PowerPN.Location = new System.Drawing.Point(122, 412);
            this.PowerPN.Name = "PowerPN";
            this.PowerPN.Size = new System.Drawing.Size(422, 110);
            this.PowerPN.TabIndex = 19;
            // 
            // PowerDownBT
            // 
            this.PowerDownBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PowerDownBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PowerDownBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerDownBT.Location = new System.Drawing.Point(294, 33);
            this.PowerDownBT.Name = "PowerDownBT";
            this.PowerDownBT.Size = new System.Drawing.Size(108, 39);
            this.PowerDownBT.TabIndex = 20;
            this.PowerDownBT.Text = "DOWN   -";
            this.PowerDownBT.UseVisualStyleBackColor = false;
            this.PowerDownBT.Click += new System.EventHandler(this.PowerDownBT_Click);
            // 
            // PowerUpBT
            // 
            this.PowerUpBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PowerUpBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PowerUpBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerUpBT.Location = new System.Drawing.Point(36, 33);
            this.PowerUpBT.Name = "PowerUpBT";
            this.PowerUpBT.Size = new System.Drawing.Size(108, 39);
            this.PowerUpBT.TabIndex = 19;
            this.PowerUpBT.Text = "UP   +";
            this.PowerUpBT.UseVisualStyleBackColor = false;
            this.PowerUpBT.Click += new System.EventHandler(this.PowerUpBT_Click);
            // 
            // PowerLN
            // 
            this.PowerLN.AutoSize = true;
            this.PowerLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerLN.Location = new System.Drawing.Point(162, 33);
            this.PowerLN.Name = "PowerLN";
            this.PowerLN.Size = new System.Drawing.Size(114, 39);
            this.PowerLN.TabIndex = 0;
            this.PowerLN.Text = "Power";
            // 
            // ChatBT
            // 
            this.ChatBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ChatBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChatBT.Location = new System.Drawing.Point(12, 5);
            this.ChatBT.Name = "ChatBT";
            this.ChatBT.Size = new System.Drawing.Size(72, 37);
            this.ChatBT.TabIndex = 20;
            this.ChatBT.Text = "chat";
            this.ChatBT.UseVisualStyleBackColor = false;
            this.ChatBT.Click += new System.EventHandler(this.ChatBT_Click);
            // 
            // SessionStartBT
            // 
            this.SessionStartBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SessionStartBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SessionStartBT.Location = new System.Drawing.Point(159, 5);
            this.SessionStartBT.Name = "SessionStartBT";
            this.SessionStartBT.Size = new System.Drawing.Size(155, 37);
            this.SessionStartBT.TabIndex = 21;
            this.SessionStartBT.Text = "start sessie";
            this.SessionStartBT.UseVisualStyleBackColor = false;
            this.SessionStartBT.Click += new System.EventHandler(this.SessionStartBT_Click);
            // 
            // SessionStopBT
            // 
            this.SessionStopBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SessionStopBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SessionStopBT.Location = new System.Drawing.Point(416, 5);
            this.SessionStopBT.Name = "SessionStopBT";
            this.SessionStopBT.Size = new System.Drawing.Size(156, 37);
            this.SessionStopBT.TabIndex = 22;
            this.SessionStopBT.Text = "stop sessie";
            this.SessionStopBT.UseVisualStyleBackColor = false;
            this.SessionStopBT.Click += new System.EventHandler(this.SessionStopBT_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(658, 529);
            this.Controls.Add(this.SessionStopBT);
            this.Controls.Add(this.SessionStartBT);
            this.Controls.Add(this.ChatBT);
            this.Controls.Add(this.PowerPN);
            this.Controls.Add(this.EmergencyBreakBT);
            this.Controls.Add(this.SpeedChart);
            this.Controls.Add(this.ActualPowerPN);
            this.Controls.Add(this.RequestedPowerPN);
            this.Controls.Add(this.EnergyPN);
            this.Controls.Add(this.TimePN);
            this.Controls.Add(this.RPMPN);
            this.Controls.Add(this.PulsePN);
            this.Controls.Add(this.DistancePN);
            this.Controls.Add(this.SpeedPN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataForm";
            this.Text = "Monitor";
            this.SpeedPN.ResumeLayout(false);
            this.SpeedPN.PerformLayout();
            this.DistancePN.ResumeLayout(false);
            this.DistancePN.PerformLayout();
            this.PulsePN.ResumeLayout(false);
            this.PulsePN.PerformLayout();
            this.RPMPN.ResumeLayout(false);
            this.RPMPN.PerformLayout();
            this.TimePN.ResumeLayout(false);
            this.TimePN.PerformLayout();
            this.EnergyPN.ResumeLayout(false);
            this.EnergyPN.PerformLayout();
            this.RequestedPowerPN.ResumeLayout(false);
            this.RequestedPowerPN.PerformLayout();
            this.ActualPowerPN.ResumeLayout(false);
            this.ActualPowerPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).EndInit();
            this.PowerPN.ResumeLayout(false);
            this.PowerPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label SpeedLB;
        private System.Windows.Forms.Label SpeedTextLB;
        private System.Windows.Forms.Panel SpeedPN;
        private System.Windows.Forms.Label DistanceLB;
        private System.Windows.Forms.Label DistanceTextLB;
        private System.Windows.Forms.Panel DistancePN;
        private System.Windows.Forms.Label PulseLB;
        private System.Windows.Forms.Label PulseTextLB;
        private System.Windows.Forms.Panel PulsePN;
        private System.Windows.Forms.Label RPMLB;
        private System.Windows.Forms.Label RPMTextLB;
        private System.Windows.Forms.Panel RPMPN;
        private System.Windows.Forms.Label ElapsedTimeLB;
        private System.Windows.Forms.Label ElepsedTimeTextLB;
        private System.Windows.Forms.Panel TimePN;
        private System.Windows.Forms.Label EnergyLB;
        private System.Windows.Forms.Label EnergyTextLB;
        private System.Windows.Forms.Panel EnergyPN;
        private System.Windows.Forms.Label RequestedPowerLB;
        private System.Windows.Forms.Label RequestedPowerTextLB;
        private System.Windows.Forms.Panel RequestedPowerPN;
        private System.Windows.Forms.Label ActualPowerLB;
        private System.Windows.Forms.Label ActualPowerTextLB;
        private System.Windows.Forms.Panel ActualPowerPN;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpeedChart;
        private System.Windows.Forms.Button EmergencyBreakBT;
        private System.Windows.Forms.Panel PowerPN;
        private System.Windows.Forms.Label PowerLN;
        private System.Windows.Forms.Button PowerDownBT;
        private System.Windows.Forms.Button PowerUpBT;
        private System.Windows.Forms.Button ChatBT;
        private System.Windows.Forms.Button SessionStartBT;
        private System.Windows.Forms.Button SessionStopBT;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


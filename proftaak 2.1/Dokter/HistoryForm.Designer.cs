namespace Dokter
{
    partial class HistoryForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.button1 = new System.Windows.Forms.Button();
            this.HistroyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ActualPowerPN = new System.Windows.Forms.Panel();
            this.ActualPowerTextLB = new System.Windows.Forms.Label();
            this.ActualPowerLB = new System.Windows.Forms.Label();
            this.RequestedPowerPN = new System.Windows.Forms.Panel();
            this.RequestedPowerTextLB = new System.Windows.Forms.Label();
            this.RequestedPowerLB = new System.Windows.Forms.Label();
            this.EnergyPN = new System.Windows.Forms.Panel();
            this.EnergyTextLB = new System.Windows.Forms.Label();
            this.EnergyLB = new System.Windows.Forms.Label();
            this.ElapsedTimePN = new System.Windows.Forms.Panel();
            this.ElepsedTimeTextLB = new System.Windows.Forms.Label();
            this.ElepsedTimeLB = new System.Windows.Forms.Label();
            this.RPMPN = new System.Windows.Forms.Panel();
            this.RPMTextLB = new System.Windows.Forms.Label();
            this.RPMLB = new System.Windows.Forms.Label();
            this.PulsePN = new System.Windows.Forms.Panel();
            this.PulseTextLB = new System.Windows.Forms.Label();
            this.PulseLB = new System.Windows.Forms.Label();
            this.DistancePN = new System.Windows.Forms.Panel();
            this.DistanceTextLB = new System.Windows.Forms.Label();
            this.DistanceLB = new System.Windows.Forms.Label();
            this.SpeedPN = new System.Windows.Forms.Panel();
            this.SpeedTextLB = new System.Windows.Forms.Label();
            this.SpeedLB = new System.Windows.Forms.Label();
            this.dataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HistroyChart)).BeginInit();
            this.ActualPowerPN.SuspendLayout();
            this.RequestedPowerPN.SuspendLayout();
            this.EnergyPN.SuspendLayout();
            this.ElapsedTimePN.SuspendLayout();
            this.RPMPN.SuspendLayout();
            this.PulsePN.SuspendLayout();
            this.DistancePN.SuspendLayout();
            this.SpeedPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open file";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HistroyChart
            // 
            this.HistroyChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.HistroyChart.BorderlineColor = System.Drawing.Color.Black;
            this.HistroyChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.HistroyChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.HistroyChart.Legends.Add(legend1);
            this.HistroyChart.Location = new System.Drawing.Point(13, 166);
            this.HistroyChart.Name = "HistroyChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Pulse";
            this.HistroyChart.Series.Add(series1);
            this.HistroyChart.Size = new System.Drawing.Size(639, 191);
            this.HistroyChart.TabIndex = 21;
            this.HistroyChart.Text = "HistroyChart";
            // 
            // ActualPowerPN
            // 
            this.ActualPowerPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ActualPowerPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActualPowerPN.Controls.Add(this.ActualPowerTextLB);
            this.ActualPowerPN.Controls.Add(this.ActualPowerLB);
            this.ActualPowerPN.Location = new System.Drawing.Point(496, 116);
            this.ActualPowerPN.Name = "ActualPowerPN";
            this.ActualPowerPN.Size = new System.Drawing.Size(156, 32);
            this.ActualPowerPN.TabIndex = 20;
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
            // ActualPowerLB
            // 
            this.ActualPowerLB.AutoSize = true;
            this.ActualPowerLB.Location = new System.Drawing.Point(110, 9);
            this.ActualPowerLB.Name = "ActualPowerLB";
            this.ActualPowerLB.Size = new System.Drawing.Size(13, 13);
            this.ActualPowerLB.TabIndex = 3;
            this.ActualPowerLB.Text = "0";
            // 
            // RequestedPowerPN
            // 
            this.RequestedPowerPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RequestedPowerPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestedPowerPN.Controls.Add(this.RequestedPowerTextLB);
            this.RequestedPowerPN.Controls.Add(this.RequestedPowerLB);
            this.RequestedPowerPN.Location = new System.Drawing.Point(335, 116);
            this.RequestedPowerPN.Name = "RequestedPowerPN";
            this.RequestedPowerPN.Size = new System.Drawing.Size(156, 32);
            this.RequestedPowerPN.TabIndex = 19;
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
            // RequestedPowerLB
            // 
            this.RequestedPowerLB.AutoSize = true;
            this.RequestedPowerLB.Location = new System.Drawing.Point(106, 9);
            this.RequestedPowerLB.Name = "RequestedPowerLB";
            this.RequestedPowerLB.Size = new System.Drawing.Size(13, 13);
            this.RequestedPowerLB.TabIndex = 3;
            this.RequestedPowerLB.Text = "0";
            // 
            // EnergyPN
            // 
            this.EnergyPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EnergyPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnergyPN.Controls.Add(this.EnergyTextLB);
            this.EnergyPN.Controls.Add(this.EnergyLB);
            this.EnergyPN.Location = new System.Drawing.Point(174, 116);
            this.EnergyPN.Name = "EnergyPN";
            this.EnergyPN.Size = new System.Drawing.Size(155, 32);
            this.EnergyPN.TabIndex = 18;
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
            // EnergyLB
            // 
            this.EnergyLB.AutoSize = true;
            this.EnergyLB.Location = new System.Drawing.Point(114, 9);
            this.EnergyLB.Name = "EnergyLB";
            this.EnergyLB.Size = new System.Drawing.Size(13, 13);
            this.EnergyLB.TabIndex = 3;
            this.EnergyLB.Text = "0";
            // 
            // ElapsedTimePN
            // 
            this.ElapsedTimePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ElapsedTimePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElapsedTimePN.Controls.Add(this.ElepsedTimeTextLB);
            this.ElapsedTimePN.Controls.Add(this.ElepsedTimeLB);
            this.ElapsedTimePN.Location = new System.Drawing.Point(13, 116);
            this.ElapsedTimePN.Name = "ElapsedTimePN";
            this.ElapsedTimePN.Size = new System.Drawing.Size(155, 32);
            this.ElapsedTimePN.TabIndex = 17;
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
            // ElepsedTimeLB
            // 
            this.ElepsedTimeLB.AutoSize = true;
            this.ElepsedTimeLB.Location = new System.Drawing.Point(118, 9);
            this.ElepsedTimeLB.Name = "ElepsedTimeLB";
            this.ElepsedTimeLB.Size = new System.Drawing.Size(13, 13);
            this.ElepsedTimeLB.TabIndex = 3;
            this.ElepsedTimeLB.Text = "0";
            // 
            // RPMPN
            // 
            this.RPMPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RPMPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPMPN.Controls.Add(this.RPMTextLB);
            this.RPMPN.Controls.Add(this.RPMLB);
            this.RPMPN.Location = new System.Drawing.Point(496, 78);
            this.RPMPN.Name = "RPMPN";
            this.RPMPN.Size = new System.Drawing.Size(155, 32);
            this.RPMPN.TabIndex = 16;
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
            // RPMLB
            // 
            this.RPMLB.AutoSize = true;
            this.RPMLB.Location = new System.Drawing.Point(110, 9);
            this.RPMLB.Name = "RPMLB";
            this.RPMLB.Size = new System.Drawing.Size(13, 13);
            this.RPMLB.TabIndex = 3;
            this.RPMLB.Text = "0";
            // 
            // PulsePN
            // 
            this.PulsePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PulsePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PulsePN.Controls.Add(this.PulseTextLB);
            this.PulsePN.Controls.Add(this.PulseLB);
            this.PulsePN.Location = new System.Drawing.Point(335, 78);
            this.PulsePN.Name = "PulsePN";
            this.PulsePN.Size = new System.Drawing.Size(155, 32);
            this.PulsePN.TabIndex = 15;
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
            // PulseLB
            // 
            this.PulseLB.AutoSize = true;
            this.PulseLB.Location = new System.Drawing.Point(106, 9);
            this.PulseLB.Name = "PulseLB";
            this.PulseLB.Size = new System.Drawing.Size(13, 13);
            this.PulseLB.TabIndex = 3;
            this.PulseLB.Text = "0";
            // 
            // DistancePN
            // 
            this.DistancePN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DistancePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DistancePN.Controls.Add(this.DistanceTextLB);
            this.DistancePN.Controls.Add(this.DistanceLB);
            this.DistancePN.Location = new System.Drawing.Point(174, 78);
            this.DistancePN.Name = "DistancePN";
            this.DistancePN.Size = new System.Drawing.Size(155, 32);
            this.DistancePN.TabIndex = 14;
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
            // DistanceLB
            // 
            this.DistanceLB.AutoSize = true;
            this.DistanceLB.Location = new System.Drawing.Point(114, 9);
            this.DistanceLB.Name = "DistanceLB";
            this.DistanceLB.Size = new System.Drawing.Size(13, 13);
            this.DistanceLB.TabIndex = 3;
            this.DistanceLB.Text = "0";
            // 
            // SpeedPN
            // 
            this.SpeedPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SpeedPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpeedPN.Controls.Add(this.SpeedTextLB);
            this.SpeedPN.Controls.Add(this.SpeedLB);
            this.SpeedPN.Location = new System.Drawing.Point(13, 78);
            this.SpeedPN.Name = "SpeedPN";
            this.SpeedPN.Size = new System.Drawing.Size(155, 32);
            this.SpeedPN.TabIndex = 13;
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
            // SpeedLB
            // 
            this.SpeedLB.AutoSize = true;
            this.SpeedLB.Location = new System.Drawing.Point(118, 9);
            this.SpeedLB.Name = "SpeedLB";
            this.SpeedLB.Size = new System.Drawing.Size(13, 13);
            this.SpeedLB.TabIndex = 3;
            this.SpeedLB.Text = "0";
            // 
            // dataBindingSource1
            // 
            this.dataBindingSource1.DataSource = typeof(Dokter.Data);
            // 
            // dataBindingSource
            // 
            this.dataBindingSource.DataSource = typeof(Dokter.Data);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(679, 374);
            this.Controls.Add(this.HistroyChart);
            this.Controls.Add(this.ActualPowerPN);
            this.Controls.Add(this.RequestedPowerPN);
            this.Controls.Add(this.EnergyPN);
            this.Controls.Add(this.ElapsedTimePN);
            this.Controls.Add(this.RPMPN);
            this.Controls.Add(this.PulsePN);
            this.Controls.Add(this.DistancePN);
            this.Controls.Add(this.SpeedPN);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryForm";
            this.Text = "Overview";
            ((System.ComponentModel.ISupportInitialize)(this.HistroyChart)).EndInit();
            this.ActualPowerPN.ResumeLayout(false);
            this.ActualPowerPN.PerformLayout();
            this.RequestedPowerPN.ResumeLayout(false);
            this.RequestedPowerPN.PerformLayout();
            this.EnergyPN.ResumeLayout(false);
            this.EnergyPN.PerformLayout();
            this.ElapsedTimePN.ResumeLayout(false);
            this.ElapsedTimePN.PerformLayout();
            this.RPMPN.ResumeLayout(false);
            this.RPMPN.PerformLayout();
            this.PulsePN.ResumeLayout(false);
            this.PulsePN.PerformLayout();
            this.DistancePN.ResumeLayout(false);
            this.DistancePN.PerformLayout();
            this.SpeedPN.ResumeLayout(false);
            this.SpeedPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart HistroyChart;
        private System.Windows.Forms.Panel ActualPowerPN;
        private System.Windows.Forms.Label ActualPowerTextLB;
        private System.Windows.Forms.Label ActualPowerLB;
        private System.Windows.Forms.Panel RequestedPowerPN;
        private System.Windows.Forms.Label RequestedPowerTextLB;
        private System.Windows.Forms.Label RequestedPowerLB;
        private System.Windows.Forms.Panel EnergyPN;
        private System.Windows.Forms.Label EnergyTextLB;
        private System.Windows.Forms.Label EnergyLB;
        private System.Windows.Forms.Panel ElapsedTimePN;
        private System.Windows.Forms.Label ElepsedTimeTextLB;
        private System.Windows.Forms.Label ElepsedTimeLB;
        private System.Windows.Forms.Panel RPMPN;
        private System.Windows.Forms.Label RPMTextLB;
        private System.Windows.Forms.Label RPMLB;
        private System.Windows.Forms.Panel PulsePN;
        private System.Windows.Forms.Label PulseTextLB;
        private System.Windows.Forms.Label PulseLB;
        private System.Windows.Forms.Panel DistancePN;
        private System.Windows.Forms.Label DistanceTextLB;
        private System.Windows.Forms.Label DistanceLB;
        private System.Windows.Forms.Panel SpeedPN;
        private System.Windows.Forms.Label SpeedTextLB;
        private System.Windows.Forms.Label SpeedLB;
        private System.Windows.Forms.BindingSource dataBindingSource;
        private System.Windows.Forms.BindingSource dataBindingSource1;
    }
}
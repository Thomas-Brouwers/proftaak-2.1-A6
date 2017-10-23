namespace VRConnection
{
    partial class VRForm2
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
            this.SceneLV = new System.Windows.Forms.ListView();
            this.ConnectBT = new System.Windows.Forms.Button();
            this.ConnectCB = new System.Windows.Forms.ComboBox();
            this.FindTF = new System.Windows.Forms.TextBox();
            this.FindBT = new System.Windows.Forms.Button();
            this.TimeCB = new System.Windows.Forms.ComboBox();
            this.TimeBT = new System.Windows.Forms.Button();
            this.RefreshSceneBT = new System.Windows.Forms.Button();
            this.RefreshConnectionsBT = new System.Windows.Forms.Button();
            this.ItemLB = new System.Windows.Forms.Label();
            this.SaveBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SceneLV
            // 
            this.SceneLV.Location = new System.Drawing.Point(12, 12);
            this.SceneLV.Name = "SceneLV";
            this.SceneLV.Size = new System.Drawing.Size(193, 186);
            this.SceneLV.TabIndex = 0;
            this.SceneLV.UseCompatibleStateImageBehavior = false;
            this.SceneLV.SelectedIndexChanged += new System.EventHandler(this.SceneLV_SelectedIndexChanged);
            // 
            // ConnectBT
            // 
            this.ConnectBT.Location = new System.Drawing.Point(338, 10);
            this.ConnectBT.Name = "ConnectBT";
            this.ConnectBT.Size = new System.Drawing.Size(75, 23);
            this.ConnectBT.TabIndex = 2;
            this.ConnectBT.Text = "Connect";
            this.ConnectBT.UseVisualStyleBackColor = true;
            this.ConnectBT.Click += new System.EventHandler(this.ConnectBT_Click);
            // 
            // ConnectCB
            // 
            this.ConnectCB.FormattingEnabled = true;
            this.ConnectCB.Location = new System.Drawing.Point(211, 12);
            this.ConnectCB.Name = "ConnectCB";
            this.ConnectCB.Size = new System.Drawing.Size(121, 21);
            this.ConnectCB.TabIndex = 3;
            // 
            // FindTF
            // 
            this.FindTF.Location = new System.Drawing.Point(211, 95);
            this.FindTF.Name = "FindTF";
            this.FindTF.Size = new System.Drawing.Size(121, 20);
            this.FindTF.TabIndex = 4;
            // 
            // FindBT
            // 
            this.FindBT.Location = new System.Drawing.Point(338, 95);
            this.FindBT.Name = "FindBT";
            this.FindBT.Size = new System.Drawing.Size(75, 23);
            this.FindBT.TabIndex = 5;
            this.FindBT.Text = "Find";
            this.FindBT.UseVisualStyleBackColor = true;
            this.FindBT.Click += new System.EventHandler(this.FindBT_Click);
            // 
            // TimeCB
            // 
            this.TimeCB.FormattingEnabled = true;
            this.TimeCB.Location = new System.Drawing.Point(211, 68);
            this.TimeCB.Name = "TimeCB";
            this.TimeCB.Size = new System.Drawing.Size(121, 21);
            this.TimeCB.TabIndex = 6;
            // 
            // TimeBT
            // 
            this.TimeBT.Location = new System.Drawing.Point(338, 68);
            this.TimeBT.Name = "TimeBT";
            this.TimeBT.Size = new System.Drawing.Size(75, 23);
            this.TimeBT.TabIndex = 7;
            this.TimeBT.Text = "Select time";
            this.TimeBT.UseVisualStyleBackColor = true;
            this.TimeBT.Click += new System.EventHandler(this.TimeBT_Click);
            // 
            // RefreshSceneBT
            // 
            this.RefreshSceneBT.Location = new System.Drawing.Point(211, 121);
            this.RefreshSceneBT.Name = "RefreshSceneBT";
            this.RefreshSceneBT.Size = new System.Drawing.Size(202, 23);
            this.RefreshSceneBT.TabIndex = 8;
            this.RefreshSceneBT.Text = "Refresh scene";
            this.RefreshSceneBT.UseVisualStyleBackColor = true;
            this.RefreshSceneBT.Click += new System.EventHandler(this.RefreshSceneBT_Click);
            // 
            // RefreshConnectionsBT
            // 
            this.RefreshConnectionsBT.Location = new System.Drawing.Point(211, 39);
            this.RefreshConnectionsBT.Name = "RefreshConnectionsBT";
            this.RefreshConnectionsBT.Size = new System.Drawing.Size(202, 23);
            this.RefreshConnectionsBT.TabIndex = 9;
            this.RefreshConnectionsBT.Text = "Refresh connections";
            this.RefreshConnectionsBT.UseVisualStyleBackColor = true;
            this.RefreshConnectionsBT.Click += new System.EventHandler(this.RefreshConnectionsBT_Click);
            // 
            // ItemLB
            // 
            this.ItemLB.AutoSize = true;
            this.ItemLB.Location = new System.Drawing.Point(12, 201);
            this.ItemLB.Name = "ItemLB";
            this.ItemLB.Size = new System.Drawing.Size(88, 13);
            this.ItemLB.TabIndex = 10;
            this.ItemLB.Text = "boom shaka laka";
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(211, 150);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(75, 23);
            this.SaveBT.TabIndex = 11;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // VRForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 427);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.ItemLB);
            this.Controls.Add(this.RefreshConnectionsBT);
            this.Controls.Add(this.RefreshSceneBT);
            this.Controls.Add(this.TimeBT);
            this.Controls.Add(this.TimeCB);
            this.Controls.Add(this.FindBT);
            this.Controls.Add(this.FindTF);
            this.Controls.Add(this.ConnectCB);
            this.Controls.Add(this.ConnectBT);
            this.Controls.Add(this.SceneLV);
            this.Name = "VRForm2";
            this.Text = "VRForm2";
            this.Load += new System.EventHandler(this.VRForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView SceneLV;
        private System.Windows.Forms.Button ConnectBT;
        private System.Windows.Forms.ComboBox ConnectCB;
        private System.Windows.Forms.TextBox FindTF;
        private System.Windows.Forms.Button FindBT;
        private System.Windows.Forms.ComboBox TimeCB;
        private System.Windows.Forms.Button TimeBT;
        private System.Windows.Forms.Button RefreshSceneBT;
        private System.Windows.Forms.Button RefreshConnectionsBT;
        private System.Windows.Forms.Label ItemLB;
        private System.Windows.Forms.Button SaveBT;
    }
}
namespace VRconnection
{
    partial class Form2
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
            this.ConnectionsCB = new System.Windows.Forms.ComboBox();
            this.ConnectionsBT = new System.Windows.Forms.Button();
            this.TimeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeBT = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PlayBT = new System.Windows.Forms.Button();
            this.PaneBT = new System.Windows.Forms.Button();
            this.TreeBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectionsCB
            // 
            this.ConnectionsCB.FormattingEnabled = true;
            this.ConnectionsCB.Location = new System.Drawing.Point(70, 10);
            this.ConnectionsCB.Name = "ConnectionsCB";
            this.ConnectionsCB.Size = new System.Drawing.Size(121, 21);
            this.ConnectionsCB.TabIndex = 0;
            // 
            // ConnectionsBT
            // 
            this.ConnectionsBT.Location = new System.Drawing.Point(197, 10);
            this.ConnectionsBT.Name = "ConnectionsBT";
            this.ConnectionsBT.Size = new System.Drawing.Size(75, 23);
            this.ConnectionsBT.TabIndex = 1;
            this.ConnectionsBT.Text = "Select";
            this.ConnectionsBT.UseVisualStyleBackColor = true;
            this.ConnectionsBT.Click += new System.EventHandler(this.ConnectionsBT_Click);
            // 
            // TimeCB
            // 
            this.TimeCB.FormattingEnabled = true;
            this.TimeCB.Location = new System.Drawing.Point(70, 47);
            this.TimeCB.Name = "TimeCB";
            this.TimeCB.Size = new System.Drawing.Size(121, 21);
            this.TimeCB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time";
            // 
            // TimeBT
            // 
            this.TimeBT.Location = new System.Drawing.Point(197, 47);
            this.TimeBT.Name = "TimeBT";
            this.TimeBT.Size = new System.Drawing.Size(75, 23);
            this.TimeBT.TabIndex = 5;
            this.TimeBT.Text = "Set time";
            this.TimeBT.UseVisualStyleBackColor = true;
            this.TimeBT.Click += new System.EventHandler(this.TimeBT_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Update Sky";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlayBT
            // 
            this.PlayBT.Location = new System.Drawing.Point(116, 76);
            this.PlayBT.Name = "PlayBT";
            this.PlayBT.Size = new System.Drawing.Size(75, 23);
            this.PlayBT.TabIndex = 7;
            this.PlayBT.Text = "Play";
            this.PlayBT.UseVisualStyleBackColor = true;
            this.PlayBT.Click += new System.EventHandler(this.PlayBT_Click);
            // 
            // PaneBT
            // 
            this.PaneBT.Location = new System.Drawing.Point(15, 76);
            this.PaneBT.Name = "PaneBT";
            this.PaneBT.Size = new System.Drawing.Size(75, 23);
            this.PaneBT.TabIndex = 8;
            this.PaneBT.Text = "Pane";
            this.PaneBT.UseVisualStyleBackColor = true;
            this.PaneBT.Click += new System.EventHandler(this.PaneBT_Click);
            // 
            // TreeBT
            // 
            this.TreeBT.Location = new System.Drawing.Point(12, 105);
            this.TreeBT.Name = "TreeBT";
            this.TreeBT.Size = new System.Drawing.Size(75, 23);
            this.TreeBT.TabIndex = 9;
            this.TreeBT.Text = "Tree";
            this.TreeBT.UseVisualStyleBackColor = true;
            this.TreeBT.Click += new System.EventHandler(this.TreeBT_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TreeBT);
            this.Controls.Add(this.PaneBT);
            this.Controls.Add(this.PlayBT);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TimeBT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeCB);
            this.Controls.Add(this.ConnectionsBT);
            this.Controls.Add(this.ConnectionsCB);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ConnectionsCB;
        private System.Windows.Forms.Button ConnectionsBT;
        private System.Windows.Forms.ComboBox TimeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TimeBT;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button PlayBT;
        private System.Windows.Forms.Button PaneBT;
        private System.Windows.Forms.Button TreeBT;
    }
}
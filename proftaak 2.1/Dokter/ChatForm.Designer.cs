namespace Dokter
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.ChatInputTB = new System.Windows.Forms.TextBox();
            this.SendBt = new System.Windows.Forms.Button();
            this.ChatHistoryTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChatInputTB
            // 
            this.ChatInputTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatInputTB.Location = new System.Drawing.Point(13, 269);
            this.ChatInputTB.Multiline = true;
            this.ChatInputTB.Name = "ChatInputTB";
            this.ChatInputTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatInputTB.Size = new System.Drawing.Size(794, 74);
            this.ChatInputTB.TabIndex = 0;
            // 
            // SendBt
            // 
            this.SendBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SendBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBt.Location = new System.Drawing.Point(503, 399);
            this.SendBt.Name = "SendBt";
            this.SendBt.Size = new System.Drawing.Size(175, 49);
            this.SendBt.TabIndex = 2;
            this.SendBt.Text = "Send";
            this.SendBt.UseVisualStyleBackColor = false;
            this.SendBt.Click += new System.EventHandler(this.SendBt_Click);
            // 
            // ChatHistoryTB
            // 
            this.ChatHistoryTB.Location = new System.Drawing.Point(13, 13);
            this.ChatHistoryTB.Multiline = true;
            this.ChatHistoryTB.Name = "ChatHistoryTB";
            this.ChatHistoryTB.ReadOnly = true;
            this.ChatHistoryTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatHistoryTB.Size = new System.Drawing.Size(794, 250);
            this.ChatHistoryTB.TabIndex = 3;
            // 
            // Chat
            // 
            this.AcceptButton = this.SendBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(819, 510);
            this.Controls.Add(this.ChatHistoryTB);
            this.Controls.Add(this.SendBt);
            this.Controls.Add(this.ChatInputTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatInputTB;
        private System.Windows.Forms.Button SendBt;
        private System.Windows.Forms.TextBox ChatHistoryTB;
    }
}
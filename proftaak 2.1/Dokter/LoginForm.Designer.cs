namespace Dokter
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UserLB = new System.Windows.Forms.Label();
            this.UserTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.PasswordLB = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LoginBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserLB
            // 
            this.UserLB.AutoSize = true;
            this.UserLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLB.Location = new System.Drawing.Point(134, 128);
            this.UserLB.Name = "UserLB";
            this.UserLB.Size = new System.Drawing.Size(59, 25);
            this.UserLB.TabIndex = 1;
            this.UserLB.Text = "User:";
            // 
            // UserTB
            // 
            this.UserTB.Location = new System.Drawing.Point(199, 133);
            this.UserTB.Name = "UserTB";
            this.UserTB.Size = new System.Drawing.Size(121, 20);
            this.UserTB.TabIndex = 2;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(199, 160);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(121, 20);
            this.PasswordTB.TabIndex = 3;
            // 
            // PasswordLB
            // 
            this.PasswordLB.AutoSize = true;
            this.PasswordLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLB.Location = new System.Drawing.Point(89, 155);
            this.PasswordLB.Name = "PasswordLB";
            this.PasswordLB.Size = new System.Drawing.Size(104, 25);
            this.PasswordLB.TabIndex = 4;
            this.PasswordLB.Text = "Password:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Monitor",
            "Oud overzicht"});
            this.comboBox1.Location = new System.Drawing.Point(199, 187);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // LoginBT
            // 
            this.LoginBT.Location = new System.Drawing.Point(199, 224);
            this.LoginBT.Name = "LoginBT";
            this.LoginBT.Size = new System.Drawing.Size(121, 23);
            this.LoginBT.TabIndex = 6;
            this.LoginBT.Text = "Log in";
            this.LoginBT.UseVisualStyleBackColor = true;
            this.LoginBT.Click += new System.EventHandler(this.LoginBT_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(489, 446);
            this.Controls.Add(this.LoginBT);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PasswordLB);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UserTB);
            this.Controls.Add(this.UserLB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Log in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserLB;
        private System.Windows.Forms.TextBox UserTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label PasswordLB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button LoginBT;
    }
}
namespace WindowsForms_TextEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username_box = new System.Windows.Forms.TextBox();
            this.password_Box = new System.Windows.Forms.TextBox();
            this.newuser = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // username_box
            // 
            this.username_box.Location = new System.Drawing.Point(186, 63);
            this.username_box.MaxLength = 16;
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(100, 20);
            this.username_box.TabIndex = 2;
            // 
            // password_Box
            // 
            this.password_Box.Location = new System.Drawing.Point(186, 121);
            this.password_Box.MaxLength = 16;
            this.password_Box.Name = "password_Box";
            this.password_Box.Size = new System.Drawing.Size(100, 20);
            this.password_Box.TabIndex = 3;
            this.password_Box.UseSystemPasswordChar = true;
            // 
            // newuser
            // 
            this.newuser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newuser.Location = new System.Drawing.Point(40, 184);
            this.newuser.Name = "newuser";
            this.newuser.Size = new System.Drawing.Size(75, 23);
            this.newuser.TabIndex = 4;
            this.newuser.Text = "New User";
            this.newuser.UseVisualStyleBackColor = true;
            this.newuser.Click += new System.EventHandler(this.newuser_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(161, 184);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 5;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(274, 184);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 243);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.login);
            this.Controls.Add(this.newuser);
            this.Controls.Add(this.password_Box);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_box;
        private System.Windows.Forms.TextBox password_Box;
        private System.Windows.Forms.Button newuser;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button exit;
    }
}

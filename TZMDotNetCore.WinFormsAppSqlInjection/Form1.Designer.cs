﻿namespace TZMDotNetCore.WinFormsAppSqlInjection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(154, 227);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 46);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(154, 169);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(496, 37);
            txtPassword.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(154, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(496, 37);
            txtEmail.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 405);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtEmail;
    }
}

namespace MainOffice
{
    partial class AuthorizationForm
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
            this.connectedLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.leftmarignPanel = new System.Windows.Forms.Panel();
            this.rightnarignPpanel = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // connectedLabel
            // 
            this.connectedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectedLabel.Location = new System.Drawing.Point(305, 0);
            this.connectedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(174, 116);
            this.connectedLabel.TabIndex = 0;
            this.connectedLabel.Text = "Connecting..";
            this.connectedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginLabel
            // 
            this.loginLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginLabel.Location = new System.Drawing.Point(305, 116);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(174, 21);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Login:";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginTextBox.Location = new System.Drawing.Point(305, 137);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(174, 29);
            this.loginTextBox.TabIndex = 0;
            this.loginTextBox.Tag = "admin";
            this.loginTextBox.Text = "admin";
            this.loginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // leftmarignPanel
            // 
            this.leftmarignPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftmarignPanel.Location = new System.Drawing.Point(0, 0);
            this.leftmarignPanel.Margin = new System.Windows.Forms.Padding(5);
            this.leftmarignPanel.Name = "leftmarignPanel";
            this.leftmarignPanel.Size = new System.Drawing.Size(305, 455);
            this.leftmarignPanel.TabIndex = 4;
            // 
            // rightnarignPpanel
            // 
            this.rightnarignPpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightnarignPpanel.Location = new System.Drawing.Point(479, 0);
            this.rightnarignPpanel.Margin = new System.Windows.Forms.Padding(5);
            this.rightnarignPpanel.Name = "rightnarignPpanel";
            this.rightnarignPpanel.Size = new System.Drawing.Size(305, 455);
            this.rightnarignPpanel.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordTextBox.Location = new System.Drawing.Point(305, 187);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(174, 29);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Tag = "admin";
            this.passwordTextBox.Text = "admin";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Location = new System.Drawing.Point(305, 166);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(174, 21);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginButton
            // 
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginButton.Location = new System.Drawing.Point(305, 216);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(174, 27);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Enter";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.Location = new System.Drawing.Point(305, 243);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(174, 212);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 455);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.connectedLabel);
            this.Controls.Add(this.leftmarignPanel);
            this.Controls.Add(this.rightnarignPpanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AuthorizationForm";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Panel leftmarignPanel;
        private System.Windows.Forms.Panel rightnarignPpanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}


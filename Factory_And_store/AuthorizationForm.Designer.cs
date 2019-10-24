namespace Factory_And_store
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.loginStoreTextBox = new System.Windows.Forms.TextBox();
            this.resultStoreLabel = new System.Windows.Forms.Label();
            this.errorStoreProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.connectedStoreLabel = new System.Windows.Forms.Label();
            this.passwordStoreTextBox = new System.Windows.Forms.TextBox();
            this.enterStoreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorStoreProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // loginStoreTextBox
            // 
            this.loginStoreTextBox.Location = new System.Drawing.Point(225, 125);
            this.loginStoreTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.loginStoreTextBox.Name = "loginStoreTextBox";
            this.loginStoreTextBox.Size = new System.Drawing.Size(205, 32);
            this.loginStoreTextBox.TabIndex = 0;
            this.loginStoreTextBox.Text = "pat";
            // 
            // resultStoreLabel
            // 
            this.resultStoreLabel.AutoSize = true;
            this.resultStoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.resultStoreLabel.ForeColor = System.Drawing.Color.Brown;
            this.resultStoreLabel.Location = new System.Drawing.Point(221, 245);
            this.resultStoreLabel.Name = "resultStoreLabel";
            this.resultStoreLabel.Size = new System.Drawing.Size(0, 23);
            this.resultStoreLabel.TabIndex = 2;
            // 
            // errorStoreProvider
            // 
            this.errorStoreProvider.ContainerControl = this;
            // 
            // connectedStoreLabel
            // 
            this.connectedStoreLabel.AutoSize = true;
            this.connectedStoreLabel.BackColor = System.Drawing.Color.White;
            this.connectedStoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.connectedStoreLabel.Location = new System.Drawing.Point(12, 9);
            this.connectedStoreLabel.Name = "connectedStoreLabel";
            this.connectedStoreLabel.Size = new System.Drawing.Size(2, 25);
            this.connectedStoreLabel.TabIndex = 4;
            // 
            // passwordStoreTextBox
            // 
            this.passwordStoreTextBox.Location = new System.Drawing.Point(225, 188);
            this.passwordStoreTextBox.Name = "passwordStoreTextBox";
            this.passwordStoreTextBox.Size = new System.Drawing.Size(205, 32);
            this.passwordStoreTextBox.TabIndex = 1;
            this.passwordStoreTextBox.Text = "pat32";
            this.passwordStoreTextBox.UseSystemPasswordChar = true;
            // 
            // enterStoreButton
            // 
            this.enterStoreButton.BackColor = System.Drawing.Color.DarkOrange;
            this.enterStoreButton.ForeColor = System.Drawing.Color.White;
            this.enterStoreButton.Location = new System.Drawing.Point(265, 282);
            this.enterStoreButton.Name = "enterStoreButton";
            this.enterStoreButton.Size = new System.Drawing.Size(125, 42);
            this.enterStoreButton.TabIndex = 3;
            this.enterStoreButton.Text = "Enter";
            this.enterStoreButton.UseVisualStyleBackColor = false;
            this.enterStoreButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // AuthorizationForm
            // 
            this.AcceptButton = this.enterStoreButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 396);
            this.Controls.Add(this.enterStoreButton);
            this.Controls.Add(this.passwordStoreTextBox);
            this.Controls.Add(this.connectedStoreLabel);
            this.Controls.Add(this.resultStoreLabel);
            this.Controls.Add(this.loginStoreTextBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store authorization";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorStoreProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginStoreTextBox;
        private System.Windows.Forms.Label resultStoreLabel;
        private System.Windows.Forms.ErrorProvider errorStoreProvider;
        private System.Windows.Forms.Label connectedStoreLabel;
        private System.Windows.Forms.TextBox passwordStoreTextBox;
        private System.Windows.Forms.Button enterStoreButton;
    }
}


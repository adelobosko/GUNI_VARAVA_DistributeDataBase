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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.loginTextBoxStore = new System.Windows.Forms.TextBox();
            this.passwordTextBoxStore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginTextBoxStore
            // 
            this.loginTextBoxStore.Location = new System.Drawing.Point(238, 137);
            this.loginTextBoxStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginTextBoxStore.Name = "loginTextBoxStore";
            this.loginTextBoxStore.Size = new System.Drawing.Size(148, 32);
            this.loginTextBoxStore.TabIndex = 0;
            this.loginTextBoxStore.Text = "manager";
            // 
            // passwordTextBoxStore
            // 
            this.passwordTextBoxStore.Location = new System.Drawing.Point(238, 213);
            this.passwordTextBoxStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBoxStore.Name = "passwordTextBoxStore";
            this.passwordTextBoxStore.Size = new System.Drawing.Size(148, 32);
            this.passwordTextBoxStore.TabIndex = 1;
            this.passwordTextBoxStore.Text = "pass1";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 396);
            this.Controls.Add(this.passwordTextBoxStore);
            this.Controls.Add(this.loginTextBoxStore);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AuthorizationForm";
            this.Text = "Store authorization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBoxStore;
        private System.Windows.Forms.TextBox passwordTextBoxStore;
    }
}


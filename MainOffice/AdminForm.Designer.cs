namespace MainOffice
{
    partial class AdminForm
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
            this.adminTabControl = new System.Windows.Forms.TabControl();
            this.adminMenuStrip = new System.Windows.Forms.MenuStrip();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminTabControl
            // 
            this.adminTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTabControl.Location = new System.Drawing.Point(0, 24);
            this.adminTabControl.Name = "adminTabControl";
            this.adminTabControl.SelectedIndex = 0;
            this.adminTabControl.Size = new System.Drawing.Size(800, 426);
            this.adminTabControl.TabIndex = 1;
            // 
            // adminMenuStrip
            // 
            this.adminMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseToolStripMenuItem});
            this.adminMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.adminMenuStrip.Name = "adminMenuStrip";
            this.adminMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.adminMenuStrip.TabIndex = 0;
            this.adminMenuStrip.Text = "menuStrip1";
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeActiveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dataBaseToolStripMenuItem.Text = "DataBase";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainOfficeToolStripMenuItem,
            this.storeToolStripMenuItem,
            this.factoryToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // mainOfficeToolStripMenuItem
            // 
            this.mainOfficeToolStripMenuItem.Name = "mainOfficeToolStripMenuItem";
            this.mainOfficeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mainOfficeToolStripMenuItem.Text = "MainOffice";
            this.mainOfficeToolStripMenuItem.Click += new System.EventHandler(this.openDataBaseToolStripMenuItem_Click);
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storeToolStripMenuItem.Text = "Store";
            this.storeToolStripMenuItem.Click += new System.EventHandler(this.openDataBaseToolStripMenuItem_Click);
            // 
            // factoryToolStripMenuItem
            // 
            this.factoryToolStripMenuItem.Name = "factoryToolStripMenuItem";
            this.factoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.factoryToolStripMenuItem.Text = "Factory";
            this.factoryToolStripMenuItem.Click += new System.EventHandler(this.openDataBaseToolStripMenuItem_Click);
            // 
            // closeActiveToolStripMenuItem
            // 
            this.closeActiveToolStripMenuItem.Name = "closeActiveToolStripMenuItem";
            this.closeActiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeActiveToolStripMenuItem.Text = "CloseActive";
            this.closeActiveToolStripMenuItem.Click += new System.EventHandler(this.closeActiveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.adminTabControl);
            this.Controls.Add(this.adminMenuStrip);
            this.MainMenuStrip = this.adminMenuStrip;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.adminMenuStrip.ResumeLayout(false);
            this.adminMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl adminTabControl;
        private System.Windows.Forms.MenuStrip adminMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainOfficeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}
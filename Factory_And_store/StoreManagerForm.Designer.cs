namespace Factory_And_store
{
    partial class StoreManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreManagerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAnOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merchandiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workVisitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.visitEmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.merchandiseToolStripMenuItem,
            this.workVisitToolStripMenuItem,
            this.newsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeAnOrderToolStripMenuItem,
            this.acceptToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // makeAnOrderToolStripMenuItem
            // 
            this.makeAnOrderToolStripMenuItem.Name = "makeAnOrderToolStripMenuItem";
            this.makeAnOrderToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.makeAnOrderToolStripMenuItem.Text = "Make";
            // 
            // acceptToolStripMenuItem
            // 
            this.acceptToolStripMenuItem.Name = "acceptToolStripMenuItem";
            this.acceptToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.acceptToolStripMenuItem.Text = "Accept";
            // 
            // merchandiseToolStripMenuItem
            // 
            this.merchandiseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.merchandiseToolStripMenuItem.Name = "merchandiseToolStripMenuItem";
            this.merchandiseToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.merchandiseToolStripMenuItem.Text = "Merchandise";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // workVisitToolStripMenuItem
            // 
            this.workVisitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setStartTimeToolStripMenuItem});
            this.workVisitToolStripMenuItem.Name = "workVisitToolStripMenuItem";
            this.workVisitToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.workVisitToolStripMenuItem.Text = "Work visit";
            // 
            // setStartTimeToolStripMenuItem
            // 
            this.setStartTimeToolStripMenuItem.Name = "setStartTimeToolStripMenuItem";
            this.setStartTimeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.setStartTimeToolStripMenuItem.Text = "Update";
            this.setStartTimeToolStripMenuItem.Click += new System.EventHandler(this.setStartTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.newsToolStripMenuItem.Text = "News";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.visitEmployeeComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 84);
            this.panel1.TabIndex = 1;
            // 
            // visitEmployeeComboBox
            // 
            this.visitEmployeeComboBox.FormattingEnabled = true;
            this.visitEmployeeComboBox.Location = new System.Drawing.Point(29, 13);
            this.visitEmployeeComboBox.Name = "visitEmployeeComboBox";
            this.visitEmployeeComboBox.Size = new System.Drawing.Size(121, 24);
            this.visitEmployeeComboBox.Sorted = true;
            this.visitEmployeeComboBox.TabIndex = 0;
            // 
            // StoreManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StoreManagerForm";
            this.Text = "StoreManagerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoreManagerForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeAnOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merchandiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workVisitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStartTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox visitEmployeeComboBox;
    }
}
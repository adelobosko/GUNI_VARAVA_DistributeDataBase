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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAnOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merchandiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workVisitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.merchandiseToolStripMenuItem,
            this.workVisitToolStripMenuItem});
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
            this.acceptToolStripMenuItem});
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
            // 
            // StoreManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StoreManagerForm";
            this.Text = "StoreManagerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoreManagerForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}
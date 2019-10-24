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
            this.mainOfficeTabPage = new System.Windows.Forms.TabPage();
            this.mainOfficeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainOfficeListBox = new System.Windows.Forms.ListBox();
            this.horizontalMainOfficeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.storeTabPage = new System.Windows.Forms.TabPage();
            this.factoryTabPage = new System.Windows.Forms.TabPage();
            this.storeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.storeListBox = new System.Windows.Forms.ListBox();
            this.horizontalStoreSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.adminTabControl.SuspendLayout();
            this.mainOfficeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainOfficeSplitContainer)).BeginInit();
            this.mainOfficeSplitContainer.Panel1.SuspendLayout();
            this.mainOfficeSplitContainer.Panel2.SuspendLayout();
            this.mainOfficeSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalMainOfficeSplitContainer)).BeginInit();
            this.horizontalMainOfficeSplitContainer.SuspendLayout();
            this.storeTabPage.SuspendLayout();
            this.factoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storeSplitContainer)).BeginInit();
            this.storeSplitContainer.Panel1.SuspendLayout();
            this.storeSplitContainer.Panel2.SuspendLayout();
            this.storeSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalStoreSplitContainer)).BeginInit();
            this.horizontalStoreSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminTabControl
            // 
            this.adminTabControl.Controls.Add(this.mainOfficeTabPage);
            this.adminTabControl.Controls.Add(this.storeTabPage);
            this.adminTabControl.Controls.Add(this.factoryTabPage);
            this.adminTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTabControl.Location = new System.Drawing.Point(0, 0);
            this.adminTabControl.Name = "adminTabControl";
            this.adminTabControl.SelectedIndex = 0;
            this.adminTabControl.Size = new System.Drawing.Size(800, 450);
            this.adminTabControl.TabIndex = 1;
            // 
            // mainOfficeTabPage
            // 
            this.mainOfficeTabPage.Controls.Add(this.mainOfficeSplitContainer);
            this.mainOfficeTabPage.Location = new System.Drawing.Point(4, 22);
            this.mainOfficeTabPage.Name = "mainOfficeTabPage";
            this.mainOfficeTabPage.Size = new System.Drawing.Size(792, 424);
            this.mainOfficeTabPage.TabIndex = 0;
            this.mainOfficeTabPage.Text = "MainOffice";
            this.mainOfficeTabPage.UseVisualStyleBackColor = true;
            // 
            // mainOfficeSplitContainer
            // 
            this.mainOfficeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainOfficeSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainOfficeSplitContainer.Name = "mainOfficeSplitContainer";
            // 
            // mainOfficeSplitContainer.Panel1
            // 
            this.mainOfficeSplitContainer.Panel1.Controls.Add(this.mainOfficeListBox);
            // 
            // mainOfficeSplitContainer.Panel2
            // 
            this.mainOfficeSplitContainer.Panel2.Controls.Add(this.horizontalMainOfficeSplitContainer);
            this.mainOfficeSplitContainer.Size = new System.Drawing.Size(792, 424);
            this.mainOfficeSplitContainer.SplitterDistance = 177;
            this.mainOfficeSplitContainer.TabIndex = 0;
            // 
            // mainOfficeListBox
            // 
            this.mainOfficeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainOfficeListBox.FormattingEnabled = true;
            this.mainOfficeListBox.Items.AddRange(new object[] {
            "ConnectingStrings",
            "Departaments",
            "Employees",
            "EmployeeWorkLogs",
            "HeadOrders",
            "PerformedHeadOrders",
            "Positions",
            "RealEstateContacts",
            "RealEstates",
            "RealEstateTypes",
            "StatusOrders",
            "Users"});
            this.mainOfficeListBox.Location = new System.Drawing.Point(0, 0);
            this.mainOfficeListBox.Name = "mainOfficeListBox";
            this.mainOfficeListBox.Size = new System.Drawing.Size(177, 424);
            this.mainOfficeListBox.TabIndex = 1;
            this.mainOfficeListBox.SelectedIndexChanged += new System.EventHandler(this.mainOfficeListBox_SelectedIndexChanged);
            // 
            // horizontalMainOfficeSplitContainer
            // 
            this.horizontalMainOfficeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalMainOfficeSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.horizontalMainOfficeSplitContainer.Name = "horizontalMainOfficeSplitContainer";
            this.horizontalMainOfficeSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.horizontalMainOfficeSplitContainer.Size = new System.Drawing.Size(611, 424);
            this.horizontalMainOfficeSplitContainer.SplitterDistance = 203;
            this.horizontalMainOfficeSplitContainer.TabIndex = 0;
            // 
            // storeTabPage
            // 
            this.storeTabPage.Controls.Add(this.storeSplitContainer);
            this.storeTabPage.Location = new System.Drawing.Point(4, 22);
            this.storeTabPage.Name = "storeTabPage";
            this.storeTabPage.Size = new System.Drawing.Size(792, 424);
            this.storeTabPage.TabIndex = 1;
            this.storeTabPage.Text = "Store";
            this.storeTabPage.UseVisualStyleBackColor = true;
            // 
            // factoryTabPage
            // 
            this.factoryTabPage.Controls.Add(this.splitContainer3);
            this.factoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.factoryTabPage.Name = "factoryTabPage";
            this.factoryTabPage.Size = new System.Drawing.Size(792, 424);
            this.factoryTabPage.TabIndex = 2;
            this.factoryTabPage.Text = "Factory";
            this.factoryTabPage.UseVisualStyleBackColor = true;
            // 
            // storeSplitContainer
            // 
            this.storeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storeSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.storeSplitContainer.Name = "storeSplitContainer";
            // 
            // storeSplitContainer.Panel1
            // 
            this.storeSplitContainer.Panel1.Controls.Add(this.storeListBox);
            // 
            // storeSplitContainer.Panel2
            // 
            this.storeSplitContainer.Panel2.Controls.Add(this.horizontalStoreSplitContainer);
            this.storeSplitContainer.Size = new System.Drawing.Size(792, 424);
            this.storeSplitContainer.SplitterDistance = 177;
            this.storeSplitContainer.TabIndex = 1;
            // 
            // storeListBox
            // 
            this.storeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storeListBox.FormattingEnabled = true;
            this.storeListBox.Items.AddRange(new object[] {
            "ConnectingStrings",
            "Departaments",
            "Employees",
            "EmployeeWorkLogs",
            "HeadOrders",
            "PerformedHeadOrders",
            "Positions",
            "RealEstateContacts",
            "RealEstates",
            "RealEstateTypes",
            "StatusOrders",
            "Users"});
            this.storeListBox.Location = new System.Drawing.Point(0, 0);
            this.storeListBox.Name = "storeListBox";
            this.storeListBox.Size = new System.Drawing.Size(177, 424);
            this.storeListBox.TabIndex = 1;
            // 
            // horizontalStoreSplitContainer
            // 
            this.horizontalStoreSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalStoreSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.horizontalStoreSplitContainer.Name = "horizontalStoreSplitContainer";
            this.horizontalStoreSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.horizontalStoreSplitContainer.Size = new System.Drawing.Size(611, 424);
            this.horizontalStoreSplitContainer.SplitterDistance = 203;
            this.horizontalStoreSplitContainer.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(792, 424);
            this.splitContainer3.SplitterDistance = 177;
            this.splitContainer3.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "ConnectingStrings",
            "Departaments",
            "Employees",
            "EmployeeWorkLogs",
            "HeadOrders",
            "PerformedHeadOrders",
            "Positions",
            "RealEstateContacts",
            "RealEstates",
            "RealEstateTypes",
            "StatusOrders",
            "Users"});
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(177, 424);
            this.listBox2.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer4.Size = new System.Drawing.Size(611, 424);
            this.splitContainer4.SplitterDistance = 203;
            this.splitContainer4.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.adminTabControl);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.adminTabControl.ResumeLayout(false);
            this.mainOfficeTabPage.ResumeLayout(false);
            this.mainOfficeSplitContainer.Panel1.ResumeLayout(false);
            this.mainOfficeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainOfficeSplitContainer)).EndInit();
            this.mainOfficeSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horizontalMainOfficeSplitContainer)).EndInit();
            this.horizontalMainOfficeSplitContainer.ResumeLayout(false);
            this.storeTabPage.ResumeLayout(false);
            this.factoryTabPage.ResumeLayout(false);
            this.storeSplitContainer.Panel1.ResumeLayout(false);
            this.storeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storeSplitContainer)).EndInit();
            this.storeSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horizontalStoreSplitContainer)).EndInit();
            this.horizontalStoreSplitContainer.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl adminTabControl;
        private System.Windows.Forms.TabPage mainOfficeTabPage;
        private System.Windows.Forms.SplitContainer mainOfficeSplitContainer;
        private System.Windows.Forms.ListBox mainOfficeListBox;
        private System.Windows.Forms.TabPage storeTabPage;
        private System.Windows.Forms.TabPage factoryTabPage;
        private System.Windows.Forms.SplitContainer horizontalMainOfficeSplitContainer;
        private System.Windows.Forms.SplitContainer storeSplitContainer;
        private System.Windows.Forms.ListBox storeListBox;
        private System.Windows.Forms.SplitContainer horizontalStoreSplitContainer;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control = System.Windows.Forms.Control;

namespace MainOffice
{
    public partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.adminTabControl = new System.Windows.Forms.TabControl();
            this.mainOfficeTabPage = new System.Windows.Forms.TabPage();
            this.mainOfficeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainOfficeListBox = new System.Windows.Forms.ListBox();
            this.mainOfficeHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.storeTabPage = new System.Windows.Forms.TabPage();
            this.storeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.storeListBox = new System.Windows.Forms.ListBox();
            this.storeHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.factoryTabPage = new System.Windows.Forms.TabPage();
            this.factorySplitContainer = new System.Windows.Forms.SplitContainer();
            this.factoryListBox = new System.Windows.Forms.ListBox();
            this.factoryHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SQLTabPage = new System.Windows.Forms.TabPage();
            this.SQLSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SQLTextBox = new System.Windows.Forms.TextBox();
            this.SQLTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SQLQueryButton = new System.Windows.Forms.Button();
            this.SQLCommandButton = new System.Windows.Forms.Button();
            this.adminTabControl.SuspendLayout();
            this.mainOfficeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainOfficeSplitContainer)).BeginInit();
            this.mainOfficeSplitContainer.Panel1.SuspendLayout();
            this.mainOfficeSplitContainer.Panel2.SuspendLayout();
            this.mainOfficeSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainOfficeHorizontalSplitContainer)).BeginInit();
            this.mainOfficeHorizontalSplitContainer.SuspendLayout();
            this.storeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storeSplitContainer)).BeginInit();
            this.storeSplitContainer.Panel1.SuspendLayout();
            this.storeSplitContainer.Panel2.SuspendLayout();
            this.storeSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storeHorizontalSplitContainer)).BeginInit();
            this.storeHorizontalSplitContainer.SuspendLayout();
            this.factoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factorySplitContainer)).BeginInit();
            this.factorySplitContainer.Panel1.SuspendLayout();
            this.factorySplitContainer.Panel2.SuspendLayout();
            this.factorySplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factoryHorizontalSplitContainer)).BeginInit();
            this.factoryHorizontalSplitContainer.SuspendLayout();
            this.SQLTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SQLSplitContainer)).BeginInit();
            this.SQLSplitContainer.Panel1.SuspendLayout();
            this.SQLSplitContainer.Panel2.SuspendLayout();
            this.SQLSplitContainer.SuspendLayout();
            this.SQLTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminTabControl
            // 
            this.adminTabControl.Controls.Add(this.mainOfficeTabPage);
            this.adminTabControl.Controls.Add(this.storeTabPage);
            this.adminTabControl.Controls.Add(this.factoryTabPage);
            this.adminTabControl.Controls.Add(this.SQLTabPage);
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
            this.mainOfficeSplitContainer.Panel2.Controls.Add(this.mainOfficeHorizontalSplitContainer);
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
            this.mainOfficeListBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // mainOfficeHorizontalSplitContainer
            // 
            this.mainOfficeHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainOfficeHorizontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainOfficeHorizontalSplitContainer.Name = "mainOfficeHorizontalSplitContainer";
            this.mainOfficeHorizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.mainOfficeHorizontalSplitContainer.Size = new System.Drawing.Size(611, 424);
            this.mainOfficeHorizontalSplitContainer.SplitterDistance = 203;
            this.mainOfficeHorizontalSplitContainer.TabIndex = 0;
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
            this.storeSplitContainer.Panel2.Controls.Add(this.storeHorizontalSplitContainer);
            this.storeSplitContainer.Size = new System.Drawing.Size(792, 424);
            this.storeSplitContainer.SplitterDistance = 177;
            this.storeSplitContainer.TabIndex = 1;
            // 
            // storeListBox
            // 
            this.storeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storeListBox.FormattingEnabled = true;
            this.storeListBox.Location = new System.Drawing.Point(0, 0);
            this.storeListBox.Name = "storeListBox";
            this.storeListBox.Size = new System.Drawing.Size(177, 424);
            this.storeListBox.TabIndex = 1;
            this.storeListBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // storeHorizontalSplitContainer
            // 
            this.storeHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storeHorizontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.storeHorizontalSplitContainer.Name = "storeHorizontalSplitContainer";
            this.storeHorizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.storeHorizontalSplitContainer.Size = new System.Drawing.Size(611, 424);
            this.storeHorizontalSplitContainer.SplitterDistance = 203;
            this.storeHorizontalSplitContainer.TabIndex = 0;
            // 
            // factoryTabPage
            // 
            this.factoryTabPage.Controls.Add(this.factorySplitContainer);
            this.factoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.factoryTabPage.Name = "factoryTabPage";
            this.factoryTabPage.Size = new System.Drawing.Size(792, 424);
            this.factoryTabPage.TabIndex = 2;
            this.factoryTabPage.Text = "Factory";
            this.factoryTabPage.UseVisualStyleBackColor = true;
            // 
            // factorySplitContainer
            // 
            this.factorySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.factorySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.factorySplitContainer.Name = "factorySplitContainer";
            // 
            // factorySplitContainer.Panel1
            // 
            this.factorySplitContainer.Panel1.Controls.Add(this.factoryListBox);
            // 
            // factorySplitContainer.Panel2
            // 
            this.factorySplitContainer.Panel2.Controls.Add(this.factoryHorizontalSplitContainer);
            this.factorySplitContainer.Size = new System.Drawing.Size(792, 424);
            this.factorySplitContainer.SplitterDistance = 177;
            this.factorySplitContainer.TabIndex = 1;
            // 
            // factoryListBox
            // 
            this.factoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.factoryListBox.FormattingEnabled = true;
            this.factoryListBox.Location = new System.Drawing.Point(0, 0);
            this.factoryListBox.Name = "factoryListBox";
            this.factoryListBox.Size = new System.Drawing.Size(177, 424);
            this.factoryListBox.TabIndex = 1;
            this.factoryListBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // factoryHorizontalSplitContainer
            // 
            this.factoryHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.factoryHorizontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.factoryHorizontalSplitContainer.Name = "factoryHorizontalSplitContainer";
            this.factoryHorizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.factoryHorizontalSplitContainer.Size = new System.Drawing.Size(611, 424);
            this.factoryHorizontalSplitContainer.SplitterDistance = 203;
            this.factoryHorizontalSplitContainer.TabIndex = 0;
            // 
            // SQLTabPage
            // 
            this.SQLTabPage.Controls.Add(this.SQLSplitContainer);
            this.SQLTabPage.Location = new System.Drawing.Point(4, 22);
            this.SQLTabPage.Name = "SQLTabPage";
            this.SQLTabPage.Size = new System.Drawing.Size(792, 424);
            this.SQLTabPage.TabIndex = 3;
            this.SQLTabPage.Text = "TSQL";
            this.SQLTabPage.UseVisualStyleBackColor = true;
            // 
            // SQLSplitContainer
            // 
            this.SQLSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SQLSplitContainer.Name = "SQLSplitContainer";
            this.SQLSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SQLSplitContainer.Panel1
            // 
            this.SQLSplitContainer.Panel1.Controls.Add(this.SQLTextBox);
            // 
            // SQLSplitContainer.Panel2
            // 
            this.SQLSplitContainer.Panel2.Controls.Add(this.SQLTableLayoutPanel);
            this.SQLSplitContainer.Size = new System.Drawing.Size(792, 424);
            this.SQLSplitContainer.SplitterDistance = 203;
            this.SQLSplitContainer.TabIndex = 1;
            // 
            // SQLTextBox
            // 
            this.SQLTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLTextBox.Location = new System.Drawing.Point(0, 0);
            this.SQLTextBox.Multiline = true;
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.Size = new System.Drawing.Size(792, 203);
            this.SQLTextBox.TabIndex = 0;
            this.SQLTextBox.Text = resources.GetString("SQLTextBox.Text");
            // 
            // SQLTableLayoutPanel
            // 
            this.SQLTableLayoutPanel.ColumnCount = 3;
            this.SQLTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SQLTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SQLTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SQLTableLayoutPanel.Controls.Add(this.SQLCommandButton, 1, 0);
            this.SQLTableLayoutPanel.Controls.Add(this.SQLQueryButton, 0, 0);
            this.SQLTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SQLTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SQLTableLayoutPanel.Name = "SQLTableLayoutPanel";
            this.SQLTableLayoutPanel.RowCount = 1;
            this.SQLTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SQLTableLayoutPanel.Size = new System.Drawing.Size(792, 40);
            this.SQLTableLayoutPanel.TabIndex = 0;
            // 
            // SQLQueryButton
            // 
            this.SQLQueryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLQueryButton.Location = new System.Drawing.Point(3, 3);
            this.SQLQueryButton.Name = "SQLQueryButton";
            this.SQLQueryButton.Size = new System.Drawing.Size(257, 34);
            this.SQLQueryButton.TabIndex = 1;
            this.SQLQueryButton.Text = "ExecuteReader";
            this.SQLQueryButton.UseVisualStyleBackColor = true;
            this.SQLQueryButton.Click += new System.EventHandler(this.SQLQueryButton_Click);
            // 
            // SQLCommandButton
            // 
            this.SQLCommandButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLCommandButton.Location = new System.Drawing.Point(266, 3);
            this.SQLCommandButton.Name = "SQLCommandButton";
            this.SQLCommandButton.Size = new System.Drawing.Size(257, 34);
            this.SQLCommandButton.TabIndex = 2;
            this.SQLCommandButton.Text = "SQLCommand";
            this.SQLCommandButton.UseVisualStyleBackColor = true;
            this.SQLCommandButton.Click += new System.EventHandler(this.SQLCommandButton_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.mainOfficeHorizontalSplitContainer)).EndInit();
            this.mainOfficeHorizontalSplitContainer.ResumeLayout(false);
            this.storeTabPage.ResumeLayout(false);
            this.storeSplitContainer.Panel1.ResumeLayout(false);
            this.storeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storeSplitContainer)).EndInit();
            this.storeSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storeHorizontalSplitContainer)).EndInit();
            this.storeHorizontalSplitContainer.ResumeLayout(false);
            this.factoryTabPage.ResumeLayout(false);
            this.factorySplitContainer.Panel1.ResumeLayout(false);
            this.factorySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.factorySplitContainer)).EndInit();
            this.factorySplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.factoryHorizontalSplitContainer)).EndInit();
            this.factoryHorizontalSplitContainer.ResumeLayout(false);
            this.SQLTabPage.ResumeLayout(false);
            this.SQLSplitContainer.Panel1.ResumeLayout(false);
            this.SQLSplitContainer.Panel1.PerformLayout();
            this.SQLSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SQLSplitContainer)).EndInit();
            this.SQLSplitContainer.ResumeLayout(false);
            this.SQLTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl adminTabControl;
        private System.Windows.Forms.TabPage mainOfficeTabPage;
        private System.Windows.Forms.SplitContainer mainOfficeSplitContainer;
        private System.Windows.Forms.ListBox mainOfficeListBox;
        private System.Windows.Forms.TabPage storeTabPage;
        private System.Windows.Forms.TabPage factoryTabPage;
        private System.Windows.Forms.SplitContainer mainOfficeHorizontalSplitContainer;
        private System.Windows.Forms.SplitContainer storeSplitContainer;
        private System.Windows.Forms.ListBox storeListBox;
        private System.Windows.Forms.SplitContainer storeHorizontalSplitContainer;
        private System.Windows.Forms.SplitContainer factorySplitContainer;
        private System.Windows.Forms.ListBox factoryListBox;
        private System.Windows.Forms.SplitContainer factoryHorizontalSplitContainer;
        private System.Windows.Forms.TabPage SQLTabPage;
        private System.Windows.Forms.SplitContainer SQLSplitContainer;
        private System.Windows.Forms.TextBox SQLTextBox;
        private System.Windows.Forms.TableLayoutPanel SQLTableLayoutPanel;
        private System.Windows.Forms.Button SQLCommandButton;
        private System.Windows.Forms.Button SQLQueryButton;
    }
}

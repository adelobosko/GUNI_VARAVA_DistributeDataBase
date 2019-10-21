using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using EF_Model;
using Microsoft.Win32;
using static EF_Model.DistributedDataBaseContainer;
using Control = System.Windows.Forms.Control;

namespace MainOffice
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalHelper.AuthorizationForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static T GetPropertyValue<T>(Type type, string propName)
        {
            return (T)type.GetProperty(propName).GetValue(type, null);
        }

        private static Control FindControlParentForm(Control theControl)
        {
            Control rControl = null;

            if (theControl.Parent != null)
            {
                rControl = theControl.Parent is AdminForm ? theControl.Parent : FindControlParentForm(theControl.Parent);
            }

            return rControl;
        }

        private static DataGridView CreateDataGridView(string uniqueName)
        {
            var dataGridView = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ColumnHeadersVisible = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Location = new Point(240, 32),
                MultiSelect = false,
                Name = $"{uniqueName}DataGridView",
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                RowHeadersVisible = false,
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                Size = new Size(240, 175)
            };

            return dataGridView;
        }


        private static TabPage TabPageCtreatator(DataBaseType dbName)
        {
            var tabPage = new TabPage(Enum.GetName(typeof(DataBaseType), dbName));
            var splitContainer = new SplitContainer();
            var horizontalSplitContainer = new SplitContainer();
            var splitWidth = 30;
            var textBox = new TextBox();
            var listBox = new ListBox();
            var autoCompleteStringCollection = new AutoCompleteStringCollection();

            tabPage.Name = $"{tabPage.Text}TabPage";
            textBox.Name = $"{tabPage.Text}TextBox";
            listBox.Name = $"{tabPage.Text}ListBox";
            splitContainer.Name = $"{tabPage.Text}SplitContainer";
            horizontalSplitContainer.Name = $"{tabPage.Text}horizontalSplitContainer";

            textBox.Dock = DockStyle.Top;
            listBox.Dock = DockStyle.Fill;
            horizontalSplitContainer.Dock = DockStyle.Fill;



            var database = GetPropertyValue<DistributedDataBaseContainer>(typeof(GlobalHelper), tabPage.Text);
            var tables = database.DataBaseTables.Select(t => t.TableName).ToArray();

            textBox.TextChanged += (sender, args) =>
            {

                var databaseName = textBox.Name.Replace(textBox.GetType().Name, "");

                var admForm = FindControlParentForm(textBox);

                var senderListBox = admForm.Controls.Find($"{databaseName}ListBox", true)[0] as ListBox;

                senderListBox.Items.Clear();
                senderListBox.Items.AddRange(database.DataBaseTables.Where(t => t.TableName.Contains(textBox.Text)).Select(t => t.TableName).ToArray());

            };

            autoCompleteStringCollection.AddRange(tables);
            textBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            listBox.Items.AddRange(tables);
            horizontalSplitContainer.Orientation = Orientation.Horizontal;

            listBox.SelectedIndexChanged += (sender, args) =>
            {
                if (listBox.SelectedIndex < 0) return;

                horizontalSplitContainer.Panel1.Controls.Clear();
                horizontalSplitContainer.Panel2.Controls.Clear();

                var tableName = listBox.Items[listBox.SelectedIndex].ToString();
                var structures = database.TableStructures.Where(s => s.DataBaseTable.TableName == tableName).Select(s => s).ToList();
                dynamic table = DataBinder.Eval(database, tableName);
                var dataGridView = CreateDataGridView($"{tabPage.Text}_{tableName}");
                var rowIndex = 0;

                dataGridView.ColumnCount = structures.Count();
                var addButton = new Button();
                var updateButton = new Button();
                var deleteButton = new Button();
                addButton.Dock = DockStyle.Top;
                updateButton.Dock = DockStyle.Top;
                deleteButton.Dock = DockStyle.Top;



                for (var i = 0; i < structures.Count(); i++)
                {
                    if (!dataGridView.Columns.Contains(structures[i].ColumnName))
                    {
                        dataGridView.Columns[i].HeaderText = structures[i].ColumnName;
                        var dataLabel = new Label();
                        var dataTextBox = new TextBox();
                        dataLabel.Dock = DockStyle.Top;
                        dataTextBox.Dock = DockStyle.Top;

                        dataLabel.Name = $"{tabPage.Text}_{tableName}_{structures[i].ColumnName}_{structures[i].ColumnType}Label";
                        dataTextBox.Name = $"{tabPage.Text}_{tableName}_{structures[i].ColumnName}_{structures[i].ColumnType}TextBox";

                        dataLabel.Text = $"{structures[i].ColumnName}";

                        horizontalSplitContainer.Panel2.Controls.Add(dataTextBox);
                        horizontalSplitContainer.Panel2.Controls.Add(dataLabel);
                    }
                }

                horizontalSplitContainer.Panel2.Controls.Add(deleteButton);
                horizontalSplitContainer.Panel2.Controls.Add(updateButton);
                horizontalSplitContainer.Panel2.Controls.Add(addButton);

                addButton.Click += (o, eventArgs) =>
                {
                    /*
                     *
                     */
                };


                foreach (var row in table)
                {
                    dataGridView.RowCount = rowIndex + 1;
                    for (var i = 0; i < structures.Count(); i++)
                    {
                        var obj = "";
                        try
                        {
                            obj = DataBinder.Eval(row, structures[i].ColumnName).ToString();
                        }
                        catch
                        {
                            MessageBox.Show($"{tableName} : {structures[i].ColumnName}\r\nERROR: Can not find column", "ERROR: Can not find column");

                            obj = DataBinder.Eval(row, structures[i].ColumnName).ToString();
                        }


                        dataGridView[i, rowIndex].Value = obj;
                    }

                    rowIndex++;
                }


                horizontalSplitContainer.Panel1.Controls.Add(dataGridView);
            };


            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.Panel1.Controls.Add(listBox);
            splitContainer.Panel1.Controls.Add(textBox);
            splitContainer.Panel2.Controls.Add(horizontalSplitContainer);
            tabPage.Controls.Add(splitContainer);

            splitContainer.SplitterDistance = splitWidth;
            return tabPage;
        }

        private void openDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;

            Enum.TryParse(toolStripMenuItem.Name.Replace("ToolStripMenuItem", ""),
                true,
                out DataBaseType dbName);



            foreach (TabPage tabPage in adminTabControl.TabPages)
            {
                if (tabPage.Text != Enum.GetName(typeof(DataBaseType), dbName))
                {
                    continue;
                }

                adminTabControl.SelectTab(tabPage);
                return;
            }

            var databaseTabPage = TabPageCtreatator(dbName);
            adminTabControl.TabPages.Add(databaseTabPage);
            adminTabControl.SelectTab(databaseTabPage);
        }

        private void closeActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminTabControl.TabPages.Count == 0)
            {
                return;
            }

            var selectedTab = adminTabControl.SelectedTab;

            adminTabControl.TabPages.Remove(selectedTab);


            foreach (var control in selectedTab.Controls)
            {
                if (control is SplitContainer container)
                {
                    container.Panel1.Controls.Clear();
                    container.Panel2.Controls.Clear();
                    container.Dispose();
                }
            }

            selectedTab.Controls.Clear();
            selectedTab.Dispose();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }
    }
}

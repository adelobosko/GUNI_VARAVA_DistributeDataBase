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


        private static string GenerateControlName(Type type, params string[] parts)
        {
            var controlName = "";

            if (parts.Length == 0)
                return type.Name;

            for (var i = 0; i < parts.Length - 1; i++)
            {
                controlName += $"{parts[i]}_";
            }

            return controlName + parts[parts.Length - 1] + type.Name;
        }


        private static Control CreateColumnControlByType(string columnName, string type, bool isPrimary)
        {
            var panel = new Panel();
            panel.Name = GenerateControlName(panel.GetType(), columnName);
            panel.Dock = DockStyle.Top;

            switch (type)
            {
                case "DateTime":
                case "int":
                case "String":
                case "Guide":
                case "Guid":
                {
                    var dataLabel = new Label();
                    var dataTextBox = new TextBox();
                    dataLabel.Name = GenerateControlName(dataLabel.GetType(), columnName);
                    dataTextBox.Name = GenerateControlName(dataTextBox.GetType(), columnName);
                    dataLabel.AutoSize = true;

                    dataLabel.Dock = DockStyle.Left;
                    dataTextBox.Dock = DockStyle.Fill;

                    dataTextBox.ReadOnly = isPrimary;


                    dataLabel.Text = $"{columnName}:";


                    panel.Controls.Add(dataTextBox);
                    panel.Controls.Add(dataLabel);
                    break;
                }
                case "bool":
                {
                    var dataCheckBox = new CheckBox();
                    dataCheckBox.Name = GenerateControlName(dataCheckBox.GetType(), columnName);
                    dataCheckBox.AutoSize = true;
                    dataCheckBox.Text = columnName;
                    dataCheckBox.Dock = DockStyle.Left;

                    panel.Controls.Add(dataCheckBox);
                    break;
                }
                default:
                {
                    var str = $"{type}\r\nUnknown column type";
                    MessageBox.Show(str);
                    throw new Exception(str);
                }
            }


            panel.Height = 30;
            return panel;
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

                dataGridView.Columns.Clear();
                var addButton = new Button();
                var updateButton = new Button();
                var deleteButton = new Button();
                addButton.Dock = DockStyle.Top;
                updateButton.Dock = DockStyle.Top;
                deleteButton.Dock = DockStyle.Top;
                addButton.Text = "Add";
                addButton.Name = $"{tabPage.Text}_{tableName}_{addButton.Text}Button";
                deleteButton.Text = "Del";
                deleteButton.Name = $"{tabPage.Text}_{tableName}_{deleteButton.Text}Button";
                updateButton.Text = "Upd";
                updateButton.Name = $"{tabPage.Text}_{tableName}_{updateButton.Text}Button";


                horizontalSplitContainer.Panel2.Controls.Add(deleteButton);
                horizontalSplitContainer.Panel2.Controls.Add(updateButton);
                horizontalSplitContainer.Panel2.Controls.Add(addButton);

                for (var i = 0; i < structures.Count(); i++)
                {
                    dataGridView.Columns.Add(structures[i].ColumnName, structures[i].ColumnName);
                    var control = CreateColumnControlByType(structures[i].ColumnName, structures[i].ColumnType, structures[i].IsPrimary);
                    horizontalSplitContainer.Panel2.Controls.Add(control);
                    dataGridView.Columns[i].HeaderText = structures[i].ColumnName;
                    horizontalSplitContainer.Panel2.AutoScroll = false;
                    horizontalSplitContainer.Panel2.AutoScroll = true;
                }

                addButton.Click += (o, eventArgs) =>
                {
                    var linqCommand = "";

                    /* for (var i = 0; i < structures.Count(); i++)
                     {

                         switch (structures[i].ColumnType)
                         {
                             case "DateTime":
                             case "int":
                             case "String":
                             case "Guide":
                             case "Guid":
                             {
                                 var resControl = horizontalSplitContainer.Panel2.Controls.Find(GenerateControlName(typeof(TextBox), structures[i].ColumnName), true)[0] as TextBox;

                                 linqCommand += ""
                                 resControl.Text = dataGridView[structures[i].ColumnName, eventArgs.RowIndex].Value.ToString();
                                 break;
                             }
                             case "bool":
                             {
                                 var resControl = horizontalSplitContainer.Panel2.Controls.Find(GenerateControlName(typeof(CheckBox), structures[i].ColumnName), true)[0] as CheckBox;

                                 resControl.Checked =
                                     Convert.ToBoolean(dataGridView[structures[i].ColumnName, eventArgs.RowIndex].Value.ToString());
                                 break;
                             }
                         }
                     }*/
                    /*switch (tableName)
                    {
                        case "Users":
                        {

                        }
                    }
                    database.SaveChanges();*/
                };
                deleteButton.Click += (o, eventArgs) =>
                {
                    database.SaveChanges();
                    /*
                     * *
                     */

                };


                dataGridView.CellClick += (o, eventArgs) =>
                {
                    if(eventArgs.RowIndex < 0) return;
                    
                    for (var i = 0; i < structures.Count(); i++)
                    {
                        switch (structures[i].ColumnType)
                        {
                            case "DateTime":
                            case "int":
                            case "String":
                            case "Guide":
                            case "Guid":
                            {
                                var resControl = horizontalSplitContainer.Panel2.Controls.Find(GenerateControlName(typeof(TextBox), structures[i].ColumnName), true)[0] as TextBox;

                                resControl.Text = dataGridView[structures[i].ColumnName, eventArgs.RowIndex].Value.ToString();
                                break;
                            }
                            case "bool":
                            {
                                var resControl = horizontalSplitContainer.Panel2.Controls.Find(GenerateControlName(typeof(CheckBox), structures[i].ColumnName), true)[0] as CheckBox;

                                resControl.Checked =
                                    Convert.ToBoolean(dataGridView[structures[i].ColumnName, eventArgs.RowIndex].Value.ToString());
                                break;
                            }
                        }
                    }
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

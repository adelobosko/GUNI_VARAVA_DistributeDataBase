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
using System.Windows.Forms;
using EF_Model;
using Microsoft.Win32;
using static EF_Model.DistributedDataBaseContainer;

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


        private static TabPage TabPageCtreatator(DataBaseType dbName)
        {
            var tabPage = new TabPage(Enum.GetName(typeof(DataBaseType), dbName));
            var splitContainer = new SplitContainer();
            var horizontalSplitContainer = new SplitContainer();
            var splitWidth = 116;
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


            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.SplitterDistance = splitWidth;
            splitContainer.Panel1.Controls.Add(listBox);
            splitContainer.Panel1.Controls.Add(textBox);
            splitContainer.Panel2.Controls.Add(horizontalSplitContainer);
            tabPage.Controls.Add(splitContainer);

            return tabPage;
        }

        private void openDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripmenuItem = (ToolStripMenuItem)sender;

            Enum.TryParse(toolStripmenuItem.Name.Replace("ToolStripMenuItem", ""),
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

            adminTabControl.TabPages.Add(TabPageCtreatator(dbName));
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
                if (control is SplitContainer)
                {
                    var container = control as SplitContainer;
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

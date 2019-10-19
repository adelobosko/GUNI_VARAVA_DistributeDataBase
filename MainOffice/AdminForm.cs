using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

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


        public static T GetPropertyValue<T>(object obj, string propName)
        {
            return (T)obj.GetType().GetProperty(propName).GetValue(obj, null);
        }


        private static TabPage TabPageCtreatator(string dbName)
        {
            var tabPage = new TabPage(dbName);
            var splitContainer = new SplitContainer();
            var splitWidth = 305;
            var textBox = new TextBox();
            var listBox = new ListBox();
            var autoCompleteStringCollection = new AutoCompleteStringCollection();

            textBox.Dock = DockStyle.Top;
            listBox.Dock = DockStyle.Fill;

            var properties = GlobalHelper.MainOffice.GetType().GetProperties();
            
            /*foreach (var propertyInfo in properties)
            {
                if (propertyInfo.DeclaringType != typeof(EF_Model.DistributedDataBaseContainer) ||
                    propertyInfo.MemberType != MemberTypes.Property)
                {
                    continue;
                }

                var type = propertyInfo.PropertyType;

                MessageBox.Show($"\r\n{propertyInfo.Name}\r\n{propertyInfo.PropertyType.Name}");

                //try
                {
                    var res = GetPropertyValue<object>(GlobalHelper.MainOffice, propertyInfo.Name);

                    if(res is DbSet<>)
                    {
                        
                    }

                    //var list = objectValue;

                    MessageBox.Show($"{objectValue.GetType()}\r\n{propertyInfo.Name}\r\n{propertyInfo.MemberType}\r\n{propertyInfo.ReflectedType}");

                    autoCompleteStringCollection.Add(propertyInfo.Name);
                }
               // catch { MessageBox.Show($"\r\n{memberInfo.Name}\r\n{memberInfo.MemberType}\r\n{memberInfo.ReflectedType}", "ERRor"); }
                
            }*/

            textBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;


            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;

            splitContainer.SplitterDistance = splitWidth;
            splitContainer.Panel1.Controls.Add(textBox);
            splitContainer.Panel1.Controls.Add(listBox);



            tabPage.Controls.Add(splitContainer);
            /*
             * myFlowLayoutPanel.Controls.Clear();

myFlowLayoutPanel.Dispose();
             */
            return tabPage;
        }

        private void openDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripmenuItem = (ToolStripMenuItem) sender;
            var dbName = toolStripmenuItem.Name.Replace("ToolStripMenuItem", "");

            foreach (TabPage variTabPage in adminTabControl.TabPages)
            {
                if (variTabPage.Text != dbName) continue;

                adminTabControl.SelectTab(variTabPage);
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

            selectedTab.Dispose();
            selectedTab = null;
        }
    }
}

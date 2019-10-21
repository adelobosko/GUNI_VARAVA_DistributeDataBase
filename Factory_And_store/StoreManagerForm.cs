using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory_And_store
{
    public partial class StoreManagerForm : Form
    {
        public StoreManagerForm()
        {
            InitializeComponent();
        }

        private void StoreManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalHelper.AuthorizationForm.Show();
        }

        private void setStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //visitEmployeeComboBox.Items.Clear();
            //List<string> employeeList = new List<string> { };
            //employeeList.Add(GlobalHelper.Store.Employees.Select(e1 => $"{e1.FirstName} {e1.SecondName} {e1.MiddleName}").ToString());

            //visitEmployeeComboBox.Items.AddRange(eList);
        }
    }
}

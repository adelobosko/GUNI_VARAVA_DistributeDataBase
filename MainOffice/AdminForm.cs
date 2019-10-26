using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EF_Model;
using static MainOffice.DataExchanger;

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


        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.Text =
                $@"{GlobalHelper.User.Employee.FirstName} {GlobalHelper.User.Employee.SecondName} {GlobalHelper.User.Employee.MiddleName}";

            var factoryTables = new[]
            {
                "Components", "ConnectingStrings", "Departaments", "Employees", "EmployeeWorkLogs", "MeasurementUnits",
                "Merchandises", "Positions", "Products", "RawMaterialProviderContracts", "RawMaterials",
                "RealEstateContacts", "RealEstates", "RealEstateTypes", "StatusOrders", "StockRawMaterials", "Users"
            };
            factoryListBox.Items.AddRange(factoryTables);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListBox listBox) || listBox.SelectedIndex < 0 || listBox.SelectedIndex >= listBox.Items.Count)
                return;

            OpenTable(listBox, listBox.SelectedIndex);
        }
    }
}
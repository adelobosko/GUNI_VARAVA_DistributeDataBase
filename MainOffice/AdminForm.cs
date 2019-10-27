using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var storeTables = new[]
            {
                "CashRegisterAccesses", "CashRegisters", "ConnectingStrings", "Departaments", "Employees", "EmployeeWorkLogs", "LackLogs", "MerchandiseAcceptanceLogs", "Merchandises", "PerformedStoreOrders", "Positions", "Products", "Purchases", "RealEstateContacts", "RealEstates", "RealEstateTypes", "StatusOrders", "StoreOrders", "Users"
            };

            storeListBox.Items.AddRange(storeTables);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListBox listBox) || listBox.SelectedIndex < 0 || listBox.SelectedIndex >= listBox.Items.Count)
                return;

            OpenTable(listBox, listBox.SelectedIndex);
        }

        private void SQLQueryButton_Click(object sender, EventArgs e)
        {
            var DataSource = @"(localdb)\MSSQLLocalDB";
            var InitialCatalog = "VaravaStore";
            var UserId = "sa";
            var UserPassword = "2584744";
            string connectionString = $@"Data Source={DataSource};Initial Catalog={InitialCatalog};User ID={UserId};Password={UserPassword};integrated security=False;MultipleActiveResultSets=True;";

            var sqlText = SQLTextBox.Text;
            SQLTextBox.Text += "\r\n";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlText, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        SQLTextBox.Text += $"{reader.GetName(i)}\t";
                    }
                    

                    while (reader.Read())
                    {
                        SQLTextBox.Text += "\r\n";
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            SQLTextBox.Text += $"{reader.GetValue(i)}\t";
                        }

                    }
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SQLCommandButton_Click(object sender, EventArgs e)
        {
            var DataSource = @"(localdb)\MSSQLLocalDB";
            var InitialCatalog = "VaravaStore";
            var UserId = "sa";
            var UserPassword = "2584744";
            string connectionString = $@"Data Source={DataSource};Initial Catalog={InitialCatalog};User ID={UserId};Password={UserPassword};integrated security=False;MultipleActiveResultSets=True;";

            var sqlText = SQLTextBox.Text;
            SQLTextBox.Text += "\r\n";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
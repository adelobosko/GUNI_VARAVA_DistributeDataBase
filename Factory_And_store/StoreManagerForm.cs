using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_Model;
using static EF_Model.DistributedDataBaseContainer;

namespace Factory_And_store
{
    public partial class StoreManagerForm : Form
    {
        public StoreManagerForm()
        {
            InitializeComponent();
            storeVisitEmployeeDataGridView.Columns.Add("worker", "Worker");
            storeVisitEmployeeDataGridView.Columns.Add("workerStartData", "Start data");
            storeVisitEmployeeDataGridView.Columns.Add("workerEndData", "End data");

        }

        private void StoreManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalHelper.AuthorizationForm.Show();
        }

        private void setStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptPanel.Hide();
            merchandisePanel.Hide();
            orderPanel.Hide();
            workVisitPanel.Show();
            performedStoreOrderPanel.Hide();

            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);

            visitEmployeeStoreComboBox.Items.Clear();
            // всі працівники

            var tempEmployees = storeDB.Employees.Where(item => item.IsEnabled);
            // відвідування
            var tempLogEmployees = storeDB.EmployeeWorkLogs.Where(item => item.Employee.IsEnabled);

            // ComboBox
            foreach (var i in tempEmployees)
            {
                visitEmployeeStoreComboBox.Items.Add(new { Text = $"{i.FirstName} {i.SecondName} {i.MiddleName}", Value = i });
            }
            foreach (var i in tempLogEmployees)
            {
                storeVisitEmployeeDataGridView.Rows.Add($"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName}",
                                                                    $"{i.DateTimeStart}",
                                                                    $"{i.DateTimeEnd}");
            }
            visitEmployeeStoreComboBox.Sorted = true;
            visitEmployeeStoreComboBox.SelectedIndex = 0;
            visitEmployeeStoreShiftComboBox.SelectedIndex = 0;
            storeVisitEmployeeRefreshButton.PerformClick();
        }

        private DateTime shiftDateTime(DateTime dt, String shift, bool l)
        {
            DateTime dateTime = new DateTime();
            if (!l)
            {
                switch (shift)
                {
                    case "I":
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 6, 0, 0);
                        break;
                    case "II":
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 14, 0, 0);
                        break;
                    default:
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 22, 0, 0);
                        break;
                }
            }
            else
            {
                switch (shift)
                {
                    case "I":
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 15, 0, 0);
                        break;
                    case "II":
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 23, 0, 0);
                        break;
                    default:
                        dateTime = new DateTime(dt.Year, dt.Month, dt.Day + 1, 6, 0, 0);
                        break;
                }

            }
            return dateTime;
        }

        private void storeVisitEmployeeButton_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            Guid workerID = (visitEmployeeStoreComboBox.SelectedItem as dynamic).Value.ID_Employee;
            var tempLogEmployees = storeDB.EmployeeWorkLogs.Where(item => item.ID_Employee == workerID);

            var newWorkLog = new EmployeeWorkLog()
            {
                ID_EmployeeWorkLog = Guid.NewGuid(),
                ID_Employee = workerID,
                DateTimeStart = shiftDateTime(storeVisitEmployeeDateTimePicker.Value, visitEmployeeStoreShiftComboBox.Text, false),
                DateTimeEnd = shiftDateTime(storeVisitEmployeeDateTimePicker.Value, visitEmployeeStoreShiftComboBox.Text, true)
            };

            storeDB.EmployeeWorkLogs.Add(newWorkLog);

            storeDB.SaveChanges();

            storeVisitEmployeeRefreshButton.PerformClick();
        }

        private void storeVisitEmployeeRefreshButton_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
             var comList = storeDB.EmployeeWorkLogs.Select(item => item);
             if (checkBox1.Checked)
             {
                 Guid workerID = (visitEmployeeStoreComboBox.SelectedItem as dynamic).Value.ID_Employee;
                 comList = comList.Where(item => item.ID_Employee == workerID);
             }
             if (checkBox2.Checked)
             {
                 int shiftValue = 0;
                 switch (visitEmployeeStoreShiftComboBox.Text)
                 {
                     case "I":
                         shiftValue = 6;
                         break;
                     case "II":
                         shiftValue = 14;
                         break;
                     default:
                         shiftValue = 22;
                         break;
                 }
                 comList = comList.Where(item => item.DateTimeStart.Hour == shiftValue);
             }
             if (checkBox3.Checked)
             {
                 DateTime dataFound = storeVisitEmployeeDateTimePicker.Value;
                 comList = comList.Where(item => item.DateTimeStart.Day == dataFound.Day && item.DateTimeStart.Month == dataFound.Month && item.DateTimeStart.Year == dataFound.Year);
             }
            var tempEmployees = storeDB.Employees.Where(item => item.IsEnabled);
            storeVisitEmployeeDataGridView.Rows.Clear();
            foreach (var i in comList)
            {
                Console.WriteLine($"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName} {i.DateTimeStart} {i.DateTimeEnd}");
                storeVisitEmployeeDataGridView.Rows.Add($"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName}",
                    $"{i.DateTimeStart}",
                    $"{i.DateTimeEnd}");
            }
        }

        private void makeAnOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            acceptPanel.Hide();
            merchandisePanel.Hide();
            orderPanel.Show();
            workVisitPanel.Hide();
            performedStoreOrderPanel.Hide();

            comboBox1.Items.Clear();

            var tempCookies = storeDB.Products.Select(item => item);
            var tempOrders = storeDB.StoreOrders.Select(item => item);

            foreach (var i in tempCookies)
            {
                comboBox1.Items.Add(new { Text = $"{i.ProductName}", Value = i });
            }

            refreshOrderButton.PerformClick();
            comboBox1.Sorted = true;
            comboBox1.SelectedIndex = 0;
            string pos = "StoreManager";
            var comList = storeDB.Employees.Where(item => item.Position.NamePosition == pos);
            foreach (var i in comList)
            {
                comboBox2.Items.Add(new { Text = $"{i.FirstName} {i.SecondName} {i.MiddleName}", Value = i });
            }
            comboBox2.Sorted = true;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            Guid cookie = (comboBox1.SelectedItem as dynamic).Value.ID_Product;
            var tempCookies = storeDB.Products.Where(item => item.ID_Product == cookie);
            pictureBox1.Image = Image.FromFile(tempCookies.Select(item => item.Photo).Single().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid produtID = (comboBox1.SelectedItem as dynamic).Value.ID_Product;
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            var newOrder = new StoreOrder()
            {
                ID_StoreOrder = Guid.NewGuid(),
                ID_Product = produtID,
                ID_RealEstateStore = GlobalHelper.User.Employee.RealEstate.ID_RealEstate,
                ID_StoreManager = GlobalHelper.User.ID_Employee,
                ID_StatusOrder = storeDB.StatusOrders.Where(item => item.NameStatusOrder == "Created").Select(item => item.ID_StatusOrder).Single(),
                InitialDate = DateTime.Now,
                Weight = (int)numericUpDown1.Value
            };

            storeDB.StoreOrders.Add(newOrder);

            storeDB.SaveChanges();

            refreshOrderButton.PerformClick();
        }

        private void RefreshOrderButton_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            var comList = storeDB.StoreOrders.Select(item => item);
            if (checkBox6.Checked)
            {
                comList = comList.Where(item => item.InitialDate == new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day));
            }
            if (checkBox7.Checked)
            {
                Guid workerID = (comboBox2.SelectedItem as dynamic).Value.ID_Employee;
                comList = comList.Where(item => item.ID_StoreManager == workerID);
            }
            if (checkBox4.Checked)
            {
                Guid cookieID = (comboBox1.SelectedItem as dynamic).Value.ID_Product;
                comList = comList.Where(item => item.ID_Product == cookieID);
            }
            if (checkBox5.Checked)
            {
                var weight = Convert.ToInt32(numericUpDown1.Value);
                comList = comList.Where(item => item.Weight == weight);
            }
            dataGridView1.Rows.Clear();
            foreach (var i in comList)
            {
                dataGridView1.Rows.Add(i.ID_StoreOrder,
                    $"{i.Product.ProductName}",
                    $"{i.RealEstate.NameRealEstate}",
                    $"{i.Weight}",
                    $"{i.InitialDate}",
                    $"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName}",
                    $"{i.StatusOrder.NameStatusOrder}");
            }
        }

        private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            acceptPanel.Show();
            merchandisePanel.Hide();
            orderPanel.Hide();
            workVisitPanel.Hide();
            performedStoreOrderPanel.Hide();
            dataGridView2.Rows.Clear();
            var tempOrders = storeDB.StoreOrders.Where(item => item.StatusOrder.NameStatusOrder != "Accepted by the store");
            int c = 0;
            foreach (var i in tempOrders)
            {
                dataGridView2.Rows.Add();
                dataGridView2["idColumn", c].Value = i.ID_StoreOrder;
                dataGridView2["imageColumn", c].Value = Image.FromFile(i.Product.Photo);
                dataGridView2["initialDateColumn", c].Value = i.InitialDate.ToString();
                dataGridView2["weightColumn", c].Value = i.Weight;
                c++;
            }

            label4.Text = $"Count active orders: {tempOrders.Count().ToString()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView2[0, i].Value))
                {
                    var newr = new MerchandiseAcceptanceLog()
                    {
                        ID_StoreOrder = Guid.Parse(dataGridView2["idColumn", i].Value.ToString()),
                        ID_AcceptManager = GlobalHelper.User.ID_Employee,
                        AcceptDate = DateTime.Now,
                        Weight = Convert.ToInt32(dataGridView2["weightColumn", i].Value)
                    };
                    storeDB.MerchandiseAcceptanceLogs.Add(newr);
                    storeDB.SaveChanges();

                    var id_o = Guid.Parse(dataGridView2["idColumn", i].Value.ToString());
                    var order = storeDB.StoreOrders.SingleOrDefault(item =>
                        item.ID_StoreOrder == id_o);
                    if (order == null) { return; }

                    order.ID_StatusOrder =
                        storeDB.StatusOrders.SingleOrDefault(item => item.NameStatusOrder == "Accepted by the store").ID_StatusOrder;

                    storeDB.SaveChanges();

                    var newm = new Merchandise()
                    {
                        ID_Merchandise = Guid.NewGuid(),
                        ID_Product = order.ID_Product,
                        ID_RealEstate = order.ID_RealEstateStore,
                        Weight = newr.Weight,
                        ManufactureDate = newr.AcceptDate,
                        PricePerGramm = 15
                    };
                    storeDB.Merchandises.Add(newm);
                    storeDB.SaveChanges();
                }
            }
            acceptToolStripMenuItem.PerformClick();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var countCheckedRows = 0;
                for (var i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (e.RowIndex == i)
                    {
                        if (Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[0].EditedFormattedValue))
                        {
                            countCheckedRows++;
                        }
                        continue;
                    }

                    if (Convert.ToBoolean(dataGridView2[0, i].Value))
                    {
                        countCheckedRows++;
                    }
                }
                label3.Text = $"Count selected orders: {countCheckedRows}";
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int countCheckedRows = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (Convert.ToBoolean(dataGridView2[0, i].Value))
                        countCheckedRows++;
                }
                label3.Text = $"Count selected orders: {countCheckedRows}";
            }
        }

        private void acceptedOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptPanel.Hide();
            merchandisePanel.Hide();
            orderPanel.Hide();
            workVisitPanel.Hide();
            performedStoreOrderPanel.Show();
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            dataGridView3.Rows.Clear();
            var tempOrders = storeDB.MerchandiseAcceptanceLogs.Where(item => item.StoreOrder.StatusOrder.NameStatusOrder == "Accepted by the store");
            var emp = storeDB.Employees.Select(item => item);
            int c = 0;
            foreach (var i in tempOrders)
            {
                dataGridView3.Rows.Add();
                dataGridView3["idAcColumn", c].Value = i.ID_StoreOrder;
                dataGridView3["productimColumn", c].Value = Image.FromFile(i.StoreOrder.Product.Photo);
                dataGridView3["productColumn", c].Value = i.StoreOrder.Product.ProductName;
                dataGridView3["cmanagerColumn", c].Value = $"{i.StoreOrder.Employee.FirstName} {i.StoreOrder.Employee.SecondName} {i.StoreOrder.Employee.MiddleName}";
                dataGridView3["amanagerColumn", c].Value = $"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName}";
                dataGridView3["inDateColumn", c].Value = i.StoreOrder.InitialDate;
                dataGridView3["acDateColumn", c].Value = i.AcceptDate;
                dataGridView3["sweightColumn", c].Value = i.StoreOrder.Weight;
                dataGridView3["eweightColumn", c].Value = i.Weight;
                dataGridView3["differenceColumn", c].Value = Math.Abs(i.StoreOrder.Weight - i.Weight);
                c++;
            }

            label4.Text = $"Count active orders: {tempOrders.Count().ToString()}";
        }

        private void viewMerchandiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptPanel.Hide();
            merchandisePanel.Show();
            orderPanel.Hide();
            workVisitPanel.Hide();
            performedStoreOrderPanel.Hide();
            var storeDB = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
            dataGridView4.Rows.Clear();
            var tempMerch = storeDB.Merchandises.Select(item => item);
            int c = 0;
            foreach (var i in tempMerch)
            {
                dataGridView4.Rows.Add();
                dataGridView4["idmerColumn", c].Value = i.ID_Merchandise;
                dataGridView4["productimColumn2", c].Value = Image.FromFile(i.Product.Photo);
                dataGridView4["productColumn2", c].Value = i.Product.ProductName;
                dataGridView4["weightColumn2", c].Value =  i.Weight;
                c++;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

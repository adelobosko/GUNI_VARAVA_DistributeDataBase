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
            visitEmployeeStoreComboBox.Items.Clear();
            // всі працівники
            var tempEmployees = GlobalHelper.Store.Employees.Where(item => item.IsEnabled);
            // відвідування
            var tempLogEmployees = GlobalHelper.Store.EmployeeWorkLogs.Where(item => item.Employee.IsEnabled);

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

            Guid workerID = (visitEmployeeStoreComboBox.SelectedItem as dynamic).Value.ID_Employee;
            var tempLogEmployees = GlobalHelper.Store.EmployeeWorkLogs.Where(item => item.ID_Employee == workerID);

            var newWorkLog = new EmployeeWorkLog()
            {
                ID_EmployeeWorkLog = Guid.NewGuid(),
                ID_Employee = workerID,
                DateTimeStart = shiftDateTime(storeVisitEmployeeDateTimePicker.Value, visitEmployeeStoreShiftComboBox.Text, false),
                DateTimeEnd = shiftDateTime(storeVisitEmployeeDateTimePicker.Value, visitEmployeeStoreShiftComboBox.Text, true)
            };

            GlobalHelper.Store.EmployeeWorkLogs.Add(newWorkLog);

            GlobalHelper.Store.SaveChanges();

            storeVisitEmployeeRefreshButton.PerformClick();
        }

        private void storeVisitEmployeeRefreshButton_Click(object sender, EventArgs e)
        {
            var comList = GlobalHelper.Store.EmployeeWorkLogs.Select(item => item);
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
            var tempEmployees = GlobalHelper.Store.Employees.Where(item => item.IsEnabled);
            storeVisitEmployeeDataGridView.Rows.Clear();
            foreach (var i in comList)
            {
                storeVisitEmployeeDataGridView.Rows.Add($"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.FirstName).Single().ToString()}",
                    $"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.SecondName).Single().ToString()}",
                    $"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.MiddleName).Single().ToString()}",
                    $"{i.DateTimeStart}",
                    $"{i.DateTimeEnd}");
            }
        }

        private void makeAnOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptPanel.Hide();
            merchandisePanel.Hide();
            orderPanel.Show();
            workVisitPanel.Hide();

            comboBox1.Items.Clear();

            var tempCookies = GlobalHelper.Store.Products.Select(item => item);
            var tempOrders = GlobalHelper.Store.StoreOrders.Select(item => item);

            foreach (var i in tempCookies)
            {
                comboBox1.Items.Add(new { Text = $"{i.ProductName}", Value = i });
            }

            refreshOrderButton.PerformClick();
            comboBox1.Sorted = true;
            comboBox1.SelectedIndex = 0;
            string pos = "StoreManager";
            var comList = GlobalHelper.Store.Employees.Where(item => item.Position.NamePosition == pos);
            foreach (var i in comList)
            {
                comboBox2.Items.Add(new { Text = $"{i.FirstName} {i.SecondName} {i.MiddleName}", Value = i });
            }
            comboBox2.Sorted = true;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid cookie = (comboBox1.SelectedItem as dynamic).Value.ID_Product;
            var tempCookies = GlobalHelper.Store.Products.Where(item => item.ID_Product == cookie);
            pictureBox1.Image = Image.FromFile(tempCookies.Select(item => item.Photo).Single().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid produtID = (comboBox1.SelectedItem as dynamic).Value.ID_Product;

            var newOrder = new StoreOrder()
            {
                ID_StoreOrder = Guid.NewGuid(),
                ID_Product = produtID,
                ID_RealEstateStore = GlobalHelper.User.Employee.RealEstate.ID_RealEstate,
                ID_StoreManager = GlobalHelper.User.ID_Employee,
                ID_StatusOrder = GlobalHelper.Store.StatusOrders.Where(item => item.NameStatusOrder == "Created").Select(item => item.ID_StatusOrder).Single(),
                InitialDate = DateTime.Now,
                Weight = (int)numericUpDown1.Value
            };

            GlobalHelper.Store.StoreOrders.Add(newOrder);

            GlobalHelper.Store.SaveChanges();

            refreshOrderButton.PerformClick();
        }

        private void RefreshOrderButton_Click(object sender, EventArgs e)
        {
            var comList = GlobalHelper.Store.StoreOrders.Select(item => item);
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
            int c = 0;
            foreach (var i in comList)
            {
                c++;
                dataGridView1.Rows.Add(i.ID_StoreOrder,
                    $"{i.Product.ProductName}",
                    $"{i.RealEstate.NameRealEstate}",
                    $"{i.Weight}",
                    $"{i.InitialDate}",
                    $"{i.Employee.FirstName} {i.Employee.SecondName} {i.Employee.MiddleName}");

            }
        }

        private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptPanel.Show();
            merchandisePanel.Hide();
            orderPanel.Hide();
            workVisitPanel.Hide();

            var tempOrders = GlobalHelper.Store.StoreOrders.Select(item => item);
            int c = 0;
            foreach (var i in tempOrders)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[c].Cells[1].Value = i.ID_StoreOrder;
                dataGridView2.Rows[c].Cells[2].Value = Image.FromFile(i.Product.Photo);
                dataGridView2.Rows[c].Cells[3].Value = i.InitialDate.ToString();
                dataGridView2.Rows[c].Cells[5].Value = i.Weight;
                c++;
            }
            foreach (var j in GlobalHelper.Store.Employees.Where(item => item.Position.NamePosition == "Carrier"))
            {
                Column4.Items.Add(new { Text = $"{j.FirstName} {j.SecondName} {j.MiddleName}", Value = j });
            }
            Column4.Sorted = true;
            Column4.ValueMember = "Value";
            Column4.DisplayMember = "Text";

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private int lastRow = -1;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int countCheckedRows = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {;
                    if (Convert.ToBoolean(dataGridView2[0, i].Value))
                        countCheckedRows++;
                }

                
                countCheckedRows += (Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[0].EditedFormattedValue))
                    ? 1
                    : lastRow == e.RowIndex
                        ? 0
                        :-1;
                lastRow = e.RowIndex;
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
    }
}

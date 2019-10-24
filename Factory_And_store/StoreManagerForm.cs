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
            storeVisitEmployeeDataGridView.Columns.Add("workerFirstName", "First name");
            storeVisitEmployeeDataGridView.Columns.Add("workerSecondName", "Second name");
            storeVisitEmployeeDataGridView.Columns.Add("workerMiddleName", "Middle name");
            storeVisitEmployeeDataGridView.Columns.Add("workerStartData", "Start data");
            storeVisitEmployeeDataGridView.Columns.Add("workerEndData", "End data");


            dataGridView1.Columns.Add("OrderNum", "№");
            dataGridView1.Columns.Add("OrderCookieName", "Cookie name");
            dataGridView1.Columns.Add("OrderCookieAmount", "Weight");
            dataGridView1.Columns.Add("OrderDate", "Date");
            dataGridView1.Columns.Add("Manager", "Manager");
        }

        private void StoreManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalHelper.AuthorizationForm.Show();
        }

        private void setStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newsPanel.Hide();
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
                storeVisitEmployeeDataGridView.Rows.Add($"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.FirstName).Single().ToString()}",
                                                                    $"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.SecondName).Single().ToString()}",
                                                                    $"{tempEmployees.Where(item => item.ID_Employee == i.ID_Employee).Select(item => item.MiddleName).Single().ToString()}",
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
            newsPanel.Hide();
            merchandisePanel.Hide();
            orderPanel.Show();
            workVisitPanel.Hide();

            comboBox1.Items.Clear();

            var tempCookies = GlobalHelper.Store.Products.Select(item => item);
            var tempOrders= GlobalHelper.Store.StoreOrders.Select(item => item);
            
            foreach (var i in tempCookies)
            {
                comboBox1.Items.Add(new { Text = $"{i.ProductName}", Value = i });
            }

            int c = 0;
            foreach (var i in tempOrders)
            {
                c++;
                var tempManagers = GlobalHelper.Store.Employees.Where(item => item.ID_Employee == i.ID_StoreManager);
                dataGridView1.Rows.Add(c.ToString(),
                    $"{tempCookies.Where(item => item.ID_Product == i.ID_Product).Select(item => item.ProductName).Single().ToString()}",
                    $"{i.Weight}",
                    $"{i.InitialDate}",
                    $"{tempManagers.ToString()}");
            }
            comboBox1.Sorted = true;
            comboBox1.SelectedIndex = 0;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid cookie = (comboBox1.SelectedItem as dynamic).Value.ID_Product;
            var tempCookies = GlobalHelper.Store.Products.Where(item => item.ID_Product == cookie);
            pictureBox1.Image = Image.FromFile(tempCookies.Select(item => item.Photo).Single().ToString());
            //label2.Text = tempCookies.Select(item => item.Photo).Single().ToString();
        }
    }
}

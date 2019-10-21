using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EF_Model.DistributedDataBaseContainer;

namespace Factory_And_store
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            loginStoreTextBox.Validating += LoginStoreTextBoxValidating;
            passwordStoreTextBox.Validating += LoginStoreTextBoxValidating;
        }

        private void LoginStoreTextBoxValidating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorStoreProvider.SetError(textBox, $"Please input {textBox.Name.Replace("TextBox", "")}!");
            }
            else
            {
                errorStoreProvider.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DomesticDataBase.DataSource = "(localdb)\\MSSQLLocalDB";
            DomesticDataBase.InitialCatalog = "VaravaStore";
            DomesticDataBase.UserId = "sa";
            DomesticDataBase.UserPassword = "2584744";


            GlobalHelper.Store = GenerateConnection(DataBaseType.Store, ConnectionType.Host);



            var tablesName = GlobalHelper.Store.DataBaseTables.Select(t => t.TableName).ToList();

            var res = GlobalHelper.Store.Positions.Select(i => i).ToList();
            MessageBox.Show(res.Count.ToString());
            MessageBox.Show(res[0].NamePosition);

            connectedStoreLabel.Text = GlobalHelper.MainOffice.Users.Any() ? "Connected" : "Connection failed. Please, call to admin for correct this mistake!";

            var connectionType = ConnectionType.Host;
            GlobalHelper.Factory = GenerateConnection(DataBaseType.Factory, connectionType);
            GlobalHelper.Store = GenerateConnection(DataBaseType.Store, connectionType);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            resultStoreLabel.Text = "";
            if (Keys.Enter == e.KeyCode)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private static bool Authorization(string login, string password)
        {
            var user = GlobalHelper.MainOffice.Users
                .FirstOrDefault(u => u.UserLogin == login && u.UserPassword == password);

            if (user == null)
            {
                return false;
            }

            GlobalHelper.User = user;

            return true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var isLogined = Authorization(loginStoreTextBox.Text, passwordStoreTextBox.Text);
            if (!isLogined)
            {
                resultStoreLabel.Text = "Login or Password is not correct.";
                return;
            }

            this.Hide();
            passwordStoreTextBox.Text = "";
            GlobalHelper.AuthorizationForm = this;

            if (GlobalHelper.User.Employee.Position.NamePosition == "Admin")
            {
                new StoreManagerForm().Show();
            }
        }
    }
}

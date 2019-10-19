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

namespace MainOffice
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            loginTextBox.Validating += LoginTextBox_Validating;
            passwordTextBox.Validating += LoginTextBox_Validating;
        }

        private void LoginTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox) sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, $"Please input {textBox.Name.Replace("TextBox","")}!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalHelper.MainOffice = GenerateConnection(dataBaseType: DataBaseType.MainOffice, connectionType: ConnectionType.Host);

            connectedLabel.Text = GlobalHelper.MainOffice.Users.Any() ? "Connected" : "Connection failed. Please, call to admin for correct this mistake!";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            resultLabel.Text = "";
            if (Keys.Enter == e.KeyCode)
            {
                var control = (Control) sender;
                
                if(control.Name == loginTextBox.Name)
                {
                    passwordTextBox.Focus();
                }
                else
                {
                    loginButton.Focus();
                }
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
            var isLogined = Authorization(loginTextBox.Text, passwordTextBox.Text);
            if (!isLogined)
            {
                resultLabel.Text = "Login or Password is not correct.";
                return;
            }
            
            this.Hide();
            passwordTextBox.Text = "";
            if (GlobalHelper.User.Employee.Position.NamePosition == "Admin")
            {
                new AdminForm().Show();
            }
        }
    }
}

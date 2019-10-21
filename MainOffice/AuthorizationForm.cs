﻿using System;
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
            DomesticDataBase.DataSource = "127.0.0.1,31340";
            DomesticDataBase.InitialCatalog = "VaravaMainOffice";
            DomesticDataBase.UserId = "sa";
            DomesticDataBase.UserPassword = "2584744";

            GlobalHelper.MainOffice = GenerateConnection(dataBaseType: DataBaseType.MainOffice, connectionType: ConnectionType.Host);
            connectedLabel.Text = GlobalHelper.MainOffice.Users.Any() ? "Connected" : "Connection failed. Please, call to admin for correct this mistake!";

            var connectionType = ConnectionType.Host;
            GlobalHelper.Factory = GenerateConnection(DataBaseType.Factory, connectionType);
            GlobalHelper.Store = GenerateConnection(DataBaseType.Store, connectionType);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            resultLabel.Text = "";
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
            var isLogined = Authorization(loginTextBox.Text, passwordTextBox.Text);
            if (!isLogined)
            {
                resultLabel.Text = "Login or Password is not correct.";
                return;
            }
            
            this.Hide();
            passwordTextBox.Text = "";
            GlobalHelper.AuthorizationForm = this;

            if (GlobalHelper.User.Employee.Position.NamePosition == "Admin")
            {
                new AdminForm().Show();
            }
        }
    }
}

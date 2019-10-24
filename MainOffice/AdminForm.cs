using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EF_Model;
using Control = System.Windows.Forms.Control;

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


        private static Panel CreateCheckBox(string columnName, int tabIndex)
        {
            var panel = new Panel
            {
                Name = $"{columnName}Panel",
                Dock = DockStyle.Top,
                Height = 30
            };

            var dataCheckBox = new CheckBox
            {
                Name = $"{columnName}CheckBox",
                AutoSize = true,
                Text = columnName,
                Dock = DockStyle.Left,
                TabIndex = tabIndex
            };

            panel.Controls.Add(dataCheckBox);

            return panel;
        }

        private static Panel CreateDateTimePicker(string columnName, int tabIndex)
        {
            var panel = new Panel
            {
                Name = $"{columnName}Panel",
                Dock = DockStyle.Top,
                Height = 30
            };

            var dataDateTimePicker = new DateTimePicker()
            {
                Name = $"{columnName}DateTimePicker",
                AutoSize = true,
                Dock = DockStyle.Left,
                TabIndex = tabIndex,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm dd.MM.yyyy"
            };

            panel.Controls.Add(dataDateTimePicker);

            return panel;
        }

        private static Panel CreateTextBox(string columnName, int tabIndex, bool isPrimary)
        {
            var panel = new Panel
            {
                Name = $"{columnName}Panel",
                Dock = DockStyle.Top,
                Height = 30,
                TabIndex = tabIndex
            };


            var dataLabel = new Label()
            {
                Name = $"{columnName}Label",
                AutoSize = true,
                Dock = DockStyle.Left,
                Text = $@"{columnName}:"
            };

            var dataTextBox = new TextBox
            {
                Name = $"{columnName}TextBox",
                Dock = DockStyle.Fill,
                ReadOnly = isPrimary,
                TabIndex = tabIndex
            };

            panel.Controls.Add(dataTextBox);
            panel.Controls.Add(dataLabel);

            return panel;
        }

        private static Panel CreateMaskedTextBox(string columnName, int tabIndex, bool isPrimary)
        {
            var panel = new Panel
            {
                Name = $"{columnName}Panel",
                Dock = DockStyle.Top,
                Height = 30,
                TabIndex = tabIndex
            };


            var dataLabel = new Label()
            {
                Name = $"{columnName}Label",
                AutoSize = true,
                Dock = DockStyle.Left,
                Text = $@"{columnName}:"
            };

            var dataTextBox = new MaskedTextBox()
            {
                Name = $"{columnName}MaskedTextBox",
                Dock = DockStyle.Fill,
                ReadOnly = isPrimary,
                Mask = "(000) 000-0000",
                TabIndex = tabIndex
            };

            panel.Controls.Add(dataTextBox);
            panel.Controls.Add(dataLabel);

            return panel;
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.Text =
                $"{GlobalHelper.User.Employee.FirstName} {GlobalHelper.User.Employee.SecondName} {GlobalHelper.User.Employee.MiddleName}";
        }

        private void OpenTable(int selectedIndex)
        {
            horizontalMainOfficeSplitContainer.Panel2.Controls.Clear();
            horizontalMainOfficeSplitContainer.Panel1.Controls.Clear();

            var mainOfficeDataGridView = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                MultiSelect = false,
                Name = "mainOfficeDataGridView",
                ReadOnly = true,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                Size = new Size(611, 203),
                TabStop = false
            };

            horizontalMainOfficeSplitContainer.Panel1.Controls.Add(mainOfficeDataGridView);

            switch (mainOfficeListBox.Items[selectedIndex].ToString())
            {
                case "ConnectingStrings":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 6
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 7
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 8
                    };


                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);
                    mainOfficeDataGridView.Columns.Add("ID_ConnectingString", "ID_ConnectingString");
                    mainOfficeDataGridView.Columns.Add("DataSource", "DataSource");
                    mainOfficeDataGridView.Columns.Add("ConnectionType", "ConnectionType");
                    mainOfficeDataGridView.Columns.Add("InitialCatalog", "InitialCatalog");
                    mainOfficeDataGridView.Columns.Add("UserId", "UserId");
                    mainOfficeDataGridView.Columns.Add("UserPassword", "UserPassword");

                    var ID_ConnectingStringPanel = CreateTextBox("ID_ConnectingString", 0, true);
                    var DataSourcePanel = CreateTextBox("DataSource", 1, false);
                    var ConnectionTypePanel = CreateTextBox("ConnectionType", 2, false);
                    var InitialCatalogPanel = CreateTextBox("InitialCatalog", 3, false);
                    var UserIdPanel = CreateTextBox($"UserId", 4, false);
                    var UserPasswordPanel = CreateTextBox($"UserPassword", 5, false);

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(UserPasswordPanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(UserIdPanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(InitialCatalogPanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(ConnectionTypePanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(DataSourcePanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(ID_ConnectingStringPanel);

                    var ID_ConnectingStringTextBox = ID_ConnectingStringPanel
                        .Controls.Find($"ID_ConnectingStringTextBox", true)[0] as TextBox;
                    var DataSourceTextBox = DataSourcePanel
                        .Controls.Find($"DataSourceTextBox", true)[0] as TextBox;
                    var ConnectionTypeTextBox = ConnectionTypePanel
                        .Controls.Find($"ConnectionTypeTextBox", true)[0] as TextBox;
                    var InitialCatalogTextBox = InitialCatalogPanel
                        .Controls.Find($"InitialCatalogTextBox", true)[0] as TextBox;
                    var UserIdTextBox = UserIdPanel
                        .Controls.Find($"UserIdTextBox", true)[0] as TextBox;
                    var userPasswordTextBox = UserPasswordPanel
                        .Controls.Find($"UserPasswordTextBox", true)[0] as TextBox;

                    var table = GlobalHelper.MainOffice.ConnectingStrings.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();
                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_ConnectingString", i].Value =
                            table[i].ID_ConnectingString.ToString();

                        mainOfficeDataGridView["DataSource", i].Value =
                            table[i].DataSource;

                        mainOfficeDataGridView["ConnectionType", i].Value =
                            table[i].ConnectionType;

                        mainOfficeDataGridView["InitialCatalog", i].Value =
                            table[i].InitialCatalog;

                        mainOfficeDataGridView["UserId", i].Value =
                            table[i].UserId;

                        mainOfficeDataGridView["UserPassword", i].Value =
                            table[i].UserPassword;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var cs = new ConnectingString()
                        {
                            ID_ConnectingString = Guid.NewGuid(),
                            DataSource = DataSourceTextBox.Text,
                            ConnectionType = ConnectionTypeTextBox.Text,
                            InitialCatalog = InitialCatalogTextBox.Text,
                            UserId = UserIdTextBox.Text,
                            UserPassword = userPasswordTextBox.Text
                        };

                        GlobalHelper.MainOffice.ConnectingStrings.Add(cs);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(ID_ConnectingStringTextBox.Text);
                        var connectingString = GlobalHelper.MainOffice.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);

                        if (connectingString == null)
                            return;

                        connectingString.DataSource = DataSourceTextBox.Text;
                        connectingString.ConnectionType = ConnectionTypeTextBox.Text;
                        connectingString.InitialCatalog = InitialCatalogTextBox.Text;
                        connectingString.UserId = UserIdTextBox.Text;
                        connectingString.UserPassword = userPasswordTextBox.Text;
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(ID_ConnectingStringTextBox.Text);
                        var connectingString = GlobalHelper.MainOffice.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);

                        if (connectingString == null)
                            return;

                        GlobalHelper.MainOffice.ConnectingStrings.Remove(connectingString);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                     {
                         if (args.RowIndex < 0)
                             return;

                         ID_ConnectingStringTextBox.Text = mainOfficeDataGridView["ID_ConnectingString", args.RowIndex]
                             .Value.ToString();
                         DataSourceTextBox.Text = mainOfficeDataGridView["DataSource", args.RowIndex]
                             .Value.ToString();
                         ConnectionTypeTextBox.Text = mainOfficeDataGridView["ConnectionType", args.RowIndex]
                             .Value.ToString();
                         InitialCatalogTextBox.Text = mainOfficeDataGridView["InitialCatalog", args.RowIndex]
                             .Value.ToString();
                         UserIdTextBox.Text = mainOfficeDataGridView["UserId", args.RowIndex]
                             .Value.ToString();
                         userPasswordTextBox.Text = mainOfficeDataGridView["userPassword", args.RowIndex]
                             .Value.ToString();
                     };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Departaments":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 6
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 7
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 8
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);
                    mainOfficeDataGridView.Columns.Add("ID_Departament", "ID_Departament");
                    mainOfficeDataGridView.Columns.Add("NameDepartament", "NameDepartament");
                    mainOfficeDataGridView.Columns.Add("Description", "Description");

                    var ID_DepartamentPanel = CreateTextBox("ID_Departament", 0, true);
                    var NameDepartamentPanel = CreateTextBox("NameDepartament", 1, false);
                    var DescriptionPanel = CreateTextBox("Description", 2, false);

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(DescriptionPanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(NameDepartamentPanel);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(ID_DepartamentPanel);

                    var ID_DepartamentTextBox = ID_DepartamentPanel
                        .Controls.Find(ID_DepartamentPanel.Name.Replace("Panel", "TextBox"), true)[0] as TextBox;
                    var NameDepartamentTextBox = NameDepartamentPanel
                        .Controls.Find(NameDepartamentPanel.Name.Replace("Panel", "TextBox"), true)[0] as TextBox;
                    var DescriptionTextBox = DescriptionPanel
                        .Controls.Find(DescriptionPanel.Name.Replace("Panel", "TextBox"), true)[0] as TextBox;

                    var table = GlobalHelper.MainOffice.Departaments.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();
                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView[ID_DepartamentTextBox.Name.Replace("TextBox", ""), i].Value = table[i].ID_Departament.ToString();
                        mainOfficeDataGridView[NameDepartamentTextBox.Name.Replace("TextBox", ""), i].Value = table[i].NameDepartament;
                        mainOfficeDataGridView[DescriptionTextBox.Name.Replace("TextBox", ""), i].Value = table[i].Description;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new Departament()
                        {
                            ID_Departament = Guid.NewGuid(),
                            NameDepartament = NameDepartamentTextBox.Text,
                            Description = DescriptionTextBox.Text
                        };

                        GlobalHelper.MainOffice.Departaments.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var ID = Guid.Parse(ID_DepartamentTextBox.Text);
                        var updRow = GlobalHelper.MainOffice.Departaments.SingleOrDefault(t => t.ID_Departament == ID);

                        if (updRow == null)
                            return;

                        updRow.NameDepartament = NameDepartamentTextBox.Text;
                        updRow.Description = DescriptionTextBox.Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var id = Guid.Parse(ID_DepartamentTextBox.Text);
                            var storeUpdRow = GlobalHelper.Store.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            if (storeUpdRow == null)
                                return;

                            storeUpdRow.NameDepartament = NameDepartamentTextBox.Text;
                            storeUpdRow.Description = DescriptionTextBox.Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var id = Guid.Parse(ID_DepartamentTextBox.Text);
                            var factoryUpdRow = GlobalHelper.Factory.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            if (factoryUpdRow == null)
                                return;

                            factoryUpdRow.NameDepartament = NameDepartamentTextBox.Text;
                            factoryUpdRow.Description = DescriptionTextBox.Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(ID_DepartamentTextBox.Text);
                        var delRow = GlobalHelper.MainOffice.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Departaments.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        ID_DepartamentTextBox.Text = mainOfficeDataGridView[ID_DepartamentTextBox.Name.Replace("TextBox", ""), args.RowIndex]
                            .Value.ToString();
                        NameDepartamentTextBox.Text = mainOfficeDataGridView[NameDepartamentTextBox.Name.Replace("TextBox", ""), args.RowIndex]
                            .Value.ToString();
                        DescriptionTextBox.Text = mainOfficeDataGridView[DescriptionTextBox.Name.Replace("TextBox", ""), args.RowIndex]
                            .Value.ToString();
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Employees":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_Employee", CreateTextBox("ID_Employee", tabIndex++, true)},
                        {"ID_Position", CreateTextBox("ID_Position", tabIndex++, false)},
                        {"ID_RealEstate", CreateTextBox("ID_RealEstate", tabIndex++, false)},
                        {"FirstName", CreateTextBox("FirstName", tabIndex++, false)},
                        {"SecondName", CreateTextBox("SecondName", tabIndex++, false)},
                        {"MiddleName", CreateTextBox("MiddleName", tabIndex++, false)},
                        {"Passport", CreateTextBox("Passport", tabIndex++, false)},
                        {"IDK", CreateTextBox("IDK", tabIndex++, false)},
                        {"Telephone", CreateMaskedTextBox("Telephone", tabIndex++, false)},
                        {"IsEnabled", CreateCheckBox("IsEnabled", tabIndex++)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            case "Telephone":
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{maskedTextBoxTypeName}", true)[0]);
                                break;
                            case "IsEnabled":
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{checkBoxTypeName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.Employees.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        mainOfficeDataGridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        mainOfficeDataGridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        mainOfficeDataGridView["FirstName", i].Value = table[i].FirstName;
                        mainOfficeDataGridView["SecondName", i].Value = table[i].SecondName;
                        mainOfficeDataGridView["MiddleName", i].Value = table[i].MiddleName;
                        mainOfficeDataGridView["Passport", i].Value = table[i].Passport;
                        mainOfficeDataGridView["IDK", i].Value = table[i].IDK;
                        mainOfficeDataGridView["Telephone", i].Value = table[i].Telephone;
                        mainOfficeDataGridView["IsEnabled", i].Value = table[i].IsEnabled.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new Employee()
                        {
                            ID_Employee = Guid.NewGuid(),
                            ID_Position = Guid.Parse(controls["ID_Position"].Text),
                            ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text),
                            FirstName = controls["FirstName"].Text,
                            SecondName = controls["SecondName"].Text,
                            MiddleName = controls["MiddleName"].Text,
                            Passport = controls["Passport"].Text,
                            IDK = controls["IDK"].Text,
                            Telephone = controls["Telephone"].Text,
                            IsEnabled = (controls["IsEnabled"] as CheckBox).Checked
                        };

                        GlobalHelper.MainOffice.Employees.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var updRow = GlobalHelper.MainOffice.Employees.SingleOrDefault(t => t.ID_Employee == id);

                        if (updRow == null)
                            return;


                        updRow.ID_Position = new Guid(controls["ID_Position"].Text);
                        updRow.ID_RealEstate = new Guid(controls["ID_RealEstate"].Text);
                        updRow.FirstName = controls["FirstName"].Text;
                        updRow.SecondName = controls["SecondName"].Text;
                        updRow.MiddleName = controls["MiddleName"].Text;
                        updRow.Passport = controls["Passport"].Text;
                        updRow.IDK = controls["IDK"].Text;
                        updRow.Telephone = controls["Telephone"].Text;
                        updRow.IsEnabled = (controls["IsEnabled"] as CheckBox).Checked;

                        GlobalHelper.MainOffice.SaveChanges();

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var delRow = GlobalHelper.MainOffice.Employees.SingleOrDefault(t => t.ID_Employee == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Employees.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "IsEnabled":
                                    (item.Value as CheckBox).Checked =
                                        Convert.ToBoolean(mainOfficeDataGridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "EmployeeWorkLogs":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_EmployeeWorkLog", CreateTextBox("ID_EmployeeWorkLog", tabIndex++, true)},
                        {"ID_Employee", CreateTextBox("ID_Employee", tabIndex++, false)},
                        {"DateTimeStart", CreateDateTimePicker("DateTimeStart", tabIndex++)},
                        {"DateTimeEnd", CreateDateTimePicker("DateTimeEnd", tabIndex++)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            case "DateTimeStart":
                            case "DateTimeEnd":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.EmployeeWorkLogs.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_EmployeeWorkLog", i].Value = table[i].ID_EmployeeWorkLog.ToString();
                        mainOfficeDataGridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        mainOfficeDataGridView["DateTimeStart", i].Value = table[i].DateTimeStart.ToString();
                        mainOfficeDataGridView["DateTimeEnd", i].Value = table[i].DateTimeEnd.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new EmployeeWorkLog()
                        {
                            ID_EmployeeWorkLog = Guid.NewGuid(),
                            ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                            DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value,
                            DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value
                        };

                        GlobalHelper.MainOffice.EmployeeWorkLogs.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_EmployeeWorkLog"].Text);
                        var updRow = GlobalHelper.MainOffice.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);

                        if (updRow == null)
                            return;

                        updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                        updRow.DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value;
                        updRow.DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value;

                        GlobalHelper.MainOffice.SaveChanges();

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_EmployeeWorkLog"].Text);
                        var delRow = GlobalHelper.MainOffice.EmployeeWorkLogs.SingleOrDefault(t =>
                            t.ID_EmployeeWorkLog == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.EmployeeWorkLogs.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "DateTimeStart":
                                case "DateTimeEnd":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(mainOfficeDataGridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "HeadOrders":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_HeadOrder", CreateTextBox("ID_HeadOrder", tabIndex++, true)},
                        {"ID_Position", CreateTextBox("ID_Position", tabIndex++, false)},
                        {"ID_StatusOrder", CreateTextBox("ID_StatusOrder", tabIndex++, false)},
                        {"AssignFor", CreateTextBox("AssignFor", tabIndex++, false)},
                        {"Date", CreateDateTimePicker("Date", tabIndex++)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.HeadOrders.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_HeadOrder", i].Value = table[i].ID_HeadOrder.ToString();
                        mainOfficeDataGridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        mainOfficeDataGridView["ID_StatusOrder", i].Value = table[i].ID_StatusOrder.ToString();
                        mainOfficeDataGridView["AssignFor", i].Value = table[i].AssignFor.ToString();
                        mainOfficeDataGridView["Date", i].Value = table[i].Date.ToString();
                        mainOfficeDataGridView["Description", i].Value = table[i].Description.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new HeadOrder()
                        {
                            ID_HeadOrder = Guid.NewGuid(),
                            ID_Position = Guid.Parse(controls["ID_Position"].Text),
                            ID_StatusOrder = Guid.Parse(controls["ID_StatusOrder"].Text),
                            AssignFor = controls["AssignFor"].Text,
                            Date = (controls["Date"] as DateTimePicker).Value,
                            Description = controls["Description"].Text
                        };

                        GlobalHelper.MainOffice.HeadOrders.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_HeadOrder"].Text);
                        var updRow = GlobalHelper.MainOffice.HeadOrders.SingleOrDefault(t => t.ID_HeadOrder == id);

                        if (updRow == null)
                            return;

                        updRow.ID_Position = Guid.Parse(controls["ID_Position"].Text);
                        updRow.ID_StatusOrder = Guid.Parse(controls["ID_StatusOrder"].Text);
                        updRow.AssignFor = controls["AssignFor"].Text;
                        updRow.Date = (controls["Date"] as DateTimePicker).Value;
                        updRow.Description = controls["Description"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_HeadOrder"].Text);
                        var delRow = GlobalHelper.MainOffice.HeadOrders.SingleOrDefault(t => t.ID_HeadOrder == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.HeadOrders.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "Date":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(mainOfficeDataGridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "PerformedHeadOrders":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_PerformedOrder", CreateTextBox("ID_PerformedOrder", tabIndex++, true)},
                        {"ID_HeadOrder", CreateTextBox("ID_HeadOrder", tabIndex++, false)},
                        {"ID_Employee", CreateTextBox("ID_Employee", tabIndex++, false)},
                        {"Date", CreateDateTimePicker("Date", tabIndex++)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.PerformedHeadOrders.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_PerformedOrder", i].Value = table[i].ID_PerformedOrder.ToString();
                        mainOfficeDataGridView["ID_HeadOrder", i].Value = table[i].ID_HeadOrder.ToString();
                        mainOfficeDataGridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        mainOfficeDataGridView["Date", i].Value = table[i].Date.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new PerformedHeadOrder()
                        {
                            ID_PerformedOrder = Guid.NewGuid(),
                            ID_HeadOrder = Guid.Parse(controls["ID_HeadOrder"].Text),
                            ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                            Date = (controls["Date"] as DateTimePicker).Value
                        };

                        GlobalHelper.MainOffice.PerformedHeadOrders.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_PerformedOrder"].Text);
                        var updRow = GlobalHelper.MainOffice.PerformedHeadOrders.SingleOrDefault(t => t.ID_PerformedOrder == id);

                        if (updRow == null)
                            return;

                        updRow.ID_HeadOrder = Guid.Parse(controls["ID_HeadOrder"].Text);
                        updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                        updRow.Date = (controls["Date"] as DateTimePicker).Value;

                        GlobalHelper.MainOffice.SaveChanges();

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_PerformedOrder"].Text);
                        var delRow = GlobalHelper.MainOffice.PerformedHeadOrders.SingleOrDefault(t => t.ID_PerformedOrder == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.PerformedHeadOrders.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "Date":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(mainOfficeDataGridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Positions":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_Position", CreateTextBox("ID_Position", tabIndex++, true)},
                        {"NamePosition", CreateTextBox("NamePosition", tabIndex++, false)},
                        {"PaymentHrnPerHour", CreateTextBox("PaymentHrnPerHour", tabIndex++, false)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.Positions.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        mainOfficeDataGridView["NamePosition", i].Value = table[i].NamePosition;
                        mainOfficeDataGridView["PaymentHrnPerHour", i].Value = table[i].PaymentHrnPerHour.ToString();
                        mainOfficeDataGridView["Description", i].Value = table[i].Description;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new Position()
                        {
                            ID_Position = Guid.NewGuid(),
                            NamePosition = controls["NamePosition"].Text,
                            PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text),
                            Description = controls["Description"].Text
                        };

                        GlobalHelper.MainOffice.Positions.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            GlobalHelper.Store.Positions.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            GlobalHelper.Factory.Positions.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Position"].Text);
                        var updRow = GlobalHelper.MainOffice.Positions.SingleOrDefault(t => t.ID_Position == id);

                        if (updRow == null)
                            return;

                        updRow.NamePosition = controls["NamePosition"].Text;
                        updRow.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                        updRow.Description = controls["Description"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_Position"].Text);
                            var updRowT = GlobalHelper.Store.Positions.SingleOrDefault(t => t.ID_Position == idT);

                            if (updRowT == null)
                                return;

                            updRowT.NamePosition = controls["NamePosition"].Text;
                            updRowT.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                            updRowT.Description = controls["Description"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idt = Guid.Parse(controls["ID_Position"].Text);
                            var updRowT = GlobalHelper.Factory.Positions.SingleOrDefault(t => t.ID_Position == idt);

                            if (updRowT == null)
                                return;

                            updRowT.NamePosition = controls["NamePosition"].Text;
                            updRowT.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                            updRowT.Description = controls["Description"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Position"].Text);
                        var delRow = GlobalHelper.MainOffice.Positions.SingleOrDefault(t => t.ID_Position == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Positions.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();


                        try
                        {
                            var idT = Guid.Parse(controls["ID_Position"].Text);
                            var delRowT = GlobalHelper.Store.Positions.SingleOrDefault(t => t.ID_Position == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Store.Positions.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT =  Guid.Parse(controls["ID_Position"].Text);
                            var delRowT = GlobalHelper.Factory.Positions.SingleOrDefault(t => t.ID_Position == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Factory.Positions.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstateContacts":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_RealEstateContact", CreateTextBox("ID_RealEstateContact", tabIndex++, true)},
                        {"ID_RealEstate", CreateTextBox("ID_RealEstate", tabIndex++, false)},
                        {"ID_Departament", CreateTextBox("ID_Departament", tabIndex++, false)},
                        {"Telephone", CreateMaskedTextBox("Telephone", tabIndex++, false)},
                        {"Email", CreateTextBox("Email", tabIndex++, false)}

                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            case "Telephone":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{maskedTextBoxTypeName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.RealEstateContacts.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_RealEstateContact", i].Value = table[i].ID_RealEstateContact.ToString();
                        mainOfficeDataGridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        mainOfficeDataGridView["ID_Departament", i].Value = table[i].ID_Departament.ToString();
                        mainOfficeDataGridView["Telephone", i].Value = table[i].Telephone;
                        mainOfficeDataGridView["Email", i].Value = table[i].Email;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new RealEstateContact()
                        {
                            ID_RealEstateContact = Guid.NewGuid(),
                            ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text),
                            ID_Departament = Guid.Parse(controls["ID_Departament"].Text),
                            Telephone = controls["Telephone"].Text,
                            Email = controls["Email"].Text
                        };

                        GlobalHelper.MainOffice.RealEstateContacts.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            GlobalHelper.Store.RealEstateContacts.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            GlobalHelper.Factory.RealEstateContacts.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateContact"].Text);
                        var updRow = GlobalHelper.MainOffice.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                        if (updRow == null)
                            return;

                        updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                        updRow.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                        updRow.Telephone = controls["Telephone"].Text;
                        updRow.Email = controls["Email"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateContact"].Text);
                            var updRowT = GlobalHelper.Store.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == idT);

                            if (updRowT == null)
                                return;

                            updRowT.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            updRowT.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                            updRowT.Telephone = controls["Telephone"].Text;
                            updRowT.Email = controls["Email"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateContact"].Text);
                            var updRowT = GlobalHelper.Factory.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == idT);

                            if (updRowT == null)
                                return;

                            updRowT.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            updRowT.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                            updRowT.Telephone = controls["Telephone"].Text;
                            updRowT.Email = controls["Email"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateContact"].Text);
                        var delRow = GlobalHelper.MainOffice.RealEstateContacts.SingleOrDefault(t =>
                            t.ID_RealEstateContact == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.RealEstateContacts.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateContact"].Text);
                            var delRowT = GlobalHelper.Store.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Store.RealEstateContacts.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateContact"].Text);
                            var delRowT = GlobalHelper.Factory.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Factory.RealEstateContacts.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }


                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstates":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_RealEstate", CreateTextBox("ID_RealEstate", tabIndex++, true)},
                        {"ID_RealEstateType", CreateTextBox("ID_RealEstateType", tabIndex++, false)},
                        {"NameRealEstate", CreateTextBox("NameRealEstate", tabIndex++, false)},
                        {"Country", CreateTextBox("Country", tabIndex++, false)},
                        {"Region", CreateTextBox("Region", tabIndex++, false)},
                        {"City", CreateTextBox("City", tabIndex++, false)},
                        {"Street", CreateTextBox("Street", tabIndex++, false)},
                        {"BuildingNumber", CreateTextBox("BuildingNumber", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.RealEstates.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        mainOfficeDataGridView["ID_RealEstateType", i].Value = table[i].ID_RealEstateType.ToString();
                        mainOfficeDataGridView["NameRealEstate", i].Value = table[i].NameRealEstate;
                        mainOfficeDataGridView["Country", i].Value = table[i].Country;
                        mainOfficeDataGridView["Region", i].Value = table[i].Region;
                        mainOfficeDataGridView["City", i].Value = table[i].City;
                        mainOfficeDataGridView["Street", i].Value = table[i].Street;
                        mainOfficeDataGridView["BuildingNumber", i].Value = table[i].BuildingNumber;

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new RealEstate()
                        {
                            ID_RealEstate = Guid.NewGuid(),
                            ID_RealEstateType = Guid.Parse(controls["ID_RealEstateType"].Text),
                            NameRealEstate = controls["NameRealEstate"].Text,
                            Country = controls["Country"].Text,
                            Region = controls["Region"].Text,
                            City = controls["City"].Text,
                            Street = controls["Street"].Text,
                            BuildingNumber = controls["BuildingNumber"].Text
                        };

                        GlobalHelper.MainOffice.RealEstates.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            GlobalHelper.Store.RealEstates.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            GlobalHelper.Factory.RealEstates.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstate"].Text);
                        var updRow = GlobalHelper.MainOffice.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                        if (updRow == null)
                            return;

                        updRow.ID_RealEstateType = Guid.Parse(controls["ID_RealEstateType"].Text);
                        updRow.NameRealEstate = controls["NameRealEstate"].Text;
                        updRow.Country = controls["Country"].Text;
                        updRow.Region = controls["Region"].Text;
                        updRow.City = controls["City"].Text;
                        updRow.Street = controls["Street"].Text;
                        updRow.BuildingNumber = controls["BuildingNumber"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstate"].Text);
                            var updRowT = GlobalHelper.Store.RealEstates.SingleOrDefault(t => t.ID_RealEstate == idT);

                            if (updRowT == null)
                                return;

                            updRowT.ID_RealEstateType = Guid.Parse(controls["ID_RealEstateType"].Text);
                            updRowT.NameRealEstate = controls["NameRealEstate"].Text;
                            updRowT.Country = controls["Country"].Text;
                            updRowT.Region = controls["Region"].Text;
                            updRowT.City = controls["City"].Text;
                            updRowT.Street = controls["Street"].Text;
                            updRowT.BuildingNumber = controls["BuildingNumber"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstate"].Text);
                            var updRowT = GlobalHelper.Factory.RealEstates.SingleOrDefault(t => t.ID_RealEstate == idT);

                            if (updRowT == null)
                                return;

                            updRowT.ID_RealEstateType = Guid.Parse(controls["ID_RealEstateType"].Text);
                            updRowT.NameRealEstate = controls["NameRealEstate"].Text;
                            updRowT.Country = controls["Country"].Text;
                            updRowT.Region = controls["Region"].Text;
                            updRowT.City = controls["City"].Text;
                            updRowT.Street = controls["Street"].Text;
                            updRowT.BuildingNumber = controls["BuildingNumber"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstate"].Text);
                        var delRow = GlobalHelper.MainOffice.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.RealEstates.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstate"].Text);
                            var delRowT = GlobalHelper.Store.RealEstates.SingleOrDefault(t => t.ID_RealEstate == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Store.RealEstates.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstate"].Text);
                            var delRowT = GlobalHelper.Factory.RealEstates.SingleOrDefault(t => t.ID_RealEstate == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Factory.RealEstates.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }


                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstateTypes":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);

                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_RealEstateType", CreateTextBox("ID_RealEstateType", tabIndex++, true)},
                        {"TypeName", CreateTextBox("TypeName", tabIndex++, false)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.RealEstateTypes.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_RealEstateType", i].Value = table[i].ID_RealEstateType.ToString();
                        mainOfficeDataGridView["TypeName", i].Value = table[i].TypeName.ToString();
                        mainOfficeDataGridView["Description", i].Value = table[i].Description;

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new RealEstateType()
                        {
                            ID_RealEstateType = Guid.NewGuid(),
                            TypeName = controls["TypeName"].Text,
                            Description = controls["Description"].Text
                        };

                        GlobalHelper.MainOffice.RealEstateTypes.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            GlobalHelper.Store.RealEstateTypes.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            GlobalHelper.Factory.RealEstateTypes.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateType"].Text);
                        var updRow = GlobalHelper.MainOffice.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                        if (updRow == null)
                            return;

                        updRow.TypeName = controls["TypeName"].Text;
                        updRow.Description = controls["Description"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateType"].Text);
                            var updRowT = GlobalHelper.Store.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == idT);

                            if (updRowT == null)
                                return;

                            updRowT.TypeName = controls["TypeName"].Text;
                            updRowT.Description = controls["Description"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateType"].Text);
                            var updRowT = GlobalHelper.Factory.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == idT);

                            if (updRowT == null)
                                return;

                            updRowT.TypeName = controls["TypeName"].Text;
                            updRowT.Description = controls["Description"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateType"].Text);
                        var delRow = GlobalHelper.MainOffice.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.RealEstateTypes.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateType"].Text);
                            var delRowT = GlobalHelper.Store.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Store.RealEstateTypes.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_RealEstateType"].Text);
                            var delRowT = GlobalHelper.Factory.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Factory.RealEstateTypes.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }


                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "StatusOrders":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);

                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_StatusOrder", CreateTextBox("ID_StatusOrder", tabIndex++, true)},
                        {"NameStatusOrder", CreateTextBox("NameStatusOrder", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.StatusOrders.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_StatusOrder", i].Value = table[i].ID_StatusOrder.ToString();
                        mainOfficeDataGridView["NameStatusOrder", i].Value = table[i].NameStatusOrder.ToString();

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new StatusOrder()
                        {
                            ID_StatusOrder = Guid.NewGuid(),
                            NameStatusOrder = controls["NameStatusOrder"].Text
                        };

                        GlobalHelper.MainOffice.StatusOrders.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            GlobalHelper.Store.StatusOrders.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            GlobalHelper.Factory.StatusOrders.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_StatusOrder"].Text);
                        var updRow = GlobalHelper.MainOffice.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                        if (updRow == null)
                            return;

                        updRow.NameStatusOrder = controls["NameStatusOrder"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_StatusOrder"].Text);
                            var updRowT = GlobalHelper.Store.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == idT);

                            if (updRowT == null)
                                return;

                            updRowT.NameStatusOrder = controls["NameStatusOrder"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_StatusOrder"].Text);
                            var updRowT = GlobalHelper.Factory.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == idT);

                            if (updRowT == null)
                                return;

                            updRowT.NameStatusOrder = controls["NameStatusOrder"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_StatusOrder"].Text);
                        var delRow = GlobalHelper.MainOffice.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.StatusOrders.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();

                        try
                        {
                            var idT = Guid.Parse(controls["ID_StatusOrder"].Text);
                            var delRowT = GlobalHelper.Store.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Store.StatusOrders.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Store database");
                        }

                        try
                        {
                            var idT = Guid.Parse(controls["ID_StatusOrder"].Text);
                            var delRowT = GlobalHelper.Factory.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == idT);

                            if (delRowT == null)
                                return;

                            GlobalHelper.Factory.StatusOrders.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not update in Factory database");
                        }


                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Users":
                {
                    var addButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Add",
                        Name = $"{Text}Button",
                        TabIndex = 30
                    };

                    var updButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Upd",
                        Name = $"{Text}Button",
                        TabIndex = 31
                    };

                    var delButton = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = @"Del",
                        Name = $"{Text}Button",
                        TabIndex = 32
                    };

                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(delButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(updButton);
                    horizontalMainOfficeSplitContainer.Panel2.Controls.Add(addButton);

                    var panelTypeName = "Panel";
                    var textBoxTypeName = "TextBox";
                    var maskedTextBoxTypeName = "MaskedTextBox";
                    var checkBoxTypeName = "CheckBox";
                    var dateTimePickerTypeName = "DateTimePicker";
                    var tabIndex = 0;


                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_Employee", CreateTextBox("ID_Employee", tabIndex++, true)},
                        {"UserLogin", CreateTextBox("UserLogin", tabIndex++, false)},
                        {"UserPassword", CreateTextBox("UserPassword", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(mainOfficeDataGridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{textBoxTypeName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        horizontalMainOfficeSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.Users.ToList();
                    mainOfficeDataGridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        mainOfficeDataGridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        mainOfficeDataGridView["UserLogin", i].Value = table[i].UserLogin.ToString();
                        mainOfficeDataGridView["UserPassword", i].Value = table[i].UserPassword.ToString();

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new User()
                        {
                            ID_Employee = Guid.NewGuid(),
                            UserLogin = controls["UserLogin"].Text,
                            UserPassword = controls["UserPassword"].Text
                        };

                        GlobalHelper.MainOffice.Users.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var updRow = GlobalHelper.MainOffice.Users.SingleOrDefault(t => t.ID_Employee == id);

                        if (updRow == null)
                            return;

                        updRow.UserLogin = controls["UserLogin"].Text;
                        updRow.UserPassword = controls["UserPassword"].Text;

                        GlobalHelper.MainOffice.SaveChanges();

                        OpenTable(selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var delRow = GlobalHelper.MainOffice.Users.SingleOrDefault(t => t.ID_Employee == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Users.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();


                        OpenTable(selectedIndex);
                    };


                    mainOfficeDataGridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        mainOfficeDataGridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = false;
                    horizontalMainOfficeSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
            }
        }

        private static void DGAddColumn(DataGridView dgw, string colName)
        {
            dgw.Columns.Add(colName, colName);
        }

        private void mainOfficeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainOfficeListBox.SelectedIndex < 0 || mainOfficeListBox.SelectedIndex >= mainOfficeListBox.Items.Count)
                return;

            OpenTable(mainOfficeListBox.SelectedIndex);
        }
    }
}

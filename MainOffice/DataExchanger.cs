using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_Model;
using static MainOffice.ControlGenerator;

namespace MainOffice
{
    public static class DataExchanger
    {
        public static void OpenTable(ListBox listbox, int selectedIndex)
        {
            const string store = "store";
            const string factory = "factory";
            const string mainOffice = "mainOffice";

            var lBTName = "ListBox";
            var pTName = "Panel";
            var tBTName = "TextBox";
            var mTBTName = "MaskedTextBox";
            var cBTName = "CheckBox";
            var hSCTName = "horizontalSplitContainer";
            var dTPTName = "DateTimePicker";


            var basename = listbox.Name.Replace(lBTName, "");

            if (!(listbox.Parent.Parent
                .Controls.Find($"{basename}{hSCTName}", true)[0] is SplitContainer hSplitContainer))
                return;

            hSplitContainer.Panel2.Controls.Clear();
            hSplitContainer.Panel1.Controls.Clear();

            var gridView = CreateDataGridView(basename);

            hSplitContainer.Panel1.Controls.Add(gridView);

            switch (listbox.SelectedItem.ToString())
            {
                case "EmployeeWorkLogs":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "DateTimeStart":
                            case "DateTimeEnd":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.EmployeeWorkLogs.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.EmployeeWorkLogs.ToList() :
                                GlobalHelper.MainOffice.EmployeeWorkLogs.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_EmployeeWorkLog", i].Value = table[i].ID_EmployeeWorkLog.ToString();
                        gridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        gridView["DateTimeStart", i].Value = table[i].DateTimeStart.ToString();
                        gridView["DateTimeEnd", i].Value = table[i].DateTimeEnd.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new EmployeeWorkLog()
                            {
                                ID_EmployeeWorkLog = Guid.NewGuid(),
                                ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                                DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value,
                                DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value
                            };
                            switch (basename)
                            {
                                case store:
                                {
                                    GlobalHelper.Store.EmployeeWorkLogs.Add(newRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    GlobalHelper.Factory.EmployeeWorkLogs.Add(newRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    GlobalHelper.MainOffice.EmployeeWorkLogs.Add(newRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_EmployeeWorkLog"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var updRow = GlobalHelper.Store.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                                    updRow.DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value;
                                    updRow.DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value;
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var updRow = GlobalHelper.Factory.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                                    updRow.DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value;
                                    updRow.DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value;
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var updRow = GlobalHelper.MainOffice.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                                    updRow.DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value;
                                    updRow.DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value;
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_EmployeeWorkLog"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var delRow = GlobalHelper.Store.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    GlobalHelper.Store.EmployeeWorkLogs.Remove(delRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var delRow = GlobalHelper.Factory.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    GlobalHelper.Factory.EmployeeWorkLogs.Remove(delRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var delRow = GlobalHelper.MainOffice.EmployeeWorkLogs.SingleOrDefault(t => t.ID_EmployeeWorkLog == id);
                                    GlobalHelper.MainOffice.EmployeeWorkLogs.Remove(delRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
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
                                        Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Users":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Employee", CreateTextBox("ID_Employee", tabIndex++, false)},
                         {"UserLogin", CreateTextBox("UserLogin", tabIndex++, false)},
                         {"UserPassword", CreateTextBox("UserPassword", tabIndex++, false)}
                     };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Users.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.Users.ToList() :
                                GlobalHelper.MainOffice.Users.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        gridView["UserLogin", i].Value = table[i].UserLogin;
                        gridView["UserPassword", i].Value = table[i].UserPassword;

                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new User()
                            {
                                ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                                UserLogin = controls["UserLogin"].Text,
                                UserPassword = controls["UserPassword"].Text
                            };
                            switch (basename)
                            {
                                case store:
                                {
                                    GlobalHelper.Store.Users.Add(newRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    GlobalHelper.Factory.Users.Add(newRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    GlobalHelper.MainOffice.Users.Add(newRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var updRow = GlobalHelper.Store.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    updRow.UserLogin = controls["UserLogin"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var updRow = GlobalHelper.Factory.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    updRow.UserLogin = controls["UserLogin"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var updRow = GlobalHelper.MainOffice.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    updRow.UserLogin = controls["UserLogin"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var delRow = GlobalHelper.Store.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.Store.Users.Remove(delRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var delRow = GlobalHelper.Factory.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.Factory.Users.Remove(delRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var delRow = GlobalHelper.MainOffice.Users.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.MainOffice.Users.Remove(delRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Employees":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Telephone":
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{mTBTName}", true)[0]);
                                break;
                            case "IsEnabled":
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{cBTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key, item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Employees.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.Employees.ToList() :
                                GlobalHelper.MainOffice.Employees.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        gridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        gridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        gridView["FirstName", i].Value = table[i].FirstName;
                        gridView["SecondName", i].Value = table[i].SecondName;
                        gridView["MiddleName", i].Value = table[i].MiddleName;
                        gridView["Passport", i].Value = table[i].Passport;
                        gridView["IDK", i].Value = table[i].IDK;
                        gridView["Telephone", i].Value = table[i].Telephone;
                        gridView["IsEnabled", i].Value = table[i].IsEnabled.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
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
                            switch (basename)
                            {
                                case store:
                                {
                                    GlobalHelper.Store.Employees.Add(newRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    GlobalHelper.Factory.Employees.Add(newRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    GlobalHelper.MainOffice.Employees.Add(newRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var updRow = GlobalHelper.Store.Employees.SingleOrDefault(t => t.ID_Employee == id);
                                    updRow.ID_Position = new Guid(controls["ID_Position"].Text);
                                    updRow.ID_RealEstate = new Guid(controls["ID_RealEstate"].Text);
                                    updRow.FirstName = controls["FirstName"].Text;
                                    updRow.SecondName = controls["SecondName"].Text;
                                    updRow.MiddleName = controls["MiddleName"].Text;
                                    updRow.Passport = controls["Passport"].Text;
                                    updRow.IDK = controls["IDK"].Text;
                                    updRow.Telephone = controls["Telephone"].Text;
                                    updRow.IsEnabled = (controls["IsEnabled"] as CheckBox).Checked;
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {

                                    var updRow = GlobalHelper.Factory.Employees.SingleOrDefault(t => t.ID_Employee == id);
                                    updRow.ID_Position = new Guid(controls["ID_Position"].Text);
                                    updRow.ID_RealEstate = new Guid(controls["ID_RealEstate"].Text);
                                    updRow.FirstName = controls["FirstName"].Text;
                                    updRow.SecondName = controls["SecondName"].Text;
                                    updRow.MiddleName = controls["MiddleName"].Text;
                                    updRow.Passport = controls["Passport"].Text;
                                    updRow.IDK = controls["IDK"].Text;
                                    updRow.Telephone = controls["Telephone"].Text;
                                    updRow.IsEnabled = (controls["IsEnabled"] as CheckBox).Checked;
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var updRow = GlobalHelper.MainOffice.Employees.SingleOrDefault(t => t.ID_Employee == id);
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
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {

                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var delRow = GlobalHelper.Store.Employees.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.Store.Employees.Remove(delRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var delRow = GlobalHelper.Factory.Employees.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.Factory.Employees.Remove(delRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var delRow = GlobalHelper.MainOffice.Employees.SingleOrDefault(t => t.ID_Employee == id);
                                    GlobalHelper.MainOffice.Employees.Remove(delRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "IsEnabled":
                                    (item.Value as CheckBox).Checked = Convert.ToBoolean(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "ConnectingStrings":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_ConnectingString", CreateTextBox("ID_ConnectingString", tabIndex++, true)},
                        {"DataSource", CreateTextBox("DataSource", tabIndex++, false)},
                        {"ConnectionType", CreateTextBox("ConnectionType", tabIndex++, false)},
                        {"InitialCatalog", CreateTextBox("InitialCatalog", tabIndex++, false)},
                        {"UserId", CreateTextBox("UserId", tabIndex++, false)},
                        {"UserPassword", CreateTextBox("UserPassword", tabIndex++, false)},
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.ConnectingStrings.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.ConnectingStrings.ToList() :
                                GlobalHelper.MainOffice.ConnectingStrings.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_ConnectingString", i].Value = table[i].ID_ConnectingString.ToString();
                        gridView["DataSource", i].Value = table[i].DataSource;
                        gridView["ConnectionType", i].Value = table[i].ConnectionType;
                        gridView["InitialCatalog", i].Value = table[i].InitialCatalog;
                        gridView["UserId", i].Value = table[i].UserId;
                        gridView["UserPassword", i].Value = table[i].UserPassword;
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new ConnectingString()
                            {
                                ID_ConnectingString = Guid.NewGuid(),
                                DataSource = controls["DataSource"].Text,
                                ConnectionType = controls["ConnectionType"].Text,
                                InitialCatalog = controls["InitialCatalog"].Text,
                                UserId = controls["UserId"].Text,
                                UserPassword = controls["UserPassword"].Text
                            };
                            switch (basename)
                            {
                                case store:
                                {
                                    GlobalHelper.Store.ConnectingStrings.Add(newRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    GlobalHelper.Factory.ConnectingStrings.Add(newRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    GlobalHelper.MainOffice.ConnectingStrings.Add(newRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_ConnectingString"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var updRow = GlobalHelper.Store.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    updRow.DataSource = controls["DataSource"].Text;
                                    updRow.ConnectionType = controls["ConnectionType"].Text;
                                    updRow.InitialCatalog = controls["InitialCatalog"].Text;
                                    updRow.UserId = controls["UserId"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var updRow = GlobalHelper.Factory.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    updRow.DataSource = controls["DataSource"].Text;
                                    updRow.ConnectionType = controls["ConnectionType"].Text;
                                    updRow.InitialCatalog = controls["InitialCatalog"].Text;
                                    updRow.UserId = controls["UserId"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var updRow = GlobalHelper.MainOffice.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    updRow.DataSource = controls["DataSource"].Text;
                                    updRow.ConnectionType = controls["ConnectionType"].Text;
                                    updRow.InitialCatalog = controls["InitialCatalog"].Text;
                                    updRow.UserId = controls["UserId"].Text;
                                    updRow.UserPassword = controls["UserPassword"].Text;
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_ConnectingString"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var delRow = GlobalHelper.Store.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    GlobalHelper.Store.ConnectingStrings.Remove(delRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var delRow = GlobalHelper.Factory.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    GlobalHelper.Factory.ConnectingStrings.Remove(delRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var delRow = GlobalHelper.MainOffice.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);
                                    GlobalHelper.MainOffice.ConnectingStrings.Remove(delRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "StatusOrders":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_StatusOrder", CreateTextBox("ID_StatusOrder", tabIndex++, true)},
                        {"NameStatusOrder", CreateTextBox("NameStatusOrder", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.StatusOrders.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.StatusOrders.ToList() :
                                GlobalHelper.MainOffice.StatusOrders.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StatusOrder", i].Value = table[i].ID_StatusOrder.ToString();
                        gridView["NameStatusOrder", i].Value = table[i].NameStatusOrder.ToString();

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new StatusOrder()
                        {
                            ID_StatusOrder = Guid.NewGuid(),
                            NameStatusOrder = controls["NameStatusOrder"].Text
                        };
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.StatusOrders.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }


                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.StatusOrders.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.StatusOrders.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_StatusOrder"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            updRow.NameStatusOrder = controls["NameStatusOrder"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRow = GlobalHelper.Store.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            updRow.NameStatusOrder = controls["NameStatusOrder"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRow = GlobalHelper.Factory.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            updRow.NameStatusOrder = controls["NameStatusOrder"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_StatusOrder"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            GlobalHelper.MainOffice.StatusOrders.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var delRow = GlobalHelper.Store.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            GlobalHelper.Store.StatusOrders.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRow = GlobalHelper.Factory.StatusOrders.SingleOrDefault(t => t.ID_StatusOrder == id);

                            GlobalHelper.Factory.StatusOrders.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Positions":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Positions.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.Positions.ToList() :
                                GlobalHelper.MainOffice.Positions.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        gridView["NamePosition", i].Value = table[i].NamePosition;
                        gridView["PaymentHrnPerHour", i].Value = table[i].PaymentHrnPerHour.ToString();
                        gridView["Description", i].Value = table[i].Description;
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
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.Positions.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.Positions.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.Positions.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Position"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.Positions.SingleOrDefault(t => t.ID_Position == id);

                            updRow.NamePosition = controls["NamePosition"].Text;
                            updRow.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRow = GlobalHelper.Store.Positions.SingleOrDefault(t => t.ID_Position == id);

                            updRow.NamePosition = controls["NamePosition"].Text;
                            updRow.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRow = GlobalHelper.Factory.Positions.SingleOrDefault(t => t.ID_Position == id);

                            updRow.NamePosition = controls["NamePosition"].Text;
                            updRow.PaymentHrnPerHour = Convert.ToInt32(controls["PaymentHrnPerHour"].Text);
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Position"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.Positions.SingleOrDefault(t => t.ID_Position == id);

                            if (delRow == null)
                                return;

                            GlobalHelper.MainOffice.Positions.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var delRowT = GlobalHelper.Store.Positions.SingleOrDefault(t => t.ID_Position == id);

                            GlobalHelper.Store.Positions.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRowT = GlobalHelper.Factory.Positions.SingleOrDefault(t => t.ID_Position == id);

                            GlobalHelper.Factory.Positions.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;


                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Departaments":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_Departament", CreateTextBox("ID_Departament", tabIndex++, true)},
                        {"NameDepartament", CreateTextBox("NameDepartament", tabIndex++, false)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Departaments.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.Departaments.ToList() :
                                GlobalHelper.MainOffice.Departaments.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Departament", i].Value = table[i].ID_Departament.ToString();
                        gridView["NameDepartament", i].Value = table[i].NameDepartament;
                        gridView["Description", i].Value = table[i].Description;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new Departament()
                        {
                            ID_Departament = Guid.NewGuid(),
                            NameDepartament = controls["NameDepartament"].Text,
                            Description = controls["Description"].Text
                        };
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.Departaments.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.Departaments.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.Departaments.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_DepartamentTextBox"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            updRow.NameDepartament = controls["NameDepartament"].Text;
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRow = GlobalHelper.Store.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            updRow.NameDepartament = controls["NameDepartament"].Text;
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Departaments";
                            var updRow = GlobalHelper.Factory.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            updRow.NameDepartament = controls["NameDepartament"].Text;
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_DepartamentTextBox"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            GlobalHelper.MainOffice.Departaments.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = store;
                            var delRow = GlobalHelper.Store.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            GlobalHelper.Store.Departaments.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = factory;
                            var delRow = GlobalHelper.Factory.Departaments.SingleOrDefault(t => t.ID_Departament == id);

                            GlobalHelper.Factory.Departaments.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstateContacts":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Telephone":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{mTBTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.RealEstateContacts.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.RealEstateContacts.ToList() :
                                GlobalHelper.MainOffice.RealEstateContacts.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_RealEstateContact", i].Value = table[i].ID_RealEstateContact.ToString();
                        gridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        gridView["ID_Departament", i].Value = table[i].ID_Departament.ToString();
                        gridView["Telephone", i].Value = table[i].Telephone;
                        gridView["Email", i].Value = table[i].Email;
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
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.RealEstateContacts.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.RealEstateContacts.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.RealEstateContacts.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateContact"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            updRow.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                            updRow.Telephone = controls["Telephone"].Text;
                            updRow.Email = controls["Email"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRowT = GlobalHelper.Store.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            updRowT.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            updRowT.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                            updRowT.Telephone = controls["Telephone"].Text;
                            updRowT.Email = controls["Email"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRowT = GlobalHelper.Factory.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            updRowT.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            updRowT.ID_Departament = Guid.Parse(controls["ID_Departament"].Text);
                            updRowT.Telephone = controls["Telephone"].Text;
                            updRowT.Email = controls["Email"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateContact"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            GlobalHelper.MainOffice.RealEstateContacts.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }


                        try
                        {
                            nameDB = store;
                            var delRow = GlobalHelper.Store.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            GlobalHelper.Store.RealEstateContacts.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRow = GlobalHelper.Factory.RealEstateContacts.SingleOrDefault(t => t.ID_RealEstateContact == id);

                            GlobalHelper.Factory.RealEstateContacts.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstates":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.RealEstates.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.RealEstates.ToList() :
                                GlobalHelper.MainOffice.RealEstates.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        gridView["ID_RealEstateType", i].Value = table[i].ID_RealEstateType.ToString();
                        gridView["NameRealEstate", i].Value = table[i].NameRealEstate;
                        gridView["Country", i].Value = table[i].Country;
                        gridView["Region", i].Value = table[i].Region;
                        gridView["City", i].Value = table[i].City;
                        gridView["Street", i].Value = table[i].Street;
                        gridView["BuildingNumber", i].Value = table[i].BuildingNumber;

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
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.RealEstates.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.RealEstates.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.RealEstates.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstate"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                            updRow.ID_RealEstateType = Guid.Parse(controls["ID_RealEstateType"].Text);
                            updRow.NameRealEstate = controls["NameRealEstate"].Text;
                            updRow.Country = controls["Country"].Text;
                            updRow.Region = controls["Region"].Text;
                            updRow.City = controls["City"].Text;
                            updRow.Street = controls["Street"].Text;
                            updRow.BuildingNumber = controls["BuildingNumber"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRowT = GlobalHelper.Store.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

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
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRowT = GlobalHelper.Factory.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

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
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstate"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                            GlobalHelper.MainOffice.RealEstates.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var delRowT = GlobalHelper.Store.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                            GlobalHelper.Store.RealEstates.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRowT = GlobalHelper.Factory.RealEstates.SingleOrDefault(t => t.ID_RealEstate == id);

                            GlobalHelper.Factory.RealEstates.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RealEstateTypes":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_RealEstateType", CreateTextBox("ID_RealEstateType", tabIndex++, true)},
                        {"TypeName", CreateTextBox("TypeName", tabIndex++, false)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.RealEstateTypes.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.RealEstateTypes.ToList() :
                                GlobalHelper.MainOffice.RealEstateTypes.ToList()
                    );
                    gridView.RowCount = table.Count();
                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_RealEstateType", i].Value = table[i].ID_RealEstateType.ToString();
                        gridView["TypeName", i].Value = table[i].TypeName;
                        gridView["Description", i].Value = table[i].Description;

                    }

                    addButton.Click += (o, args) =>
                    {
                        var newRow = new RealEstateType()
                        {
                            ID_RealEstateType = Guid.NewGuid(),
                            TypeName = controls["TypeName"].Text,
                            Description = controls["Description"].Text
                        };

                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.RealEstateTypes.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception = ex.Message;
                        }

                        try
                        {
                            nameDB = " Store";
                            GlobalHelper.Store.RealEstateTypes.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = " Factory";
                            GlobalHelper.Factory.RealEstateTypes.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateType"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            updRow.TypeName = controls["TypeName"].Text;
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception = ex.Message;
                        }

                        try
                        {
                            nameDB = store;
                            var updRow = GlobalHelper.Store.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            updRow.TypeName = controls["TypeName"].Text;
                            updRow.Description = controls["Description"].Text;

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRowT = GlobalHelper.Factory.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            updRowT.TypeName = controls["TypeName"].Text;
                            updRowT.Description = controls["Description"].Text;

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_RealEstateType"].Text);
                        var nameDB = "";
                        var exception = "";

                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            GlobalHelper.MainOffice.RealEstateTypes.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception = ex.Message;
                        }

                        try
                        {
                            nameDB = store;
                            var delRowT = GlobalHelper.Store.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            GlobalHelper.Store.RealEstateTypes.Remove(delRowT);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRowT = GlobalHelper.Factory.RealEstateTypes.SingleOrDefault(t => t.ID_RealEstateType == id);

                            GlobalHelper.Factory.RealEstateTypes.Remove(delRowT);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Products":
                {
                    if (basename == mainOffice)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;

                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                    {
                        {"ID_Product", CreateTextBox("ID_Product", tabIndex++, true)},
                        {"ProductName", CreateTextBox("ProductName", tabIndex++, false)},
                        {"Photo", CreateTextBox("Photo", tabIndex++, false)},
                        {"ExpirationDate", CreateTextBox("ExpirationDate", tabIndex++, false)},
                        {"Description", CreateTextBox("Description", tabIndex++, false)},
                        {"CalorieContent", CreateTextBox("CalorieContent", tabIndex++, false)},
                        {"Carbohydrates", CreateTextBox("Carbohydrates", tabIndex++, false)},
                        {"Fats", CreateTextBox("Fats", tabIndex++, false)},
                        {"Proteins", CreateTextBox("Proteins", tabIndex++, false)},
                        {"MinTemperature", CreateTextBox("MinTemperature", tabIndex++, false)},
                        {"MaxTemperature", CreateTextBox("MaxTemperature", tabIndex++, false)}
                    };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Products.ToList() :
                            basename == factory ?
                                GlobalHelper.Factory.Products.ToList() :
                                GlobalHelper.MainOffice.Products.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Product", i].Value = table[i].ID_Product.ToString();
                        gridView["ProductName", i].Value = table[i].ProductName;
                        gridView["Photo", i].Value = table[i].Photo;
                        gridView["ExpirationDate", i].Value = table[i].ExpirationDate.ToString();
                        gridView["Description", i].Value = table[i].Description;
                        gridView["CalorieContent", i].Value = table[i].CalorieContent;
                        gridView["Carbohydrates", i].Value = table[i].Carbohydrates;
                        gridView["Fats", i].Value = table[i].Fats;
                        gridView["Proteins", i].Value = table[i].Proteins;
                        gridView["MinTemperature", i].Value = table[i].MinTemperature;
                        gridView["MaxTemperature", i].Value = table[i].MaxTemperature;
                    }

                    addButton.Click += (o, args) =>
                    {
                        var nameDB = "";
                        var exception = "";
                        var newRow = new Product()
                        {
                            ID_Product = Guid.NewGuid(),
                            ProductName = controls["ProductName"].Text,
                            Photo = controls["Photo"].Text,
                            ExpirationDate = Convert.ToInt32(controls["ExpirationDate"].Text),
                            Description = controls["Description"].Text,
                            CalorieContent = Convert.ToInt32(controls["CalorieContent"].Text),
                            Carbohydrates = Convert.ToInt32(controls["Carbohydrates"].Text),
                            Fats = Convert.ToInt32(controls["Fats"].Text),
                            Proteins = Convert.ToInt32(controls["Proteins"].Text),
                            MinTemperature = Convert.ToInt32(controls["MinTemperature"].Text),
                            MaxTemperature = Convert.ToInt32(controls["MaxTemperature"].Text)

                        };
                        try
                        {
                            nameDB = mainOffice;
                            GlobalHelper.MainOffice.Products.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = store;
                            GlobalHelper.Store.Products.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            GlobalHelper.Factory.Products.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Product"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var updRow = GlobalHelper.MainOffice.Products.SingleOrDefault(t => t.ID_Product == id);

                            updRow.ProductName = controls["ProductName"].Text;
                            updRow.Photo = controls["Photo"].Text;
                            updRow.ExpirationDate = Convert.ToInt32(controls["ExpirationDate"].Text);
                            updRow.Description = controls["Description"].Text;
                            updRow.CalorieContent = Convert.ToInt32(controls["CalorieContent"].Text);
                            updRow.Carbohydrates = Convert.ToInt32(controls["Carbohydrates"].Text);
                            updRow.Fats = Convert.ToInt32(controls["Fats"].Text);
                            updRow.Proteins = Convert.ToInt32(controls["Proteins"].Text);
                            updRow.MinTemperature = Convert.ToInt32(controls["MinTemperature"].Text);
                            updRow.MaxTemperature = Convert.ToInt32(controls["MaxTemperature"].Text);

                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var updRow = GlobalHelper.Store.Products.SingleOrDefault(t => t.ID_Product == id);

                            updRow.ProductName = controls["ProductName"].Text;
                            updRow.Photo = controls["Photo"].Text;
                            updRow.ExpirationDate = Convert.ToInt32(controls["ExpirationDate"].Text);
                            updRow.Description = controls["Description"].Text;
                            updRow.CalorieContent = Convert.ToInt32(controls["CalorieContent"].Text);
                            updRow.Carbohydrates = Convert.ToInt32(controls["Carbohydrates"].Text);
                            updRow.Fats = Convert.ToInt32(controls["Fats"].Text);
                            updRow.Proteins = Convert.ToInt32(controls["Proteins"].Text);
                            updRow.MinTemperature = Convert.ToInt32(controls["MinTemperature"].Text);
                            updRow.MaxTemperature = Convert.ToInt32(controls["MaxTemperature"].Text);

                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var updRow = GlobalHelper.Factory.Products.SingleOrDefault(t => t.ID_Product == id);

                            updRow.ProductName = controls["ProductName"].Text;
                            updRow.Photo = controls["Photo"].Text;
                            updRow.ExpirationDate = Convert.ToInt32(controls["ExpirationDate"].Text);
                            updRow.Description = controls["Description"].Text;
                            updRow.CalorieContent = Convert.ToInt32(controls["CalorieContent"].Text);
                            updRow.Carbohydrates = Convert.ToInt32(controls["Carbohydrates"].Text);
                            updRow.Fats = Convert.ToInt32(controls["Fats"].Text);
                            updRow.Proteins = Convert.ToInt32(controls["Proteins"].Text);
                            updRow.MinTemperature = Convert.ToInt32(controls["MinTemperature"].Text);
                            updRow.MaxTemperature = Convert.ToInt32(controls["MaxTemperature"].Text);

                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Product"].Text);
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = mainOffice;
                            var delRow = GlobalHelper.MainOffice.Products.SingleOrDefault(t => t.ID_Product == id);

                            GlobalHelper.MainOffice.Products.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = store;
                            var delRow = GlobalHelper.Store.Products.SingleOrDefault(t => t.ID_Product == id);

                            GlobalHelper.Store.Products.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = factory;
                            var delRow = GlobalHelper.Factory.Products.SingleOrDefault(t => t.ID_Product == id);

                            GlobalHelper.Factory.Products.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        if (exception.Length > 0)
                        {
                            MessageBox.Show($"Can not update in {nameDB}");
                            MessageBox.Show(exception);
                        }


                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Merchandises":
                {
                    if (basename == mainOffice)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Merchandise", CreateTextBox("ID_Merchandise", tabIndex++, true)},
                         {"ID_Product", CreateTextBox("ID_Product", tabIndex++, false)},
                         {"ID_RealEstate", CreateTextBox("ID_RealEstate", tabIndex++, false)},
                         {"Weight", CreateTextBox("Weight", tabIndex++, false)},
                         {"ManufactureDate", CreateDateTimePicker("ManufactureDate", tabIndex++)},
                         {"PricePerGramm", CreateTextBox("PricePerGramm", tabIndex++, false)}
                     };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "ManufactureDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = (
                        basename == store ?
                            GlobalHelper.Store.Merchandises.ToList() :
                            GlobalHelper.Factory.Merchandises.ToList()
                    );
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Merchandise", i].Value = table[i].ID_Merchandise.ToString();
                        gridView["ID_Product", i].Value = table[i].ID_Product.ToString();
                        gridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                        gridView["Weight", i].Value = table[i].Weight.ToString();
                        gridView["ManufactureDate", i].Value = table[i].ManufactureDate.ToString();
                        gridView["PricePerGramm", i].Value = table[i].PricePerGramm.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new Merchandise()
                            {
                                ID_Merchandise = Guid.NewGuid(),
                                ID_Product = Guid.Parse(controls["ID_Product"].Text),
                                ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text),
                                Weight = Convert.ToInt32(controls["Weight"].Text),
                                ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value,
                                PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text)
                            };
                            switch (basename)
                            {
                                case store:
                                {
                                    GlobalHelper.Store.Merchandises.Add(newRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    GlobalHelper.Factory.Merchandises.Add(newRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    GlobalHelper.MainOffice.Merchandises.Add(newRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Merchandise"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var updRow = GlobalHelper.Store.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    updRow.ID_Merchandise = Guid.NewGuid();
                                    updRow.ID_Product = Guid.Parse(controls["ID_Product"].Text);
                                    updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                                    updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                                    updRow.ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value;
                                    updRow.PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var updRow = GlobalHelper.Factory.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    updRow.ID_Merchandise = Guid.NewGuid();
                                    updRow.ID_Product = Guid.Parse(controls["ID_Product"].Text);
                                    updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                                    updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                                    updRow.ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value;
                                    updRow.PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var updRow = GlobalHelper.MainOffice.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    updRow.ID_Merchandise = Guid.NewGuid();
                                    updRow.ID_Product = Guid.Parse(controls["ID_Product"].Text);
                                    updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                                    updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                                    updRow.ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value;
                                    updRow.PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Merchandise"].Text);
                        try
                        {
                            switch (basename)
                            {
                                case store:
                                {
                                    var delRow = GlobalHelper.Store.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    GlobalHelper.Store.Merchandises.Remove(delRow);
                                    GlobalHelper.Store.SaveChanges();
                                    break;
                                }
                                case factory:
                                {
                                    var delRow = GlobalHelper.Factory.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    GlobalHelper.Factory.Merchandises.Remove(delRow);
                                    GlobalHelper.Factory.SaveChanges();
                                    break;
                                }
                                default:
                                {
                                    var delRow = GlobalHelper.MainOffice.Merchandises.SingleOrDefault(t => t.ID_Merchandise == id);
                                    GlobalHelper.MainOffice.Merchandises.Remove(delRow);
                                    GlobalHelper.MainOffice.SaveChanges();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "ManufactureDate":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "HeadOrders":
                {
                    if (basename == store || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.HeadOrders.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_HeadOrder", i].Value = table[i].ID_HeadOrder.ToString();
                        gridView["ID_Position", i].Value = table[i].ID_Position.ToString();
                        gridView["ID_StatusOrder", i].Value = table[i].ID_StatusOrder.ToString();
                        gridView["AssignFor", i].Value = table[i].AssignFor.ToString();
                        gridView["Date", i].Value = table[i].Date.ToString();
                        gridView["Description", i].Value = table[i].Description.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_HeadOrder"].Text);
                            var updRow = GlobalHelper.MainOffice.HeadOrders.SingleOrDefault(t => t.ID_HeadOrder == id);
                            updRow.ID_Position = Guid.Parse(controls["ID_Position"].Text);
                            updRow.ID_StatusOrder = Guid.Parse(controls["ID_StatusOrder"].Text);
                            updRow.AssignFor = controls["AssignFor"].Text;
                            updRow.Date = (controls["Date"] as DateTimePicker).Value;
                            updRow.Description = controls["Description"].Text;
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_HeadOrder"].Text);
                            var delRow = GlobalHelper.MainOffice.HeadOrders.SingleOrDefault(t => t.ID_HeadOrder == id);
                            GlobalHelper.MainOffice.HeadOrders.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "Date":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "PerformedHeadOrders":
                {
                    if (basename == store || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.MainOffice.PerformedHeadOrders.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_PerformedOrder", i].Value = table[i].ID_PerformedOrder.ToString();
                        gridView["ID_HeadOrder", i].Value = table[i].ID_HeadOrder.ToString();
                        gridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        gridView["Date", i].Value = table[i].Date.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_PerformedOrder"].Text);
                            var updRow = GlobalHelper.MainOffice.PerformedHeadOrders.SingleOrDefault(t => t.ID_PerformedOrder == id);
                            updRow.ID_HeadOrder = Guid.Parse(controls["ID_HeadOrder"].Text);
                            updRow.ID_Employee = Guid.Parse(controls["ID_Employee"].Text);
                            updRow.Date = (controls["Date"] as DateTimePicker).Value;
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_PerformedOrder"].Text);
                            var delRow = GlobalHelper.MainOffice.PerformedHeadOrders.SingleOrDefault(t => t.ID_PerformedOrder == id);
                            GlobalHelper.MainOffice.PerformedHeadOrders.Remove(delRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "Date":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "StoreOrders":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_StoreOrder", CreateTextBox("ID_StoreOrder", tabIndex++, true)},
                         {"ID_RealEstateStore", CreateTextBox("ID_RealEstateStore", tabIndex++, false)},
                         {"ID_StoreManager", CreateTextBox("ID_StoreManager", tabIndex++, false)},
                         {"ID_StatusOrder", CreateTextBox("ID_StatusOrder", tabIndex++, false)},
                         {"ID_Product", CreateTextBox("ID_Product", tabIndex++, false)},
                         {"Weight", CreateTextBox("Weight", tabIndex++, false)},
                         {"InitialDate", CreateDateTimePicker("InitialDate", tabIndex++)}
                     };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "InitialDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.StoreOrders.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StoreOrder", i].Value = table[i].ID_StoreOrder.ToString();
                        gridView["ID_RealEstateStore", i].Value = table[i].ID_RealEstateStore.ToString();
                        gridView["ID_StoreManager", i].Value = table[i].ID_StoreManager.ToString();
                        gridView["ID_StatusOrder", i].Value = table[i].ID_StatusOrder.ToString();
                        gridView["ID_Product", i].Value = table[i].ID_Product.ToString();
                        gridView["Weight", i].Value = table[i].Weight.ToString();
                        gridView["InitialDate", i].Value = table[i].InitialDate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new StoreOrder()
                            {
                                ID_StoreOrder = Guid.NewGuid(),
                                ID_RealEstateStore = Guid.Parse(controls["ID_RealEstateStore"].Text),
                                ID_StoreManager = Guid.Parse(controls["ID_StoreManager"].Text),
                                ID_StatusOrder = Guid.Parse(controls["ID_StatusOrder"].Text),
                                ID_Product = Guid.Parse(controls["ID_Product"].Text),
                                Weight = Convert.ToInt32(controls["Weight"].Text),
                                InitialDate = (controls["InitialDate"] as DateTimePicker).Value
                            };
                            GlobalHelper.Store.StoreOrders.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var updRow = GlobalHelper.Store.StoreOrders.SingleOrDefault(t => t.ID_StoreOrder == id);
                            updRow.ID_RealEstateStore = Guid.Parse(controls["ID_RealEstateStore"].Text);
                            updRow.ID_StoreManager = Guid.Parse(controls["ID_StoreManager"].Text);
                            updRow.ID_StatusOrder = Guid.Parse(controls["ID_StatusOrder"].Text);
                            updRow.ID_Product = Guid.Parse(controls["ID_Product"].Text);
                            updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                            updRow.InitialDate = (controls["InitialDate"] as DateTimePicker).Value;
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var delRow = GlobalHelper.Store.StoreOrders.SingleOrDefault(t => t.ID_StoreOrder == id);
                            GlobalHelper.Store.StoreOrders.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "InitialDate":
                                    (item.Value as DateTimePicker).Value =
                                        Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text =
                                        gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "PerformedStoreOrders":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_StoreOrder", CreateTextBox("ID_StoreOrder", tabIndex++, false)},
                         {"ID_FactoryManager", CreateTextBox("ID_FactoryManager", tabIndex++, false)},
                         {"ID_Carrier", CreateTextBox("ID_Carrier", tabIndex++, false)},
                         {"Weight", CreateTextBox("Weight", tabIndex++, false)}
                     };

                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.PerformedStoreOrders.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StoreOrder", i].Value = table[i].ID_StoreOrder.ToString();
                        gridView["ID_FactoryManager", i].Value = table[i].ID_FactoryManager.ToString();
                        gridView["ID_Carrier", i].Value = table[i].ID_Carrier.ToString();
                        gridView["Weight", i].Value = table[i].Weight.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new PerformedStoreOrder()
                            {
                                ID_StoreOrder = Guid.Parse(controls["ID_StoreOrder"].Text),
                                ID_FactoryManager = Guid.Parse(controls["ID_FactoryManager"].Text),
                                ID_Carrier = Guid.Parse(controls["ID_Carrier"].Text),
                                Weight = Convert.ToInt32(controls["Weight"].Text)
                            };
                            GlobalHelper.Store.PerformedStoreOrders.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var updRow = GlobalHelper.Store.PerformedStoreOrders.SingleOrDefault(t => t.ID_StoreOrder == id);
                            updRow.ID_FactoryManager = Guid.Parse(controls["ID_FactoryManager"].Text);
                            updRow.ID_Carrier = Guid.Parse(controls["ID_Carrier"].Text);
                            updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var delRow = GlobalHelper.Store.PerformedStoreOrders.SingleOrDefault(t => t.ID_StoreOrder == id);
                            GlobalHelper.Store.PerformedStoreOrders.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "MerchandiseAcceptanceLogs":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_StoreOrder", CreateTextBox("ID_StoreOrder", tabIndex++, false)},
                         {"ID_AcceptManager", CreateTextBox("ID_AcceptManager", tabIndex++, false)},
                         {"Weight", CreateTextBox("Weight", tabIndex++, false)},
                         {"AcceptDate", CreateDateTimePicker("AcceptDate", tabIndex++)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "AcceptDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.MerchandiseAcceptanceLogs.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StoreOrder", i].Value = table[i].ID_StoreOrder.ToString();
                        gridView["ID_AcceptManager", i].Value = table[i].ID_AcceptManager.ToString();
                        gridView["Weight", i].Value = table[i].Weight.ToString();
                        gridView["AcceptDate", i].Value = table[i].AcceptDate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new MerchandiseAcceptanceLog()
                            {
                                ID_StoreOrder = Guid.Parse(controls["ID_StoreOrder"].Text),
                                ID_AcceptManager = Guid.Parse(controls["ID_AcceptManager"].Text),
                                Weight = Convert.ToInt32(controls["Weight"].Text),
                                AcceptDate = (controls["AcceptDate"] as DateTimePicker).Value
                            };
                            GlobalHelper.Store.MerchandiseAcceptanceLogs.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var updRow = GlobalHelper.Store.MerchandiseAcceptanceLogs.SingleOrDefault(t => t.ID_StoreOrder == id);
                            updRow.ID_AcceptManager = Guid.Parse(controls["ID_AcceptManager"].Text);
                            updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                            updRow.AcceptDate = (controls["AcceptDate"] as DateTimePicker).Value;
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var delRow = GlobalHelper.Store.MerchandiseAcceptanceLogs.SingleOrDefault(t => t.ID_StoreOrder == id);
                            GlobalHelper.Store.MerchandiseAcceptanceLogs.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "AcceptDate":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "LackLogs":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_StoreOrder", CreateTextBox("ID_StoreOrder", tabIndex++, false)},
                         {"WeightOfLack", CreateTextBox("WeightOfLack", tabIndex++, false)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.LackLogs.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StoreOrder", i].Value = table[i].ID_StoreOrder.ToString();
                        gridView["WeightOfLack", i].Value = table[i].WeightOfLack.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new LackLog()
                            {
                                ID_StoreOrder = Guid.Parse(controls["ID_StoreOrder"].Text),
                                WeightOfLack = Convert.ToInt32(controls["WeightOfLack"].Text)
                            };
                            GlobalHelper.Store.LackLogs.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var updRow = GlobalHelper.Store.LackLogs.SingleOrDefault(t => t.ID_StoreOrder == id);
                            updRow.WeightOfLack = Convert.ToInt32(controls["WeightOfLack"].Text);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StoreOrder"].Text);
                            var delRow = GlobalHelper.Store.LackLogs.SingleOrDefault(t => t.ID_StoreOrder == id);
                            GlobalHelper.Store.LackLogs.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "CashRegisterAccesses":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_CashRegisterAccess", CreateTextBox("ID_CashRegisterAccess", tabIndex++, true)},
                         {"ID_CashRegister", CreateTextBox("ID_CashRegister", tabIndex++, false)},
                         {"ID_EmployeeSeller", CreateTextBox("ID_EmployeeSeller", tabIndex++, false)},
                         {"ID_Operation", CreateTextBox("ID_Operation", tabIndex++, false)},
                         {"Date", CreateDateTimePicker("Date", tabIndex++)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.CashRegisterAccesses.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_CashRegisterAccess", i].Value = table[i].ID_CashRegisterAccess.ToString();
                        gridView["ID_CashRegister", i].Value = table[i].ID_CashRegister.ToString();
                        gridView["ID_EmployeeSeller", i].Value = table[i].ID_EmployeeSeller.ToString();
                        gridView["ID_Operation", i].Value = table[i].ID_Operation.ToString();
                        gridView["Date", i].Value = table[i].Date.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new CashRegisterAccess()
                            {
                                ID_CashRegisterAccess = Guid.NewGuid(),
                                ID_CashRegister = Guid.Parse(controls["ID_CashRegister"].Text),
                                ID_EmployeeSeller = Guid.Parse(controls["ID_EmployeeSeller"].Text),
                                ID_Operation = Guid.Parse(controls["ID_Operation"].Text),
                                Date = (controls["Date"] as DateTimePicker).Value
                            };
                            GlobalHelper.Store.CashRegisterAccesses.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_CashRegisterAccess"].Text);
                            var updRow = GlobalHelper.Store.CashRegisterAccesses.SingleOrDefault(t => t.ID_CashRegisterAccess == id);
                            updRow.ID_CashRegister = Guid.Parse(controls["ID_CashRegister"].Text);
                            updRow.ID_EmployeeSeller = Guid.Parse(controls["ID_EmployeeSeller"].Text);
                            updRow.ID_Operation = Guid.Parse(controls["ID_Operation"].Text);
                            updRow.Date = (controls["Date"] as DateTimePicker).Value;
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_CashRegisterAccess"].Text);
                            var delRow = GlobalHelper.Store.CashRegisterAccesses.SingleOrDefault(t => t.ID_CashRegisterAccess == id);
                            GlobalHelper.Store.CashRegisterAccesses.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "Date":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "CashRegisters":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_CashRegister", CreateTextBox("ID_CashRegister", tabIndex++, true)},
                         {"ID_RealEstate", CreateTextBox("ID_RealEstate", tabIndex++, false)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.CashRegisters.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_CashRegister", i].Value = table[i].ID_CashRegister.ToString();
                        gridView["ID_RealEstate", i].Value = table[i].ID_RealEstate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new CashRegister()
                            {
                                ID_CashRegister = Guid.NewGuid(),
                                ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text)
                            };
                            GlobalHelper.Store.CashRegisters.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_CashRegister"].Text);
                            var updRow = GlobalHelper.Store.CashRegisters.SingleOrDefault(t => t.ID_CashRegister == id);
                            updRow.ID_RealEstate = Guid.Parse(controls["ID_RealEstate"].Text);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_CashRegister"].Text);
                            var delRow = GlobalHelper.Store.CashRegisters.SingleOrDefault(t => t.ID_CashRegister == id);
                            GlobalHelper.Store.CashRegisters.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "CashRegisterOperations":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Operation", CreateTextBox("ID_Operation", tabIndex++, true)},
                         {"NameOperation", CreateTextBox("NameOperation", tabIndex++, false)},
                         {"Description", CreateTextBox("Description", tabIndex++, false)}
                    };
                    var controls = new Dictionary<string, Control>();
                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.CashRegisterOperations.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Operation", i].Value = table[i].ID_Operation.ToString();
                        gridView["NameOperation", i].Value = table[i].NameOperation.ToString();
                        gridView["Description", i].Value = table[i].Description.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new CashRegisterOperation()
                            {
                                ID_Operation = Guid.NewGuid(),
                                NameOperation = controls["NameOperation"].Text,
                                Description = controls["Description"].Text
                            };
                            GlobalHelper.Store.CashRegisterOperations.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Operation"].Text);
                            var updRow = GlobalHelper.Store.CashRegisterOperations.SingleOrDefault(t => t.ID_Operation == id);
                            updRow.NameOperation = controls["NameOperation"].Text;
                            updRow.Description = controls["Description"].Text;
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Operation"].Text);
                            var delRow = GlobalHelper.Store.CashRegisterOperations.SingleOrDefault(t => t.ID_Operation == id);
                            GlobalHelper.Store.CashRegisterOperations.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Purchases":
                {
                    if (basename == mainOffice || basename == factory)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Purchase", CreateTextBox("ID_Purchase", tabIndex++, true)},
                         {"ID_CashRegisterAccess", CreateTextBox("ID_CashRegisterAccess", tabIndex++, false)},
                         {"ID_Merchandise", CreateTextBox("ID_Merchandise", tabIndex++, false)},
                         {"Weight", CreateTextBox("Weight", tabIndex++, false)},
                         {"PurchaseDate", CreateDateTimePicker("PurchaseDate", tabIndex++)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "PurchaseDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }

                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Store.Purchases.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Purchase", i].Value = table[i].ID_Purchase.ToString();
                        gridView["ID_CashRegisterAccess", i].Value = table[i].ID_CashRegisterAccess.ToString();
                        gridView["ID_Merchandise", i].Value = table[i].ID_Merchandise.ToString();
                        gridView["Weight", i].Value = table[i].Weight.ToString();
                        gridView["PurchaseDate", i].Value = table[i].PurchaseDate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new Purchase()
                            {
                                ID_Purchase = Guid.NewGuid(),
                                ID_CashRegisterAccess = Guid.Parse(controls["ID_CashRegisterAccess"].Text),
                                ID_Merchandise = Guid.Parse(controls["ID_Merchandise"].Text),
                                Weight = Convert.ToInt32(controls["Weight"].Text),
                                PurchaseDate = (controls["PurchaseDate"] as DateTimePicker).Value
                            };
                            GlobalHelper.Store.Purchases.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Purchase"].Text);
                            var updRow = GlobalHelper.Store.Purchases.SingleOrDefault(t => t.ID_Purchase == id);
                            updRow.ID_CashRegisterAccess = Guid.Parse(controls["ID_CashRegisterAccess"].Text);
                            updRow.ID_Merchandise = Guid.Parse(controls["ID_Merchandise"].Text);
                            updRow.Weight = Convert.ToInt32(controls["Weight"].Text);
                            updRow.PurchaseDate = (controls["PurchaseDate"] as DateTimePicker).Value;
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Purchase"].Text);
                            var delRow = GlobalHelper.Store.Purchases.SingleOrDefault(t => t.ID_Purchase == id);
                            GlobalHelper.Store.Purchases.Remove(delRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "PurchaseDate":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "RawMaterialProviderContracts":
                {
                    if (basename == mainOffice || basename == store)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Contract", CreateTextBox("ID_Contract", tabIndex++, true)},
                         {"ID_StatusContract", CreateTextBox("ID_StatusContract", tabIndex++, false)},
                         {"ID_RawMaterial", CreateTextBox("ID_RawMaterial", tabIndex++, false)},
                         {"ID_MeasurementUnit", CreateTextBox("ID_MeasurementUnit", tabIndex++, false)},
                         {"Count", CreateTextBox("Count", tabIndex++, false)},
                         {"PricePerCount", CreateTextBox("PricePerCount", tabIndex++, false)},
                         {"ManufactureDate", CreateDateTimePicker("ManufactureDate", tabIndex++)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "ManufactureDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }
                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Factory.RawMaterialProviderContracts.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Contract", i].Value = table[i].ID_Contract.ToString();
                        gridView["ID_StatusContract", i].Value = table[i].ID_StatusContract.ToString();
                        gridView["ID_RawMaterial", i].Value = table[i].ID_RawMaterial.ToString();
                        gridView["ID_MeasurementUnit", i].Value = table[i].ID_MeasurementUnit.ToString();
                        gridView["Count", i].Value = table[i].Count.ToString();
                        gridView["PricePerCount", i].Value = table[i].PricePerCount.ToString();
                        gridView["ManufactureDate", i].Value = table[i].ManufactureDate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new RawMaterialProviderContract()
                            {
                                ID_Contract = Guid.NewGuid(),
                                ID_StatusContract = Guid.Parse(controls["ID_StatusContract"].Text),
                                ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text),
                                ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text),
                                Count = Convert.ToInt32(controls["Count"].Text),
                                PricePerCount = Convert.ToInt32(controls["PricePerCount"].Text),
                                ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value
                            };
                            GlobalHelper.Factory.RawMaterialProviderContracts.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Contract"].Text);
                            var updRow = GlobalHelper.Factory.RawMaterialProviderContracts.SingleOrDefault(t => t.ID_Contract == id);
                            updRow.ID_StatusContract = Guid.Parse(controls["ID_StatusContract"].Text);
                            updRow.ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text);
                            updRow.ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text);
                            updRow.Count = Convert.ToInt32(controls["Count"].Text);
                            updRow.PricePerCount = Convert.ToInt32(controls["PricePerCount"].Text);
                            updRow.ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value;
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Contract"].Text);
                            var delRow = GlobalHelper.Factory.RawMaterialProviderContracts.SingleOrDefault(t => t.ID_Contract == id);
                            GlobalHelper.Factory.RawMaterialProviderContracts.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "ManufactureDate":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "StockRawMaterials":
                {
                    if (basename == mainOffice || basename == store)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_StockRawMaterial", CreateTextBox("ID_StockRawMaterial", tabIndex++, true)},
                         {"ID_RawMaterial", CreateTextBox("ID_RawMaterial", tabIndex++, false)},
                         {"ID_MeasurementUnit", CreateTextBox("ID_MeasurementUnit", tabIndex++, false)},
                         {"Count", CreateTextBox("Count", tabIndex++, false)},
                         {"PricePerGramm", CreateTextBox("PricePerGramm", tabIndex++, false)},
                         {"ManufactureDate", CreateDateTimePicker("ManufactureDate", tabIndex++)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "ManufactureDate":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dTPTName}", true)[0]);
                                break;
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }
                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Factory.StockRawMaterials.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_StockRawMaterial", i].Value = table[i].ID_StockRawMaterial.ToString();
                        gridView["ID_RawMaterial", i].Value = table[i].ID_RawMaterial.ToString();
                        gridView["ID_MeasurementUnit", i].Value = table[i].ID_MeasurementUnit.ToString();
                        gridView["Count", i].Value = table[i].Count.ToString();
                        gridView["PricePerGramm", i].Value = table[i].PricePerGramm.ToString();
                        gridView["ManufactureDate", i].Value = table[i].ManufactureDate.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new StockRawMaterial()
                            {
                                ID_StockRawMaterial = Guid.NewGuid(),
                                ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text),
                                ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text),
                                Count = Convert.ToInt32(controls["Count"].Text),
                                PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text),
                                ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value
                            };
                            GlobalHelper.Factory.StockRawMaterials.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StockRawMaterial"].Text);
                            var updRow = GlobalHelper.Factory.StockRawMaterials.SingleOrDefault(t => t.ID_StockRawMaterial == id);
                            updRow.ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text);
                            updRow.ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text);
                            updRow.Count = Convert.ToInt32(controls["Count"].Text);
                            updRow.PricePerGramm = Convert.ToInt32(controls["PricePerGramm"].Text);
                            updRow.ManufactureDate = (controls["ManufactureDate"] as DateTimePicker).Value;
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_StockRawMaterial"].Text);
                            var delRow = GlobalHelper.Factory.StockRawMaterials.SingleOrDefault(t => t.ID_StockRawMaterial == id);
                            GlobalHelper.Factory.StockRawMaterials.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                case "ManufactureDate":
                                    (item.Value as DateTimePicker).Value = Convert.ToDateTime(gridView[item.Key, args.RowIndex].Value);
                                    break;
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "Components":
                {
                    if (basename == mainOffice || basename == store)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_Product", CreateTextBox("ID_Product", tabIndex++, false)},
                         {"ID_RawMaterial", CreateTextBox("ID_RawMaterial", tabIndex++, false)},
                         {"ID_MeasurementUnit", CreateTextBox("ID_MeasurementUnit", tabIndex++, false)},
                         {"Count", CreateTextBox("Count", tabIndex++, false)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }
                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Factory.Components.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Product", i].Value = table[i].ID_Product.ToString();
                        gridView["ID_RawMaterial", i].Value = table[i].ID_RawMaterial.ToString();
                        gridView["ID_MeasurementUnit", i].Value = table[i].ID_MeasurementUnit.ToString();
                        gridView["Count", i].Value = table[i].Count.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new Component()
                            {
                                ID_Product = Guid.Parse(controls["ID_Product"].Text),
                                ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text),
                                ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text),
                                Count = Convert.ToInt32(controls["Count"].Text)
                            };
                            GlobalHelper.Factory.Components.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Product"].Text);
                            var updRow = GlobalHelper.Factory.Components.SingleOrDefault(t => t.ID_Product == id);
                            updRow.ID_RawMaterial = Guid.Parse(controls["ID_RawMaterial"].Text);
                            updRow.ID_MeasurementUnit = Guid.Parse(controls["ID_MeasurementUnit"].Text);
                            updRow.Count = Convert.ToInt32(controls["Count"].Text);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_Product"].Text);
                            var delRow = GlobalHelper.Factory.Components.SingleOrDefault(t => t.ID_Product == id);
                            GlobalHelper.Factory.Components.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
                case "MeasurementUnits":
                {
                    if (basename == mainOffice || basename == store)
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Del", tabIndex++);
                    tabIndex = 0;
                    hSplitContainer.Panel2.Controls.AddRange(new[] { delButton, updButton, addButton });

                    var panels = new Dictionary<string, Panel>
                     {
                         {"ID_MeasurementUnit", CreateTextBox("ID_MeasurementUnit", tabIndex++, true)},
                         {"NameMeasurementUnit", CreateTextBox("NameMeasurementUnit", tabIndex++, false)}
                     };
                    var controls = new Dictionary<string, Control>();

                    foreach (var item in panels)
                    {
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            default:
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{tBTName}", true)[0]);
                                break;
                        }
                    }
                    foreach (var item in panels.Reverse())
                    {
                        hSplitContainer.Panel2.Controls.Add(item.Value);
                    }

                    var table = GlobalHelper.Factory.MeasurementUnits.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_MeasurementUnit", i].Value = table[i].ID_MeasurementUnit.ToString();
                        gridView["NameMeasurementUnit", i].Value = table[i].NameMeasurementUnit.ToString();
                    }

                    addButton.Click += (o, args) =>
                    {
                        try
                        {
                            var newRow = new MeasurementUnit()
                            {
                                ID_MeasurementUnit = Guid.NewGuid(),
                                NameMeasurementUnit = controls["NameMeasurementUnit"].Text
                            };
                            GlobalHelper.Factory.MeasurementUnits.Add(newRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }
                        OpenTable(listbox, selectedIndex);
                    };

                    updButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_MeasurementUnit"].Text);
                            var updRow = GlobalHelper.Factory.MeasurementUnits.SingleOrDefault(t => t.ID_MeasurementUnit == id);
                            updRow.NameMeasurementUnit = controls["NameMeasurementUnit"].Text;
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        try
                        {
                            var id = Guid.Parse(controls["ID_MeasurementUnit"].Text);
                            var delRow = GlobalHelper.Factory.MeasurementUnits.SingleOrDefault(t => t.ID_MeasurementUnit == id);
                            GlobalHelper.Factory.MeasurementUnits.Remove(delRow);
                            GlobalHelper.Factory.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not update in {basename}");
                            MessageBox.Show(ex.Message);
                        }

                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        foreach (var item in controls)
                        {
                            switch (item.Key)
                            {
                                default:
                                    controls[item.Key].Text = gridView[item.Key, args.RowIndex].Value.ToString();
                                    break;
                            }
                        }
                    };

                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
                    break;
                }
            }
        }
    }
}

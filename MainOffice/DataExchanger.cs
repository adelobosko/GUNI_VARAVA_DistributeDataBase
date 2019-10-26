using System;
using System.Collections.Generic;
using System.Drawing;
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
                case "Products":
                {
                    if (basename == "mainOffice")
                    {
                        throw new Exception($"{basename} can not have {listbox.SelectedItem} table!");
                    }
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Upd", tabIndex++);
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

                    List<Product> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.Products.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.Products.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.Products.ToList();
                            break;
                    }
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
                        var nameDB = "";
                        var exception = "";
                        try
                        {
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.Products.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.Products.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                case "StatusOrders":
                {
                    var tabIndex = 30;
                    var addButton = CeateButton("Add", tabIndex++);
                    var updButton = CeateButton("Upd", tabIndex++);
                    var delButton = CeateButton("Upd", tabIndex++);
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

                    List<StatusOrder> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.StatusOrders.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.StatusOrders.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.StatusOrders.ToList();
                            break;
                    }
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
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.StatusOrders.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }


                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.StatusOrders.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                    var delButton = CeateButton("Upd", tabIndex++);
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

                    List<Position> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.Positions.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.Positions.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.Positions.ToList();
                            break;
                    }
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
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.Positions.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.Positions.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                    var delButton = CeateButton("Upd", tabIndex++);
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

                    List<Departament> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.Departaments.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.Departaments.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.Departaments.ToList();
                            break;
                    }
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
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.Departaments.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.Departaments.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }
                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                    var delButton = CeateButton("Upd", tabIndex++);
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
                    
                    List<RealEstateContact> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.RealEstateContacts.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.RealEstateContacts.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.RealEstateContacts.ToList();
                            break;
                    }
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
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.RealEstateContacts.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.RealEstateContacts.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                    var delButton = CeateButton("Upd", tabIndex++);
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
                    
                    List<RealEstate> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.RealEstates.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.RealEstates.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.RealEstates.ToList();
                            break;
                    }

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
                            nameDB = "MainOffice";
                            GlobalHelper.MainOffice.RealEstates.Add(newRow);
                            GlobalHelper.MainOffice.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Store";
                            GlobalHelper.Store.RealEstates.Add(newRow);
                            GlobalHelper.Store.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            exception += $"\r\n{ex.Message}";
                        }

                        try
                        {
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                    var delButton = CeateButton("Upd", tabIndex++);
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

                    List<RealEstateType> table;
                    switch (basename)
                    {
                        case "store":
                            table = GlobalHelper.Store.RealEstateTypes.ToList();
                            break;
                        case "factory":
                            table = GlobalHelper.Factory.RealEstateTypes.ToList();
                            break;
                        default:
                            table = GlobalHelper.MainOffice.RealEstateTypes.ToList();
                            break;
                    }

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
                            nameDB = "MainOffice";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                            nameDB = "MainOffice";
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
                            nameDB = "Store";
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
                            nameDB = "Factory";
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
                /*case "ConnectingStrings":
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


                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);
                    gridView.Columns.Add("ID_ConnectingString", "ID_ConnectingString");
                    gridView.Columns.Add("DataSource", "DataSource");
                    gridView.Columns.Add("ConnectionType", "ConnectionType");
                    gridView.Columns.Add("InitialCatalog", "InitialCatalog");
                    gridView.Columns.Add("UserId", "UserId");
                    gridView.Columns.Add("UserPassword", "UserPassword");

                    var ID_ConnectingStringPanel = CreateTextBox("ID_ConnectingString", 0, true);
                    var DataSourcePanel = CreateTextBox("DataSource", 1, false);
                    var ConnectionTypePanel = CreateTextBox("ConnectionType", 2, false);
                    var InitialCatalogPanel = CreateTextBox("InitialCatalog", 3, false);
                    var UserIdPanel = CreateTextBox($"UserId", 4, false);
                    var UserPasswordPanel = CreateTextBox($"UserPassword", 5, false);

                    hSplitContainer.Panel2.Controls.Add(UserPasswordPanel);
                    hSplitContainer.Panel2.Controls.Add(UserIdPanel);
                    hSplitContainer.Panel2.Controls.Add(InitialCatalogPanel);
                    hSplitContainer.Panel2.Controls.Add(ConnectionTypePanel);
                    hSplitContainer.Panel2.Controls.Add(DataSourcePanel);
                    hSplitContainer.Panel2.Controls.Add(ID_ConnectingStringPanel);

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
                    gridView.RowCount = table.Count();
                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_ConnectingString", i].Value =
                            table[i].ID_ConnectingString.ToString();

                        gridView["DataSource", i].Value =
                            table[i].DataSource;

                        gridView["ConnectionType", i].Value =
                            table[i].ConnectionType;

                        gridView["InitialCatalog", i].Value =
                            table[i].InitialCatalog;

                        gridView["UserId", i].Value =
                            table[i].UserId;

                        gridView["UserPassword", i].Value =
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
                        OpenTable(listbox, selectedIndex);
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
                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(ID_ConnectingStringTextBox.Text);
                        var connectingString = GlobalHelper.MainOffice.ConnectingStrings.SingleOrDefault(cs => cs.ID_ConnectingString == id);

                        if (connectingString == null)
                            return;

                        GlobalHelper.MainOffice.ConnectingStrings.Remove(connectingString);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(listbox, selectedIndex);
                    };


                    gridView.CellClick += (sender, args) =>
                    {
                        if (args.RowIndex < 0)
                            return;

                        ID_ConnectingStringTextBox.Text = gridView["ID_ConnectingString", args.RowIndex]
                            .Value.ToString();
                        DataSourceTextBox.Text = gridView["DataSource", args.RowIndex]
                            .Value.ToString();
                        ConnectionTypeTextBox.Text = gridView["ConnectionType", args.RowIndex]
                            .Value.ToString();
                        InitialCatalogTextBox.Text = gridView["InitialCatalog", args.RowIndex]
                            .Value.ToString();
                        UserIdTextBox.Text = gridView["UserId", args.RowIndex]
                            .Value.ToString();
                        userPasswordTextBox.Text = gridView["userPassword", args.RowIndex]
                            .Value.ToString();
                    };


                    hSplitContainer.Panel2.AutoScroll = false;
                    hSplitContainer.Panel2.AutoScroll = true;
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

                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);
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

                    var table = GlobalHelper.MainOffice.Employees.ToList();
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
                        OpenTable(listbox, selectedIndex);
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

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var delRow = GlobalHelper.MainOffice.Employees.SingleOrDefault(t => t.ID_Employee == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Employees.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
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
                                    (item.Value as CheckBox).Checked =
                                        Convert.ToBoolean(gridView[item.Key, args.RowIndex].Value);
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

                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var tBTName = "TextBox";
                    var mTBTName = "MaskedTextBox";
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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "DateTimeStart":
                            case "DateTimeEnd":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
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

                    var table = GlobalHelper.MainOffice.EmployeeWorkLogs.ToList();
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
                        var newRow = new EmployeeWorkLog()
                        {
                            ID_EmployeeWorkLog = Guid.NewGuid(),
                            ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                            DateTimeStart = (controls["DateTimeStart"] as DateTimePicker).Value,
                            DateTimeEnd = (controls["DateTimeEnd"] as DateTimePicker).Value
                        };

                        GlobalHelper.MainOffice.EmployeeWorkLogs.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(listbox, selectedIndex);
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

                        OpenTable(listbox, selectedIndex);
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

                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var tBTName = "TextBox";
                    var mTBTName = "MaskedTextBox";
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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
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
                        OpenTable(listbox, selectedIndex);
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

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_HeadOrder"].Text);
                        var delRow = GlobalHelper.MainOffice.HeadOrders.SingleOrDefault(t => t.ID_HeadOrder == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.HeadOrders.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
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

                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);


                    var panelTypeName = "Panel";
                    var tBTName = "TextBox";
                    var mTBTName = "MaskedTextBox";
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
                        DGAddColumn(gridView, item.Key);

                        switch (item.Key)
                        {
                            case "Date":
                                controls.Add(item.Key,
                                    item.Value.Controls.Find($"{item.Key}{dateTimePickerTypeName}", true)[0]);
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
                        var newRow = new PerformedHeadOrder()
                        {
                            ID_PerformedOrder = Guid.NewGuid(),
                            ID_HeadOrder = Guid.Parse(controls["ID_HeadOrder"].Text),
                            ID_Employee = Guid.Parse(controls["ID_Employee"].Text),
                            Date = (controls["Date"] as DateTimePicker).Value
                        };

                        GlobalHelper.MainOffice.PerformedHeadOrders.Add(newRow);
                        GlobalHelper.MainOffice.SaveChanges();
                        OpenTable(listbox, selectedIndex);
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

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_PerformedOrder"].Text);
                        var delRow = GlobalHelper.MainOffice.PerformedHeadOrders.SingleOrDefault(t => t.ID_PerformedOrder == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.PerformedHeadOrders.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();
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

                    hSplitContainer.Panel2.Controls.Add(delButton);
                    hSplitContainer.Panel2.Controls.Add(updButton);
                    hSplitContainer.Panel2.Controls.Add(addButton);

                    var panelTypeName = "Panel";
                    var tBTName = "TextBox";
                    var mTBTName = "MaskedTextBox";
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

                    var table = GlobalHelper.MainOffice.Users.ToList();
                    gridView.RowCount = table.Count();

                    for (var i = 0; i < table.Count(); i++)
                    {
                        gridView["ID_Employee", i].Value = table[i].ID_Employee.ToString();
                        gridView["UserLogin", i].Value = table[i].UserLogin.ToString();
                        gridView["UserPassword", i].Value = table[i].UserPassword.ToString();

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
                        OpenTable(listbox, selectedIndex);
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

                        OpenTable(listbox, selectedIndex);
                    };

                    delButton.Click += (sender, args) =>
                    {
                        var id = Guid.Parse(controls["ID_Employee"].Text);
                        var delRow = GlobalHelper.MainOffice.Users.SingleOrDefault(t => t.ID_Employee == id);

                        if (delRow == null)
                            return;

                        GlobalHelper.MainOffice.Users.Remove(delRow);
                        GlobalHelper.MainOffice.SaveChanges();


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
                }*/
            }
        }
    }
}

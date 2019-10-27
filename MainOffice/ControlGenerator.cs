using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainOffice
{
    public static class ControlGenerator
    {
        public static DataGridView CreateDataGridView(string columnName)
        {
            return new DataGridView()
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
                Name = $"{columnName}DataGridView",
                ReadOnly = true,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                Size = new Size(611, 203),
                TabStop = false
            };
        }

        public static void DGAddColumn(DataGridView dgw, string colName)
        {
            dgw.Columns.Add(colName, colName);
        }

        public static Panel CreateCheckBox(string columnName, int tabIndex)
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

        public static Button CeateButton(string name, int tabIndex)
        {
            return new Button
            {
                Dock = DockStyle.Top,
                Text = name,
                Name = $"{name}Button",
                TabIndex = tabIndex
            };
        }

        public static Panel CreateDateTimePicker(string columnName, int tabIndex)
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

        public static Panel CreateTextBox(string columnName, int tabIndex, bool isPrimary)
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

        public static Panel CreateMaskedTextBox(string columnName, int tabIndex, bool isPrimary)
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
    }
}

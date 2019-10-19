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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dataBase = DistributedDataBaseContainer.GenerateConnection(DataBaseType.Factory, ConnectionType.Host);


            var res = dataBase.Positions.Select(i => i).ToList();
            MessageBox.Show(res.Count.ToString());
            MessageBox.Show(res[0].NamePosition);
        }
    }
}

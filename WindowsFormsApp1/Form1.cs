using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void xMLBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.xMLBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testXmlDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testXmlDataSet.XML". При необходимости она может быть перемещена или удалена.
            this.xMLTableAdapter.Fill(this.testXmlDataSet.XML);

        }
    }
}

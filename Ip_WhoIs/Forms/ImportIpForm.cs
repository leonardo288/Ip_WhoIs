using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;

namespace Ip_WhoIs.Forms
{
    public partial class ImportIpForm : System.Windows.Forms.Form
    {
        ImportIp ip = new ImportIp();
        private BindingSource bindingSource = new BindingSource();
        private BindingSource IPbindingSource = new BindingSource();
        public ImportIpForm()
        {
            InitializeComponent();
            bindingSource.DataSource = ip.GetIPAddresses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip.InsertIntoDB(textBox1.Text);
            this.dataGridView1.DataSource = ip.GetIPAddresses();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ImportIpForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }
    }
}

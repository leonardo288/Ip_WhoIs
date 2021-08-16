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
    public partial class Remove : Form
    {
        private BindingSource bindingSource = new BindingSource();
        ImportIp ip = new ImportIp();
        public Remove()
        {
            InitializeComponent();
            bindingSource.DataSource = ip.GetIPAddresses();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = ip.Filter(txtIP.Text.ToString());
        }

        private void Remove_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item", " ", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    IPAddress iP = new IPAddress();
                    iP.ip = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    ip.Delete(iP);
                    bindingSource.DataSource = ip.GetIPs();
                }
                else if (result == DialogResult.No)
                {

                }
            }
        }
    }
}

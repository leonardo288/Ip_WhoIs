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
    public partial class EditMain : Form
    {
        private BindingSource bindingSource = new BindingSource();
        ImportIp ip = new ImportIp();
        public EditMain()
        {
            InitializeComponent();
            bindingSource.DataSource = ip.GetIPAddresses();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                Edit edit = new Edit(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                edit.Show();

                edit.txtIP.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                edit.txtSuccess.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                edit.txtType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                edit.txtContinent.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                edit.txtConCode.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                edit.txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                edit.txtCounCode.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                edit.txtFlag.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                edit.txtCapital.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                edit.txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                edit.txtNeigh.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                edit.txtRegion.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                edit.txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                edit.txtLatit.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                edit.txtLong.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                edit.txtAsn.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                edit.txtOrg.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                edit.txtIsp.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                edit.txtTime.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                edit.txtTimeName.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                edit.txtDstOff.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
                edit.txtGmtOff.Text = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
                edit.txtGmt.Text = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                edit.txtCurrency.Text = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
                edit.txtCurrencyCode.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
                edit.txtCurrencySymbol.Text = dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString();
                edit.txtCurrencyRates.Text = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();
                edit.txtCurrencyPlural.Text = dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString();
                edit.txtRequests.Text = dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString();

                this.Close();
            }
        }
        private void EditMain_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = ip.Filter(txtIP.Text.ToString());
        }
    }
}

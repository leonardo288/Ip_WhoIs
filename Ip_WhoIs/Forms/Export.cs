using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Repository;

namespace Ip_WhoIs.Forms
{
    public partial class Export : System.Windows.Forms.Form
    {
        ImportIp ip = new ImportIp();
        private BindingSource bindingSource = new BindingSource();
        public Export()
        {
            InitializeComponent();
            bindingSource.DataSource = ip.GetIPAddresses();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveFile = JsonConvert.SerializeObject(ip.GetIPAddresses());

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*|Json files (*.json)|*.json";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.WriteLine(saveFile);
            }
        }

        private void Export_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                Export2 formexport = new Export2();
                formexport.Show();
                formexport.btnShowMap.Hide();

                formexport.lblIP.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                formexport.lblSuccess.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                formexport.lblType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                formexport.lblContinent.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                formexport.lblConCode.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                formexport.lblCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                formexport.lblCounCode.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                formexport.lblFlag.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                formexport.lblCapital.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                formexport.lblPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                formexport.lblNeigh.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                formexport.lblRegion.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                formexport.lblCity.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                formexport.lblLat.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                formexport.lblLong.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                formexport.lblAsn.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                formexport.lblOrg.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                formexport.lblIsp.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                formexport.lblTimezone.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                formexport.lblTimename.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                formexport.lblTimeDstOff.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
                formexport.lblTimeGmtOff.Text = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
                formexport.lblGmt.Text = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                formexport.lblCurrency.Text = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
                formexport.lblCurrencyCode.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
                formexport.lblCurrencySymbol.Text = dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString();
                formexport.lblCurrencyRate.Text = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();
                formexport.lblCurrencyPlural.Text = dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString();
                formexport.lblRequests.Text = dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString();

                formexport.webBrowser1.Url = new Uri(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }
    }
}

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
    public partial class Export2 : Form
    {
        public Export2()
        {
            InitializeComponent();
        }

        private void lblFlag_Click(object sender, EventArgs e)
        {

        }

        private void Export2_Load(object sender, EventArgs e)
        {
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            IPAddress ip = new IPAddress();
            ip.ip = lblIP.Text;
            ip.success = lblSuccess.Text;
            ip.type = lblType.Text;
            ip.continent = lblContinent.Text;
            ip.continent_code = lblConCode.Text;
            ip.country = lblCountry.Text;
            ip.country_code = lblConCode.Text;
            ip.country_flag = lblFlag.Text;
            ip.country_capital = lblCapital.Text;
            ip.phone = lblPhone.Text;
            ip.country_neighbours = lblNeigh.Text;
            ip.region = lblRegion.Text;
            ip.city = lblCity.Text;
            ip.latitude = lblLat.Text;
            ip.longitude = lblLong.Text;
            ip.asn = lblAsn.Text;
            ip.org = lblOrg.Text;
            ip.isp = lblIsp.Text;
            ip.time_zone = lblTimezone.Text;
            ip.timezone_name = lblTimename.Text;
            ip.timezone_dstOffset = lblTimeDstOff.Text;
            ip.timezone_gmtOffset = lblTimeGmtOff.Text;
            ip.timezone_gmt = lblGmt.Text;
            ip.currency = lblCurrency.Text;
            ip.currency_code = lblConCode.Text;
            ip.currency_symbol = lblCurrencySymbol.Text;
            ip.currency_rates = lblCurrencyRate.Text;
            ip.currency_plural = lblCurrencyPlural.Text;
            ip.complete_requests = lblRequests.Text;

            string saveFile = JsonConvert.SerializeObject(ip);    

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*|Json files (*.json)|*.json";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.WriteLine(saveFile);
            }

            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            Map form = new Map(lblLong.Text.ToString(), lblLat.Text.ToString());
            form.Show();
        }
    }
}

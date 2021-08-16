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
    public partial class Edit : Form
    {
        string Adresa;
        public Edit(string address)
        {
            InitializeComponent();
            Adresa = address;
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IPAddress ip = new IPAddress();
            ip.ip = txtIP.Text;
            ip.success = txtSuccess.Text;
            ip.type = txtType.Text;
            ip.continent = txtContinent.Text;
            ip.continent_code = txtConCode.Text;
            ip.country = txtCountry.Text;
            ip.country_code = txtConCode.Text;
            ip.country_flag = txtFlag.Text;
            ip.country_capital = txtCapital.Text;
            ip.phone = txtPhone.Text;
            ip.country_neighbours = txtNeigh.Text;
            ip.region = txtRegion.Text;
            ip.city = txtCity.Text;
            ip.latitude = txtLatit.Text;
            ip.longitude = txtLong.Text;
            ip.asn = txtAsn.Text;
            ip.org = txtOrg.Text;
            ip.isp = txtIsp.Text;
            ip.time_zone = txtTime.Text;
            ip.timezone_name = txtTimeName.Text;
            ip.timezone_dstOffset = txtDstOff.Text;
            ip.timezone_gmtOffset = txtGmtOff.Text;
            ip.timezone_gmt = txtGmt.Text;
            ip.currency = txtCurrency.Text;
            ip.currency_code = txtConCode.Text;
            ip.currency_symbol = txtCurrencySymbol.Text;
            ip.currency_rates = txtCurrencyRates.Text;
            ip.currency_plural = txtCurrencyPlural.Text;
            ip.complete_requests = txtRequests.Text;

            ImportIp Ip = new ImportIp();
            Ip.Update(ip, Adresa);

            this.Close();
        }
    }
}

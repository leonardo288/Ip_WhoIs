using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ip_WhoIs.Forms
{
    public partial class Map : Form
    {
        string latit;
        string longi;
        public Map(string longitude, string latitude)
        {
            InitializeComponent();
            latit = latitude;
            longi = longitude;
        }

        private void webMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Map_Load(object sender, EventArgs e)
        {
            webMap.Url = new System.Uri("https://maps.google.com/?q=" + latit + "," + longi + "");
        }
    }
}

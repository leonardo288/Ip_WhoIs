using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Windows.Themes;
using Repository;



namespace Ip_WhoIs
{
    public partial class HomeForm : Form
    {
       

        public HomeForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
        
        }

        //------------DESIGN--------------

        private Button currentButton;
        private Random random;
        private int TempIndex;
        private Form activeForm;

        private Color SelectThemeColor()
        {
            int index = random.Next(Design.ColorList.Count);
            while (TempIndex == index)
            {
               index = random.Next(Design.ColorList.Count);
            }
            TempIndex = index;
            string color = Design.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActiveButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    pnlTitle.BackColor = color;
                }
            }
        }

        private void ChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlForm.Controls.Add(childForm);
            this.pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in pnlControls.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(64, 64, 64);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnIP_Click_1(object sender, EventArgs e)
        {
            ChildForm(new Forms.ImportIpForm(), sender);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChildForm(new Forms.Export(), sender);
        }

        private void pnlControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChildForm(new Forms.Home(), sender);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChildForm(new Forms.Search(), sender);
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            ChildForm(new Forms.EditMain(), sender);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ChildForm(new Forms.Remove(), sender);
            
        }
    }
}

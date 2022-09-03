using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webroamransomwgui
{
    public partial class AlertRansome : Form
    {
        string[] Args = null;
        public AlertRansome(string[] args)
        {
            Args = args[0].Split(',');
            InitializeComponent();
        }
        public AlertRansome()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertRansome_Load(object sender, EventArgs e)
        {
            if (Args != null)
                label6.Text = Args[0];
            var rec = Screen.GetWorkingArea(this);
            this.Location = new Point(rec.Right/2,
                          rec.Bottom - Size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form1(Args);
            this.Hide();
            frm.Show();
            frm.FormClosed += Frm_FormClosed;
            
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}

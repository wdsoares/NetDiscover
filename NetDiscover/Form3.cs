using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace NetDiscover
{
    public partial class Form3 : Form
    {
        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface inter in Interfaces)
            {
                listBox1.Items.Add(inter.Description.ToString());                            
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selec = listBox1.SelectedIndex.ToString();
            this.ReturnValue1 = selec;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

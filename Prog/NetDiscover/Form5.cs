using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using CsvHelper;
using System.IO;
using System.Text.RegularExpressions;

namespace NetDiscover
{
    public partial class Form5 : Form
    {
        List<fabricantes_listagem> fabs;
        public string ReturnValue1 { get; set; }
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            using (var sr = new StreamReader("./mac-vendor.csv"))
            using (var csv = new CsvReader(sr))
            {
                csv.Configuration.HasHeaderRecord = false;
                fabs = csv.GetRecords<fabricantes_listagem>().ToList();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fabs;
            dataGridView1.Columns[1].Width = 300;
        }

    }
     public class fabricantes_listagem
    {
        public string MAC { get; set; }
        public string Fabricante { get; set; }

        public fabricantes_listagem()
        {

        }
    }
}

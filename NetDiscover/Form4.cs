using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;

namespace NetDiscover
{
    public partial class Form4 : Form
    {
        public string ReturnValue1 { get; set; }
        
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 7)
            {
                List<fabricantes> fabs = new List<fabricantes>();
                using (var sr = new StreamReader("./mac-vendor.csv"))
                using (var csv = new CsvReader(sr))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    fabs = csv.GetRecords<fabricantes>().ToList();
                }
                string entrada = textBox1.Text;
                int find = 0;
                foreach (var item in fabs)
                {
                    if (item.cod.Contains(entrada.ToUpper()))
                    {
                        find++;
                        MessageBox.Show("Fabricante: " + item.fab);
                        break;
                    }
                }
                if (find == 0)
                {
                    MessageBox.Show("Fabricante não encontrado!");
                }
            }
            else
            {
                MessageBox.Show("Preencha corretamente o endereço!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}

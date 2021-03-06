﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using CsvHelper;
using System.IO;
using System.Text.RegularExpressions;
using UITimer = System.Windows.Forms.Timer;


/* ÃÃÃÃÃNNNHHH ÕÕÕÕÕNNNHHH HÕÃÃÃÃNNNN HÃÃÃÕÕNNNN 
    vose caiu no gemidaum do ce charpi
 * APOSKAOPKSPOAKSPOAKSOPAKSPOKASOPKAPOSKOPAKS
 */

namespace NetDiscover
{
    public partial class Form1 : Form
    {
        private UITimer timer1, timer2; 
        int selec = 0,tick = 0;
        string interf, subn, ips;
        int pref;
        IPAddress faixaini, faixafim;
        List<fabricantes> fabs;
        List<listaip> lista = new List<listaip>();
        List<MacIpPair> matches = new List<MacIpPair>();

        public Form1()
        {
            InitializeComponent();
        }

        //Ao iniciar, cria uma lista com todos os fabricantes e macs disponíveis, e carrega o histórico da sessão anterior
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var sr = new StreamReader("./mac-vendor.csv"))
            using (var csv = new CsvReader(sr))
            {
                csv.Configuration.HasHeaderRecord = false;
                fabs = csv.GetRecords<fabricantes>().ToList();
            }
            using (var srs = new StreamReader("./addresses.csv"))
            using (var csvs = new CsvReader(srs))
            {
                csvs.Configuration.HasHeaderRecord = true;
                matches = csvs.GetRecords<MacIpPair>().ToList();
            }

            List<MacIpPair> nova = new List<MacIpPair>();
            foreach(var i in matches)
            {
                MacIpPair novo = i;
                novo.Status = "Offline";
                nova.Add(novo);
            }
            matches = nova;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = matches;
            dataGridView1.Columns[2].Width = 140;
            totaldisp_label.Text = dataGridView1.RowCount.ToString();
            totaldisp_label.Visible = true;
        }
        //Cria arquivo com os registros da busca
        public void updatestatus()
        {
            try
            {
                using (var txtWriter = new StreamWriter(@"./addresses.csv"))
                {
                    var writer = new CsvWriter(txtWriter);
                    writer.Configuration.Delimiter = ",";
                    writer.WriteRecords(matches);
                }
                MessageBox.Show("Sucesso!");
            }
            catch
            {
                MessageBox.Show("Não foi possível criar/acessar o arquivo, execute o aplicativo como administrador!");
            }
        }
        
        private void ScanButton_Click(object sender, EventArgs e)
        {
            tick = 0;
            if (Convert.ToInt32(textBox1.Text) < 500)
            {
                MessageBox.Show("Insira um valor acima de 500ms!");
                return;
            }
            using (var win = new Form3())
            {
                var result = win.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Int32.TryParse(win.ReturnValue1, out selec);
                }
            }
            //Obtém as propriedades do adaptador de rede
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            IPInterfaceProperties adapterProperties = Interfaces[selec].GetIPProperties();
            GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
            UnicastIPAddressInformationCollection UnicastIPInfoCol = Interfaces[selec].GetIPProperties().UnicastAddresses;
            foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
            {//exibe as propriedades nos labels da form 
                interface_label.Text = Interfaces[selec].Description;
                interf = Interfaces[selec].Description;
                interface_label.Visible = true;
                ip_label.Text = UnicatIPInfo.Address.ToString();
                ips = UnicatIPInfo.Address.ToString();
                ip_label.Visible = true;
                subnet_label.Text = UnicatIPInfo.IPv4Mask.ToString();
                subn = UnicatIPInfo.IPv4Mask.ToString();
                subnet_label.Visible = true;
                pre_label.Text = "/" + UnicatIPInfo.PrefixLength.ToString();
                pref = UnicatIPInfo.PrefixLength;
                pre_label.Visible = true;
            }
            //////////////////////////////////////////////////////////////////////////////////////////
            //Obtém o IP da rede e faixa inicial da rede
            //Endereço IP
            IPAddress ad = IPAddress.Parse(ip_label.Text);
            Byte[] ipbytes = ad.GetAddressBytes();
            //Subnet
            IPAddress sbn = IPAddress.Parse(subnet_label.Text);
            Byte[] sbnbytes = sbn.GetAddressBytes();
            string[] ipbin = new string[4], sbnbin = new string[4];
            for (int k = 0; k < ipbytes.Length; k++)
            {   //Converte cada byte do ip para binário, adicionando zeros ao início com o PadLeft();
                ipbin[k] = Convert.ToString(ipbytes[k], 2).PadLeft(8, '0');
                sbnbin[k] = Convert.ToString(sbnbytes[k], 2).PadLeft(8, '0');
            }
            string[] ipabsoluto = new string[4];
            string ipp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ipbin[i].ToString()[j] == '1' && sbnbin[i].ToString()[j] == '1')
                    {
                        ipabsoluto[i] += '1';
                    }
                    else
                    {
                        ipabsoluto[i] += '0';
                    }
                }
                int str = Convert.ToInt32(ipabsoluto[i], 2);
                ipp += str.ToString();
                if (i < 3)
                {
                    ipp += '.';
                }
            }
            IPAddress ipa = IPAddress.Parse(ipp);
            iprede_label.Text = ipa.ToString();
            iprede_label.Visible = true;
            ////////////////////////////////////////////////////////////////////////////////////
            //Converte o ip inicial para binário
            string[] ip_ini = new string[4];
            Byte[] ini = ipa.GetAddressBytes();
            ini[3] = 1;
            for (int k = 0; k < ini.Length; k++)
            {
                ip_ini[k] = Convert.ToString(ini[k], 2).PadLeft(8,'0');
            }
            ////////////////////////////////////////////
            // Transfere o array de string ip_ini para uma string
            string ipini = string.Empty;
            int kk = 0;
            foreach (string i in ip_ini)
            {
                int str = Convert.ToInt32(ip_ini[kk], 2);
                ipini += str.ToString();
                if (kk < 3)
                {
                    ipini += '.';
                }
                kk++;
            }
            faixaini = IPAddress.Parse(ipini);
            ////////////////////////////////////////////
            ////////////////////////////////////////////
            // Calcula último ip possível por inversão de bits
            string[] ip_fim = new string[4];
            int cont = 1; ipp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cont <= pref)
                    {
                        ip_fim[i] += ip_ini[i].ToString()[j];
                    }
                    else
                    {
                        if (ip_ini[i].ToString()[j] == '1')
                        {
                            ip_fim[i] += '0';
                        }
                        else
                        {
                            ip_fim[i] += '1';
                        }
                    }
                    cont++;
                }
                int str = Convert.ToInt32(ip_fim[i], 2);
                ipp += str.ToString();
                if (i < 3)
                {
                    ipp += '.';
                }
            }
            //////////////////////////////////////////////
            IPAddress ipfinal = IPAddress.Parse(ipp);
            faixafim = ipfinal;
            ini_label.Text = ipini;
            ini_label.Visible = true;
            fim_label.Text = ipfinal.ToString();
            fim_label.Visible = true;

            int[] ip_iterador = new int[4];
            int[] subnet_iterador = new int[4];
            int[] ipfim = new int[4];
            //Converte o ip inicial de volta para array de inteiros
            for (int kl = 0; kl < 4; kl++)
            {
                ip_iterador[kl] = Convert.ToInt32(ipabsoluto[kl],2);
            }
            //Converte a subnet para array de inteiros
            for (int kl = 0; kl < 4; kl++)
            {
                subnet_iterador[kl] = sbnbytes[kl];
            }
            //Converte o ip final para array de inteiros
            for (int kl = 0; kl < 4; kl++)
            {
                ipfim[kl] = Convert.ToInt32(ip_fim[kl], 2);
            }
            //////////////////////////////////////////////////
            // Calcula o total de endereços na faixa
            int faixatotal = 1, resto = 256 - ipfim[3];
            for (int it = 3; subnet_iterador[it] != 255; it--)
            {
                if (subnet_iterador[it] == 0)
                {
                    faixatotal *= 256;
                }
                else
                {
                    faixatotal *= 255 - subnet_iterador[it];
                }
            }
            faixatotal -= resto;
            totalend_label.Text = faixatotal.ToString();
            totalend_label.Visible = true;
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // Cria lista de endereços disponíveis
            Byte[] inicio = ipa.GetAddressBytes();
            inicio[3]++;
            int i0 = 0, i1 = 0, i2 = 0, i3 = 0;
            for (int it = 0; it < faixatotal; it++)
            {
                string novo = string.Empty;
                for (int i = 0; i < 4; i++)
                {
                    novo += inicio[i].ToString();
                    if (i < 3)
                    {
                        novo += '.';
                    }
                }
                lista.Add(new listaip()
                    {
                        ip = IPAddress.Parse(novo),
                    }
                         );
                i3++;
                inicio[3]++;
                if (i3 == 255)
                {
                    i3 = 0;
                    i2++;
                    inicio[2]++;
                }
                if (i2 == 255)
                {
                    i2 = 0;
                    i1++;
                    inicio[1]++;
                }
                if (i1 == 255)
                {
                    i1 = 0;
                    i0++;
                    inicio[0]++;
                }
            }

            //Confirmação para grande números de endereços
            if (MessageBox.Show("ATENÇÃO!" + Environment.NewLine + "Escaneamentos com mais de 8192 endereços podem levar a travamentos e crashs no sistema, continuar?"
                , "Confirmar ação",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                InitTimer2();
                InitTimer(Convert.ToInt32(textBox1.Text));
            }
            else
            {
                return;
            }
            ////////////////////////////////////////////
        }

        public void fetchlist()
        {
            List<MacIpPair> listaa = ArpA(faixaini.ToString(), faixafim.ToString());
            foreach (MacIpPair i in listaa)
            {
                if (!matches.Exists(x => x.MAC == i.MAC))
                {
                    matches.Add(i);
                }
                for (int ik = 0; ik < matches.Count; ik++ )
                {
                    if (matches[ik].Status == "Offline" && matches[ik].MAC == i.MAC)
                    {
                        MacIpPair novo = i;
                        novo.Status = "Online";
                        matches.Remove(matches[ik]);
                        matches.Add(novo);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = matches;
            dataGridView1.Columns[2].Width = 140;
            totaldisp_label.Text = dataGridView1.RowCount.ToString();
            totaldisp_label.Visible = true;
        }

        public async void PingAsync()
        {
            string data = "aaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            var tasks = lista.Select(ips => new Ping().SendPingAsync(ips.ip.ToString(), 600,buffer));
            var results = await Task.WhenAll(tasks);
        }

        public string getMacByIp(string ip)
        {
            var macIpPairs = ArpA(faixaini.ToString(),faixafim.ToString());
            int index = macIpPairs.FindIndex(x => x.IP == ip);
            if (index >= 0)
            {
                return macIpPairs[index].MAC.ToUpper();
            }
            else
            {
                return null;
            }
        }

        //ArpA = Executa comando arp -a para coletar MAC
        public List<MacIpPair> ArpA(string ini, string fim)
        {
            List<MacIpPair> mip = new List<MacIpPair>();
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a ";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string cmdOutput = pProcess.StandardOutput.ReadToEnd();
            string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

            foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
            {
                if ((String.Compare(m.Groups["ip"].Value, fim) <= 0) && (String.Compare(m.Groups["ip"].Value, ini) >= 0))
                {
                    mip.Add(new MacIpPair()
                    {
                        MAC = m.Groups["mac"].Value,
                        IP = m.Groups["ip"].Value,
                        Fabricante = acha_fab(m.Groups["mac"].Value, fabs),
                        Data = DateTime.Now,
                        Status = "Novo"

                    });  
                }
            }
            return mip;            
        }

        public string acha_fab(string mac, List<fabricantes>lista)
        {
            foreach (var item in lista)
            {
                if (mac.Contains(item.cod.ToLower()))
                {
                    return item.fab;
                }
            }
            return "NÃO ENCONTRADO";   
        }

        public struct MacIpPair
        {
            public string IP { get; set; }
            public string MAC { get; set; }
            public string Fabricante { get; set; }
            public DateTime Data { get; set; }
            public string Status { get; set; }
        }

        private void consultarBancoDeDadosDeFabricantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var win = new Form4())
            {
                var result = win.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Int32.TryParse(win.ReturnValue1, out selec);
                }
            }
        }

        private void listarFabricantesEMACsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var win = new Form5())
            {
                var result = win.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Int32.TryParse(win.ReturnValue1, out selec);
                }
            }
        }

        public void InitTimer(int tempo)
        {
            timer1 = new UITimer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = tempo; // in miliseconds
            timer1.Start();
            varredura_label.Text = tick.ToString();
            varredura_label.Visible = true;
            button1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            varredura_label.Text = tick.ToString();
            dataGridView1.Update();
            dataGridView1.Refresh();
            fetchlist();
        }

        public void InitTimer2()
        {
            timer2 = new UITimer();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 3000; // in miliseconds
            timer2.Start();
            varredura_label.Text = tick.ToString();
            varredura_label.Visible = true;
            button1.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PingAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, insira somente números");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            timer1.Stop();
            timer2.Stop();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatestatus();
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectInterface_Button.PerformClick();
        }

    }

    public class fabricantes
    {
        public string cod { get; set; }
        public string fab { get; set; }

        public fabricantes()
        {

        }
    }

    public struct listaip
    {
        public IPAddress ip { get; set; }
    }
}

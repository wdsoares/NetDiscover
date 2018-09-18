namespace NetDiscover
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectInterface_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.interface_label = new System.Windows.Forms.Label();
            this.ip_label = new System.Windows.Forms.Label();
            this.subnet_label = new System.Windows.Forms.Label();
            this.prefixo_label = new System.Windows.Forms.Label();
            this.pre_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iprede_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ini_label = new System.Windows.Forms.Label();
            this.fim_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarBancoDeDadosDeFabricantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarFabricantesEMACsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.totalend_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.totaldisp_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.varredura_label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // SelectInterface_Button
            // 
            resources.ApplyResources(this.SelectInterface_Button, "SelectInterface_Button");
            this.SelectInterface_Button.Name = "SelectInterface_Button";
            this.SelectInterface_Button.UseVisualStyleBackColor = true;
            this.SelectInterface_Button.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // interface_label
            // 
            resources.ApplyResources(this.interface_label, "interface_label");
            this.interface_label.Name = "interface_label";
            // 
            // ip_label
            // 
            resources.ApplyResources(this.ip_label, "ip_label");
            this.ip_label.Name = "ip_label";
            // 
            // subnet_label
            // 
            resources.ApplyResources(this.subnet_label, "subnet_label");
            this.subnet_label.Name = "subnet_label";
            // 
            // prefixo_label
            // 
            resources.ApplyResources(this.prefixo_label, "prefixo_label");
            this.prefixo_label.Name = "prefixo_label";
            // 
            // pre_label
            // 
            resources.ApplyResources(this.pre_label, "pre_label");
            this.pre_label.Name = "pre_label";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // iprede_label
            // 
            resources.ApplyResources(this.iprede_label, "iprede_label");
            this.iprede_label.Name = "iprede_label";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ini_label
            // 
            resources.ApplyResources(this.ini_label, "ini_label");
            this.ini_label.Name = "ini_label";
            // 
            // fim_label
            // 
            resources.ApplyResources(this.fim_label, "fim_label");
            this.fim_label.Name = "fim_label";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.miscToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarBancoDeDadosDeFabricantesToolStripMenuItem,
            this.listarFabricantesEMACsToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            resources.ApplyResources(this.miscToolStripMenuItem, "miscToolStripMenuItem");
            // 
            // consultarBancoDeDadosDeFabricantesToolStripMenuItem
            // 
            this.consultarBancoDeDadosDeFabricantesToolStripMenuItem.Name = "consultarBancoDeDadosDeFabricantesToolStripMenuItem";
            resources.ApplyResources(this.consultarBancoDeDadosDeFabricantesToolStripMenuItem, "consultarBancoDeDadosDeFabricantesToolStripMenuItem");
            this.consultarBancoDeDadosDeFabricantesToolStripMenuItem.Click += new System.EventHandler(this.consultarBancoDeDadosDeFabricantesToolStripMenuItem_Click);
            // 
            // listarFabricantesEMACsToolStripMenuItem
            // 
            this.listarFabricantesEMACsToolStripMenuItem.Name = "listarFabricantesEMACsToolStripMenuItem";
            resources.ApplyResources(this.listarFabricantesEMACsToolStripMenuItem, "listarFabricantesEMACsToolStripMenuItem");
            this.listarFabricantesEMACsToolStripMenuItem.Click += new System.EventHandler(this.listarFabricantesEMACsToolStripMenuItem_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // totalend_label
            // 
            resources.ApplyResources(this.totalend_label, "totalend_label");
            this.totalend_label.Name = "totalend_label";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // totaldisp_label
            // 
            resources.ApplyResources(this.totaldisp_label, "totaldisp_label");
            this.totaldisp_label.Name = "totaldisp_label";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // varredura_label
            // 
            resources.ApplyResources(this.varredura_label, "varredura_label");
            this.varredura_label.Name = "varredura_label";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            resources.ApplyResources(this.filesToolStripMenuItem, "filesToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.varredura_label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.totaldisp_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totalend_label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fim_label);
            this.Controls.Add(this.ini_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.iprede_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pre_label);
            this.Controls.Add(this.prefixo_label);
            this.Controls.Add(this.subnet_label);
            this.Controls.Add(this.ip_label);
            this.Controls.Add(this.interface_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectInterface_Button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SelectInterface_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label interface_label;
        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.Label subnet_label;
        private System.Windows.Forms.Label prefixo_label;
        private System.Windows.Forms.Label pre_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label iprede_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ini_label;
        private System.Windows.Forms.Label fim_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarBancoDeDadosDeFabricantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarFabricantesEMACsToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label totalend_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totaldisp_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label varredura_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}


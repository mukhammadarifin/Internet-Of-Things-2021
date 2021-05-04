namespace SocketTCP
{
    partial class frmKontrolTCP
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxLCD = new System.Windows.Forms.GroupBox();
            this.txtTeksDikirim2 = new System.Windows.Forms.TextBox();
            this.lblBaris2 = new System.Windows.Forms.Label();
            this.lblBaris1 = new System.Windows.Forms.Label();
            this.btnKirim = new System.Windows.Forms.Button();
            this.txtTeksDikirim1 = new System.Windows.Forms.TextBox();
            this.groupBoxLED = new System.Windows.Forms.GroupBox();
            this.rdKuning = new System.Windows.Forms.RadioButton();
            this.rdHijau = new System.Windows.Forms.RadioButton();
            this.rdMerah = new System.Windows.Forms.RadioButton();
            this.txtPortTujuan = new System.Windows.Forms.TextBox();
            this.txtIPTujuan = new System.Windows.Forms.TextBox();
            this.lblPortClient = new System.Windows.Forms.Label();
            this.lblIPTujuan = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxKelembaban = new System.Windows.Forms.GroupBox();
            this.lblHum = new System.Windows.Forms.Label();
            this.groupBoxTemperatur = new System.Windows.Forms.GroupBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblIPServer = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtPortServer = new System.Windows.Forms.TextBox();
            this.lblPortServer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxLCD.SuspendLayout();
            this.groupBoxLED.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxKelembaban.SuspendLayout();
            this.groupBoxTemperatur.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(406, 210);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxLCD);
            this.tabPage1.Controls.Add(this.groupBoxLED);
            this.tabPage1.Controls.Add(this.txtPortTujuan);
            this.tabPage1.Controls.Add(this.txtIPTujuan);
            this.tabPage1.Controls.Add(this.lblPortClient);
            this.tabPage1.Controls.Add(this.lblIPTujuan);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(398, 184);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxLCD
            // 
            this.groupBoxLCD.Controls.Add(this.txtTeksDikirim2);
            this.groupBoxLCD.Controls.Add(this.lblBaris2);
            this.groupBoxLCD.Controls.Add(this.lblBaris1);
            this.groupBoxLCD.Controls.Add(this.btnKirim);
            this.groupBoxLCD.Controls.Add(this.txtTeksDikirim1);
            this.groupBoxLCD.Location = new System.Drawing.Point(9, 94);
            this.groupBoxLCD.Name = "groupBoxLCD";
            this.groupBoxLCD.Size = new System.Drawing.Size(378, 80);
            this.groupBoxLCD.TabIndex = 13;
            this.groupBoxLCD.TabStop = false;
            this.groupBoxLCD.Text = "Teks LCD";
            // 
            // txtTeksDikirim2
            // 
            this.txtTeksDikirim2.Location = new System.Drawing.Point(83, 44);
            this.txtTeksDikirim2.Name = "txtTeksDikirim2";
            this.txtTeksDikirim2.Size = new System.Drawing.Size(194, 20);
            this.txtTeksDikirim2.TabIndex = 7;
            // 
            // lblBaris2
            // 
            this.lblBaris2.AutoSize = true;
            this.lblBaris2.Location = new System.Drawing.Point(14, 47);
            this.lblBaris2.Name = "lblBaris2";
            this.lblBaris2.Size = new System.Drawing.Size(55, 13);
            this.lblBaris2.TabIndex = 10;
            this.lblBaris2.Text = "Baris Ke-2";
            // 
            // lblBaris1
            // 
            this.lblBaris1.AutoSize = true;
            this.lblBaris1.Location = new System.Drawing.Point(14, 22);
            this.lblBaris1.Name = "lblBaris1";
            this.lblBaris1.Size = new System.Drawing.Size(55, 13);
            this.lblBaris1.TabIndex = 9;
            this.lblBaris1.Text = "Baris Ke-1";
            // 
            // btnKirim
            // 
            this.btnKirim.Location = new System.Drawing.Point(283, 19);
            this.btnKirim.Name = "btnKirim";
            this.btnKirim.Size = new System.Drawing.Size(78, 45);
            this.btnKirim.TabIndex = 8;
            this.btnKirim.Text = "Kirim";
            this.btnKirim.UseVisualStyleBackColor = true;
            this.btnKirim.Click += new System.EventHandler(this.btnKirim_Click);
            // 
            // txtTeksDikirim1
            // 
            this.txtTeksDikirim1.Location = new System.Drawing.Point(83, 19);
            this.txtTeksDikirim1.Name = "txtTeksDikirim1";
            this.txtTeksDikirim1.Size = new System.Drawing.Size(194, 20);
            this.txtTeksDikirim1.TabIndex = 6;
            // 
            // groupBoxLED
            // 
            this.groupBoxLED.Controls.Add(this.rdKuning);
            this.groupBoxLED.Controls.Add(this.rdHijau);
            this.groupBoxLED.Controls.Add(this.rdMerah);
            this.groupBoxLED.Location = new System.Drawing.Point(9, 43);
            this.groupBoxLED.Name = "groupBoxLED";
            this.groupBoxLED.Size = new System.Drawing.Size(378, 45);
            this.groupBoxLED.TabIndex = 11;
            this.groupBoxLED.TabStop = false;
            this.groupBoxLED.Text = "LED";
            // 
            // rdKuning
            // 
            this.rdKuning.AutoSize = true;
            this.rdKuning.Location = new System.Drawing.Point(163, 19);
            this.rdKuning.Name = "rdKuning";
            this.rdKuning.Size = new System.Drawing.Size(58, 17);
            this.rdKuning.TabIndex = 12;
            this.rdKuning.TabStop = true;
            this.rdKuning.Text = "Kuning";
            this.rdKuning.UseVisualStyleBackColor = true;
            this.rdKuning.Click += new System.EventHandler(this.rdKuning_Click);
            // 
            // rdHijau
            // 
            this.rdHijau.AutoSize = true;
            this.rdHijau.Location = new System.Drawing.Point(265, 19);
            this.rdHijau.Name = "rdHijau";
            this.rdHijau.Size = new System.Drawing.Size(49, 17);
            this.rdHijau.TabIndex = 13;
            this.rdHijau.TabStop = true;
            this.rdHijau.Text = "Hijau";
            this.rdHijau.UseVisualStyleBackColor = true;
            this.rdHijau.Click += new System.EventHandler(this.rdHijau_Click);
            // 
            // rdMerah
            // 
            this.rdMerah.AutoSize = true;
            this.rdMerah.Location = new System.Drawing.Point(72, 19);
            this.rdMerah.Name = "rdMerah";
            this.rdMerah.Size = new System.Drawing.Size(55, 17);
            this.rdMerah.TabIndex = 11;
            this.rdMerah.TabStop = true;
            this.rdMerah.Text = "Merah";
            this.rdMerah.UseVisualStyleBackColor = true;
            this.rdMerah.Click += new System.EventHandler(this.rdMerah_Click);
            // 
            // txtPortTujuan
            // 
            this.txtPortTujuan.Location = new System.Drawing.Point(248, 17);
            this.txtPortTujuan.Name = "txtPortTujuan";
            this.txtPortTujuan.Size = new System.Drawing.Size(55, 20);
            this.txtPortTujuan.TabIndex = 3;
            // 
            // txtIPTujuan
            // 
            this.txtIPTujuan.Location = new System.Drawing.Point(82, 17);
            this.txtIPTujuan.Name = "txtIPTujuan";
            this.txtIPTujuan.Size = new System.Drawing.Size(128, 20);
            this.txtIPTujuan.TabIndex = 2;
            // 
            // lblPortClient
            // 
            this.lblPortClient.AutoSize = true;
            this.lblPortClient.Location = new System.Drawing.Point(216, 20);
            this.lblPortClient.Name = "lblPortClient";
            this.lblPortClient.Size = new System.Drawing.Size(26, 13);
            this.lblPortClient.TabIndex = 1;
            this.lblPortClient.Text = "Port";
            // 
            // lblIPTujuan
            // 
            this.lblIPTujuan.AutoSize = true;
            this.lblIPTujuan.Location = new System.Drawing.Point(23, 20);
            this.lblIPTujuan.Name = "lblIPTujuan";
            this.lblIPTujuan.Size = new System.Drawing.Size(53, 13);
            this.lblIPTujuan.TabIndex = 0;
            this.lblIPTujuan.Text = "IP Tujuan";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxKelembaban);
            this.tabPage2.Controls.Add(this.groupBoxTemperatur);
            this.tabPage2.Controls.Add(this.lblIPServer);
            this.tabPage2.Controls.Add(this.txtIPServer);
            this.tabPage2.Controls.Add(this.btnStartServer);
            this.tabPage2.Controls.Add(this.txtPortServer);
            this.tabPage2.Controls.Add(this.lblPortServer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(398, 184);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Server";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxKelembaban
            // 
            this.groupBoxKelembaban.Controls.Add(this.lblHum);
            this.groupBoxKelembaban.Location = new System.Drawing.Point(199, 67);
            this.groupBoxKelembaban.Name = "groupBoxKelembaban";
            this.groupBoxKelembaban.Size = new System.Drawing.Size(181, 96);
            this.groupBoxKelembaban.TabIndex = 8;
            this.groupBoxKelembaban.TabStop = false;
            this.groupBoxKelembaban.Text = "Kelembaban";
            // 
            // lblHum
            // 
            this.lblHum.AutoSize = true;
            this.lblHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHum.Location = new System.Drawing.Point(6, 16);
            this.lblHum.Name = "lblHum";
            this.lblHum.Size = new System.Drawing.Size(64, 69);
            this.lblHum.TabIndex = 1;
            this.lblHum.Text = "0";
            // 
            // groupBoxTemperatur
            // 
            this.groupBoxTemperatur.Controls.Add(this.lblTemp);
            this.groupBoxTemperatur.Location = new System.Drawing.Point(12, 67);
            this.groupBoxTemperatur.Name = "groupBoxTemperatur";
            this.groupBoxTemperatur.Size = new System.Drawing.Size(181, 96);
            this.groupBoxTemperatur.TabIndex = 7;
            this.groupBoxTemperatur.TabStop = false;
            this.groupBoxTemperatur.Text = "Temperatur";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(6, 16);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(64, 69);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "0";
            // 
            // lblIPServer
            // 
            this.lblIPServer.AutoSize = true;
            this.lblIPServer.Location = new System.Drawing.Point(18, 28);
            this.lblIPServer.Name = "lblIPServer";
            this.lblIPServer.Size = new System.Drawing.Size(51, 13);
            this.lblIPServer.TabIndex = 6;
            this.lblIPServer.Text = "IP Server";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(75, 25);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(104, 20);
            this.txtIPServer.TabIndex = 5;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(296, 21);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 29);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // txtPortServer
            // 
            this.txtPortServer.Location = new System.Drawing.Point(217, 26);
            this.txtPortServer.Name = "txtPortServer";
            this.txtPortServer.Size = new System.Drawing.Size(63, 20);
            this.txtPortServer.TabIndex = 1;
            // 
            // lblPortServer
            // 
            this.lblPortServer.AutoSize = true;
            this.lblPortServer.Location = new System.Drawing.Point(185, 28);
            this.lblPortServer.Name = "lblPortServer";
            this.lblPortServer.Size = new System.Drawing.Size(26, 13);
            this.lblPortServer.TabIndex = 0;
            this.lblPortServer.Text = "Port";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmKontrolTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 210);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmKontrolTCP";
            this.Text = "Socket TCP";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxLCD.ResumeLayout(false);
            this.groupBoxLCD.PerformLayout();
            this.groupBoxLED.ResumeLayout(false);
            this.groupBoxLED.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxKelembaban.ResumeLayout(false);
            this.groupBoxKelembaban.PerformLayout();
            this.groupBoxTemperatur.ResumeLayout(false);
            this.groupBoxTemperatur.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxLCD;
        private System.Windows.Forms.Button btnKirim;
        private System.Windows.Forms.TextBox txtTeksDikirim1;
        private System.Windows.Forms.GroupBox groupBoxLED;
        private System.Windows.Forms.RadioButton rdKuning;
        private System.Windows.Forms.RadioButton rdHijau;
        private System.Windows.Forms.RadioButton rdMerah;
        private System.Windows.Forms.TextBox txtPortTujuan;
        private System.Windows.Forms.TextBox txtIPTujuan;
        private System.Windows.Forms.Label lblPortClient;
        private System.Windows.Forms.Label lblIPTujuan;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtPortServer;
        private System.Windows.Forms.Label lblPortServer;
        private System.Windows.Forms.Label lblIPServer;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.TextBox txtTeksDikirim2;
        private System.Windows.Forms.Label lblBaris2;
        private System.Windows.Forms.Label lblBaris1;
        private System.Windows.Forms.GroupBox groupBoxKelembaban;
        private System.Windows.Forms.GroupBox groupBoxTemperatur;
        private System.Windows.Forms.Label lblHum;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Timer timer1;
    }
}


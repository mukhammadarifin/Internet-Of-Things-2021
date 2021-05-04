using System;
using System.Windows.Forms;

namespace SocketTCP
{
    public partial class frmKontrolTCP : Form
    {
        public frmKontrolTCP()
        {
            InitializeComponent();
            txtIPTujuan.Text = "192.168.0.104";
            txtIPServer.Text = "192.168.0.101";
            txtPortTujuan.Text = "16375";
            txtPortServer.Text = "16375";
            
            txtTeksDikirim1.MaxLength = 16;
            txtTeksDikirim2.MaxLength = 16;
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            if (txtPortTujuan.Text != "" && txtPortTujuan.Text != "")
            {
                GlobalVariable.iptujuan = txtIPTujuan.Text;
                GlobalVariable.port = Convert.ToUInt16(txtPortTujuan.Text);
                SocketLib.StartClient("LCD#" + txtTeksDikirim1.Text + "#" + txtTeksDikirim2.Text + "#");
            }
            else
            {
                MessageBox.Show("Alamat IP dan Port harus diisi!", "Kesalahan");
            }
        }

        private void rdMerah_Click(object sender, EventArgs e)
        {
            if (txtPortTujuan.Text != "" && txtPortTujuan.Text != "")
            {
                GlobalVariable.iptujuan = txtIPTujuan.Text;
                GlobalVariable.port = Convert.ToUInt16(txtPortTujuan.Text);
                SocketLib.StartClient("Merah");
            }
            else
            {
                MessageBox.Show("Alamat IP dan Port harus diisi!", "Kesalahan");
            }
        }

        private void rdHijau_Click(object sender, EventArgs e)
        {
            if (txtPortTujuan.Text != "" && txtPortTujuan.Text != "")
            {
                GlobalVariable.iptujuan = txtIPTujuan.Text;
                GlobalVariable.port = Convert.ToUInt16(txtPortTujuan.Text);
                SocketLib.StartClient("Hijau");
            }
            else
            {
                MessageBox.Show("Alamat IP dan Port harus diisi!", "Kesalahan");
            }
        }

        private void rdKuning_Click(object sender, EventArgs e)
        {
            if (txtPortTujuan.Text != "" && txtPortTujuan.Text != "")
            {
                GlobalVariable.iptujuan = txtIPTujuan.Text;
                GlobalVariable.port = Convert.ToUInt16(txtPortTujuan.Text);
                SocketLib.StartClient("Kuning");
            }
            else
            {
                MessageBox.Show("Alamat IP dan Port harus diisi!", "Kesalahan");
            }
        }
        
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            GlobalVariable.ipserver = txtIPServer.Text;
            GlobalVariable.port = Convert.ToUInt16(txtPortServer.Text);
            System.Threading.Thread thread = new System.Threading.Thread(SocketLib.StartListening);
            thread.Start();
            timer1.Enabled = true;
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobalVariable.pesanTerima != null)
            {
                string data = GlobalVariable.pesanTerima;
                string[] words = data.Split('#');
                lblTemp.Text = words[0] + "°C";
                lblHum.Text = words[1] + "H";
            }
        }
    }
}

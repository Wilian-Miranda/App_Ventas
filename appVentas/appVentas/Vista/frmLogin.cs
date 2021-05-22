using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVentas.DAO;
using AppVentas.VISTA;

namespace AppVentas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btbIniciarSecion_Click(object sender, EventArgs e)
        {
            FrmPrincipal usuarioIngresado = new FrmPrincipal();
            string user = txtUser.Text;
            //usuarioIngresado.lblUsuarioIngresado.Text = user;
            ClsAcceso acce = new ClsAcceso();

            Boolean valor = acce.Acceso(txtUser.Text, txtPass.Text);

            if (valor == true)
            {
                MessageBox.Show("Bienvenido");
                FrmPrincipal principal = new FrmPrincipal();
                this.Visible = false;
                FrmPrincipal.FrVenta.dataGridView1.Rows.Clear();
                FrmPrincipal.FrVenta.txtTotalFinal.Clear();
                principal.Show();
                

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario registroUsuario = new FrmRegistroUsuario();
            this.Visible = false;
            registroUsuario.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int posX = 0;
        int posY = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += (e.Y - posY);
            }
        }
    }
}

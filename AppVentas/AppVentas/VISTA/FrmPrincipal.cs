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

namespace AppVentas.VISTA
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }
        public string usu;

        public static FrmVenta FrVenta= new FrmVenta();
        public void DesactivarResaltado()
        {
            //verificando que el boton actual sea diferente de nulo
            if (btnEnUso != null)
            {
                //RETORNANDO A LAS CONFIGURACIONES POR DEFECTO
                //retornando el color por defecto del boton
                btnEnUso.BackColor = Color.Sienna;
                //Aliniando el texto al centro
                btnEnUso.TextAlign = ContentAlignment.MiddleCenter;
                //cambiado relacion de texto a imagen antes de texto
                btnEnUso.TextImageRelation = TextImageRelation.ImageBeforeText;
                //Aliniando el icono a la izquierda
                btnEnUso.ImageAlign = ContentAlignment.MiddleCenter;
                btnEnUso.FlatAppearance.BorderSize = 3;
                btnEnUso.ForeColor = Color.FromArgb(217, 187, 132);
            }
        }

        Button btnEnUso = new Button();
        //Metodo void para resaltar el botón activo
        public void BotonActivo(object btnActivo)
        {
            //verificando que el botón sea diferente de nulo
            if (btnActivo != null)
            {
                //invocando el método de desactivar resaltado para desactivar el resaltado
                //en el boton anterior
                DesactivarResaltado();
                //BOTÓN
                btnEnUso = (Button)btnActivo;
                //cambiando el color de fondo del color
                btnEnUso.BackColor = Color.FromArgb(217, 187, 132);
                //Aliniando el texto al centro
                btnEnUso.TextAlign = ContentAlignment.MiddleCenter;
                //cambiado relacion de texto a texto antes de imagen
                btnEnUso.TextImageRelation = TextImageRelation.TextBeforeImage;
                //Aliniando el icono a la derecha
                btnEnUso.ImageAlign = ContentAlignment.MiddleRight;
                btnEnUso.FlatAppearance.BorderSize = 3;
                btnEnUso.ForeColor = Color.Sienna;


                ////BORDE IZQUIERDO DEL BOTON
                ////se cambia el borde izquierdo de acuerdo al parámetro color de método
                //bordeIzquierdoDelBoton.BackColor = Color.FromArgb(67, 194, 243);
                ////nueva ubicacion en el eje x y obteniedo la ubicacion en el eje y del boton actual
                //bordeIzquierdoDelBoton.Location = new Point(0, btnEnUso.Location.Y);
                ////visibilidad en verdader
                //bordeIzquierdoDelBoton.Visible = true;
                ////trayendo al frente
                //bordeIzquierdoDelBoton.BringToFront();
            }
        }
        private Form formulario;
        private Form formularioVenta;
        private void AbrirFormEnPanel<Miform>() where Miform : Form, new()
        {
            if (formulario != null)
            {
                formulario.Close();
            }

            formulario = pnlPadre.Controls.OfType<Miform>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Miform();
                formulario.TopLevel = false;
                formulario.Dock = DockStyle.Fill;
                pnlPadre.Controls.Add(formulario);
                pnlPadre.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }

            else
            {
                formulario.BringToFront();
            }
        }
        private void pnlUsuarioIngresado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPadre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //lblUsuarioIngresado.Text = usu;
            cargarDatosLabel();
        }

        private void btbPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<FrmClientes>();
            BotonActivo(btnClientes);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (formulario != null)
            {
                formulario.Close();
                DesactivarResaltado();
            }
            if (formularioVenta != null)
            {
                formularioVenta.Hide();
                FrmPrincipal.FrVenta.dataGridView1.Rows.Clear();
                FrmPrincipal.FrVenta.txtTotalFinal.Clear();
                DesactivarResaltado();
            }
        }


        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<FrmProductos>();
            BotonActivo(btnProductos);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {

            formularioVenta = pnlPadre.Controls.OfType<FrmVenta>().FirstOrDefault();

            if (formularioVenta == null)
            {
                formularioVenta = FrVenta;
                formularioVenta.TopLevel = false;
                formularioVenta.Dock = DockStyle.Fill;
                pnlPadre.Controls.Add(formularioVenta);
                pnlPadre.Tag = formularioVenta;
                formularioVenta.Show();
                formularioVenta.BringToFront();
                FrVenta.txtBuscador.Focus();
            }
            if (formularioVenta != null)
            {
                FrVenta.txtCodigo.Clear();
                FrVenta.txtPrecio.Clear();
                FrVenta.txtProducto.Clear();
                formularioVenta.Show();
                formularioVenta.BringToFront();
                FrVenta.txtBuscador.Focus();
            }

            else
            {
                formularioVenta.BringToFront();
            }
            BotonActivo(btnVentas);
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<FrmDocumentos>();
            BotonActivo(btnDocumentos);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<FrmUsuarios>();
            BotonActivo(btnUsuarios);
        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<FrmActividad>();
            BotonActivo(btnActividad);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public static implicit operator FrmPrincipal(FrmVenta v)
        {
            throw new NotImplementedException();
        }

        private void pnlPadre_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblClientes_Click(object sender, EventArgs e)
        {

        }
        void cargarDatosLabel()
        {
            ClsDdashboard board = new ClsDdashboard();

            lblClientes.Text = board.TotalClientes().ToString();
            lblProductos.Text = board.TotalProductos().ToString();
            lblVentas.Text = board.TotalVentas().ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
        int posX = 0;
        int posY = 0;
        private void pnlUsuarioIngresado_MouseMove(object sender, MouseEventArgs e)
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmPrincipal salir = this;
            FrmLogin login = new FrmLogin();
            login.Show();
            salir.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            cargarDatosLabel();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrVenta.txtCantidad.Focus();
        }
    }
}

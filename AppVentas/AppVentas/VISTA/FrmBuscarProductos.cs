using AppVentas.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.VISTA
{
    public partial class FrmBuscarProductos : Form
    {
        public FrmBuscarProductos()
        {
            InitializeComponent();
        }

        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void cargarDatos()
        {
            ClsDProductos DBproductos = new ClsDProductos();
            dataGridView1.Rows.Clear();
            foreach (var i in DBproductos.CargarProductos(txtBuscardor.Text))
            {
                dataGridView1.Rows.Add(i.idProducto, i.nombreProducto, i.precioProducto, i.estadoProducto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            envio();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void envio()
        {
            FrmVenta venta = VISTA.FrmPrincipal.FrVenta;
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            venta.txtCodigo.Text = id;
            venta.txtProducto.Text = Nombre;
            venta.txtPrecio.Text = precio;
            venta.txtCantidad.Focus();


            this.Close();

        }

        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                
                envio();
            }
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

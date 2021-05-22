using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVentas.MODELO;
using AppVentas.DAO;

namespace AppVentas.VISTA
{
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
            txtCantidad.Text = "0";
            txtPrecio.Text = "0.0000";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            ClsDClientes DBcliente = new ClsDClientes();
            var clientes = DBcliente.CargarComboCliente();
            cbCliente.DataSource = clientes;
            cbCliente.DisplayMember = "nombreCliente";
            cbCliente.ValueMember = "iDCliente";

            ClsDDocumentos BDdocumento = new ClsDDocumentos();
            var BDdoc = BDdocumento.CargarComboDocumentos();
            cbTipoDocumento.DataSource = BDdoc;
            cbTipoDocumento.DisplayMember = "nombreDocumento";
            cbTipoDocumento.ValueMember = "iDDocumento";

            UltimoCorrelativoVenta();
        }
        private void UltimoCorrelativoVenta()
        {
            var UltimaVenta = new ClsDVenta();
            int lista = 0;
            foreach (var i in UltimaVenta.UltimaVenta())
            {
                lista = i.iDVenta;
            }
            lista ++;
            txtUltimaVenta.Text = lista.ToString();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void BuscarProducto()
        {
            FrmBuscarProductos buscar = new FrmBuscarProductos();
            buscar.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

            CalculoTotal();
        }

        private void CalculoTotal()
        {
            if (txtCantidad.Text != "" && txtCantidad.Text!="0" && txtPrecio.Text!="")
            {
                Double cantidad, precio, total;

                cantidad = Convert.ToDouble(txtCantidad.Text);
                precio = Convert.ToDouble(txtPrecio.Text);
                total = cantidad * precio;

                txtTotal.Text = total.ToString();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text.Equals("0.0000"))
            {
                MessageBox.Show("Datos de producto inválidos: campos obligatorios vacíos");
                txtBuscador.Focus();
                Limpiar();
            }
            else
            {
                dataGridView1.Rows.Add(txtCodigo.Text, txtProducto.Text, txtPrecio.Text, txtCantidad.Text, txtTotal.Text);
                Double suma = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string datosOperarTotal = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        Double datosConvertidos = Convert.ToDouble(datosOperarTotal);
                        suma += datosConvertidos;
                    }
                }
                txtBuscador.Focus();
                txtTotalFinal.Text = suma.ToString();
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtProducto.Clear();
            txtPrecio.Text="0.0000";
            txtCantidad.Text="0";
            txtTotal.Text = "0.0000";
        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscador.Focused == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BuscarProducto();
                }

            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCantidad.Focused == true && txtCantidad.Text != "")
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtBuscador.Focus();
                        btnAgregar.PerformClick();
                    }
                }
            }
        }

        public void Focos()
        {
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }

        private void txtCantidad_BackColorChanged(object sender, EventArgs e)
        {
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }
    }
}

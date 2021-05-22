﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVentas.DAO;
using AppVentas.MODELO;
using Microsoft.SqlServer.Server;

namespace AppVentas.VISTA
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            load();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" || txtPrecio.Text == "" || txtEstado.Text == "")
            {
                MessageBox.Show("Datos incompletos: El nombre del producto, su precio y estado, son datos obligatorios");
            }
            else
            {
                ClsDProductos VProductos = new ClsDProductos();
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    tb_producto producto = new tb_producto();
                    producto.nombreProducto = txtProducto.Text;
                    producto.precioProducto = txtPrecio.Text;
                    producto.estadoProducto = txtEstado.Text;
                    VProductos.GuardarProducto(producto);
                    load();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" || txtPrecio.Text == "" || txtEstado.Text == "")
            {
                MessageBox.Show("Datos incompletos: Debe eligir el registro del producto que desea modificar");
            }
            else
            {
                ClsDProductos VProductos = new ClsDProductos();
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    tb_producto producto = new tb_producto();
                    producto.idProducto = Convert.ToInt32(dtgProductos.CurrentRow.Cells[0].Value.ToString());
                    producto.nombreProducto = txtProducto.Text;
                    producto.precioProducto = txtPrecio.Text;
                    producto.estadoProducto = txtEstado.Text;
                    VProductos.ActualizarProducto(producto);
                    load();
                    
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDProductos VProductos = new ClsDProductos();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                VProductos.EliminarProducto(Convert.ToInt32(dtgProductos.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
        }

        private void load()
        {
            dtgProductos.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var consulta = (from a in db.tb_producto
                                select a).ToList();
                foreach (var i in consulta)
                {
                    dtgProductos.Rows.Add(i.idProducto,i.nombreProducto,i.precioProducto,i.estadoProducto);
                }
                //dtgProductos.RowsDefaultCellStyle.Format = "C4";
            }
        }
        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string producto = dtgProductos.CurrentRow.Cells[1].Value.ToString();
            string precio = dtgProductos.CurrentRow.Cells[2].Value.ToString();
            string estado = dtgProductos.CurrentRow.Cells[3].Value.ToString();

            txtProducto.Text = producto;
            txtPrecio.Text = precio;
            txtEstado.Text = estado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            txtEstado.Clear();
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

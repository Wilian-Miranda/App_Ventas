﻿using System;
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
    public partial class FrmDocumentos : Form
    {
        public FrmDocumentos()
        {
            InitializeComponent();
            load();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text =="")
            {
                MessageBox.Show("Los datos están incompletos");
            }
            else
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    ClsDDocumentos VDocumentos = new ClsDDocumentos();
                    tb_documento Documento = new tb_documento();
                    Documento.nombreDocumento = txtDocumento.Text;
                    VDocumentos.GuardarDocumento(Documento);
                    load();
                    Limpiar();

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Los datos están incompletos");
            }
            else
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    ClsDDocumentos VDocumentos = new ClsDDocumentos();
                    tb_documento Documento = new tb_documento();
                    Documento.nombreDocumento = txtDocumento.Text;
                    Documento.iDDocumento = Convert.ToInt32(dtgDoc.CurrentRow.Cells[0].Value.ToString());
                    VDocumentos.ActualizarDocumento(Documento);
                    load();

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDDocumentos VDocumentos = new ClsDDocumentos();
            VDocumentos.EliminarDocumento(Convert.ToInt32(dtgDoc.CurrentRow.Cells[0].Value.ToString()));
            load();
            Limpiar();
        }

        private void load()
        {
            dtgDoc.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var consulta = (from a in db.tb_documento
                                select a).ToList();

                foreach (var i in consulta)
                {
                    dtgDoc.Rows.Add(i.iDDocumento,i.nombreDocumento);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtDocumento.Clear();
        }

        private void dtgDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string doc = dtgDoc.CurrentRow.Cells[1].Value.ToString();
            txtDocumento.Text = doc;
        }
    }
}

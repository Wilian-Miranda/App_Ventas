﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVentas.MODELO;

namespace AppVentas.DAO
{
    class ClsDClientes
    {
        public void GuardarCliente(tb_cliente vCliente)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_cliente dbCliente = new tb_cliente();
                dbCliente.nombreCliente = vCliente.nombreCliente;
                dbCliente.direccionCliente = vCliente.direccionCliente;
                dbCliente.duiCliente = vCliente.duiCliente;

                db.tb_cliente.Add(dbCliente);
                db.SaveChanges();
                MessageBox.Show("¡Nuevo cliente agregado exitosamente!");
            }

        }
        public void ActualizarCliente(tb_cliente vCliente)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int actualizar = vCliente.iDCliente;                                       
                    tb_cliente dbCliente = db.tb_cliente.Where(x => x.iDCliente == actualizar).Select(x => x).FirstOrDefault();
                    dbCliente.nombreCliente = vCliente.nombreCliente;
                    dbCliente.direccionCliente = vCliente.direccionCliente;
                    dbCliente.duiCliente = vCliente.duiCliente;
                    db.SaveChanges();
                    MessageBox.Show("¡Información del cliente actualizada exitosamente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void BorrarCliente(int Id)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int idBorrar = Id;
                    tb_cliente cliente = db.tb_cliente.Where(x => x.iDCliente == idBorrar).Select(x => x).FirstOrDefault();
                    db.tb_cliente.Remove(cliente);
                    db.SaveChanges();
                    MessageBox.Show("¡Cliente eliminado con éxito!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

    }
}

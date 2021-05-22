using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVentas.MODELO;

namespace AppVentas.DAO
{
    class ClsDdashboard
    {
        public double TotalClientes()
        {
            double totalClientes = 0;
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var consulta = (from a in db.tb_cliente
                                select a.iDCliente).ToList();
                totalClientes = consulta.Count();
            }
            return totalClientes;
        }
        public double TotalProductos()
        {
            double totalProductos = 0;
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var consulta = (from a in db.tb_producto
                                select a.idProducto).ToList();
                totalProductos = consulta.Count();
            }
            return totalProductos;
        }
        public double TotalVentas()
        {
            double totalVentas = 0;
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var consulta = (from a in db.tb_venta
                                select a.iDVenta).ToList();
                totalVentas = consulta.Count();
            }
            return totalVentas;
        }
    }
}

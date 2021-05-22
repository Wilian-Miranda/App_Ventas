
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVentas.MODELO;

namespace AppVentas.DAO
{
    class ClsDVenta
    {
        public List<tb_venta> UltimaVenta()
        {
            List<tb_venta> consultaUltimaVenta = new List<tb_venta>();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                consultaUltimaVenta = db.tb_venta.ToList();
            }
            return consultaUltimaVenta;
        }
    }
}

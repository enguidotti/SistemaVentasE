using Microsoft.Reporting.WinForms;
using SistemaVentasE.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVentasE.Forms
{
    public partial class FormReporteOrden : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        public FormReporteOrden()
        {
            InitializeComponent();
        }
        private void CagarOrden(int numFactura)
        {
            var q = (from d in db.DetalleCompra
                     where d.OrdenCompra.num_factura == numFactura
                     select new { 
                         d.OrdenCompra.num_factura,
                         local = d.ProductoLocal.Local.nombre,
                         d.OrdenCompra.fecha,
                         usuario = d.OrdenCompra.User.nombres + " " + d.OrdenCompra.User.apellidos,
                         d.ProductoLocal.Producto.codigo,
                         producto = d.ProductoLocal.Producto.nombre,
                         d.cantidad,
                         d.precio_compra,
                         totalProducto = d.cantidad*d.precio_compra
                     }).ToList();
            if(q.Count > 0)
            {
                //lista de tipo ordenAux para asignar los resultados de la consulta
                List<OrdenAux> orden = new List<OrdenAux>();
                //total factura
                int totalF = q.Sum(x => x.totalProducto);
                //se recorre el resultado de la consulta
                foreach (var item in q)
                {
                    //añadir las filas una a una la lista creada con anterioridad
                    orden.Add(new OrdenAux
                    {
                        numFactura = item.num_factura,
                        local = item.local,
                        fecha = item.fecha,
                        usuario = item.usuario,
                        codigo = item.codigo,
                        producto = item.producto,
                        cantidad = item.cantidad,
                        precioCompra = item.precio_compra,
                        totalProducto = item.totalProducto,
                        totalFactura = totalF
                    });
                }
                ReportDataSource report = new ReportDataSource("Orden", orden);
                rvOrden.LocalReport.DataSources.Clear();
                rvOrden.LocalReport.DataSources.Add(report);
                rvOrden.RefreshReport();

                rvOrden.Visible = true;
            }
            else
            {
                rvOrden.Visible = false;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CagarOrden(int.Parse(txtFactura.Text));
        }

        private void FormReporteOrden_Load(object sender, EventArgs e)
        {

            this.rvOrden.RefreshReport();
        }
    }
}

using Microsoft.Reporting.WinForms;
using SistemaVentasE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasE.Forms
{
    public partial class FormReporteMarca : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        public FormReporteMarca()
        {
            InitializeComponent();
        }
        private void CargarMarcas()
        {
            var listaMarcas = (from m in db.Marca
                               select new
                               {
                                   m.id_marca,
                                   m.nombre
                               }).ToList();
            //conectar nuestra consulta con un reporte
            ReportDataSource report = new ReportDataSource("Marca",listaMarcas);
            //limpia el report viewar si es que trae datos
            rvMarca.LocalReport.DataSources.Clear();
            //se añade la data al report viewer
            rvMarca.LocalReport.DataSources.Add(report);
            //se resfresca el reporte
            rvMarca.RefreshReport();
        }
        private void FormReporteMarca_Load(object sender, EventArgs e)
        {
            CargarMarcas();
        }
    }
}

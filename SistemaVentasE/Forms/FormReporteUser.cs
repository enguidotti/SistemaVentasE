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
    public partial class FormReporteUser : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        public FormReporteUser()
        {
            InitializeComponent();
        }
        private void CargarUsuario(string email)
        {
            if(email != "")
            {
                var listaUsuario = (from u in db.User
                               where u.email == email
                               select new {
                                u.id_user,
                                u.id_rol,
                                u.email,
                                u.password,
                                u.nombres,
                                u.apellidos,
                                Rol = u.Rol.nombre
                               }).ToList();
                if (listaUsuario.Count > 0)
                {

                    ReportDataSource report = new ReportDataSource("Usuario", listaUsuario);
                    rvUser.LocalReport.DataSources.Clear();
                    rvUser.LocalReport.DataSources.Add(report);
                    rvUser.RefreshReport();

                    rvUser.Visible = true;
                }
                else
                {
                    rvUser.Visible = false;
                }

            }
        }
        private void FormReporteUser_Load(object sender, EventArgs e)
        {
            this.rvUser.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuario(txtEmail.Text.Trim());
        }

        private void reporteMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteMarca marca = new FormReporteMarca();
            marca.Show();
        }
    }
}

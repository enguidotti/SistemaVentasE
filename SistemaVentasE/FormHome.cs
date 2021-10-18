using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasE
{
    public partial class FormHome : Form
    {
        private Form formActivo;//indica el formulario activo
        public FormHome()
        {
            InitializeComponent();
        }

        private void AbrirFormHijo(Form formHijo)
        {
            //cerrar el formulario activo
            if (formActivo != null) {
                formActivo.Close();
            }
            formActivo = formHijo;
            //determina si el formulario debe abrirse como ventana
            formHijo.TopLevel = false;
            //le inidicamos que no tenga bordes el formulario
            formHijo.FormBorderStyle = FormBorderStyle.None;
            //determina el tamaño y posición del formulario 
            formHijo.Dock = DockStyle.Fill;
            //añadir al panel el formulario hijo
            panelContent.Controls.Add(formHijo);
            panelContent.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormCompra());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormProducto());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(formActivo != null)
            {
                formActivo.Close();
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormMarca());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormUsuario());
        }
    }
}

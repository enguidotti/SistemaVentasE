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
    public partial class FormUsuario : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        //invoca la clase Helpers para utilizar sus métodos
        private Helpers help = new Helpers();
        public FormUsuario()
        {
            InitializeComponent();
            CargarRol();
        }

        private void CargarRol()
        {
            var listaRoles = db.Rol.ToList();

            cbRol.DataSource = listaRoles;
            cbRol.ValueMember = "id_rol";
            cbRol.DisplayMember = "nombre";
            cbRol.SelectedIndex= -1;
        }
        private string valdiar()
        {
            string error = "";
            if (string.IsNullOrEmpty(cbRol.Text))
                error = "Debe escoger el tipo de usaurio \n";
            if (string.IsNullOrEmpty(txtRun.Text))
                error += "Debe ingresar el run del usuario \n";
            if (string.IsNullOrEmpty(txtNombre.Text))
                error += "Debe ingresar nombres del usuario \n";
            if (string.IsNullOrEmpty(txtApellido.Text))
                error += "Debe ingresar apellidos del usuario \n";
            if (string.IsNullOrEmpty(txtEmail.Text))
                error += "Debe ingresar el Email del usuario \n";
            if (string.IsNullOrEmpty(txtPass.Text))
                error += "Debe ingresar contraseña de usuario \n";
            if (string.IsNullOrEmpty(txtRePass.Text))
                error += "Debe repetir contraseña de usuario \n";
            if (txtPass.Text != txtRePass.Text && txtPass.Text != "" && txtRePass.Text != "")
                error += "Las contraseñas no coinciden";

            return error;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = valdiar();
            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
            }
            else
            {

            }
        }

        private void txtRun_TextChanged(object sender, EventArgs e)
        {
            if (txtRun.Text.Trim() != "" && txtRun.Text.Length > 0)
            {
                //método formatear rut retorna el run formateado
                string runFormateado = help.formatearRut(txtRun.Text.Trim());
                //se asigna el texto formateaado a txtRun
                txtRun.Text = runFormateado;
                //es dejar el cursor de texto siempre al final del textbox
                txtRun.Select(txtRun.Text.Length, 0);
            }
        }

        private void txtRun_Leave(object sender, EventArgs e)
        {
            if (txtRun.Text.Trim() != "")
            {
                if (!help.validarRut(txtRun.Text.Trim()))
                {
                    MessageBox.Show("Run ingresado no es válido");
                    txtRun.Focus();
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if(txtEmail.Text.Trim() != "")
            {
                if (!help.emailValido(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email no tiene el formato correcto");
                    txtEmail.Focus();
                }
            }
        }
    }
}

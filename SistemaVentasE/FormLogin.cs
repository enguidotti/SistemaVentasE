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

namespace SistemaVentasE
{
    public partial class FormLogin : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        private Helpers help = new Helpers();
        public FormLogin()
        {
            InitializeComponent();
            txtEmail.Text = "admin@mail.com";
            txtPass.Text = "admin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            if (txtEmail.Text.Trim() == "")
                error = "Debe ingresar email \n";
            if (txtPass.Text.Trim() == "")
                error += "Debe ingresar contrasñea";
            if(error != "")
                MessageBox.Show(error,"Falta datos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                //consulta para verificar existencia del usuario
                //SELECT * FROM User WHERE email='admin@mail.com' AND password='admin'
                var user = db.User.FirstOrDefault(u => u.email == txtEmail.Text.Trim() && 
                    u.password == txtPass.Text.Trim());
                if(user != null)
                {
                    this.Hide();
                    FormHome form = new FormHome();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Las datos ingresados son incorrectos");
                }
            }
        }
    }
}

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
        private Random rnd;//permite seleccionar números aleatoreos
        private Button btnSelect;
        public FormHome()
        {
            InitializeComponent();
            rnd = new Random();//se inicializa random
        }
        private Color SeleccionColores()
        {
            //se crea index para obtener la posición del color seleccionado
            int index;
            //se obtiene un index aleatoreo de la lista
            index = rnd.Next(TemasColor.ColorList.Count);
            //se selecciona el color de la lista
            string color = TemasColor.ColorList[index];
            //se retorna el color transformado para su utilziación
            return ColorTranslator.FromHtml(color);
        }
        //verifica el botón del menú presionado y cambia sus propiedades
        private void BotonActivo(object btnSender)
        {
            BotonDesactivado();
            //se asigna el color
            Color color = SeleccionColores();
            //se asigna el seleccionado
            btnSelect = (Button)btnSender;
            //se cambian las configuraciones de colres del botón selecionado
            btnSelect.BackColor = color;
            btnSelect.ForeColor = Color.AliceBlue;
            //cambia el color del panel superior 
            panelTop.BackColor = color;

            //asignar los colores de la clase temascolor
            TemasColor.PrimaryColor = color;
            TemasColor.SecondaryColor = TemasColor.ChangeColorBrightness(color, -0.5);
        }
        //método vuevle a la normalid todos los botones
        private void BotonDesactivado()
        {
            //llamar a todos los elementos del panel menu
            foreach (Control btn in panelMenu.Controls)
            {
                //verifica si los elementos son de tipo botón
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = Color.FromArgb(51, 51, 76);
                    btn.ForeColor = Color.White;
                }
            }
        }
        private void AbrirFormHijo(Form formHijo, object btnSender, string titulo)
        {
            if (btnSelect != (Button)btnSender)
            {
                //cerrar el formulario activo
                if (formActivo != null)
                {
                    formActivo.Close();
                }

                BotonActivo(btnSender);
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
                //cambiar titulo al panel top
                lblTitulo.Text = titulo;
                formHijo.BringToFront();
                formHijo.Show();
            }
        }
        private void btnOrden_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormCompra(), sender,"ORDENES DE COMPRA");
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormProducto(), sender,"PRODUCTOS");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (formActivo != null)
            {
                formActivo.Close();
                lblTitulo.Text = "Bienvenidos al Sistema";
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormMarca(), sender,"MARCAS DE PRODUCTOS");
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Forms.FormUsuario(), sender,"USUARIOS DEL SISTEMA");
        }
    }
}

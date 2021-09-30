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
    public partial class FormCompra : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        int idProducto = 0;
        Helpers h = new Helpers();
        public FormCompra()
        {
            InitializeComponent();
            cargarLocales();
        }

        private void cargarLocales()
        {
            //consulta para traer lista con todos los locales
            //var listaLocales = db.Local.ToList();
            var listaLocal = (from l in db.Local select new { l.id_local, l.nombre }).ToList();
            //se asignan los datos al combobox
            cbLocal.ValueMember = "id_local";
            cbLocal.DisplayMember = "nombre";
            cbLocal.DataSource = listaLocal;
            //primer elemento queda en blanco en el combobox
            cbLocal.SelectedIndex = -1;
        }
        private void buscarProducto(int codigo)
        {
            Producto producto = db.Producto.FirstOrDefault(p => p.codigo == codigo);
            if (producto != null)
            {
                txtNombre.Text = producto.nombre;
                idProducto = producto.id_producto;
                txtPrecio.Text = producto.precio_compra.ToString();
            }
            else
            {
                MessageBox.Show("El código ingresa no esta registrado");
                limpiarProducto();
            }
        }
        //Evento Leave se dispara cuando se pierde el foco del textbox
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                buscarProducto(int.Parse(txtCodigo.Text.Trim()));
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            h.soloNumeros(e);
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                //verifica que la tecla presionada sea Enter
                if (e.KeyChar == (char)Keys.Enter)
                {
                    buscarProducto(int.Parse(txtCodigo.Text.Trim()));
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                error = "Debe ingresar producto \n";
            }
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                error += "Debe ingresar cantidad del producto \n";
            }
            if (string.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                error += "Debe ingresar precio del producto";
            }
            if (error != "")
            {
                MessageBox.Show(error);
            }
            else
            {
                // variable que verifica si es necesario modificar el registro
                string verificar = verificaExistenciaGrilla(); 
                //si verificar es vacio significa que no existe el producto, en caso contrario existe
                if (verificar == "")
                {
                    agregarProducto();
                }
                limpiarProducto();
            }
        }
        //método para agregar un elemento a la grilla 
        private void agregarProducto()
        {
            //se instancia una fila de la grilla
            DataGridViewRow fila = new DataGridViewRow();
            //se crearán celdas de la grilla(dgvDetalle)
            fila.CreateCells(dgvDetalle);
            //se añaden los valores a las celdas
            fila.Cells[0].Value = txtCodigo.Text;
            fila.Cells[1].Value = txtNombre.Text;
            fila.Cells[2].Value = txtCantidad.Text;
            fila.Cells[3].Value = txtPrecio.Text;
            fila.Cells[4].Value = int.Parse(txtCantidad.Text) * int.Parse(txtPrecio.Text);
            fila.Cells[5].Value = idProducto;
            //agrega la fila a grilla
            dgvDetalle.Rows.Add(fila);
        }
        //método para verificar y actualizar los datos
        private string verificaExistenciaGrilla()
        {
            string mensaje = "";
            //ciclo para recorrer los datos ingresados en la grilla
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                //verificar si el idProducto existe en la grilla 
                if(int.Parse(fila.Cells[5].Value.ToString()) == idProducto)
                {
                    //preguntar si desea actualizar los datos
                    var resp = MessageBox.Show("El producto ya está ingresado, ¿Desea actualizarlo?","Modificar",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    //si presiona Si
                    if(resp == DialogResult.Yes)
                    {
                        fila.Cells[2].Value = txtCantidad.Text;
                        fila.Cells[3].Value = txtPrecio.Text;
                        fila.Cells[4].Value = int.Parse(txtCantidad.Text) * int.Parse(txtPrecio.Text);                        
                    }
                    mensaje = "Existe producto";
                    return mensaje; 
                }
            }
            return mensaje;
        }
        private void limpiarProducto()
        {
            idProducto = 0;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //invoca al método de la clase Helpers soloNumeros, hay que pasar "e" como parametro
            h.soloNumeros(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            h.soloNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            h.soloNumeros(e);
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //crear instancia del formulario de producto
            FormProducto producto = new FormProducto();
            producto.Show();//abre la ventana de productos
        }
    }
}

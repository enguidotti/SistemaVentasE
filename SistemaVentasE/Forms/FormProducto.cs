
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
    public partial class FormProducto : Form
    {
        private ventasdbEntities db = new ventasdbEntities();
        private int idProducto = 0;
        Helpers h = new Helpers();
        public FormProducto()
        {
            InitializeComponent();
            cargarMarcas();
            cargarCategorias();
            CargarProductos();
        }

        //método para cargar combobox marca
        private void cargarMarcas()
        {
            //consulta para traer id y nombre de la marca
            var listaMarcas = (from m in db.Marca
                               select new
                               {
                                   id = m.id_marca,
                                   marca = m.nombre
                               }).ToList();
            //cargar la lista al combobox
            cbMarca.DisplayMember = "marca"; //lo que se muestra como texto
            cbMarca.ValueMember = "id";//lo que se guarda 
            cbMarca.DataSource = listaMarcas;//carga los datos al combobox
            //nada seleccionado
            cbMarca.SelectedIndex = -1;
        }
        private void cargarCategorias()
        {
            var listaCatregorias = (from c in db.Categoria
                                    select new
                                    {
                                        c.id_categoria,
                                        c.nombre
                                    }).ToList();
            //cargar la lista al cb
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.ValueMember = "id_categoria";
            cbCategoria.DataSource = listaCatregorias;

            cbCategoria.SelectedIndex = -1;
        }
        //método para validar campos vacios
        private string Validar() //cuando un método es de un tipo de dato, nececsita devolver ese tipo de dato
        {
            string error = "";
            //string.IsNullOrEmpty verfica si el input es distinto de nulo o vacio
            if (string.IsNullOrEmpty(cbMarca.Text))
                error = "- Debe seleccionar Marca. \n";
            if (string.IsNullOrEmpty(cbCategoria.Text))
                error += "- Debe seleccionar Categoría. \n";
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()))
                error += "- Debe ingresar Código. \n";
            if (string.IsNullOrEmpty(txtNombre.Text))
                error += "- Debe ingresar Nombre. \n";
            if (string.IsNullOrEmpty(txtCompra.Text))
                error += "- Debe ingresar Precio Compra. \n";
            if (string.IsNullOrEmpty(txtVenta.Text))
                error += "- Debe ingresar Precio Venta. \n";
            //retorna la variable error 
            return error;
        }
        //método para guardar nuevo producto
        private void IngresarProducto()
        {
            Producto p = new Producto();//instancia de la clase producto y se crea el objeto p
            p.id_marca = int.Parse(cbMarca.SelectedValue.ToString());//selected value necesita ser pasado a int
            p.id_categoria = int.Parse(cbCategoria.SelectedValue.ToString());
            p.codigo = int.Parse(txtCodigo.Text);
            p.nombre = txtNombre.Text.Trim();
            p.precio_compra = int.Parse(txtCompra.Text);
            p.precio_venta = int.Parse(txtVenta.Text);
            p.descripcion = txtDescripcion.Text;
            //guardar en bd
            db.Producto.Add(p);
            db.SaveChanges();

            MessageBox.Show("El producto se ha guardado con éxito","Guardar");
        }
        //método para modificar un producto existente
        private void ModificarProducto()
        {
            //Find sirve para buscar en la tabla por su primary key
            Producto p = db.Producto.Find(idProducto);
            p.id_marca = int.Parse(cbMarca.SelectedValue.ToString());//selected value necesita ser pasado a int
            p.id_categoria = int.Parse(cbCategoria.SelectedValue.ToString());
            p.codigo = int.Parse(txtCodigo.Text);
            p.nombre = txtNombre.Text.Trim();
            p.precio_compra = int.Parse(txtCompra.Text);
            p.precio_venta = int.Parse(txtVenta.Text);
            p.descripcion = txtDescripcion.Text;

            db.SaveChanges();
        }
        //método para cargar lista de productos
        private void CargarProductos()
        {
            //consulta que trae todos los productos 
            var listaProductos = (from p in db.Producto
                                  select new
                                  {
                                      p.id_producto,
                                      p.id_marca,
                                      p.id_categoria,
                                      Marca = p.Marca.nombre,
                                      Categoría = p.Categoria.nombre,
                                      Código = p.codigo,
                                      Nombre = p.nombre,
                                      Compra = p.precio_compra,
                                      Venta = p.precio_venta,
                                      Descripción = p.descripcion
                                  }).ToList();
            //se agrega la lista de productos a la grilla
            dgvProducto.DataSource = listaProductos;
            //no muestra el id_producto ya que esta en la posición 0
            dgvProducto.Columns[0].Visible = false;
            dgvProducto.Columns[1].Visible = false;
            dgvProducto.Columns[2].Visible = false;

        }
        private void Limpiar()
        {
            idProducto = 0;
            cbMarca.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCompra.Text = "";
            txtVenta.Text = "";
            txtDescripcion.Text = "";

            dgvProducto.ClearSelection();
            btnEliminar.Enabled = false;

        }
        //método booleano que retorna true o false según existencia dedl código del producto
        private bool ExisteCodigo(int codigo)
        {
            bool existe = false;
            //select * from Producto where codigo = txtCodigo
            Producto producto = db.Producto.FirstOrDefault(p => p.codigo == codigo);
            if(producto != null)
            {
                existe = true;
            }

            return existe;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = Validar();
            if(error != "")
            {
                MessageBox.Show(error,"Faltan datos a igresar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            } else
            {
                //guardar y modificar
                if (idProducto == 0)
                {
                    IngresarProducto();
                }
                else
                {
                    ModificarProducto();
                }
                CargarProductos();
                Limpiar();
            }
        }

        private void dgvProducto_MouseClick(object sender, MouseEventArgs e)
        {
            idProducto = int.Parse(dgvProducto.CurrentRow.Cells[0].Value.ToString());
            cbMarca.SelectedValue = int.Parse(dgvProducto.CurrentRow.Cells[1].Value.ToString());
            cbCategoria.SelectedValue = int.Parse(dgvProducto.CurrentRow.Cells[2].Value.ToString());
            txtCodigo.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();
            txtNombre.Text = dgvProducto.CurrentRow.Cells[6].Value.ToString();
            txtCompra.Text = dgvProducto.CurrentRow.Cells[7].Value.ToString();
            txtVenta.Text = dgvProducto.CurrentRow.Cells[8].Value.ToString();
            txtDescripcion.Text = dgvProducto.CurrentRow.Cells[9].Value.ToString();

            btnEliminar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(idProducto > 0)
            {
                //Alerta pregunta si desea eliminar o no
                var resultado = MessageBox.Show("¿Desea eliminar el producto " + txtNombre.Text + "?","Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
                //verifica si la opción presionada es Si
                if(resultado == DialogResult.Yes)
                {
                    Producto p = db.Producto.Find(idProducto);
                    db.Producto.Remove(p);
                    db.SaveChanges();
                    CargarProductos();
                    Limpiar();
                } 
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            //verifica si hay números en el txtCodigo
            if (txtCodigo.Text != "")
            {
                //comprueba la existencia del código con el método ExisteCodigo
                if (ExisteCodigo(int.Parse(txtCodigo.Text)))
                {
                    MessageBox.Show("El código ya esta ingresado para otro producto");
                    txtCodigo.Text = "";
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            h.soloNumeros(e);
        }
    }
}

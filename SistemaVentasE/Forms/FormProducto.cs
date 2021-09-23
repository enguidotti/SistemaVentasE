
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
        public FormProducto()
        {
            InitializeComponent();
            cargarMarcas();
            cargarCategorias();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = Validar();
            if(error != "")
            {
                MessageBox.Show(error,"Faltan datos a igresar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            } else
            {
                //guardar y modificar
                IngresarProducto();
            }
        }
    }
}

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

            int total = int.Parse(txtCantidad.Text) * int.Parse(txtPrecio.Text);
            txtTotal.Text = (int.Parse(txtTotal.Text) + total).ToString();
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
                        //actualización del campo txtTotal
                        //captura el total de la celda preciototal y se asigna a una variable
                        int totalV = int.Parse(fila.Cells[4].Value.ToString());
                        int total = int.Parse(txtCantidad.Text) * int.Parse(txtPrecio.Text);
                        txtTotal.Text = (int.Parse(txtTotal.Text) - totalV + total).ToString();
                        //actualizar la grilla con los nuevos valores
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrEmpty(cbLocal.Text))
            {
                error = "Debe escoger el local de ingreso \n";
            }
            if (string.IsNullOrEmpty(txtFactura.Text))
            {
                error += "Debe ingresar número de factura \n";
            }
            if(dgvDetalle.Rows.Count == 0)
            {
                error += "Debe ingresar al menos un producto";
            }
            if(error != "")
            {
                MessageBox.Show(error, "Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //guardar en tabla orden de compra
                OrdenCompra orden = new OrdenCompra();//instanciando la clase para acceder a sus métodos y atributos através del objeto orden
                //asignar los valores a los atributos de la clase
                orden.num_factura = int.Parse(txtFactura.Text);
                orden.fecha = dtFecha.Value;
                orden.id_user = 1;//cambiará a variable session, en un par de clases
                db.OrdenCompra.Add(orden);
                db.SaveChanges();
                //una vez que guarda el registro, capturamos el valor autogenerado y lo asignamos a una variable entera
                int idOrdenCompra = orden.id_compra;

                //guardar en detalle compra
                DetalleCompra detalle = new DetalleCompra();
                //recorrer la grilla para asignar los productos a la clase DetalleCompra
                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    int idProducto = int.Parse(fila.Cells[5].Value.ToString());
                    int idLocal = int.Parse(cbLocal.SelectedValue.ToString());
                    int cantidad = int.Parse(fila.Cells[2].Value.ToString());
                    //verifica si el producto existe en el local
                    int idStock = VerificarStock(idProducto,idLocal, cantidad);
                    detalle.id_stock = idStock;//hay que cambiarlo
                    detalle.cantidad = cantidad;
                    detalle.precio_compra = int.Parse(fila.Cells[3].Value.ToString());
                    detalle.id_compra = idOrdenCompra;
                    //guarda los cambios en la table detallecompra
                    db.DetalleCompra.Add(detalle);
                    db.SaveChanges();
                }
            }
        }
        //método para verificar existencia del producto en local
        private int VerificarStock(int idProducto, int idLocal, int cantidad)
        {
            var stock = db.ProductoLocal.FirstOrDefault(p => p.id_producto == idProducto && p.id_local == idLocal);
            //si no existe el producto en el local, crea el registro
            if(stock == null)
            {
                ProductoLocal producto = new ProductoLocal();
                producto.cantidad = cantidad;
                producto.id_producto = idProducto;
                producto.id_local = idLocal;
                db.ProductoLocal.Add(producto);
                db.SaveChanges();
                //retorno el id_stock recién creado
                return producto.id_stock;
            }
            else
            {
                //actualiza el stock 
                stock.cantidad = stock.cantidad + cantidad;
                db.SaveChanges();
                //retorno el id del producto en el local
                return stock.id_stock;
            }
        }
    }
}

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
    public partial class FormMarca : Form
    {
        //abrir conexión a la base de datos
        private ventasdbEntities db = new ventasdbEntities();
        int id_marca = 0;
        public FormMarca()
        {
            InitializeComponent();
            cargarGrilla();//cargará los datos en la grilla al comienzo
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text.Trim() != "")
            {
                if (id_marca == 0)
                {
                    //select * from marca WHERE nombre = 'Lenovo';
                    var q = db.Marca.FirstOrDefault(m => m.nombre.Equals(txtMarca.Text.Trim()));
                    //si q es igual a nulo(no encuentra en base de datos), permite guardar el registro
                    if (q == null)
                    {
                        //instancio la clase marca que corresponde a la tabla marca de la base de datos
                        Marca marca = new Marca();
                        //se asigna el valor del textbox al atributo
                        marca.nombre = txtMarca.Text;
                        //se guarda en la base de datos, con entityframework(linq)
                        db.Marca.Add(marca);//insert into Marca(nombre) values('apple')
                                            //guarda los cambios en la base de datos
                        db.SaveChanges();
                        limpiar();
                        cargarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe");
                    }
                } 
                else
                {
                    modificar(id_marca);
                    limpiar();
                    cargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar marca");
            }
        }
        private void modificar(int id)
        {
            //TAREA VERIFICAR que el nombre de la marca a modificar no exista en la base de datos(3pts)
            var q = db.Marca.FirstOrDefault(m => m.nombre.Equals(txtMarca.Text.Trim()));

            if (q == null)
            {
                //Find busca en la tabla por la primary key
                Marca marca = db.Marca.Find(id);
                //reasinga el nombre a la marca
                marca.nombre = txtMarca.Text.Trim();
                //guarda los cambios en la base de datos
                db.SaveChanges();
            } else
            {
                MessageBox.Show("La marca ya existe");
            }
        }
        private void cargarGrilla()
        {
            //carga todos los registros de la tabla marca 
            var listaMarcas = db.Marca.ToList();//ToList() trae una lista de registros de la tabla

            //asignar la lista(listaMarcas) de datos a la grilla(dgvMarca)
            dgvMarca.DataSource = listaMarcas;
            dgvMarca.Columns[2].Visible = false;//deja oculto el campo producto
        }

        private void limpiar()
        {
            id_marca = 0;//dejar en 0 id_marca para que no se pueda modificar o eliminar si no selecciona fila
            txtMarca.Text = string.Empty;//textbox queda sin datos
            dgvMarca.ClearSelection();//desmarca la opción seleccionada en la grilla
            btnEliminar.Enabled = false;
        }
        private void dgvMarca_MouseClick(object sender, MouseEventArgs e)
        { 
            //permite asignar el nombre que está en la grilla al textbox
            txtMarca.Text = dgvMarca.CurrentRow.Cells[1].Value.ToString();
            //id_marca de la grilla se asigna a nuestra variable
            id_marca = int.Parse(dgvMarca.CurrentRow.Cells[0].Value.ToString());

            //habilitar btn eliminar
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //verifica que haya seleccionado una fila de la grilla
            if(id_marca > 0)
            {
                //buscamos el registro en la base de datos en base al id_marca
                var q = db.Marca.Find(id_marca);
                //Remove, quita el registro de la base de datos
                db.Marca.Remove(q);
                //guardan los cambios en la base de datos
                db.SaveChanges();
                limpiar();
                cargarGrilla();
            }
        }






        //private void existeMarca(string nombreMarca)
        //{

        //    //ORM entity framework
        //    //FirstOrDefault, First, Where => select where
        //    //select * from marca WHERE nombre = 'Lenovo';
        //    var q = db.Marca.FirstOrDefault(m => m.nombre.Equals(nombreMarca));

        //}
    }
}

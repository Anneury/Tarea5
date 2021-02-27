using PrimeraPruebaTarea5.Entidades;
using PrimeraPruebaTarea5.Dal;
using PrimeraPruebaTarea5.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeraPruebaTarea5.UI.Registros
{
    public partial class rPermisos : Form
    {
        public rPermisos()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            MyErrorProvider.Clear();
            PermisoIdNumericUpDown.Value = 0;
            NombrePermisoTextBox.Clear();
        }

        public void LlenaCampo(Permisos permiso)
        {
            PermisoIdNumericUpDown.Value = permiso.IdPermiso;
            NombrePermisoTextBox.Text = permiso.NombrePermiso;
        }

        public Permisos LlenaClase()
        {
            Permisos permiso = new Permisos();
            permiso.IdPermiso = (int)PermisoIdNumericUpDown.Value;
            permiso.NombrePermiso = NombrePermisoTextBox.Text;

            return permiso;
        }
        public bool ExisteEnLaBaseDeDatos()
        {
            Permisos permisos = PermisosBLL.Buscar((int)PermisoIdNumericUpDown.Value);

            return (permisos != null);
        }
        public bool Validar()
        {
            bool paso = true;

            if(NombrePermisoTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombrePermisoTextBox,"Debes agregar datos en este campo!");
                NombrePermisoTextBox.Focus();

                paso = false;
            }

            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
/*
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Permisos permisos;
            bool paso = false;

            permisos = LlenaClase();

            if (!Validar())
                return;

            if (PermisoIdNumericUpDown.Value == 0)
                paso = PermisosBLL.Guardar(permisos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se pudo modificar este permiso", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Limpiar();
                    return;
                }
                paso = PermisosBLL.Modificar(permisos);
            }

            if (paso)
            {
                MessageBox.Show("Permiso guardado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar el permiso, intentelo nuevamente", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
*/
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(PermisoIdNumericUpDown.Text, out id);

            if(PermisoIdNumericUpDown.Value == 0)
            {
                MessageBox.Show("Debes agregar un Id valido para poder eliminar un permiso","Fallo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (ExisteEnLaBaseDeDatos())
            {
                if(MessageBox.Show("Deseas eliminar este permiso?","Elije una opcion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PermisosBLL.Eliminar(id))
                    {
                        MessageBox.Show("Permiso eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                        MyErrorProvider.SetError(PermisoIdNumericUpDown, "Agrega un Id Valido! Este no existe.");
                }

            }
            else
                MessageBox.Show("Este permiso no existe en la base de datos, prueba a eliminar otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Permisos permisos;
            int id;
            int.TryParse(PermisoIdNumericUpDown.Text, out id);

            Limpiar();

            permisos = PermisosBLL.Buscar(id);

            if (permisos != null)
            {
                MessageBox.Show("Permiso encontrado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(permisos);
            }
            else
                MessageBox.Show("Este Permiso no existe, prueba buscar otro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

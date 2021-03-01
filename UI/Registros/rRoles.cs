using PrimeraPruebaTarea5.BLL;
using PrimeraPruebaTarea5.Entidades;
using PrimeraPruebaTarea5.Dal;
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
    public partial class rRoles : Form
    {
        public List<RolesDetalle> Detalle { get; set; }
        public rRoles()
        {
            InitializeComponent();
            this.Detalle = new List<RolesDetalle>();
        }
        public void CargarGrid()
        {
            DetallesDataGridView.DataSource = null;
            DetallesDataGridView.DataSource = this.Detalle;
        }
        public void Limpiar()
        {
            RolIdNumericUpDown1.Value = 0;
            NombreRolTextBox.Clear();
            MyErrorProvider.Clear();
            EsAsinadoCheckBox.Checked = false;
            ActivoCheckBox.Checked = false;

            this.Detalle = new List<RolesDetalle>();
            CargarGrid();
        }

        public void LlenaCampo(Roles roles)
        {
            RolIdNumericUpDown1.Value = roles.IdRol;
            NombreRolTextBox.Text = roles.NombreRol;
            ActivoCheckBox.Checked = roles.EsActivo;
            this.Detalle = roles.Detalle;
            CargarGrid();
        }

        public Roles LlenaClase()
        {
            Roles roles = new Roles();
            roles.IdRol = (int)RolIdNumericUpDown1.Value;
            roles.NombreRol = NombreRolTextBox.Text;
            roles.EsActivo = ActivoCheckBox.Checked;
            roles.Detalle = this.Detalle;
            CargarGrid();

            return roles;
        }

        public bool Validar()
        {
            bool paso = true;

            if(NombreRolTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreRolTextBox, "Debes agregar un dato a este campo");
                NombreRolTextBox.Focus();

                paso = false;
            }

            return paso;
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            Roles roles = RolesBLL.Buscar((int)RolIdNumericUpDown1.Value);
            return (roles != null);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Roles roles;

            if (!Validar())
                return;

            roles = LlenaClase();

            var paso = RolesBLL.Guardar(roles);

            if (paso)
            {
                MessageBox.Show("Rol guardado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar este permiso, intentalo de nuevo.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(RolIdNumericUpDown1.Text, out id);

            if(RolIdNumericUpDown1.Value == 0)
            {
                MessageBox.Show("Debes agregar un Id valido para poder eliminar un Rol", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExisteEnLaBaseDeDatos())
            {
                if (MessageBox.Show("Deseas eliminar este Rol?", "Elije una opcion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PermisosBLL.Eliminar(id))
                    {
                        MessageBox.Show("Rol eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                        MyErrorProvider.SetError(RolIdNumericUpDown1, "Agrega un Id Valido! Este no existe.");
                }

            }
            else
                MessageBox.Show("Este Rol no existe en la base de datos, prueba a eliminar otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Roles roles;
            int id;
            int.TryParse(RolIdNumericUpDown1.Text, out id);

            Limpiar();

            roles = RolesBLL.Buscar(id);

            if (roles != null)
            {
                MessageBox.Show("Rol encontrado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(roles);
            }
            else
                MessageBox.Show("Este Rol no existe, prueba buscar otro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if((DetallesDataGridView.Rows.Count > 0 && DetallesDataGridView.CurrentRow != null))
            {
                Detalle.RemoveAt(DetallesDataGridView.CurrentRow.Index);
                CargarGrid();
            }
            else
            {
                MyErrorProvider.SetError(DetallesDataGridView, "no hay na");
                DetallesDataGridView.Focus();
            }
        }

        private void rRoles_Load(object sender, EventArgs e)
        {
            PermisoIdComboBox.DataSource = PermisosBLL.GetPermisos();
            PermisoIdComboBox.DisplayMember = "IdPermiso";
            PermisoIdComboBox.ValueMember = "NombrePermiso";
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (DetallesDataGridView.DataSource != null)
                this.Detalle = (List<RolesDetalle>)DetallesDataGridView.DataSource;
            if (PermisoIdComboBox.Text == string.Empty)
            {
                MessageBox.Show("Debes seleccionar un permiso antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Detalle.Add(
                new RolesDetalle(
                    Id: 0,
                    IdRol: (int)RolIdNumericUpDown1.Value,
                    IdPermiso: Convert.ToInt32(PermisoIdComboBox.Text),
                    EsAsignado: EsAsinadoCheckBox.Checked
                )
            );
            CargarGrid();
            PermisoIdComboBox.Focus();
        }
    }
}

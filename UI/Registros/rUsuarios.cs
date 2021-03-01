using PrimeraPruebaTarea5.BLL;
using PrimeraPruebaTarea5.Dal;
using PrimeraPruebaTarea5.Entidades;
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
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            MyErrorProvider.Clear();
            IdUsuarioNumericUpDown.Value = 0;
            AliasTextBox.Clear();
            NombreUsuarioTextBox.Clear();
            ClaveTextBox.Clear();
            RolComboBox.Text = "Elegir";
            Fecha.CustomFormat = " ";
            EmailTextBox.Clear();
            ConfirmarClaveTextBox.Clear();
            ActivoCheckBox.Checked = false;
        }

        public void LlenaCampo(Usuarios usuarios)
        {
            IdUsuarioNumericUpDown.Value = usuarios.IdUsuario;
            AliasTextBox.Text = usuarios.AliasUsuario;
            NombreUsuarioTextBox.Text = usuarios.NombreUsuario;
            ClaveTextBox.Text = usuarios.ClaveUsuario;
            ConfirmarClaveTextBox.Text = usuarios.ClaveUsuario;
            RolComboBox.Text = Convert.ToString(usuarios.IdRol);
            Fecha.Value = usuarios.FechaUSuario;
            EmailTextBox.Text = usuarios.Email;
            ActivoCheckBox.Checked = usuarios.Activo;
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.IdUsuario = (int)IdUsuarioNumericUpDown.Value;
            usuarios.ClaveUsuario = ClaveTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.NombreUsuario = NombreUsuarioTextBox.Text;
            usuarios.FechaUSuario = Fecha.Value;
            usuarios.AliasUsuario = AliasTextBox.Text;
            usuarios.IdRol = RolComboBox.Text;
            usuarios.Activo = ActivoCheckBox.Checked;

            return usuarios;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuarios = UsuariosBLL.Buscar((int)IdUsuarioNumericUpDown.Value);

            return (usuarios != null);
        }
        private bool Validar()
        {
            bool paso = true;

            if (NombreUsuarioTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreUsuarioTextBox, "El campo nombre no puede estar vacio");
                NombreUsuarioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MyErrorProvider.SetError(EmailTextBox, "El Email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(AliasTextBox.Text))
            {
                MyErrorProvider.SetError(AliasTextBox, "El campo Alias no puede estar vacio");
                AliasTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(RolComboBox.Text))
            {
                MyErrorProvider.SetError(RolComboBox, "Debe agregar un rol especifico");
                RolComboBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
            {
                MyErrorProvider.SetError(ClaveTextBox, "Debe asignar una clave a su usuario");
                ClaveTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ConfirmarClaveTextBox.Text))
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Debe confirmar la clave");
                ConfirmarClaveTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(Fecha.Text))
            {
                MyErrorProvider.SetError(Fecha, "Debe agregar una fecha de registro");
                Fecha.Focus();
                paso = false;
            }
            if (ClaveTextBox.Text != ConfirmarClaveTextBox.Text)
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Las contrseñas deben ser iguales.");
                ConfirmarClaveTextBox.Focus();
                MyErrorProvider.SetError(ClaveTextBox, "Las contraseñas deben ser iguales.");
                ClaveTextBox.Focus();
                paso = false;
            }
            if (UsuariosBLL.ExisteAlias(AliasTextBox.Text))
            {
                MyErrorProvider.SetError(AliasTextBox, "Los Alias no pueden repetirse!");
                AliasTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios;
            //bool paso = false;

            if (!Validar())
                return;

            usuarios = LlenaClase();

            var paso = UsuariosBLL.Guardar(usuarios);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IdUsuarioNumericUpDown.Text, out id);

            Limpiar();

            if (UsuariosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdUsuarioNumericUpDown, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            int.TryParse(IdUsuarioNumericUpDown.Text, out id);

            Limpiar();

            usuario = UsuariosBLL.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Persona Encotrada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(usuario);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rUsuarios_Load(object sender, EventArgs e)
        {
            RolComboBox.DataSource = RolesBLL.GetRoles();
            RolComboBox.DisplayMember = "NombreRol";
            RolComboBox.ValueMember = "IdRol";
        }
    }
}

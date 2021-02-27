using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeraPruebaTarea5.BLL;
using PrimeraPruebaTarea5.UI.Registros;

namespace PrimeraPruebaTarea5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.PermisosToolStripMenuItem.Click += new EventHandler(this.PermisosToolStripMenuItem_ItemClicked);
            this.UsuariosToolStripMenuItem.Click += new EventHandler(this.UsuariosToolStripMenuItem_ItemClicked);
            this.RolesToolStripMenuItem.Click += new EventHandler(this.RolesToolStripMenuItem_ItemClicked);
        }
        private void PermisosToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            var rPermisos = new rPermisos();
            rPermisos.MdiParent = this;
            rPermisos.Show();
        }
        private void UsuariosToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            rUsuarios usuarios = new rUsuarios();
            usuarios.Visible = true;
        }
        private void RolesToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            rRoles roles = new rRoles();
            roles.Show();
        }
    }
}

using EmpleadosLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEmpleados
{
    public partial class frmMantenedor : Form
    {
        empleadosEntity empleado = new empleadosEntity();
        public frmMantenedor()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            empleado.Rut = txtRut.Text;
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Mail = txtMail.Text;
            empleado.Telefono = txtTelefono.Text;
            int x = empleado.guardar();
            if (x == 1)
            {
                MessageBox.Show("Empleado Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en Guardado", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtRut.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
        }
    }
}

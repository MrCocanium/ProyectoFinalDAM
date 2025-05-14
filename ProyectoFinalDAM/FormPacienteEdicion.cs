using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalDAM
{
    public partial class FormPacienteEdicion : Form
    {
        public Paciente Paciente { get; private set; }

        public FormPacienteEdicion(Paciente pacienteExistente = null)
        {
            InitializeComponent();
            Paciente = pacienteExistente ?? new Paciente();

            // Si se está editando un paciente existente, cargar sus datos en los campos
            if (pacienteExistente != null)
            {
                txtNombre.Text = Paciente.Nombre;
                txtDNI.Text = Paciente.DNI;
            }
        }

        private bool ValidarCampos()
        {
            // Validar que el campo "Nombre" no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "DNI" sea válido
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || !EsDNIValido(txtDNI.Text))
            {
                MessageBox.Show("El DNI no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Todos los campos son válidos
            return true;
        }

        private bool EsDNIValido(string dni)
        {
            // Expresión regular para validar un DNI español: 8 dígitos seguidos de una letra
            var regex = new Regex(@"^\d{8}[A-Za-z]$");
            return regex.IsMatch(dni);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (!ValidarCampos())
                return;

            // Crear un nuevo objeto Paciente con los datos ingresados
            Paciente = new Paciente
            {
                Nombre = txtNombre.Text.Trim(),
                DNI = txtDNI.Text.Trim()
            };

            // Cerrar el formulario con resultado OK
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario con resultado Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public class Paciente
    {
        public string Nombre { get; set; }
        public string DNI { get; set; }
    }
}
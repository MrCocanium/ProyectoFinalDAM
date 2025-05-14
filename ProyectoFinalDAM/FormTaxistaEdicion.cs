using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalDAM
{
    public partial class FormTaxistaEdicion : Form
    {
        public Taxista Taxista { get; private set; }

        public FormTaxistaEdicion(Taxista taxistaExistente = null)
        {
            InitializeComponent();
            Taxista = taxistaExistente ?? new Taxista();

            // Si se está editando un taxista existente, cargar sus datos en los campos
            if (taxistaExistente != null)
            {
                txtNombre.Text = Taxista.Nombre;
                txtDNI.Text = Taxista.DNI;
                txtDireccion.Text = Taxista.Direccion;
                txtPoblacion.Text = Taxista.Poblacion;
                txtProvincia.Text = Taxista.Provincia;
                txtTelefono.Text = Taxista.NumeroTelefono.ToString();
                txtEmail.Text = Taxista.Email;
                txtCCC.Text = Taxista.CCC;
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

            // Validar que el campo "Dirección" no esté vacío
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "Población" no esté vacío
            if (string.IsNullOrWhiteSpace(txtPoblacion.Text))
            {
                MessageBox.Show("La población es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "Provincia" no esté vacío
            if (string.IsNullOrWhiteSpace(txtProvincia.Text))
            {
                MessageBox.Show("La provincia es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "Teléfono" sea un número entero
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "Email" tenga un formato válido
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el campo "CCC" tenga un formato válido
            if (string.IsNullOrWhiteSpace(txtCCC.Text) || !EsCCCValido(txtCCC.Text))
            {
                MessageBox.Show("El CCC no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool EsEmailValido(string email)
        {
            // Expresión regular para validar un email
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }

        private bool EsCCCValido(string ccc)
        {
            // Expresión regular para validar un CCC: exactamente 20 dígitos
            var regex = new Regex(@"^\d{20}$");
            return regex.IsMatch(ccc);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (!ValidarCampos())
                return;

            // Crear un nuevo objeto Taxista con los datos ingresados
            Taxista = new Taxista
            {
                Nombre = txtNombre.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Poblacion = txtPoblacion.Text.Trim(),
                Provincia = txtProvincia.Text.Trim(),
                NumeroTelefono = int.Parse(txtTelefono.Text.Trim()),
                Email = txtEmail.Text.Trim(),
                CCC = txtCCC.Text.Trim()
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
}
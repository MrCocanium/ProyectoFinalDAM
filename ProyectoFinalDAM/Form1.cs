using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDAM
{
    public partial class Form1 : Form
    {
        private Form currentForm = null;
        public Form1(string rolUsuario)
        {
            InitializeComponent();
            rol = rolUsuario; // Guardar el rol del usuario
            // Configuración inicial
            ConfigureMainLayout();
            AddButtonsToLayout();
            ConfigureButtonStyles();
        }
        private string rol;
        private void ConfigureMainLayout()
        {
            // Configura TableLayout principal
            tableLayoutMain.Dock = DockStyle.Fill;
            panelContenedor.Dock = DockStyle.Fill;

            // Configura TableLayout de botones
            tableLayoutBotones.Dock = DockStyle.Fill;
            tableLayoutBotones.RowCount = 1;
            tableLayoutBotones.ColumnCount = 5; // Igual al número de botones
        }

        private void AddButtonsToLayout()
        {
            // Añade botones al TableLayout
            tableLayoutBotones.Controls.Add(buttonTaxistas, 0, 0);
            tableLayoutBotones.Controls.Add(buttonPacientes, 1, 0);
            tableLayoutBotones.Controls.Add(buttonServicios, 2, 0);
            tableLayoutBotones.Controls.Add(buttonLugares, 3, 0);
            tableLayoutBotones.Controls.Add(buttonFacturas, 4, 0);
        }

        private void ConfigureButtonStyles()
        {
            // Columnas con igual porcentaje
            for (int i = 0; i < tableLayoutBotones.ColumnCount; i++)
            {
                tableLayoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / tableLayoutBotones.ColumnCount));
            }

            // Estilo de los botones
            int marginSize = 5;  // Reducido para menos separación
            foreach (Button btn in tableLayoutBotones.Controls.OfType<Button>())
            {
                btn.Margin = new Padding(marginSize, 3, marginSize, 3);  // 3px vertical
                btn.Anchor = AnchorStyles.None;
                btn.AutoSize = true;
                btn.Padding = new Padding(5);  // Espacio interno reducido
                btn.BackColor = SystemColors.Control;  // Color inicial
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Cierra el formulario actual si hay uno abierto
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void HighlightButton(Button btn)
        {
            // Restablece todos los botones
            foreach (var control in tableLayoutBotones.Controls.OfType<Button>())
            {
                control.BackColor = SystemColors.Control;
                control.Font = new Font(control.Font, FontStyle.Regular);
            }

            // Resalta el botón activo
            btn.BackColor = Color.LightBlue;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
        }

        private void buttonTaxistas_Click(object sender, EventArgs e)
        {
            HighlightButton(buttonTaxistas);
            OpenChildForm(new FormTaxistas());
        }

        private void buttonPacientes_Click(object sender, EventArgs e)
        {
            HighlightButton(buttonPacientes);
            OpenChildForm(new FormPacientes());
        }

        private void buttonServicios_Click(object sender, EventArgs e)
        {
            HighlightButton(buttonServicios);
            OpenChildForm(new FormServicios());
        }

        private void buttonLugares_Click(object sender, EventArgs e)
        {
            HighlightButton(buttonLugares);
            OpenChildForm(new FormLugares());
        }

        private void buttonFacturas_Click(object sender, EventArgs e)
        {
            HighlightButton(buttonFacturas);
            //OpenChildForm(new FormFacturas());
        }
    }
}
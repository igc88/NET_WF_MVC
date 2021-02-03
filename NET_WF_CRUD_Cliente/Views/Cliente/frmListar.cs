using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_WF_CRUD_Cliente {
    public partial class frmListar : Form {
        private int idActivo = 0;

        private string _nombre = string.Empty;
        private string _apellido = string.Empty;
        private string _direccion = string.Empty;
        private string _dni = string.Empty;
        private DateTime _fecha;

        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public string Apellido {
            get => _apellido;
            set => _apellido = value;
        }
        public string Direccion {
            get => _direccion;
            set => _direccion = value;
        }
        public string DNI {
            get => _dni;
            set => _dni = value;
        }
        public DateTime Fecha {
            get => _fecha;
            set => _fecha = value;
        }

        public frmListar(DataTable ds) {
            InitializeComponent();

            foreach (DataRow row in ds.Rows) {
                cbClientes.Items.Add(row[0] + " - " + row[1] + " " + row[2]);
            }
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox cb = (ComboBox)sender;

            string[] seleccionado = cb.SelectedItem.ToString().Split(' ');

            idActivo = int.Parse(seleccionado[0]);

            Cliente c = new Cliente(idActivo);

            txtNombre.Text = c.Nombre;
            txtApellido.Text = c.Apellido;
            txtDireccion.Text = c.Direccion;
            txtDni.Text = c.DNI;
            dtpFecha.Value = c.Fecha;

            foreach (Control ctrl in pnlCliente.Controls) {
                if (ctrl is TextBox) ctrl.TextChanged += EnableButtons;
            }           
        }

        public int getId () {
            return idActivo;
        }

        private void btnActualizar_Click(object sender, EventArgs e) {
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            DNI = txtDni.Text;
            Direccion = txtDireccion.Text;
            Fecha = dtpFecha.Value;

            DialogResult = DialogResult.OK;
        }


        private void EnableButtons(object sender, EventArgs e) {            
            btnActualizar.Enabled = true;
            btnBorrar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
        }
    }
}

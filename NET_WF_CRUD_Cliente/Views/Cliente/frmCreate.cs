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
    public partial class frmCreate : Form {
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
        public frmCreate() {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            DNI = txtDni.Text;
            Direccion = txtDireccion.Text;
            Fecha = dtpFecha.Value;

            DialogResult = DialogResult.OK;
        }
    }
}

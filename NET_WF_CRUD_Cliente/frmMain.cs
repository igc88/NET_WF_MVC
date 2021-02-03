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
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }
        private void btnAnadir_Click(object sender, EventArgs e) {
            using (frmCreate f = new frmCreate()) {
                f.ShowDialog();

                if (f.DialogResult == DialogResult.OK) {
                    Cliente c = new Cliente(f.Nombre, f.Apellido, f.Direccion, f.DNI, f.Fecha);

                    if (c.Guardar()) {
                        MessageBox.Show("Registro creado con éxito");
                    } else {
                        MessageBox.Show("El registro no se ha insertado correctamente.");
                    }
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e) {
            Cliente c = new Cliente();
            DataTable clientes = c.Listar();

            using (frmListar f = new frmListar(clientes)) {
                f.ShowDialog();

                if (f.DialogResult == DialogResult.OK) {
                    Cliente c2 = new Cliente(f.Nombre, f.Apellido, f.Direccion, f.DNI, f.Fecha);
                    c2.Id = f.getId();

                    c2.Guardar();
                } else if (f.DialogResult == DialogResult.No) {
                    Cliente c3 = new Cliente();
                    if (c3.Borrar(f.getId())) {
                        MessageBox.Show("Registro borrado con éxito");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace NET_WF_CRUD_Cliente {
    class Cliente : Model {
        private int _id;
        private string _nombre = string.Empty;
        private string _apellido = string.Empty;
        private string _direccion = string.Empty;
        private string _dni = string.Empty;
        private DateTime _fecha;

        public int Id {
            get => _id;
            set => _id = value;
        }
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

        public Cliente() : base () {}

        public Cliente(string nombre, string apellido, string direccion, string dni, DateTime fecha) : base() {
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            DNI = dni;
            Fecha = fecha;
        }

        public Cliente(int id) {
            try {
                DataTable cliente =  Read("SELECT * FROM Cliente WHERE Id=" + id);
                DataRow datos = cliente.Rows[0];

                Nombre = datos[1].ToString();
                Apellido = datos[2].ToString();
                Direccion = datos[3].ToString();
                DNI = datos[4].ToString();
                //Fecha = DateTime.ParseExact(datos[5].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Fecha = DateTime.Parse(datos[5].ToString());
            } catch (Exception e) {
                Console.WriteLine(e.Message);                
            }
        }

        public bool Guardar() {
            try {
                if (Id==0) {
                    return Execute("INSERT Cliente VALUES ('" + Nombre + "', '" + Apellido + "', '" + Direccion + "', '" + DNI + "','" + Fecha + "' )");
                } else {
                    return Execute("UPDATE Cliente SET Nombre='" + Nombre + "', Apellido='" + Apellido + "', Direccion='" + Direccion + "', DNI='" + DNI + "', Fecha='" + Fecha + "' WHERE Id=" + Id);
                }                
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }            
        }

        public DataTable Listar() {
            try {
                return Read("SELECT Id, Nombre, Apellido FROM Cliente");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool Borrar(int id) {
            try {
                return Execute("DELETE Cliente WHERE Id=" + id);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

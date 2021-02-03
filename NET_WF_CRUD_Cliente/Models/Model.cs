using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_WF_CRUD_Cliente {
    class Model {
        private SqlConnection _sqlConn;
        public SqlConnection Connection {
            get => _sqlConn;
            set { _sqlConn = value; }
        }

        public Model() {
            Connect();
        }
        public void Connect() {
            try {
                Connection = new SqlConnection("Server=172.23.132.105;Database=NET_WF_MVC_1;User Id=sa;Password=121916Ab;");
                Connection.Open();                
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        public void Disconnect() {
            try {
                Connection.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public bool Execute(string sql) {
            try {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();

                return true;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public DataTable Read(string sql) {
            try {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                SqlDataReader rows = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(rows);

                return dt;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

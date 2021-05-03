using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{ 
    public class dCliente
    {
        Database db = new Database();
        public string Insertar(eCliente cli)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string insertar = string.Format("insert into cliente (DNI,usuario,clave) VALUES ('{0}','{1}','{2}')", cli.DNI,cli.nombre,cli.clave);
                SqlCommand cmd = new SqlCommand(insertar, conexion);
                cmd.ExecuteNonQuery();
                return "REGISTRO USUARIO";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                db.DesconectarDB();
            }

        }
        public string Modificar(eCliente cli, string dni)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string update = string.Format("UPDATE cliente SET usuario='{0}', clave='{1}'  Where DNI={2}",cli.nombre,cli.clave,dni);
                SqlCommand cmd = new SqlCommand(update, conexion);
                cmd.ExecuteNonQuery();
                return "MODIFICO USUARIO";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDB();
            }

        }
        public string Eliminar(string id)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string delete = string.Format("DELETE from cliente WHERE idcliente='{0}'", id);
                SqlCommand cmd = new SqlCommand(delete, conexion);
                cmd.ExecuteNonQuery();
                return "ELIMINO USUARIO";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDB();
            }
        }
        public eCliente BuscarporId(string id)
        {
            try
            {
               eCliente cli = null;
                SqlConnection conexion = db.ConectarDB();
                string select = string.Format("select DNI,usuario,clave from cliente where DNI='{0}'", id);
                SqlCommand cmd = new SqlCommand(select, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   cli = new eCliente();
                   cli.DNI = (string)reader["DNI"];
                   cli.nombre= (string)reader["usuario"];
                   cli.clave = (string)reader["clave"];
                }
                reader.Close();
                return cli;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectarDB();
            }


        }
        public List<eCliente> lisarTodo()
        {
            try
            {
                List<eCliente> lisCli = new List<eCliente>();
                eCliente cli = null;
                SqlConnection conexion = db.ConectarDB();
                SqlCommand cmd = new SqlCommand("select DNI,usuario,clave from cliente", conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cli = new eCliente();
                    cli.DNI = (string)reader["DNI"];
                    cli.nombre = (string)reader["usuario"];
                    cli.clave = (string)reader["clave"];
                    lisCli.Add(cli);
                }
                reader.Close();
                return lisCli;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectarDB();
            }


        }
    }
}


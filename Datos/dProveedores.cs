using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dProveedores
    {
        Database db = new Database();
        public string Insertar(eProveedores pro)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string insertar = string.Format("insert into proveedoresT (producto,empresa) VALUES ('{0}','{1}')", pro.NombreEmpresa,pro.Nombreproducto);
                SqlCommand cmd = new SqlCommand(insertar,conexion);
                cmd.ExecuteNonQuery();
                return "Inserto";
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
        public string Modificar(eProveedores pro, int id)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB(); 
                string update = string.Format("UPDATE proveedoresT SET empresa='{0}', producto='{1}' Where idcompania={2}",pro.Nombreproducto,pro.NombreEmpresa,id );
                SqlCommand cmd = new SqlCommand(update, conexion);
                cmd.ExecuteNonQuery();
                return "Modifico";
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
        public string Eliminar(int id)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string delete = string.Format("DELETE from proveedoresT WHERE idcompania={0}", id);
                SqlCommand cmd = new SqlCommand(delete, conexion);
                cmd.ExecuteNonQuery();
                return "Elimino";
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
        public eProveedores BuscarporId(int id)
        {
            try
            {
                eProveedores pro = null;
                SqlConnection conexion = db.ConectarDB();
                string select = string.Format("select idcompania,empresa,producto from proveedoresT where idcompania={0}", id);
                SqlCommand cmd = new SqlCommand(select, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pro = new eProveedores();
                    pro.idCompania = (int)reader["idcompania"];
                    pro.NombreEmpresa = (string)reader["empresa"];
                    pro.Nombreproducto = (string)reader["producto"];
                }
                reader.Close();
                return pro;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectarDB();
            }
        }
        public List<eProveedores> lisarTodo()
        {
            try
            {
                List<eProveedores> lisPro = new List<eProveedores>();
                eProveedores pro = null;
                SqlConnection conexion = db.ConectarDB();
                SqlCommand cmd = new SqlCommand("select idcompania,empresa,producto from proveedoresT", conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pro = new eProveedores();
                    pro.idCompania = (int)reader["idcompania"];
                    pro.NombreEmpresa = (string)reader["empresa"];
                    pro.Nombreproducto = (string)reader["producto"];
                    lisPro.Add(pro);
                }
                reader.Close();
                return lisPro;
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

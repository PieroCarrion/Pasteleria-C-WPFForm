using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dProducto
    {
        Database db = new Database();
        public string Insertar(eProducto pro)
        {
            try
            {
                SqlConnection con = db.ConectarDB();
                string insert = string.Format("insert into productoT (idcompania,idplato,cantidad)values('{0}','{1}',{2})", pro.idCompania,pro.idPlato,pro.cantidad);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
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
        public string Modificar(eProducto pro, int id)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string update = string.Format("UPDATE productoT SET idcompania='{0}', idplato='{1}', cantidad={2} Where idproducto={3}", pro.idCompania,pro.idPlato,pro.cantidad,id);
                SqlCommand cmd = new SqlCommand(update, conexion);
                cmd.ExecuteNonQuery();
                return "MODIFICO PRODUCTO";
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
                string delete = string.Format("DELETE from productoT WHERE idproducto={0}", id);
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
        public eProducto BuscarPorId(int id)
        {
            try
            {
                eProducto producto = null;
                SqlConnection con = db.ConectarDB();

                string select = string.Format("select idproducto,idcompania,idplato,cantidad from productoT WHERE idproducto ={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    producto = new eProducto();
                    producto.idProducto = (int)reader["idproducto"];
                    producto.idCompania = (string)reader["idcompania"];
                    producto.idPlato = (string)reader["idplato"];
                    producto.cantidad = (int)reader["cantidad"];
                }
                reader.Close();
                return producto;
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
        public List<eProducto> listodo()
        {
            try
            {
                List<eProducto> lsproducto = new List<eProducto>();
                eProducto producto = null;
                eProveedores pro = null;
                ePlatos pla = null;
                SqlConnection con = db.ConectarDB();
                SqlCommand cmd = new SqlCommand("select idproducto,idcompania,idplato,cantidad from productoT", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new eProducto();
                    producto.idProducto = (int)reader["idproducto"];
                    producto.idCompania = (string)reader["idcompania"];
                    producto.idPlato = (string)reader["idplato"];
                    producto.cantidad = (int)reader["cantidad"];
                    lsproducto.Add(producto);
                }
                reader.Close();
                return lsproducto;
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
    }

}

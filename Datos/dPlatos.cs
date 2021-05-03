using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
   public class dPlatos
    {
        Database db = new Database();
        public string Insertar(ePlatos pla)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string insertar = string.Format("insert into platos (postre,nombre,precio) VALUES ('{0}','{1}',{2})",pla.postre, pla.nombre, pla.precio);
                SqlCommand cmd = new SqlCommand(insertar, conexion);
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
        public string Modificar(decimal precio, string nombre,string tipo,int idPlato)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string update = string.Format("UPDATE platos SET precio={0},postre = '{1}', nombre = '{2}' Where idplatos={3}", precio,tipo,nombre,idPlato);
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
                string delete = string.Format("DELETE from platos WHERE idplatos={0}", id);
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
        public ePlatos BuscarporId(int id)
        {
            try
            {
                ePlatos pla  = null;
                SqlConnection conexion = db.ConectarDB();
                string select = string.Format("select idplatos,postre,nombre,precio from platos where idplatos={0}", id);
                SqlCommand cmd = new SqlCommand(select, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    pla = new ePlatos();
                    pla.idPlatos = (int)reader["idplatos"];
                    pla.postre = (string)reader["postre"];
                    pla.nombre = (string)reader["nombre"];
                    pla.precio= (decimal)reader["precio"];
                }
                reader.Close();
                return pla;
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
        public List<ePlatos> lisarTodo()
        {
            try
            {
                List<ePlatos> lisPla = new List<ePlatos>();
                ePlatos pla = null;
                SqlConnection conexion = db.ConectarDB();
                SqlCommand cmd = new SqlCommand("select idplatos,postre,nombre,precio from platos", conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    pla = new ePlatos();
                    pla.idPlatos = (int)reader["idplatos"];
                    pla.nombre = (string)reader["nombre"];
                    pla.postre = (string)reader["postre"];
                    pla.precio = (decimal)reader["precio"];
                    lisPla.Add(pla);
                }
                reader.Close();
                return lisPla;
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

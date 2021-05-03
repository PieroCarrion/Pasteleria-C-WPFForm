using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dPasteleria
    {
        Database db = new Database();
        public string Insertar(ePasteleria pas)
        {
            try
            {
                SqlConnection con = db.ConectarDB();
                string insert = string.Format("insert into pasteleria(idcliente,idplato)values('{0}',{1})", pas.dniCliente,pas.idplatos);
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
        public string Modificar(ePasteleria pas, int idpasteleria)
        {
            try
            {
                SqlConnection conexion = db.ConectarDB();
                string update = string.Format("UPDATE pasteleria SET idcliente='{0}', idplato={1} Where idpasteleria={2}",pas.dniCliente,pas.idplatos,idpasteleria);
                SqlCommand cmd = new SqlCommand(update, conexion);
                cmd.ExecuteNonQuery();
                return "Actualizo Datos";
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
                string delete = string.Format("DELETE from pasteleria WHERE idpasteleria={0}", id);
                SqlCommand cmd = new SqlCommand(delete, conexion);
                cmd.ExecuteNonQuery();
                return "Elimino Datos";
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
        public ePasteleria BuscarPorId(int id)
        {
            try
            {
                ePasteleria pasteleria = null;
                SqlConnection con = db.ConectarDB();

                string select = string.Format("SELECT idpasteleria,idcliente,idplato FROM pasteleria WHERE idpasteleria = {0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pasteleria = new ePasteleria();
                    pasteleria.idpasteleria = (int)reader["idpasteleria"];
                    pasteleria.dniCliente = (string)reader["idcliente"];
                    pasteleria.idplatos = (int)reader["idplato"];
                }
                reader.Close();
                return pasteleria;
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
        public List<ePasteleria> listodo()
        {
            try
            {
                List<ePasteleria> lspasteleria = new List<ePasteleria>();
                ePasteleria pasteleria = null;
                SqlConnection con = db.ConectarDB();

                string select = string.Format("SELECT idpasteleria,idcliente,idplato FROM pasteleria");
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pasteleria = new ePasteleria();
                    pasteleria.idpasteleria = (int)reader["idpasteleria"];
                    pasteleria.dniCliente = (string)reader["idcliente"];
                    pasteleria.idplatos = (int)reader["idplato"];
                    lspasteleria.Add(pasteleria);
                }
                reader.Close();
                return lspasteleria;
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    public class nProducto
    {
        dProducto datospro;
        public nProducto()
        {
            datospro = new dProducto();
        }
        public string RegistrarProducto(string idempresa, string idplatos, int cantidad)
        {
            eProducto producto = new eProducto()
            {
               idCompania=idempresa,
               idPlato=idplatos,
               cantidad=cantidad
            };
            return datospro.Insertar(producto);
        }
        public string ModificarProducto(string idempresa, int cantidad,string idplato, int id)
        {

            eProducto producto = new eProducto()
            {
                idCompania = idempresa,
                cantidad = cantidad,
                idPlato = idplato
            };
            return datospro.Modificar(producto,id);
        }
        public string EliminarProducto(int id)
        {
            return datospro.Eliminar(id);
        }
        public List<eProducto> listarpasajero()
        {
            return datospro.listodo();
        }
    }
}


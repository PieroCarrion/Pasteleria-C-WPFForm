using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    public class nProveedores
    {
        dProveedores datospr;
        public nProveedores()
        {
            datospr = new dProveedores();
        }
        public string RegistrarProveedor(string producto,string empresa)
        {
            eProveedores pro = new eProveedores()
            {
                Nombreproducto = producto,
                NombreEmpresa = empresa
            };
            return datospr.Insertar(pro);
        }
        public string ModificarProveedor(string producto,string empresa, int idProveedor)
         {
            eProveedores pro = new eProveedores()
            {
                NombreEmpresa = empresa,
                Nombreproducto = producto
            };
            return datospr.Modificar(pro,idProveedor);
        }
        public string EliminarProveedor(int id)
        {
            return datospr.Eliminar(id);
        }
        public List<eProveedores> listarProveedores()
        {
            return datospr.lisarTodo();
        }
    }
}

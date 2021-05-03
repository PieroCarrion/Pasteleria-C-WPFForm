using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    
    public class nPlatos
    {
        dPlatos datosp;
        public nPlatos()
        {
            datosp = new dPlatos();
        }
        public string RegistrarPlatos(string pla, decimal precio, string nombre)
        {
            ePlatos plato = new ePlatos()
            {
                nombre = nombre,
                postre=pla,
                precio = precio
            };
            return datosp.Insertar(plato);
        }
        public string ModificarPlatos(decimal precio,string nombre ,string tipo,int id)
        {
            return datosp.Modificar(precio,nombre,tipo,id);
        }
        public string EliminarPlatos(int id)
        {
            return datosp.Eliminar(id);
        }
        public List<ePlatos> listarplatos()
        {
            return datosp.lisarTodo();
        }
    }
    
    

    
}

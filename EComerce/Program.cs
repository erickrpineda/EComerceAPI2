using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComerce.ClasesFunciones;
using EComerce.ClasesModelo;
using EComerce.BD;

namespace EComerce
{
    class Program
    {
        static void Main(string[] args)
        {

            //codigo para pruebas

            M_Clientes GuardarCliente = new M_Clientes();

            GuardarCliente.Nombre = "Pedro";
            GuardarCliente.Apellido="Lopez";
            GuardarCliente.Telefono="94959493";
            GuardarCliente.CorreoE="Pedro@dominio.com";

            var db = new EcomerceEntities();
            var x = ClasesFunciones.ClientesFunciones.ConvertirHaciaBaseDatos(GuardarCliente);

            db.Clientes.Add(x);
            db.SaveChanges();

            //codigo para pruebas
        }
    }
}

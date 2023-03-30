using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cor.Models.Interfaces;

namespace Cor
{
    public class Dclientes:IClientes
    {
        public List<clientes> listaClientes()
        {
            using(var db = new ClienteDBEntities()) 
            {

                return db.clientes.ToList();
            
            }
            
        }

        public clientes DetalleCliente(int cod)
        {
            using (var db = new ClienteDBEntities())
            {

                return db.clientes.Find(cod);

            }

        }

        public void AgregarCliente(clientes cliente)
        {

            using(var db= new ClienteDBEntities())
            {

                db.clientes.Add(cliente);
                db.SaveChanges();

            }

        }

        public void EditarCliente(clientes cliente)
        {
            using (var db = new ClienteDBEntities())
            {
                var origen = db.clientes.Find(cliente.Codigo);
                origen.Nombre = cliente.Nombre;
                origen.Apellido = cliente.Apellido;
                origen.Telefono = cliente.Telefono;
                origen.Ocupacion = cliente.Ocupacion;
                db.SaveChanges();
            }
        }
               

    }
}

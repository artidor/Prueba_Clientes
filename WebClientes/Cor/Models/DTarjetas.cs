using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cor.Models.Interfaces;

namespace Cor.Models
{
    public class DTarjetas:ITarjeta
    {
        public List<Tarjeta> listaTarjetas(int id)
        {
            using (var db = new ClienteDBEntities())
            {
                var lista = from s in db.Tarjeta
                            where s.codCliente==id
                            select s;

                return lista.ToList();

            }

        }

        public Tarjeta DetalleTarjeta(int cod)
        {
            using (var db = new ClienteDBEntities())
            {

                return db.Tarjeta.Find(cod);

            }

        }

        public List<Tarjeta> DetalleTarjetaPorNumero(string num)
        {
            using (var db = new ClienteDBEntities())
            {

                var lista = from s in db.Tarjeta
                            where s.Numero == num
                            select s;

                return lista.ToList();

            }

        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {

            using (var db = new ClienteDBEntities())
            {

                db.Tarjeta.Add(tarjeta);
                db.SaveChanges();

            }

        }

        public void EditarTarjeta(Tarjeta tarjeta)
        {
            using (var db = new ClienteDBEntities())
            {
                var origen = db.Tarjeta.Find(tarjeta.ID);
                origen.Tipo_Tarjeta = tarjeta.Tipo_Tarjeta;
                origen.Banco = tarjeta.Banco;
                origen.Numero = tarjeta.Numero;
                origen.Mes = tarjeta.Mes;
                origen.Ano = tarjeta.Ano;
                db.SaveChanges();
            }
        }


    }
}

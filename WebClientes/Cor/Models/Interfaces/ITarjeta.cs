using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cor.Models.Interfaces
{
    interface ITarjeta
    {
        List<Tarjeta> listaTarjetas(int id);
        Tarjeta DetalleTarjeta(int cod);
        List<Tarjeta> DetalleTarjetaPorNumero(string num);
        void AgregarTarjeta(Tarjeta tarjeta);
        void EditarTarjeta(Tarjeta tarjeta);
    }
}

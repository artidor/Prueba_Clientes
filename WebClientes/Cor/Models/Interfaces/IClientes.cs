using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cor;

namespace Cor
{
    interface IClientes
    {
        List<clientes> listaClientes();
        clientes DetalleCliente(int cod);
        void AgregarCliente(clientes cliente);
        void EditarCliente(clientes cliente);
    }
}

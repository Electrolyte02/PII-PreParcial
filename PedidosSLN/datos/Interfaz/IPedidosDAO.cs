using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Interfaz
{
    internal interface IPedidosDAO
    {
        List<PedidoDTO> TraerPedidos(List<Parametro> listaParams);
        List<ClienteDTO> TraerClientes();
        bool EntregarPedido(int nroPedido);
        bool BorrarPedido(int nroPedido);
    }
}

using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicio.Interfaz
{
    public interface IServicio
    {
        List<PedidoDTO> ObtenerPedidos(List<Parametro> lParams);
        List<ClienteDTO> ObtenerClientes();
        bool EntregarPedido(int nroPedido);
        bool BorrarPedido(int nroPedido);

    }
}

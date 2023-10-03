using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Implementacion;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicio.Implementacion
{
    public class Servicio : IServicio
    {
        IPedidosDAO dao;

        public Servicio()
        {
            dao = new PedidosDAO();
        }

        public bool BorrarPedido(int nroPedido)
        {
            return dao.BorrarPedido(nroPedido);
        }

        public bool EntregarPedido(int nroPedido)
        {
            return dao.EntregarPedido(nroPedido);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            return dao.TraerClientes();
        }

        public List<PedidoDTO> ObtenerPedidos(List<Parametro> lParams)
        {
            return dao.TraerPedidos(lParams);
        }
    }
}

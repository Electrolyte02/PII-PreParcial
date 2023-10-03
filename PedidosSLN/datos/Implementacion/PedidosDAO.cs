using System;
using RecetasSLN.datos.Interfaz;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.datos.DTOs;
using System.Data;
using CarpinteriaApp.datos;

namespace RecetasSLN.datos.Implementacion
{
    internal class PedidosDAO : IPedidosDAO
    {
        public bool BorrarPedido(int nroPedido)
        {
            bool aux = true;
            List<Parametro> lParam = new List<Parametro>();
            lParam.Add(new Parametro("@codigo", nroPedido));
            if (HelperDB.ObtenerInstancia().EjecutarSQL("SP_REGISTRAR_BAJA", lParam)== 0)
            {
                aux = false;
            }
            return aux;
        }

        public bool EntregarPedido(int nroPedido)
        {
            bool aux = true;
            List<Parametro> lParam = new List<Parametro>();
            lParam.Add(new Parametro("@codigo", nroPedido));
            if (HelperDB.ObtenerInstancia().EjecutarSQL("SP_REGISTRAR_ENTREGA", lParam) == 0)
            {
                aux = false;
            }
            return aux;
        }

        public List<ClienteDTO> TraerClientes()
        {
            DataTable tabla;
            List<ClienteDTO> lClientes = new List<ClienteDTO>();
            tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_CLIENTES",null);
            foreach (DataRow fila in tabla.Rows)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Id = int.Parse(fila["id_cliente"].ToString());
                cliente.NombreCompleto = (fila["nombre"].ToString()+ ',' + fila["apellido"].ToString());
                lClientes.Add(cliente);
            }
            return lClientes;
        }

        public List<PedidoDTO> TraerPedidos(List<Parametro> listParams)
        {
            DataTable tabla;
            List<PedidoDTO> listaPedidos = new List<PedidoDTO>();
            tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PEDIDOS", listParams);
            foreach(DataRow fila in tabla.Rows)
            {
                PedidoDTO ped = new PedidoDTO();
                ped.Codigo = int.Parse(fila["codigo"].ToString());
                ped.FechaEntrega = DateTime.Parse(fila["fec_entrega"].ToString());
                ped.Cliente = fila["cliente"].ToString();
            }
            return listaPedidos;
        }
    }
}

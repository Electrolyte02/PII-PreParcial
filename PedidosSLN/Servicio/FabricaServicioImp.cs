using RecetasSLN.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicio
{
    public class FabricaServicioImp:FabricaServicio
    {
        FabricaServicioImp()
        {
            new FabricaServicioImp();
        }
        public override IServicio ObtenerServicio()
        {
            return new Implementacion.Servicio();
        }
    }
}

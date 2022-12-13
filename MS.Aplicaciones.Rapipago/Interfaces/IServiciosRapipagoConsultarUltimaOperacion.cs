using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Aplicaciones.Rapipago.Interfaces
{
    public interface IServiciosRapipagoConsultarUltimaOperacion<TEntidad, T, P>
    {
        public Task<T> ConsultarUltimaOperacion(TEntidad entidad, P parameters);
    }
}

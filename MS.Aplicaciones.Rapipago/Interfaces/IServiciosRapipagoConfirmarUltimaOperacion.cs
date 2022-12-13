using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Aplicaciones.Rapipago.Interfaces
{
    public interface IServiciosRapipagoConfirmarUltimaOperacion<TEntidad, T, P>
    {
        public Task<T> ConfirmarUltimaOperacion(TEntidad entidad, P parameters);
    }
}

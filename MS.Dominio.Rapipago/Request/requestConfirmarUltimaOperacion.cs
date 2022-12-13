using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Dominio.Rapipago.Request
{
    public class requestConfirmarUltimaOperacion
    {

        public string codPuesto { get; set; } = String.Empty;
        public string idTrxAnterior { get; set; } = String.Empty;

    }
}

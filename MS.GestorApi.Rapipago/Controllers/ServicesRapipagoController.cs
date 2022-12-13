using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.Aplicaciones.Rapipago;
using MS.Aplicaciones.Rapipago.Interfaces;
using MS.Dominio.Rapipago.Param;
using MS.Dominio.Rapipago.Request;
using MS.Dominio.Rapipago.Response;

namespace MS.GestorApi.Rapipago.Controllers
{
    public class ServicesRapipagoController : Controller
    {
        private readonly ConfigParameters _parameters;

        private readonly IServicesRapipago<requestbase, responsebase, ConfigParameters> _servicesRapipago;
        private readonly IServiciosRapipagoConsultarUltimaOperacion<requestConfirmarUltimaOperacion, UltimaTransaccionResponse, ConfigParameters> _servicesRapipagoConsultarUltimaOperacion;
        private readonly IServiciosRapipagoConfirmarUltimaOperacion<requestConfirmarUltimaOperacion, responseConfirmarUltimaOperacion, ConfigParameters> _servicesRapipagoConfirmarUltimaOperacion;
        /// <summary>
        ///  Metodo que genera la ID de las interfaces para interactuar con los diferentes servicios
        /// </summary>
        /// <param name="servicesAltamira"></param>
        /// <param name="parameters"></param>
        public ServicesRapipagoController(IServicesRapipago<requestbase, responsebase, ConfigParameters> servicesRapipago,
            IServiciosRapipagoConsultarUltimaOperacion<requestConfirmarUltimaOperacion, UltimaTransaccionResponse, ConfigParameters> servicesRapipagoConsultarUltimaOperacion,
            IServiciosRapipagoConfirmarUltimaOperacion<requestConfirmarUltimaOperacion, responseConfirmarUltimaOperacion, ConfigParameters> servicesRapipagoConfirmarUltimaOperacion,
            IOptions<ConfigParameters> parameters)
        {
            _servicesRapipago = servicesRapipago;
            _servicesRapipagoConsultarUltimaOperacion = servicesRapipagoConsultarUltimaOperacion;
            _servicesRapipagoConfirmarUltimaOperacion = servicesRapipagoConfirmarUltimaOperacion;
            _parameters = parameters.Value;

        }

        [HttpPost]
        [Route("Sale")]
        [ProducesResponseType(200, Type = typeof(UltimaTransaccionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UltimaTransaccionResponse))]
        [Produces("application/json")]
        public async Task<IActionResult> ConsultarUltimaTransaccion([FromBody] requestConfirmarUltimaOperacion oReq)
        {
            UltimaTransaccionResponse responseSale = new UltimaTransaccionResponse();
            try
            {

                responseSale = await _servicesRapipago.ConsultarUltimaTransaccion(oReq, _parameters);

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            return Json(responseSale);

        }



        [HttpPost]
        [Route("testentorno")]
        [Produces("application/json")]
        public IActionResult Test()
        {
            String sFecha = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss");
            String sFecha1 = DateTime.Now.ToString("yyyyMMddHHmmss");

            String sFecha2 = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            String sFecha3 = DateTime.Now.ToOADate().ToString("yyyyMMddHHmmss");

            var targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            var targetDAteTime = TimeZoneInfo.ConvertTime(DateTime.Now, targetTimeZone).ToString("yyyyMMddHHmmss");

            var targetTimeZoneLx = TimeZoneInfo.FindSystemTimeZoneById("America/Argentina/Buenos_Aires");
            var targetDAteTimeLx = TimeZoneInfo.ConvertTime(DateTime.Now, targetTimeZone).ToString("yyyyMMddHHmmss");

            var sCadena = "Entorno " + _parameters.entorno;

            sCadena = sCadena + " urlaltamira " + _parameters.urlrapipago + "    ";
            sCadena = sCadena + " puertoenvio " + _parameters.redrapiapgo + "    ";
            

            return Ok(sCadena + "    " + Environment.NewLine + "Fecha ToLocalTime " + sFecha + "    " + " Fecha1 Now: " + sFecha1 + "    " + " Fecha2 UtcNow: " + sFecha2 + "    " + " Fecha3 ToOADate: " + sFecha3 + Environment.NewLine
                + " targetDAteTime: " + targetDAteTime + "    " + " targetDAteTimeLx: " + targetDAteTimeLx);

        }
    }
}

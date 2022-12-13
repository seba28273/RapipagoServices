using MS.Aplicaciones.Rapipago.Interfaces;
using MS.Dominio.Rapipago.Param;
using MS.Dominio.Rapipago.Request;
using MS.Dominio.Rapipago.Response;
using System.IO;

namespace MS.Aplicaciones.Rapipago
{
    public class ServicesRapipago: IServicesRapipago<requestConfirmarUltimaOperacion, UltimaTransaccionResponse, ConfigParameters>, 
                                   IServiciosRapipagoConsultarUltimaOperacion<requestbase, UltimaTransaccionResponse, ConfigParameters>, 
                                   IServiciosRapipagoConfirmarUltimaOperacion<requestConfirmarUltimaOperacion, responseConfirmarUltimaOperacion, ConfigParameters>
    {
     
        public Task<responseConfirmarUltimaOperacion> ConfirmarUltimaOperacion(requestConfirmarUltimaOperacion entidad, ConfigParameters parameters)
        {
            //address = New Uri(WebConfigurationManager.AppSettings("UrlRapipago").ToString() & "transaccion/confirmar")
            throw new NotImplementedException();
        }

        public Task<UltimaTransaccionResponse> ConsultarUltimaOperacion(requestbase entidad, ConfigParameters parameters)
        {
            //address = New Uri(WebConfigurationManager.AppSettings("UrlRapipago").ToString() & "transaccion/mensaje?codPuesto=" & codPuesto & "&idTransaccion=" & idItem)
            throw new NotImplementedException();
        }
        
        public async Task<UltimaTransaccionResponse> ConsultarUltimaTransaccion(requestConfirmarUltimaOperacion entidad, ConfigParameters parameters)
        {
            //api

            HttpClient client = new HttpClient();
            UltimaTransaccionResponse ultimaTransaccionResponse = new UltimaTransaccionResponse();
            HttpResponseMessage response = await client.GetAsync(parameters.urlrapipago + "/transaccion/ultima?codPuesto=" + entidad.codPuesto);
            if (response.IsSuccessStatusCode)
            {

                ultimaTransaccionResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                ultimaTransaccionResponse.descResul = "no se pudo consultar ultima transaccion";
                ultimaTransaccionResponse.codResul = 99;
                ultimaTransaccionResponse.existeTrxEnProceso = false;
                ultimaTransaccionResponse.idUltimaTrxPendiente = "00";
                ultimaTransaccionResponse.idUltimaTrxConfirmada = "00";
            }   

            return ultimaTransaccionResponse;
            //http://200.123.144.198/fase2/transaccion/ultima?codPuesto=27395
            
        }


       
    }
    
}

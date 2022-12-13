namespace MS.Dominio.Rapipago.Response
{
    public class UltimaTransaccionResponse : responsebase
    {

        public int codPuesto { get; set; }
        public string idUltimaTrxPendiente { get; set; } = string.Empty;
        public string idUltimaTrxConfirmada { get; set; } = string.Empty;
        public bool existeTrxEnProceso { get; set; }
        public int codResul { get; set; }
        public string descResul { get; set; } = string.Empty;

        public static implicit operator UltimaTransaccionResponse(string v)
        {
            throw new NotImplementedException();
        }
    }
}

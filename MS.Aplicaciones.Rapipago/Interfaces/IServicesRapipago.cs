namespace MS.Aplicaciones.Rapipago.Interfaces
{
    public interface  IServicesRapipago<TEntidad, T, P>
    {
        public Task<T> ConsultarUltimaTransaccion(TEntidad entidad, P parameters);

       
    }
}

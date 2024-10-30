namespace LabSoft.Data.Negocio.Servicios
{
    public interface IPreferenciaService {
        List<Preferencia> GetPreferencia();
        Preferencia? GetPreferenciaById(string id);
        void AddPreferencia(Preferencia preferencia);
    }
}
namespace LabSoft.Data.Repositorio
{
    public interface IPreferenciaRepository
    {
        List<Preferencia> GetPreferencia();
        Preferencia? GetPreferenciaById(string id);
        void AddPreferencia(Preferencia preferencia);
    }
}
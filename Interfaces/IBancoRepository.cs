namespace ApiTesteTecnico.Interfaces
{
    public interface IBancoRepository
    {
        IQueryable<Banco> GetBancos();
        IQueryable<Banco> GetBancoById(int Id);
        void Add(Banco banco);
        Task SaveChangesAsync();
    }
}

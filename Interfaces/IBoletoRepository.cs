namespace ApiTesteTecnico.Interfaces
{
    public interface IBoletoRepository
    {
        IQueryable<Boleto> GetBoletos();
        IQueryable<Boleto> GetBoletosById(int Id);
        void Add(Boleto boleto);
        Task SaveChangesAsync();
    }
}

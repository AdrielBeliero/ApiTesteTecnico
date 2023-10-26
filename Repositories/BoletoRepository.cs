using ApiTesteTecnico.Interfaces;

namespace ApiTesteTecnico.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly AppDbContext _DbContext;

        public BoletoRepository(AppDbContext DbContext) 
        {
            _DbContext = DbContext;
        }

        public IQueryable<Boleto> GetBoletos() 
        { 
            return _DbContext.Boletos;
        }

        public IQueryable<Boleto> GetBoletosById(int Id) 
        {
            return _DbContext.Boletos.Where(b => b.Id == Id);
        }

        public void Add(Boleto boleto) 
        {
            _DbContext.Boletos.Add(boleto);
        }

        public async Task SaveChangesAsync() 
        { 
            await _DbContext.SaveChangesAsync();    
        }

    }
}

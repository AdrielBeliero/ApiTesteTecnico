using ApiTesteTecnico.Interfaces;

namespace ApiTesteTecnico.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly AppDbContext _DbContext;

        public BancoRepository(AppDbContext DbContext) 
        {
            _DbContext = DbContext;
        }

        public IQueryable<Banco> GetBancos() 
        { 
            return _DbContext.Bancos;
        }

        public IQueryable<Banco> GetBancoById(int Id) 
        {
            return _DbContext.Bancos.Where(b => b.Id == Id);
        }

        public void Add(Banco banco) 
        {
            _DbContext.Bancos.Add(banco);
        }

        public async Task SaveChangesAsync() 
        { 
            await _DbContext.SaveChangesAsync();    
        }

    }
}

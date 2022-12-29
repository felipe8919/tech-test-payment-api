using tech_test_payment_api.Models;
using tech_test_payment_api.Persistence;

namespace tech_test_payment_api.Repositories
{
    public class VendaRepository : Repository<Venda>
    {
       
        public VendaRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
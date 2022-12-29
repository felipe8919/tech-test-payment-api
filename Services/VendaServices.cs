using tech_test_payment_api.Repositories;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Services
{
    public class VendaServices 
    {
        private readonly VendaRepository vendaRepository;
        public VendaServices(VendaRepository vendaRepository)
        {
            this.vendaRepository = vendaRepository;
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return vendaRepository.GetAll();
        }

        public virtual Venda ObterPorId(int id)
        {
            return vendaRepository.GetById(id);
        }

        public void RegistrarVenda(Venda venda)
        {
            vendaRepository.Add(venda);
        }

        public void AtualizarStatus(int id, EnumStatusVenda status)
        {
            var venda = vendaRepository.GetById(id);
            venda.AlterarStatus(status);
            vendaRepository.Update(venda);
        }
    }
}

namespace tech_test_payment_api.Models
{
    public class Venda 
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<Produto> Produtos { get; set; }
        public EnumStatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public bool InformouProduto => Produtos != null && Produtos.Any();
        public bool InformouData => Data != DateTime.MinValue;
        public bool InformouVendedor => Vendedor != null;

        public void AlterarStatus(EnumStatusVenda status)
        {
            // Alterar status para Pagamento Aprovado ou Cancelada
            AlterarStatusParaPagamentoAprovadoOuCancelada(status);

            // Alterar status para Enviado para transportadora ou Cancelada
            AlterarStatusParaEnviadoParaTransportadoraOuCancelado(status);

            // Alterar status para Entregue 
            AlterarStatusParaEntregue(status);

            if(Status != status)
               throw new Exception($"Não é permitido alterar para o status {status} ! ");
        }
        private void AlterarStatusParaEntregue(EnumStatusVenda status)
        {
            if (StatusAtualEnviadoParaTransportadora &&
                status == EnumStatusVenda.Entregue)
                Status = status;
        }
        private bool StatusAtualEnviadoParaTransportadora => Status == EnumStatusVenda.EnviadoParaTransportadora;
        
        private void AlterarStatusParaEnviadoParaTransportadoraOuCancelado(EnumStatusVenda status)
        {
            if (StatusAtualIgualPagamentoAprovado && (status == EnumStatusVenda.EnviadoParaTransportadora || status == EnumStatusVenda.Cancelada))
                Status = status;
        }
        private bool StatusAtualIgualPagamentoAprovado =>  Status == EnumStatusVenda.PagamentoAprovado;
        
        private void AlterarStatusParaPagamentoAprovadoOuCancelada(EnumStatusVenda status)
        {
            if (Status == EnumStatusVenda.AguardandoPagamento &&
                (status == EnumStatusVenda.PagamentoAprovado || status == EnumStatusVenda.Cancelada))
                Status = status;
        }
    }
}
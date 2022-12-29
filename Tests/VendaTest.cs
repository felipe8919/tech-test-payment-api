using tech_test_payment_api.Models;
using Xunit;

namespace tech_test_payment_api.Tests
{
    public class VendaTest
    {
        [Fact]
        public void Deve_Validar_Produto_Informado()
        {
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 1,
                        Descricao = "mola"
                    }
                },
            };

            Assert.True(venda.InformouProduto);
        }

        [Fact]
        public void Deve_Validar_Produto_Nao_Informado()
        {
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                Produtos = null
            };

            Assert.False(venda.InformouProduto);
        }

        [Fact]
        public void Deve_Validar_Data_Informar_Data()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 2,
                        Descricao = "amortecedor"
                    }
                },
            };

            Assert.True(venda.InformouData);
        }
         
        [Fact]
        public void Deve_Validar_Data_Nao_Informar()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.MinValue,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 3,
                        Descricao = "Pastilha"
                    }
                },
            };

            Assert.False(venda.InformouData, "A data da venda deve ser informada.");
        }

        [Fact]
        public void Deve_Validar_Vendedor_Informado()
        {
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 1,
                        Descricao = "mola"
                    }
                },
                
                Vendedor = new Vendedor
                {
                    Id = 1,
                    Nome = "Felipe",
                    Cpf = "14421549790",
                    Telefone = "964995150",
                    Email = "teste@gmail.com"            
                }
            };

            Assert.True(venda.InformouVendedor);
        }

        [Fact]
        public void Deve_Validar_Vendedor_Nao_Informado()
        {
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                Produtos = null,
                Vendedor = null
            };

            Assert.False(venda.InformouVendedor);
        }

        [Fact]
        public void Deve_Alterar_Status_De_Pagamento_Aprovado_Para_Enviado_Para_Transportadora()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 4,
                        Descricao = "Sensor"
                    }
                },
            };

            venda.AlterarStatus(EnumStatusVenda.EnviadoParaTransportadora);
            Assert.True(venda.Status == EnumStatusVenda.EnviadoParaTransportadora);
        }

        [Fact]
        public void Deve_Alterar_Status_De_Pagamento_Aprovado_Para_Cancelada()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 5,
                        Descricao = "Disco de Freio"
                    }
                },
            };

            venda.AlterarStatus(EnumStatusVenda.Cancelada);
            Assert.True(venda.Status == EnumStatusVenda.Cancelada);
        }

        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_De_Pagamento_Aprovado_Para_Entregue()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 6,
                        Descricao = "Tambor de Freio"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.Entregue));
        }
         
        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_De_Pagamento_Aprovado_Para_Aguardando_Pagamento()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.PagamentoAprovado,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 7,
                        Descricao = "Sapata de Freio"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.AguardandoPagamento));
        }

        [Fact]
        public void Deve_Alterar_Status_De_Aguardando_Pagamento_Para_Pagamento_Aprovado()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.AguardandoPagamento,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 8,
                        Descricao = "Lona de Freio"
                    }
                },
            };

            venda.AlterarStatus(EnumStatusVenda.PagamentoAprovado);
            Assert.True(venda.Status == EnumStatusVenda.PagamentoAprovado);
        }

        [Fact]
        public void Deve_Alterar_Status_De_Aguardando_Pagamento_Para_Cancelada()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.AguardandoPagamento,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 9,
                        Descricao = "Cabo de Vela"
                    }
                },
            };

            venda.AlterarStatus(EnumStatusVenda.Cancelada);
            Assert.True(venda.Status == EnumStatusVenda.Cancelada);
        }

        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_De_Aguardando_Pagamento_Para_Enviado_Para_Transportadora()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.AguardandoPagamento,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 10,
                        Descricao = "Vela de Ignição"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.EnviadoParaTransportadora));
        }

        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_De_Aguardando_Pagamento_Para_Entregue()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.AguardandoPagamento,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 11,
                        Descricao = "Rolamento de Roda"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.Entregue));
        }

        [Fact]
        public void Deve_Alterar_Status_De_Enviado_Para_Transportadora_Para_Entregue()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.EnviadoParaTransportadora,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 12,
                        Descricao = "Kit Amortecedor"
                    }
                },
            };

            venda.AlterarStatus(EnumStatusVenda.Entregue);
            Assert.True(venda.Status == EnumStatusVenda.Entregue);
        }

        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_Enviado_Para_Transportadora_Para_Pagamento_Aprovado()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.EnviadoParaTransportadora,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 13,
                        Descricao = "Tensor"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.PagamentoAprovado));
        }

        [Fact]
        public void Deve_Retornar_Excecao_Quando_Alterar_Status_Enviado_Para_Transportadora_Para_Cancelada()
        { 
            var venda = new Venda
            {
                Id = 1,
                Data = DateTime.Now,
                Status = EnumStatusVenda.EnviadoParaTransportadora,
                 Produtos = new List<Produto> 
                { 
                    new Produto 
                    {
                        Id = 14,
                        Descricao = "Correia"
                    }
                },
            };

            Assert.Throws<Exception>(() => venda.AlterarStatus(EnumStatusVenda.Cancelada));
        }
    }
}
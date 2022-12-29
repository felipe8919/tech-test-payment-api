using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Services;
using tech_test_payment_api.Models;


namespace tech_test_payment_api_copia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaServices vendaServices;

        public VendaController(VendaServices vendaServices)
        {
            this.vendaServices = vendaServices;
        }
       
       
        [HttpGet("ObterTodasVendas")]
        public IActionResult Get()
        {
            var vendas = vendaServices.ObterTodos();
            return Ok(vendas);
        }

           
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venda = vendaServices.ObterPorId(id);
                    
            //Obrigatório id da venda.
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        [HttpPost("RegistrarVenda")]
        public IActionResult Post(Venda venda)
        {
            //obrigatório
            try 
            { 
                if (!venda.InformouProduto)
                    return BadRequest(new { Erro = "Obrigatório a venda ter pelo menos 1 item !" });
            
                if (!venda.InformouData)
                    return BadRequest(new { Erro = "A data da venda não pode ser vazia !" });

                if (!venda.InformouVendedor)
                    return BadRequest(new { Erro = "É obrigatório informar o vendedor !" });
             
                vendaServices.RegistrarVenda(venda);
                
                return CreatedAtAction(nameof(Post), new { id = venda.Id }, venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }   
        
        [HttpPut]
        public IActionResult Put(int id, EnumStatusVenda status)
        {
            
            try 
            { 
                vendaServices.AtualizarStatus(id, status);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    } 
}
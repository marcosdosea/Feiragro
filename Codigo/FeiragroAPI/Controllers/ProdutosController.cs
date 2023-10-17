using AutoMapper;
using Core;
using Core.Service;
using FeiragroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeiragroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutoService produtoService;
        private readonly IMapper mapper;

        public ProdutosController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
            this.mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            var listaProdutos = produtoService.GetAll();
            if (listaProdutos == null)
                return NotFound();
            return Ok(listaProdutos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Produto produto = produtoService.Get(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var produto = mapper.Map<Produto>(produtoModel);
            produtoService.Create(produto);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var produto = mapper.Map<Produto>(produtoModel);
            if (produto == null)
                return NotFound();

            produtoService.Edit(produto);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Produto produto = produtoService.Get(id);
            if (produto == null)
                return NotFound();

            produtoService.Delete(id);
            return Ok();
        }
    }
}


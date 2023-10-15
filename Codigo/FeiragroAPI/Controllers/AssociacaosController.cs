using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeiragroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociacaosController : ControllerBase
    {
        private readonly IAssociacaoService associacaoService;
        private readonly IMapper mapper;

        public AssociacaosController(IAssociacaoService associacaoService, IMapper mapper)
        {
            this.associacaoService = associacaoService;
            this.mapper = mapper;
        }
        // GET: api/<AssociacaosController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAssociacao = associacaoService.GetAll();
            if (listaAssociacao == null)
                return NotFound();
            return Ok(listaAssociacao);
        }

        // GET api/<AssociacaosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            if (associacao == null)
                return NotFound();
            return Ok(associacao);
        }

        // POST api/<AssociacaosController>
        [HttpPost]
        public ActionResult Post([FromBody] AssociacaoModel associacaoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var associacao = mapper.Map<Associacao>(associacaoModel);
            associacaoService.Create(associacao);

            return Ok();
        }

        // PUT api/<AssociacaosController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] AssociacaoModel associacaoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var associacao = mapper.Map<Associacao>(associacaoModel);
            if (associacao == null)
                return NotFound();

            associacaoService.Edit(associacao);
            return Ok();
        }

        // DELETE api/<AssociacaosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            if (associacao == null)
                return NotFound();

            associacaoService.Delete(id);
            return Ok();
        }
    }
}

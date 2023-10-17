using AutoMapper;
using Core;
using Core.Service;
using FeiragroAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeiragroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeiraController : ControllerBase
    {

        private readonly IFeiraService _feiraService;
        private readonly IMapper _mapper;

        public FeiraController(IFeiraService feiraService, IMapper maper)
        {
            _feiraService = feiraService;
            _mapper = maper;
        }

        // GET: api/<FeiraController>
        [HttpGet]
        public ActionResult<List<FeiraModel>> Get()
        {
            var listaFeiras = _feiraService.GetAll();
            if(listaFeiras == null)
                return NotFound();
            return Ok(listaFeiras);
        }

        // GET api/<FeiraController>/5
        [HttpGet("{id}")]
        public ActionResult<FeiraModel> Get(int id)
        {
            Feira feira = _feiraService.Get(id);
            if(feira == null)
                return NotFound();
            return Ok(feira);
        }

        // POST api/<FeiraController>
        [HttpPost]
        public ActionResult Post([FromBody] FeiraModel feiraModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var feira = _mapper.Map<Feira>(feiraModel);
            _feiraService.Create(feira);
            return Ok();


        }

        // PUT api/<FeiraController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FeiraModel feiraModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var feira = _mapper.Map<Feira>(feiraModel);
            if (feira == null)
                return NotFound();

            _feiraService.Edit(feira);
            return Ok();
        }

        // DELETE api/<FeiraController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Feira feira = _feiraService.Get(id);
            if (feira == null)
                return NotFound();

            _feiraService.Delete(id);
            return Ok();
        }
    }
}

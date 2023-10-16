using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeiragroWeb.Controllers
{
    [Authorize]
    public class PessoaController : Controller
    {
        private readonly IPessoaService pessoaService;
        private readonly IMapper mapper;


        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            this.pessoaService = pessoaService;
            this.mapper = mapper;
        }


        [Authorize(Roles = "CLIENTE")]
        // GET: PessoaController
        public ActionResult Index()
        {
            var listaPessoas = pessoaService.GetAll();
            var listaPessoasModel = mapper.Map<List<PessoaModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = pessoaService.Get(id);
            PessoaModel pessoaModel = mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var tipoProduto = mapper.Map<Pessoa>(pessoaModel);
                pessoaService.Create(tipoProduto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = pessoaService.Get(id);
            PessoaModel pessoaMoel = mapper.Map<PessoaModel>(pessoa);
            return View(pessoaMoel);

        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = mapper.Map<Pessoa>(pessoaModel);
                pessoaService.Edit(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = pessoaService.Get(id);
            PessoaModel pessoaModel = mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PessoaModel pessoaModel)
        {
            pessoaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
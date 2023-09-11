using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeiragroWeb.Controllers
{
    public class AssociacaoController : Controller
    {
        private readonly IAssociacaoService associacaoService;
        private readonly IMapper mapper;

        public AssociacaoController(IAssociacaoService associacaoService, IMapper mapper)
        {
            this.associacaoService = associacaoService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarAssociacoes = associacaoService.GetAll();
            var listarAssociacoesModel = mapper.Map<List<AssociacaoModel>>(listarAssociacoes);
            return View(listarAssociacoesModel);
        }

        // GET: AssociacaoController/Details/5
        public ActionResult Details(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            AssociacaoModel associacaoModel = mapper.Map<AssociacaoModel>(associacao);
            return View(associacaoModel);
        }

        // GET: AssociacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssociacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssociacaoModel associacaoModel)
        {
            if(ModelState.IsValid)
            {
                var associacao = mapper.Map<Associacao>(associacaoModel);
                associacaoService.Create(associacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AssociacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            AssociacaoModel associacaoModel = mapper.Map<AssociacaoModel>(associacao);
            return View(associacaoModel);
        }

        // POST: AssociacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssociacaoModel associacaoModel)
        {
            if(ModelState.IsValid)
            {
                var associacao = mapper.Map<Associacao>(associacaoModel);
                associacaoService.Edit(associacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AssociacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            AssociacaoModel associacaoModel = mapper.Map<AssociacaoModel>(associacao);
            return View(associacaoModel);
        }

        // POST: AssociacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssociacaoModel associacaoModel)
        {
            associacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
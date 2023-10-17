using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
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
            var listarAssociacoesModel = mapper.Map<List<PontoAssociacaoModel>>(listarAssociacoes);
            return View(listarAssociacoesModel);
        }

        // GET: AssociacaoController/Details/5
        public ActionResult Details(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            PontoAssociacaoModel associacaoModel = mapper.Map<PontoAssociacaoModel>(associacao);
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
        public ActionResult Create(PontoAssociacaoModel associacaoModel)
        {
            if(ModelState.IsValid)
            {
                var associacao = mapper.Map<Associacao>(associacaoModel);
                Console.WriteLine("@@@@@@@@@@@@\n" + associacao.Status);
                associacaoService.Create(associacao);
            }
            else
            {
                Console.WriteLine("Nao criou");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AssociacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Associacao associacao = associacaoService.Get(id);
            PontoAssociacaoModel associacaoModel = mapper.Map<PontoAssociacaoModel>(associacao);
            return View(associacaoModel);
        }

        // POST: AssociacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PontoAssociacaoModel associacaoModel)
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
            PontoAssociacaoModel associacaoModel = mapper.Map<PontoAssociacaoModel>(associacao);
            return View(associacaoModel);
        }

        // POST: AssociacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PontoAssociacaoModel associacaoModel)
        {
            associacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
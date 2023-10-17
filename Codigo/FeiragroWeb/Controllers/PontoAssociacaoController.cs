using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace FeiragroWeb.Controllers
{
    public class PontoAssociacaoController : Controller
    {
        private readonly IPontoAssociacaoService _pontoAssociacaoService;
        private readonly IMapper _mapper;
        
        public PontoAssociacaoController(IPontoAssociacaoService pontoAssociacaoService, IMapper mapper)
        {
            _pontoAssociacaoService = pontoAssociacaoService;
            _mapper = mapper;
        }
        // GET: PontoAssociacaoController
        public ActionResult Index()
        {
            var listaPontoAssociacao = _pontoAssociacaoService.GetAll();
            var listaPontoAssociacaoModel = _mapper.Map<List<PontoAssociacaoModel>>(listaPontoAssociacao);
            return View(listaPontoAssociacaoModel);
        }

        // GET: PontoAssociacaoController/Details/5
        public ActionResult Details(int id)
        {
            Pontoassociacao pontoassociacao = _pontoAssociacaoService.Get(id);
            PontoAssociacaoModel pontoassociacaoModel = _mapper.Map<PontoAssociacaoModel>(pontoassociacao);
            return View(pontoassociacaoModel);
        }

        // GET: PontoAssociacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PontoAssociacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PontoAssociacaoModel pontoAssociacaoModel)
        {
            if (ModelState.IsValid)
            {
                var pontoAssociacao = _mapper.Map<Pontoassociacao>(pontoAssociacaoModel);
                _pontoAssociacaoService.Create(pontoAssociacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PontoAssociacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Pontoassociacao pontoAssociacao = _pontoAssociacaoService.Get(id);
            PontoAssociacaoModel pontoAssociacaoModel = _mapper.Map<PontoAssociacaoModel>(pontoAssociacao);
            return View(pontoAssociacaoModel);
        }

        // POST: PontoAssociacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PontoAssociacaoModel pontoAssociacaoModel)
        {
            if (ModelState.IsValid)
            {
                var pontoassociacao = _mapper.Map<Pontoassociacao>(pontoAssociacaoModel);
                _pontoAssociacaoService.Edit(pontoassociacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PontoAssociacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Pontoassociacao pontoassociacao = _pontoAssociacaoService.Get(id);
            PontoAssociacaoModel pontoAssociacaoModel = _mapper.Map<PontoAssociacaoModel>(pontoassociacao);
            return View(pontoAssociacaoModel);
        }


        // POST: PontoAssociacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PontoAssociacaoModel pontoAssociacaoModel)
        {
            _pontoAssociacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

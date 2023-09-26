using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace FeiragroWeb.Controllers
{
    public class ProdutoFeiraController : Controller
    {

        private readonly IProdutoFeiraService produtofeiraService;
        private readonly IMapper mapper;

        public ProdutoFeiraController(IProdutoFeiraService ProdutoFeiraService, IMapper mapper)
        {
            this.produtofeiraService = ProdutoFeiraService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarProdutoFeiras = produtofeiraService.GetAll();
            var listarProdutoFeirasModel = mapper.Map<List<ProdutoFeiraModel>>(listarProdutoFeiras);
            return View(listarProdutoFeirasModel);
        }

        // GET: ProdutoFeiraController/Details/5
        public ActionResult Details(int id)
        {
            Produtofeira produtofeira = produtofeiraService.Get(id);
            ProdutoFeiraModel produtofeiraModel = mapper.Map<ProdutoFeiraModel>(produtofeira);
            return View(produtofeiraModel);
        }

        // GET: ProdutoFeiraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoFeiraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoFeiraModel produtoFeiraModel)
        {
            if (ModelState.IsValid)
            {
                var produtofeira = mapper.Map<Produtofeira>(produtoFeiraModel);
                produtofeiraService.Create(produtofeira);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: ProdutoFeiraController/Edit/5
        public ActionResult Edit(int id)
        {
            Produtofeira produtofeira = produtofeiraService.Get(id);
            ProdutoFeiraModel produtoFeiraModel = mapper.Map<ProdutoFeiraModel>(produtofeira);
            return View(produtoFeiraModel);
        }

        // POST: ProdutoFeiraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProdutoFeiraModel produtoFeiraModel)
        {
            if (ModelState.IsValid)
            {
                var produtofeira = mapper.Map<Produtofeira>(produtoFeiraModel);
                produtofeiraService.Edit(produtofeira);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoFeiraController/Delete/5
        public ActionResult Delete(int id)
        {
            Produtofeira produtofeira = produtofeiraService.Get(id);
            ProdutoFeiraModel ProdutoFeiraModel = mapper.Map<ProdutoFeiraModel>(produtofeira);
            return View(ProdutoFeiraModel);
        }

        // POST: ProdutoFeiraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            produtofeiraService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
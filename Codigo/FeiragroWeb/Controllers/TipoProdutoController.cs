using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeiragroWeb.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly ITipoProdutoService tipoProdutoService;
        private readonly IMapper mapper;

        public TipoProdutoController(ITipoProdutoService tipoProdutoService, IMapper mapper)
        {
            this.tipoProdutoService = tipoProdutoService;
            this.mapper = mapper;
        }


        // GET: TipoProdutoController
        public ActionResult Index()
        {
            var listaTipoProdutos = tipoProdutoService.GetAll();
            var listaTipoProdutosModel = mapper.Map<List<TipoProdutoModel>>(listaTipoProdutos);
            return View(listaTipoProdutosModel);
        }

        // GET: TipoProdutoController/Details/5
        public ActionResult Details(int id)
        {
            Tipoproduto tipoproduto = tipoProdutoService.Get(id);
            TipoProdutoModel tipoProdutoModel = mapper.Map<TipoProdutoModel>(tipoproduto);
            return View(tipoProdutoModel);

        }

        // GET: TipoProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoProdutoModel tipoProdutoModel)
        {
            if (ModelState.IsValid)
            {
                var tipoProduto = mapper.Map<Tipoproduto>(tipoProdutoModel);
                tipoProdutoService.Create(tipoProduto);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: TipoProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipoproduto tipoproduto = tipoProdutoService.Get(id);
            TipoProdutoModel tipoProdutoModel = mapper.Map<TipoProdutoModel>(tipoproduto);
            return View(tipoProdutoModel);
        }

        // POST: TipoProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoProdutoModel tipoProdutoModel)
        {
            if (ModelState.IsValid)
            {
                var tipoProduto = mapper.Map<Tipoproduto>(tipoProdutoModel);
                tipoProdutoService.Edit(tipoProduto);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: TipoProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipoproduto tipoProduto = tipoProdutoService.Get(id);
            TipoProdutoModel tipoProdutoModel = mapper.Map<TipoProdutoModel>(tipoProduto);
            return View(tipoProdutoModel);
        }

        // POST: TipoProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoProdutoModel tipoProdutoModel)
        {
            tipoProdutoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
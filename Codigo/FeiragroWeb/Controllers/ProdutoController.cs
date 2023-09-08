using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeiragroWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService produtoService;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            this.produtoService = produtoService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaProdutos = produtoService.GetAll();
            var listaProdutosModel = mapper.Map<List<ProdutoModel>>(listaProdutos);
            return View(listaProdutosModel);
        }

        
        public ActionResult Details(int id)
        {
            Produto produto = produtoService.Get(id);
            ProdutoModel produtoModel = mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel produtoModel)
        {
            if(ModelState.IsValid)
            {
                var produto = mapper.Map<Produto>(produtoModel);
                produtoService.Create(produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            Produto produto = produtoService.Get(id);
            ProdutoModel produtoModel = mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProdutoModel produtoModel)
        {
            if(ModelState.IsValid)
            {
                var produto = mapper.Map<Produto>(produtoModel);
                produtoService.Edit(produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            Produto produto = produtoService.Get(id);
            ProdutoModel produtoModel = mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProdutoModel produtoModel)
        {
            produtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

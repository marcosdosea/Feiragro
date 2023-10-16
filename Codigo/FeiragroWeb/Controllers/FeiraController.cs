using AutoMapper;
using Core;
using Core.Service;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;

namespace FeiragroWeb.Controllers
{
    public class FeiraController : Controller
    {
        private readonly IFeiraService _feiraService;
        private readonly IMapper mapper;

        public FeiraController(IFeiraService feiraService, IMapper mapper)
        {
            _feiraService = feiraService;
            this.mapper = mapper;
        }

        // GET: FeiraController
        public ActionResult Index()
        {
            var listaFeiras = _feiraService.GetAll();
            var listaFeirasModel = mapper.Map<List<FeiraModel>>(listaFeiras);
            return View(listaFeirasModel);
        }

        // GET: FeiraController/Details/5
        public ActionResult Details(int id)
        {
            Feira feira = _feiraService.Get(id);
            FeiraModel feiraModel = mapper.Map<FeiraModel>(feira);
            return View(feiraModel);
        }

        // GET: FeiraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeiraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeiraModel feiraModel)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var feira = mapper.Map<Feira>(feiraModel);
                    _feiraService.Create(feira);
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Erro ao adicionar Feira");
                Debug.WriteLine(ModelState.ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FeiraController/Edit/5
        public ActionResult Edit(int id)
        {
            Feira feira = _feiraService.Get(id);
            FeiraModel feiraModel = mapper.Map<FeiraModel>(feira);
            return View(feiraModel);
        }

        // POST: FeiraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeiraModel feiraModel)
        {
            if (ModelState.IsValid)
            {
                var feira = mapper.Map<Feira>(feiraModel);
                _feiraService.Edit(feira);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FeiraController/Delete/5
        public ActionResult Delete(int id)
        {
            Feira feira = _feiraService.Get(id);
            FeiraModel feiraModel = mapper.Map<FeiraModel>(feira);
            return View(feiraModel);
        }

        // POST: FeiraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FeiraModel feiraModel)
        {
            _feiraService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

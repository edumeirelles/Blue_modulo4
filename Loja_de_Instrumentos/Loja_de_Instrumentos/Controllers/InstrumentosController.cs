using Loja_de_Instrumentos.Models;
using Loja_de_Instrumentos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Loja_de_Instrumentos.Controllers
{
    [Authorize]
    public class InstrumentosController : Controller
    {
        IInstrumentosService _service, _sqlService, _staticService;

        public InstrumentosController(IInstrumentosService service, InstrumentosSQLService sqlService, InstrumentosStaticService staticService)
        {
            _service = service;
            _sqlService = sqlService;
            _staticService = staticService;
        }

        private void SelectService(string service = "sql")
        {
            _service = service switch
            {
                "sql" => _sqlService,
                "static" => _staticService,
                _ => _sqlService,
            };
        }
        private void SelectViewBag(string service, string type, bool order)
        {
            SelectService(service);
            if (service == "sql")
            {
                ViewBag.source = "sql";
            }
            ViewBag.type = _service.GetAll().GroupBy(x=> x.Type).Select(x=> x.First()).OrderBy(x => x.Type).ToList();
            ViewBag.order = order;
            ViewBag.total = type != null ? _service.GetAll().FindAll(x => x.Type == type).Count : _service.GetAll().Count;

            ViewBag.sum = type != null ? Math.Round((decimal)_service.GetAll().FindAll(x=> x.Type == type).Sum(x => x.Price), 2) :
                Math.Round((decimal)_service.GetAll().Sum(x => x.Price), 2);
            
            ViewBag.maxprice = type != null ? 
                
                _service.GetAll()
                .FindAll(x => x.Type == type)
                .Find(x => x.Price == _service.GetAll()
                .FindAll(x => x.Type == type)
                .Max(x => x.Price)).Brand
                + " " + 
                _service.GetAll()
                .FindAll(x => x.Type == type)
                .Find(x => x.Price == _service.GetAll()
                .FindAll(x => x.Type == type)
                .Max(x => x.Price)).Model : 

                _service.GetAll()
                .Find(x => x.Price == _service.GetAll()
                .Max(x => x.Price)).Brand 
                + " " + 
                _service.GetAll()
                .Find(x => x.Price == _service.GetAll()
                .Max(x => x.Price)).Model;
            
        }
        public IActionResult Index(string search, string type, bool order = false, string service = "sql")
        {
            SelectViewBag(service, type, order);
            return View(_service.GetAll(search, type, order)); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instrumento instrumento)
        {
            if (!ModelState.IsValid) return View(instrumento);

            if (_service.Create(instrumento))
            {
                return RedirectToAction(nameof(Index));
            }
                
            else
                return View(instrumento);
        }
        public IActionResult Read(int id)
        {
            Instrumento instrumento = _service.Get(id);
            return instrumento != null ? View(instrumento) : NotFound();
        }
        public IActionResult Update(int id)
        {

            Instrumento instrumento = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return View(instrumento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Instrumento instrumentoUpdate)
        {
            if (!ModelState.IsValid) return View(instrumentoUpdate);
            if (_service.Update(instrumentoUpdate))
            {
  
                return RedirectToAction(nameof(Index));
            }     
            else
                return NotFound();
        }
        public IActionResult Delete(int? id)
        {           
            if (_service.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }   
            else
                return NotFound();
        }
        public IActionResult Confirm(int? id)
        {
            Instrumento instrumento = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }
    }
}

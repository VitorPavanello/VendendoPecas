using Microsoft.AspNetCore.Mvc;
using VendendoPecas.Data;
using VendendoPecas.Models;

namespace VendendoPecas.Controllers
{
    public class VendaController : Controller
    {
        readonly private ApplicationDbContext _db;

        public VendaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<VendasModel> vendas = _db.Vendas;
            return View(vendas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            VendasModel vendas = _db.Vendas.FirstOrDefault(x => x.Id == id);

            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            VendasModel vendas = _db.Vendas.FirstOrDefault(x => x.Id == id);

            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        [HttpPost]
        public IActionResult Cadastrar(VendasModel vendas)
        {
            if (ModelState.IsValid)
            {
                _db.Vendas.Add(vendas);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(VendasModel venda)
        {
            if (ModelState.IsValid)
            {
                _db.Vendas.Update(venda);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(venda);
        }

        [HttpPost]
        public IActionResult Excluir(VendasModel venda)
        {
            if (venda == null)
            {
                return NotFound();
            }

            _db.Vendas.Remove(venda);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

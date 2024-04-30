using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        [HttpGet]
        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Vendas");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Vendas.xls");
                }
            }
        }

        private DataTable GetDados()
        {
            DataTable dt = new DataTable();

            dt.TableName = "Dados Vendas";

            dt.Columns.Add("Comprador", typeof(string));
            dt.Columns.Add("Vendedor", typeof(string));
            dt.Columns.Add("Peça Vendida", typeof(string));
            dt.Columns.Add("Data Atualização", typeof(DateTime));

            var dados = _db.Vendas.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(venda =>
                {
                    dt.Rows.Add(venda.Comprador, venda.Vendedor, venda.PecaVendida, venda.DataVenda);
                });
            }

            return dt;
        }

        [HttpPost]
        public IActionResult Cadastrar(VendasModel vendas)
        {
            if (ModelState.IsValid)
            {
                vendas.DataVenda = DateTime.Now;

                _db.Vendas.Add(vendas);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(VendasModel venda)
        {
            if (ModelState.IsValid)
            {
                var vendaDB = _db.Vendas.Find(venda.Id);

                vendaDB.Comprador = venda.Comprador;
                vendaDB.Vendedor = venda.Vendedor;
                vendaDB.PecaVendida = venda.PecaVendida;

                _db.Vendas.Update(vendaDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";

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

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}

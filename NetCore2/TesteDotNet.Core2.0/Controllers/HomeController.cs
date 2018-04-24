using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TesteDotNet.Core2._0.Models;
using TesteDotNet.Data;
using TesteDotNet.Data.Context;
using TesteDotNet.Data.Models;

namespace TesteDotNet.Core2._0.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(ListarItens());
            
        }

        public IActionResult Cadastro()
        {
            return View(ListarCategorias());
        }

        public ActionResult SalvarItem()
        {
            ViewBag.CategoryID = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarItem(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Item.CreateDate = DateTime.Now;
                _context.Items.Add(model.Item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(_context.Categories, "Id", "CategoryName", model.Item.CategoryID);
            return View(model);

        }

        public ActionResult Editar(int? id) 
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return new NotFoundResult();
            }

            ViewBag.CategoryID = new SelectList(_context.Categories, "Id", "CategoryName", item.CategoryID);

            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = ListarCategorias().Categories;
            cadastroViewModel.Item = item;
            return View(cadastroViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarItem(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(_context.Categories, "Id", "CategoryName", item.CategoryID);

            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = ListarCategorias().Categories;
            cadastroViewModel.Item = item;

            return View(cadastroViewModel);
        }

        public ActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return new NotFoundResult();
            }

            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = ListarCategorias().Categories;
            cadastroViewModel.Item = item;

            return View(cadastroViewModel);
        }

        public ActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ApagarConfirma(int id)
        {
            Item item = _context.Items.Find(id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public List<Item> Buscar(string param)
        //{

        //    List<Item> announcements = _context.Items.ToList();

        //    announcements.Where(m => m.GetType().GetProperties().Any(x => x.GetValue(m, null) != null && x.GetValue(m, null).ToString().Contains(param)));

        //    return announcements;

        //}

        private CadastroViewModel ListarCategorias()
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = _context.Categories.ToList();
            return cadastroViewModel;
        }

        private CadastroViewModel ListarItens()
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = _context.Categories.ToList();
            cadastroViewModel.Itens = _context.Items.ToList();
            return cadastroViewModel;
        }


    }
}

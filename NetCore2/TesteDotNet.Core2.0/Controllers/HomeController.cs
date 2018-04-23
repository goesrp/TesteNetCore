using Microsoft.AspNetCore.Mvc;
using TesteDotNet.Data.Models;
using TesteDotNet.Data.Context;
using System.Collections.Generic;
using TesteDotNet.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteDotNet.Core2._0.Models;

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

        public IActionResult Detalhe()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarItem(CadastroViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //}

            return View(new SqlDataAccess(_context).NovoItem(model.Item));
        }

        public CadastroViewModel ListarCategorias()
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Categories = new SqlDataAccess(_context).ListarCategoria();

            return cadastroViewModel;
        }

        public CadastroViewModel ListarItens()
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.Itens = new SqlDataAccess(_context).ListarItens();

            return cadastroViewModel;
        }
    }
}

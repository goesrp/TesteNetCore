using System;
using System.Collections.Generic;
using System.Linq;
using TesteDotNet.Data.Models;

namespace TesteDotNet.Data
{
    public class SqlDataAccess
    {
        private readonly Data.Context.DataContext _context;

        public SqlDataAccess(Data.Context.DataContext context)
        {
            _context = context;
        }

        public bool NovoItem(Item item) {

            bool ret = false;
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                ret = true;
            }
            catch {
                ret = false; 
            }

            return ret;
            
        }
        public bool AlterarItem(Item item) {

            bool ret = false;
            try
            {
                _context.Update(item);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        public bool DeletarItem(int id) {
            bool ret = false;
            try
            {
                var _item = _context.Items.Find(id);
                _context.Items.Remove(_item);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        public Item VisualisarItem(int id) {
            var _item = _context.Items.Find(id);
            return _item;
        }

        public List<Item> Buscar(string param) {

            List<Item> announcements = _context.Items.ToList();

            announcements.Where(m => m.GetType().GetProperties().Any(x => x.GetValue(m, null) != null && x.GetValue(m, null).ToString().Contains(param)));

            return announcements;

        }

        public List<Item> ListarItens()
        {
            return _context.Items.ToList();
        }

        public List<Category> ListarCategoria() {
           return _context.Categories.ToList();
        }

    }
}

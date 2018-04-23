using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.Data.Models;

namespace TesteDotNet.Core2._0.Models
{
    public class CadastroViewModel
    {
        public List<Category> Categories { get; set; }

        public Item Item { get; set; }

        [DisplayName("Categoria")]
        public Category Category { get; set; }
    }
}

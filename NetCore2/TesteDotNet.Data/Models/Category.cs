using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteDotNet.Data.Models
{
 

    [Table("Category")]
    public partial class Category
    {

        public int Id { get; set; }

        [StringLength(20)]
        public string CategoryName { get; set; }


    }
}



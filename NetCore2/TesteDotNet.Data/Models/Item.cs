using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteDotNet.Data.Models
{


    [Table("Item")]
    public partial class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        public DateTime? CreateDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? DescCategoria { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataInclusao { get; set; }

        public ICollection<Produto>? Produto { get; set; }
    }
}

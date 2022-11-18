using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string? DescProduto { get; set; }

        [Column(TypeName = "integer")]
        public int Qtd { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataInclusao { get; set; }

        [Column(TypeName = "money")]
        public decimal Vlr { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.ModelView
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }
        public string? DescProduto { get; set; }
        public int Qtd { get; set; }
        public DateTime DataInclusao { get; set; }
        public decimal Vlr { get; set; }
        public int IdCategoria { get; set; }
    }
}

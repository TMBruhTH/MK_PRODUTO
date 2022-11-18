
using DataModel.Models;
using DataModel.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Repository.IRepository
{
    public interface IProdutoRepository
    {
        Task<ActionResult<IEnumerable<Produto>>> BuscaProdutos();
        Task<ActionResult<IEnumerable<Produto>>> FiltroProduto(string desc);
        Task<ActionResult<Produto>> SalvarProduto(Produto model);
        Task<ActionResult<bool>> DeletarProduto(int id);
    }
}

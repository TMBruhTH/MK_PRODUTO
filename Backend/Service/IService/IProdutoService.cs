using DataModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.IService
{
    public interface IProdutoService
    {
        Task<ActionResult<IEnumerable<Produto>>> BuscaProdutos();
        Task<ActionResult<IEnumerable<Produto>>> FiltroProduto(string desc);
        Task<ActionResult<Produto>> SalvarProduto(Produto model);
        Task<ActionResult<bool>> DeletarProduto(int id);

        Task<ActionResult<IEnumerable<Categoria>>> BuscaCategorias();
    }
}

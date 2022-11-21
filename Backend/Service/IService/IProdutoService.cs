using DataModel.Models;
using DataModel.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Service.IService
{
    public interface IProdutoService
    {
        Task<ActionResult<IEnumerable<ProdutoViewModel>>> FiltroProduto(string? desc);
        Task<ActionResult<Produto>> SalvarProduto(Produto model);
        Task<ActionResult<bool>> DeletarProduto(int id);

        Task<ActionResult<IEnumerable<Categoria>>> BuscaCategorias();
    }
}

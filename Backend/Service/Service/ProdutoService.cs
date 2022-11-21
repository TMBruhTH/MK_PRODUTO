using DataModel.Models;
using DataModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;

namespace Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        #region "Categorias"

        public Task<ActionResult<IEnumerable<Categoria>>> BuscaCategorias()
        {
            return _produtoRepository.BuscaCategorias();
        }
        #endregion

        #region "Produtos"
        public Task<ActionResult<bool>> DeletarProduto(int id)
        {
            return _produtoRepository.DeletarProduto(id);
        }

        public Task<ActionResult<IEnumerable<ProdutoViewModel>>> FiltroProduto(string? desc)
        {
            return _produtoRepository.FiltroProduto(desc);
        }

        public Task<ActionResult<Produto>> SalvarProduto(Produto model)
        {
            return _produtoRepository.SalvarProduto(model);
        }

        #endregion
    }
}

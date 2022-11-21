using DataModel.Context;
using DataModel.Models;
using DataModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.IRepository;

namespace Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _produtoContext;
        private readonly ILogger _logger;
        public ProdutoRepository(ProdutoContext produtoContext, ILogger<ProdutoRepository> logger)
        {
            _produtoContext = produtoContext;
            _logger = logger;
        }

        #region "Categorias"

        public async Task<ActionResult<IEnumerable<Categoria>>> BuscaCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                categorias = await _produtoContext.Categoria.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString()); ;
            }
            return categorias;
        }

        #endregion

        #region "Produtos"
        public async Task<ActionResult<bool>> DeletarProduto(int id)
        {
            Produto? produto = null;
            try
            {
                produto = await _produtoContext.Produto.FindAsync(id);

                if (produto == null)
                {
                    return false;
                }

                _produtoContext.Produto.Remove(produto);
                await _produtoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return true;
        }

        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> FiltroProduto(string? desc)
        {
            desc = desc == "undefined" ? null : desc;

            List<ProdutoViewModel>? produto = new List<ProdutoViewModel>();
            try
            {
                produto = await (from tb in _produtoContext.Produto
                              join tbC in _produtoContext.Categoria
                              on tb.IdCategoria equals tbC.IdCategoria
                              where string.IsNullOrEmpty(desc) || tb.DescProduto.Contains(desc)
                              select new ProdutoViewModel()
                              {
                                  IdProduto = tb.IdProduto,
                                  IdCategoria = tbC.IdCategoria,
                                  DescCategoria = tbC.DescCategoria,
                                  DescProduto = tb.DescProduto,
                                  Qtd = tb.Qtd,
                                  Vlr = tb.Vlr
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return produto;
        }

        public async Task<ActionResult<Produto>> SalvarProduto(Produto model)
        {
            Produto? produto = null;

            try
            {
                if (model.IdProduto != 0)
                {
                    produto = await _produtoContext.Produto.FindAsync(model.IdProduto);
                }

                if (produto != null)
                {
                    produto.DescProduto = model.DescProduto;
                    produto.Qtd = model.Qtd;
                    produto.Vlr = model.Vlr;
                    produto.IdCategoria = model.IdCategoria;
                    produto.DataInclusao = DateTime.Now;

                    _produtoContext.Entry(produto).State = EntityState.Modified;
                }
                else
                {
                    model.DataInclusao = DateTime.Now;
                    await _produtoContext.Produto.AddAsync(model);
                }
                await _produtoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return model;
        }
        #endregion
    }
}

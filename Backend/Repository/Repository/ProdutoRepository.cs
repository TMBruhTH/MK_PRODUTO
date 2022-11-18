using DataModel.Context;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        public async Task<ActionResult<IEnumerable<Produto>>> BuscaProdutos()
        {
            List<Produto> produto = new List<Produto>();
            try
            {
                produto = await _produtoContext.Produto.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString()); ;
            }
            return produto;
        }

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

        public async Task<ActionResult<IEnumerable<Produto>>> FiltroProduto(string desc)
        {
            List<Produto>? produto = new List<Produto>();
            try
            {
                produto = (from tb in _produtoContext.Produto
                          where string.IsNullOrEmpty(desc) || tb.DescProduto.Contains(desc)
                          select tb).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return await Task.FromResult(produto);
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
    }
}

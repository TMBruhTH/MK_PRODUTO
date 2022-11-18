using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        Task<ActionResult<IEnumerable<Produto>>> IProdutoService.BuscaProdutos()
        {
            return _produtoRepository.BuscaProdutos();
        }

        Task<ActionResult<bool>> IProdutoService.DeletarProduto(int id)
        {
            return _produtoRepository.DeletarProduto(id);
        }

        Task<ActionResult<IEnumerable<Produto>>> IProdutoService.FiltroProduto(string desc)
        {
            return _produtoRepository.FiltroProduto(desc);
        }

        Task<ActionResult<Produto>> IProdutoService.SalvarProduto(Produto model)
        {
            return _produtoRepository.SalvarProduto(model);
        }
    }
}

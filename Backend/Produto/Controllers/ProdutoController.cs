using AutoMapper;
using DataModel.Models;
using DataModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace ProdutoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        #region "Produtos"
        
        [HttpGet]
        [Route("BuscaProdutos")]
        public Task<ActionResult<IEnumerable<Produto>>> BuscaProdutos()
        {
            return _produtoService.BuscaProdutos();
        }

        [HttpGet]
        [Route("FiltroProduto/{desc}")]
        public Task<ActionResult<IEnumerable<Produto>>> FiltroProduto(string desc)
        {
            return _produtoService.FiltroProduto(desc);
        }

        [HttpPost]
        [Route("SalvarProduto")]
        public Task<ActionResult<Produto>> SalvarProduto([FromBody] ProdutoViewModel model)
        {
            var mappedResult = _mapper.Map<Produto>(model);

            return _produtoService.SalvarProduto(mappedResult);
        }

        [HttpDelete]
        [Route("DeletarProduto/{id}")]
        public Task<ActionResult<bool>> DeletarProduto(int id)
        {
            return _produtoService.DeletarProduto(id);
        }

        #endregion

        #region "Categorias"
        [HttpGet]
        [Route("BuscaCategorias")]
        public Task<ActionResult<IEnumerable<Categoria>>> BuscaCategorias()
        {
            return _produtoService.BuscaCategorias();
        }
        #endregion
    }
}

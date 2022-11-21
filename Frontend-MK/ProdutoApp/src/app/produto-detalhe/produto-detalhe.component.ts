import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProdutoDetalhe } from '../shared/produto-detalhe.model';
import { ProdutoDetalheService } from '../shared/produto-detalhe.service';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styles: [],
})
export class ProdutoDetalheComponent implements OnInit {

  listaProdutos: Array<ProdutoDetalhe>;
  descProduto: string;

  @Input() busca: EventEmitter<any> = new EventEmitter();

  constructor(
    protected produtoService: ProdutoDetalheService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.buscaProdutos();
  }

  public buscaProdutos() {
    this.busca.emit();
    this.produtoService.FiltroProduto(this.descProduto).subscribe((res) => {
      this.listaProdutos = res as Array<ProdutoDetalhe>;
    });
  }

  popularForm(produtoSelecionado: ProdutoDetalhe) {
    this.produtoService.formData = Object.assign({}, produtoSelecionado);
  }

  deletarProduto(produtoId: number) {
    this.produtoService.deletarProduto(produtoId).subscribe((res) => {
      if (res) {
        this.buscaProdutos();
        this.toastr.error("Produto excluido com sucesso!", "Exclusão de Produto!");
      }
    });
  }
}

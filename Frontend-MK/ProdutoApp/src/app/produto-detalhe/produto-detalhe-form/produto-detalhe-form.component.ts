import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Categoria } from 'src/app/shared/categoria.model';
import { ProdutoDetalhe } from 'src/app/shared/produto-detalhe.model';
import { ProdutoDetalheService } from 'src/app/shared/produto-detalhe.service';
import { ProdutoDetalheComponent } from '../produto-detalhe.component';

@Component({
  selector: 'app-produto-detalhe-form',
  templateUrl: './produto-detalhe-form.component.html',
  styles: [],
})
export class ProdutoDetalheFormComponent implements OnInit {
  listaCategorias: Array<Categoria>;

  constructor(
    protected produtoService: ProdutoDetalheService,
    private toastr: ToastrService,
    private produtoComponent: ProdutoDetalheComponent
  ) {}

  ngOnInit(): void {
    this.buscaCategorias();
  }

  onSubmit(form: NgForm) {
    this.produtoService.salvarProduto().subscribe(
      (res: any) => {
        if (res) {
          this.limparForm(form);

          this.produtoComponent.buscaProdutos();

          this.toastr.success(
            'Produto salvo com sucesso!',
            'Registro de Produto'
          );
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  limparForm(form: NgForm) {
    form.form.reset();
    this.produtoService.formData = new ProdutoDetalhe();
  }

  buscaCategorias() {
    this.produtoService.buscaCategorias().subscribe((res) => {
      this.listaCategorias = res as Array<Categoria>;
    });
  }

}

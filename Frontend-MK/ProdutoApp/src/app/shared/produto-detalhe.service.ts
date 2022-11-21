import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Categoria } from './categoria.model';
import { ProdutoDetalhe } from './produto-detalhe.model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoDetalheService {

  constructor(private http: HttpClient) { }

  formData: ProdutoDetalhe = new ProdutoDetalhe();

  formCategoria: Categoria = new Categoria();

  salvarProduto() {
    return this.http.post(environment.baseURL + '/SalvarProduto', this.formData);
  }

  FiltroProduto(desc: string) {
    let parm = desc==='' ? undefined : desc;
    return this.http.get(environment.baseURL + '/FiltroProduto/' + parm);
  }

  buscaCategorias() {
    return this.http.get(environment.baseURL + '/BuscaCategorias');
  }

  deletarProduto(produtoId: number) {
    return this.http.delete(environment.baseURL + '/DeletarProduto/' + produtoId)
  }
}

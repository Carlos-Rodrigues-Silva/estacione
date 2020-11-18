import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, pipe } from 'rxjs';
import {map, filter} from 'rxjs/operators';
import { ICestaCliente, IItemCesta, Cesta, ICestaTotal } from '../shared/models/CestaCliente';
import { IRespostaEnderecoDto } from '../shared/models/respostaEndereco';

@Injectable({
  providedIn: 'root'
})
export class CestaComprasService {
  baseUrl = environment.apiUrl;

  private cestaSource = new BehaviorSubject<ICestaCliente>(null);
  cesta$ = this.cestaSource.asObservable();


  private totalCestaSource = new BehaviorSubject<ICestaTotal>(null);
  total$ = this.totalCestaSource.asObservable();

  shipping = 0;

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get(this.baseUrl + 'cestadecompras?id=' + id)
    .pipe(
      map((cesta: ICestaCliente) => {
        this.cestaSource.next(cesta);
        // console.log(cesta);
        this.calcularTotal();
      })
    );
  }

  setBasket(cesta: ICestaCliente) {
    return this.http.post(this.baseUrl + 'cestadecompras', cesta).subscribe((response: ICestaCliente) => {
      this.cestaSource.next(response);
      this.calcularTotal();
    }, error => {
      this.cestaSource.next(cesta);
      console.log(error);
    });
  }

  addItemToBasket(item: IRespostaEnderecoDto, quantidade = 1) {
    const itemToAdd: IItemCesta = this.mapEstacionamentoItem(item, quantidade);
    const basket: ICestaCliente = this.getCurrentBasketValue() != null ? this.getCurrentBasketValue() : this.createBasket();
    basket.itensCestaCliente = this.addOrUpdateItem(basket.itensCestaCliente, itemToAdd, quantidade);
    this.setBasket(basket);
  }

  private mapEstacionamentoItem(item: IRespostaEnderecoDto, quantidade: number): IItemCesta {
    return {
      id: item.id,
      nomeEstacionamento: item.nomeEstacionamento,
      preco: item.precoHora,
      quantidade
    };
  }

  getCurrentBasketValue() {
    return this.cestaSource.value;
  }

  private createBasket(): ICestaCliente {
    const basket = new Cesta();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private addOrUpdateItem(itens: IItemCesta[], itemToAdd: IItemCesta, quantidade: number): IItemCesta[] {
    const index: number = itens.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantidade = quantidade;
      itens.push(itemToAdd);
    } else {
      itens[index].quantidade = quantidade + quantidade;
    }
    return itens;
  }

  incrementarQuantidadeItem(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    const acharItemIndex = cesta.itensCestaCliente.findIndex(x => x.id === item.id);
    cesta.itensCestaCliente[acharItemIndex].quantidade++;
    this.setBasket(cesta);
  }

  decrementarQuantidadeItem(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    const acharItemIndex = cesta.itensCestaCliente.findIndex(x => x.id === item.id);
    if (cesta.itensCestaCliente[acharItemIndex].quantidade > 1) {
      cesta.itensCestaCliente[acharItemIndex].quantidade--;
      this.setBasket(cesta);
    } else {
      this.removerItemCesta(item);
    }
  }

  removerItemCesta(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    if (cesta.itensCestaCliente.some(x => x.id === item.id) === true) {
      cesta.itensCestaCliente = cesta.itensCestaCliente.filter(i => i.id !== item.id);
      if (cesta.itensCestaCliente.length > 0) {
        this.setBasket(cesta);
      } else {
        this.deletarCesta(cesta);
      }
    }
  }

  deletarCesta(cesta: ICestaCliente) {
    return this.http.delete(this.baseUrl + 'cestadecompras?id=' + cesta.id).subscribe(() => {
      this.cestaSource.next(null);
      this.totalCestaSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
  }

  removerCestaLocal(id: string) {
    this.cestaSource.next(null);
    this.totalCestaSource.next(null);
    localStorage.removeItem('basket_id');
  }

  private calcularTotal() {
    const cesta = this.getCurrentBasketValue();
    const frete = this.shipping;
    const subtotal = cesta.itensCestaCliente.reduce((a, b) => (b.preco * b.quantidade) + a, 0);
    const total = subtotal + frete;
    this.totalCestaSource.next({total});
  }

  criarIntencaoPagamento() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    };
    return this.http.post(this.baseUrl + 'servicopagamento/' + this.getCurrentBasketValue().id, {}, httpOptions)
    .pipe(
      map((cesta: ICestaCliente) => {
        this.cestaSource.next(cesta);
        console.log(this.getCurrentBasketValue());
      })
    );
  }
}

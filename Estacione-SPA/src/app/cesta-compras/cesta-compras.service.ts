import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, pipe } from 'rxjs';
import {map, filter} from 'rxjs/operators';
import { ICestaCliente, IItemCesta, Cesta, ICestaTotal } from '../shared/models/CestaCliente';
import { IRespostaEnderecoDto } from '../shared/models/respostaEndereco';

@Injectable({
  providedIn: 'root'
})
export class CestaComprasService {
  // URL base da webapi
  baseUrl = environment.apiUrl;
  // BehaviorSubject - tipo de subject que necessita de um valor inicial (neste caso null), e emite esse valor inicial.
  // Esse Subject emite o valor null do tipo ICestaCliente
  private cestaSource = new BehaviorSubject<ICestaCliente>(null);

  // Transformar o BehaviorSubject em um Observable.
  cesta$ = this.cestaSource.asObservable();

  // BehaviorSubject - tipo de subject que necessita de um valor inicial (neste caso null), e emite esse valor inicial.
  // Esse Subject emite o valor null do tipo ICestaTotal
  private totalCestaSource = new BehaviorSubject<ICestaTotal>(null);

  // Transformar o BehaviorSubject em um Observable.
  total$ = this.totalCestaSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient) { }

  // Metódos públicos

  // Obter cesta de compras do usuário
  getBasket(id: string) {
    return this.http.get(this.baseUrl + 'cestadecompras?id=' + id)
    .pipe(
      map((cesta: ICestaCliente) => {
        this.cestaSource.next(cesta);
        // console.log(this.getCurrentBasketValue());
        // Depois de pegar o total da cesta na API, definir o total da compra
        this.calcularTotal();
      })
    );
  }


  // Criar ou atualizar cesta de compras do usuário
  setBasket(cesta: ICestaCliente) {
    return this.http.post(this.baseUrl + 'cestadecompras', cesta).subscribe((response: ICestaCliente) => {
      this.cestaSource.next(response);
      // console.log(response);
      this.calcularTotal();
    }, error => {
      this.cestaSource.next(cesta);
      console.log(error);
    });
  }

  // Adicionar item a cesta de compras
  addItemToBasket(item: IRespostaEnderecoDto, quantidade = 1) {
    const itemToAdd: IItemCesta = this.mapEstacionamentoItem(item, quantidade);
    // console.log(item.id);
    // const basket = this.getCurrentBasketValue() ?? this.createBasket();
    const basket: ICestaCliente = this.getCurrentBasketValue() != null ? this.getCurrentBasketValue() : this.createBasket();

    // Verificar se já existe um item desse tipo na nossa cesta de compras
    // Caso não exista adicionará na cesta, caso exista ele atualiza a cesta de compras com mais um item do mesmo tipo
    basket.itens = this.addOrUpdateItem(basket.itens, itemToAdd, quantidade);
    this.setBasket(basket);
  }

  // Metódos privados
  // Mapear propriedades de endereco recebidas pela API com as dos itens da cesta de compras do cliente
  private mapEstacionamentoItem(item: IRespostaEnderecoDto, quantidade: number): IItemCesta {
    return {
      id: item.id,
      nomeEstacionamento: item.nomeEstacionamento,
      preco: item.precoHora,
      quantidade
    };
  }

  // Obter o valor atual da cesta de compras do usuário
  getCurrentBasketValue() {
    return this.cestaSource.value;
  }

  // Criar cesta de compras do cliente mantendo ela no localStorage, com id único para a cesta e com array iniciado
  private createBasket(): ICestaCliente {
    const basket = new Cesta();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  // Adicionar ou atualizar itens da cesta de compras do cliente
  private addOrUpdateItem(itens: IItemCesta[], itemToAdd: IItemCesta, quantidade: number): IItemCesta[] {
    // Verificar se alguma item para adicionar já está na cesta de compras do usuário
    const index: number = itens.findIndex(i => i.id === itemToAdd.id);

    // Se o valor retornado pelo findIndex() for igual a -1
    // Acrescentar o novo item no array com a quantidade passada
    if (index === -1) {
      itemToAdd.quantidade = quantidade;
      itens.push(itemToAdd);
    // Caso contrário adicionar mais um item do mesmo tipo no array
    } else {
      // itens[index].quantidade += quantidade;
      itens[index].quantidade = quantidade + quantidade;
    }
    return itens;
  }


  // Incrementar a quantidade de itens do mesmo tipo
  incrementarQuantidadeItem(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    const acharItemIndex = cesta.itens.findIndex(x => x.id === item.id);
    cesta.itens[acharItemIndex].quantidade++;
    this.setBasket(cesta);
  }

  // Decrementar a quantidade de itens do mesmo tipo
  decrementarQuantidadeItem(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    const acharItemIndex = cesta.itens.findIndex(x => x.id === item.id);
    if (cesta.itens[acharItemIndex].quantidade > 1) {
      cesta.itens[acharItemIndex].quantidade--;
      this.setBasket(cesta);
    } else {
      this.removerItemCesta(item);
    }
  }

  // verificar se existe outros itens na cesta de compras
  // se não existir deletar a cesta toda
  removerItemCesta(item: IItemCesta) {
    const cesta = this.getCurrentBasketValue();
    if (cesta.itens.some(x => x.id === item.id) === true) {
      cesta.itens = cesta.itens.filter(i => i.id !== item.id);
      if (cesta.itens.length > 0) {
        this.setBasket(cesta);
      } else {
        this.deletarCesta(cesta);
      }
    }
  }

  // Deletar cesta de compras do cliente
  deletarCesta(cesta: ICestaCliente) {
    return this.http.delete(this.baseUrl + 'cestadecompras?id=' + cesta.id).subscribe(() => {
      this.cestaSource.next(null);
      this.totalCestaSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
  }

  // Remover cesta de compras do localStorage
  removerCestaLocal(id: string) {
    this.cestaSource.next(null);
    this.totalCestaSource.next(null);
    localStorage.removeItem('basket_id');
  }

  // Calcular valor total da cesta de compras do cliente
  private calcularTotal() {
    const cesta = this.getCurrentBasketValue();
    const frete = this.shipping;
    // OBS: b representa cada item (cada item tem seu preço e quantidade)
    // a representa o resultado que dessa função reduce (começa em 0)
    // Pegamos o preço do item vezes a quantidade de itens no carrinho e adicionamos na cesta de compras
    const subtotal = cesta.itens.reduce((a, b) => (b.preco * b.quantidade) + a, 0);
    const total = subtotal + frete;
    this.totalCestaSource.next({frete, total, subtotal});
  }

  criarIntencaoPagamento() {
    return this.http.post(this.baseUrl + 'servicopagamento/' + this.getCurrentBasketValue().id, {})
    .pipe(
      map((cesta: ICestaCliente) => {
        this.cestaSource.next(cesta);
        console.log(this.getCurrentBasketValue());
      })
    );
  }
}

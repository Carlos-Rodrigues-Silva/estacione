import { Component, OnInit } from '@angular/core';
import { CestaComprasService } from './cesta-compras.service';
import { ICestaCliente, IItemCesta, ICestaTotal } from '../shared/models/CestaCliente';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cesta-compras',
  templateUrl: './cesta-compras.component.html',
  styleUrls: ['./cesta-compras.component.scss']
})
export class CestaComprasComponent implements OnInit {
  cesta$: Observable <ICestaCliente>;
  totalCesta$: Observable<ICestaTotal>;


  constructor(private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
    this.cesta$ = this.cestaComprasService.cesta$;
    this.totalCesta$ = this.cestaComprasService.total$;
  }

  removerItemCesta(item: IItemCesta) {
    this.cestaComprasService.removerItemCesta(item);
  }

  incrementarQuantidadeItens(item: IItemCesta) {
    this.cestaComprasService.incrementarQuantidadeItem(item);
  }

  decrementarQuantidadeItens(item: IItemCesta) {
    this.cestaComprasService.decrementarQuantidadeItem(item);
  }

}

import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { Observable } from 'rxjs';
import { ICestaCliente, IItemCesta } from '../../models/CestaCliente';
import { IVagasOrdenadas } from '../../models/ordem';

@Component({
  selector: 'app-cesta-sumario',
  templateUrl: './cesta-sumario.component.html',
  styleUrls: ['./cesta-sumario.component.scss']
})
export class CestaSumarioComponent implements OnInit {
  cesta$: Observable<ICestaCliente>;
  @Output() decrementar: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Output() incrementar: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Output() remover: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Input() eUmaCesta = true;
  @Input() itens: ICestaCliente[] | IVagasOrdenadas[] = [];
  // @Input() cestaVazia = !this.cesta$;

  constructor(private cestaService: CestaComprasService) { }

  ngOnInit() {
    this.cesta$ = this.cestaService.cesta$;
  }

  decrementarQuantidadeItens(item: IItemCesta) {
    this.decrementar.emit(item);
  }

  incrementarQuantidadeItens(item: IItemCesta) {
    this.incrementar.emit(item);
  }

  removerItemCesta(item: IItemCesta) {
    this.remover.emit(item);
  }
}

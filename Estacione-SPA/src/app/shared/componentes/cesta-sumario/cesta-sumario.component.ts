import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { Observable } from 'rxjs';
import { ICestaCliente, IItemCesta } from '../../models/CestaCliente';
import { IVagasOrdenadas } from '../../models/ordem';
import { IOrdemParaRetornarDto } from '../../models/ordemParaRetornarDto';

@Component({
  selector: 'app-cesta-sumario',
  templateUrl: './cesta-sumario.component.html',
  styleUrls: ['./cesta-sumario.component.scss']
})
export class CestaSumarioComponent implements OnInit {
  @Output() decrementar: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Output() incrementar: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Output() remover: EventEmitter<IItemCesta> = new EventEmitter<IItemCesta>();
  @Input() eUmaCesta = true;
  @Input() eUmaOrdem = false;
  @Input() itens: ICestaCliente[] | IVagasOrdenadas[] = [];

  constructor(private cestaService: CestaComprasService) { }

  ngOnInit() {
    console.log(this.itens);
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

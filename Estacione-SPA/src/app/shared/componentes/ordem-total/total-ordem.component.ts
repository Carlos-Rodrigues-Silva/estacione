import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { ICestaTotal } from '../../models/CestaCliente';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { IOrdem } from '../../models/ordem';

@Component({
  selector: 'app-total-ordem',
  templateUrl: './total-ordem.component.html',
  styleUrls: ['./total-ordem.component.scss']
})
export class TotalOrdemComponent implements OnInit {
  totalCesta$: Observable<ICestaTotal>;
  @Input() total: number;
  @Input() eUmaOrdem = false;

  constructor(private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
    this.totalCesta$ = this.cestaComprasService.total$;
    console.log(this.total);
  }
}

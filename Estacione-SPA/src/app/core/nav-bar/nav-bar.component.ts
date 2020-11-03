import { Component, OnInit } from '@angular/core';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { Observable } from 'rxjs';
import { ICestaCliente } from 'src/app/shared/models/CestaCliente';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  cesta$: Observable<ICestaCliente>;

  constructor(private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
    this.cesta$ = this.cestaComprasService.cesta$;
  }

}

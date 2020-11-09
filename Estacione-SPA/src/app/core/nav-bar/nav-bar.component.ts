import { Component, OnInit } from '@angular/core';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { Observable } from 'rxjs';
import { ICestaCliente } from 'src/app/shared/models/CestaCliente';
import { IUsuario } from 'src/app/shared/models/usuario';
import { ContaService } from 'src/app/conta/conta.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  cesta$: Observable<ICestaCliente>;
  usuarioAtual$: Observable<IUsuario>;

  constructor(private cestaComprasService: CestaComprasService, private contaService: ContaService) { }

  ngOnInit() {
    this.cesta$ = this.cestaComprasService.cesta$;
    this.usuarioAtual$ = this.contaService.usuarioAtual$;
  }

  logout() {
    this.contaService.logout();
  }
}

import { Component, OnInit } from '@angular/core';
import { CestaComprasService } from './cesta-compras/cesta-compras.service';
import { ContaService } from './conta/conta.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Estacione-SPA';

  constructor(private cestaComprasService: CestaComprasService, private contaService: ContaService) {}

  ngOnInit(): void {
    this.carregarCestaDeCompras();
    this.carregarUsuarioAtual();
  }

  carregarCestaDeCompras() {
    const cestaId = localStorage.getItem('basket_id');
    if (cestaId !== null) {
      this.cestaComprasService.getBasket(cestaId).subscribe(() => {
        console.log("cesta de compras inicializada");
      }, error => {
        console.log(error);
      });
    }
  }

  carregarUsuarioAtual() {
    const token = localStorage.getItem('token');
    this.contaService.carregarUsuarioAtual(token).subscribe(() => {
      console.log('Usuário carregado');
    }, error => {
      console.log(error);
    });
  }
}

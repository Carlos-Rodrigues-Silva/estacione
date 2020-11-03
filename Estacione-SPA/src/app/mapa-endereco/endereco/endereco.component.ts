import { Component, OnInit, Input } from '@angular/core';
import { IRespostaEnderecoDto } from 'src/app/shared/models/respostaEndereco';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';

@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss']
})
export class EnderecoComponent implements OnInit {

  // Input que recebe valores pesquisados pelo cliente, e que é adicionado a cesta de compras.
  @Input() estacionamento: IRespostaEnderecoDto;

  constructor(private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
  }

  // Adicionar item a cesta de compras do cliente
  AddItemCestaCompras() {
    this.cestaComprasService.addItemToBasket(this.estacionamento);
    // console.log(this.estacionamento);
  }
}

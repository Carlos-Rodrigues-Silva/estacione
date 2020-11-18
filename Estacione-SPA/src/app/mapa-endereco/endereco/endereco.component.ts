import { Component, OnInit, Input } from '@angular/core';
import { IRespostaEnderecoDto } from 'src/app/shared/models/respostaEndereco';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';

@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss']
})
export class EnderecoComponent implements OnInit {

  @Input() estacionamento: IRespostaEnderecoDto[];

  constructor(private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
  }

  AddItemCestaCompras() {
    this.cestaComprasService.addItemToBasket(this.estacionamento[0]);
  }
}

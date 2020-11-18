import { Component, OnInit } from '@angular/core';
import { OrdensService } from './ordens.service';
import { IOrdem } from '../shared/models/ordem';

@Component({
  selector: 'app-ordens',
  templateUrl: './ordens.component.html',
  styleUrls: ['./ordens.component.scss']
})
export class OrdensComponent implements OnInit {
  ordensCliente: IOrdem[];

  constructor(private ordens: OrdensService) { }

  ngOnInit() {
    this.obterOrdens();
  }

  obterOrdens() {
    this.ordens.obterOrdens().subscribe((resposta: IOrdem[]) => {
      this.ordensCliente = resposta;
    }, error => {
      console.log(error);
    });
  }
}

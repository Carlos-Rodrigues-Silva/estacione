import { Component, OnInit } from '@angular/core';
import { OrdensService } from '../ordens.service';
import { ActivatedRoute } from '@angular/router';
import { IOrdem } from 'src/app/shared/models/ordem';
import { IOrdemParaRetornarDto } from 'src/app/shared/models/ordemParaRetornarDto';

@Component({
  selector: 'app-ordem-detalhe',
  templateUrl: './ordem-detalhe.component.html',
  styleUrls: ['./ordem-detalhe.component.scss']
})
export class OrdemDetalheComponent implements OnInit {

  // ordem: IOrdem;
  ordem: IOrdemParaRetornarDto;


  constructor(private ordens: OrdensService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.obterOrdemId();
  }

  obterOrdemId() {
    this.ordens.obterOrdensId(+this.route.snapshot.paramMap.get('id')).subscribe((ordem: IOrdemParaRetornarDto) => {
      this.ordem = ordem;
      console.log(ordem);
    });
  }
}

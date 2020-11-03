import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { IRespostaEnderecoDto } from '../shared/models/respostaEndereco';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MapaEnderecoService } from './mapa-endereco.service';
import { CestaComprasService } from '../cesta-compras/cesta-compras.service';


@Component({
  selector: 'app-mapa-endereco',
  templateUrl: './mapa-endereco.component.html',
  styleUrls: ['./mapa-endereco.component.scss']
})
export class MapaEnderecoComponent implements OnInit {

  buscaForm: FormGroup;
  latitudeLongitude: IRespostaEnderecoDto;
  zoom = 15;

  constructor(private router: Router, private mapaEnderecoService: MapaEnderecoService,
              private http: HttpClient, private cestaComprasService: CestaComprasService) { }

  ngOnInit(): void {
    this.createBuscarForm();
    this.getLocation();
    // this.basketService.addItemToBasket(this.latitudeLongitude);
  }

  createBuscarForm() {
    this.buscaForm = new FormGroup({
      RuaOuCep: new FormControl('', Validators.required)
    });
  }

  buscarEnderecoEstacionamento() {
    this.mapaEnderecoService.endereco(this.buscaForm.value).subscribe(data => {
      this.latitudeLongitude = data;
      // console.log(this.latitudeLongitude);
    });
  }

  public getLocation() {
     this.http.get<IRespostaEnderecoDto>('https://localhost:5001/api/endereco/localizacao').subscribe(response => {
       this.latitudeLongitude = response[0];
       console.log(this.latitudeLongitude.id);
       console.log(this.latitudeLongitude.nomeEstacionamento);
       console.log(this.latitudeLongitude.precoHora);
    });
  }
}

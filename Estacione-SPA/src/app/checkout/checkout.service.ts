import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IOrdemParaSerCriada } from '../shared/models/ordem';
import { ICestaCliente } from '../shared/models/CestaCliente';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  CriarOrdem(ordem: IOrdemParaSerCriada) {
    return this.http.post(this.baseUrl + 'ordens', ordem);
  }
}

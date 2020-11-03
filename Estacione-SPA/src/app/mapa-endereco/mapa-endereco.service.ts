import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IRespostaEnderecoDto } from '../shared/models/respostaEndereco';

@Injectable({
  providedIn: 'root'
})
export class MapaEnderecoService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Enviar endereço digitado pelo cliente
  endereco(values: any): Observable<IRespostaEnderecoDto> {
    return this.http.post<IRespostaEnderecoDto>(this.baseUrl + 'endereco/logradourooucep', values);
  }
}

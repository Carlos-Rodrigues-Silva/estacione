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

  endereco(values: any): Observable<IRespostaEnderecoDto[]> {
    return this.http.post<IRespostaEnderecoDto[]>(this.baseUrl + 'endereco/logradourooucep', values);
  }
}

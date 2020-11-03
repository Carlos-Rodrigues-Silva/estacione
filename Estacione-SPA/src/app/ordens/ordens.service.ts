import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdensService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  obterOrdens() {
    return this.http.get(this.baseUrl + 'ordens' + '/ordens');
  }

  obterOrdensId(id: number) {
    return this.http.get(this.baseUrl + 'ordens/ordem/' + id);
  }

}

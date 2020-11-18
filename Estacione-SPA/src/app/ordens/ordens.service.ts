import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdensService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  obterOrdens() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    };
    return this.http.get(this.baseUrl + 'ordem' + '/ordens', httpOptions);
  }

  // obterOrdensId(id: number) {
  //   return this.http.get(this.baseUrl + 'ordem/ordem/' + id);
  // }

  obterOrdensId(id: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    };
    return this.http.get(this.baseUrl + 'ordem/' + id, httpOptions);
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUsuario } from '../shared/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class ContaService {
  baseUrl = environment.apiUrl;
  // private usuarioAtualSource = new BehaviorSubject<IUsuario>(null);
  private usuarioAtualSource = new ReplaySubject<IUsuario>(1);
  usuarioAtual$ = this.usuarioAtualSource.asObservable();

  constructor(private http: HttpClient, private router: Router ) { }


  login(values: any) {
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((usuario: IUsuario) => {
        if (usuario) {
          localStorage.setItem('token', usuario.token);
          this.usuarioAtualSource.next(usuario);
        }
      })
    );
  }

  registrar(values: any) {
    return this.http.post(this.baseUrl + 'account/registrar', values).pipe(
      map((usuario: IUsuario) => {
        if (usuario) {
          localStorage.setItem('token', usuario.token);
          this.usuarioAtualSource.next(usuario);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.usuarioAtualSource.next(null);
    this.router.navigateByUrl('/');
  }

  emailExiste(email: string) {
    return this.http.get(this.baseUrl + '/account/emailexiste?email=' + email);
  }

  carregarUsuarioAtual(token: string) {
    if (token === null) {
      this.usuarioAtualSource.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get(this.baseUrl + 'account', {headers}).pipe(
      map((usuario: IUsuario) => {
        if(usuario) {
          localStorage.setItem('token', usuario.token);
          this.usuarioAtualSource.next(usuario);
        }
      })
    );
  }

  // obterUsuarioAtual() {
  //   return this.usuarioAtualSource.value;
  // }
 }

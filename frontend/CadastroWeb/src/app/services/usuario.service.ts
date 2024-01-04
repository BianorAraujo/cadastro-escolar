import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../models/Usuario';
import { Response } from '../models/Response';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private apiUrl = `${environment.ApiUrl}/usuario`
  
  constructor(private http: HttpClient) { }

  GetUsuarios() : Observable<Response<Usuario[]>>{
    return this.http.get<Response<Usuario[]>>(this.apiUrl);
  }

  GetUsuario(id: number) : Observable<Response<Usuario>>{
    return this.http.get<Response<Usuario>>(`${this.apiUrl}/${id}`);
  }

  CreateUsuario(usuario: Usuario) : Observable<Response<number>>{
    return this.http.post<Response<number>>(`${this.apiUrl}`, usuario);
  }

  EditarUsuario(usuario: Usuario) : Observable<Response<Usuario>>{
    return this.http.put<Response<Usuario>>(`${this.apiUrl}`, usuario);
  }

  ExcluirUsuario(id: number) : Observable<Response<Usuario>>{
    return this.http.delete<Response<Usuario>>(`${this.apiUrl}/${id}`);
  }

}

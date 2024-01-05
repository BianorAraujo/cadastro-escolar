import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private apiUrl = `${environment.ApiUrl}/usuario`
  
  constructor(private http: HttpClient) { }

  GetUsuarios() : Observable<Usuario[]>{
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  GetUsuario(id: number) : Observable<Usuario>{
    return this.http.get<Usuario>(`${this.apiUrl}/${id}`);
  }

  CreateUsuario(usuario: Usuario) : Observable<number>{
    return this.http.post<number>(`${this.apiUrl}`, usuario);
  }

  EditarUsuario(usuario: Usuario) : Observable<Usuario>{
    return this.http.put<Usuario>(`${this.apiUrl}`, usuario);
  }

  ExcluirUsuario(id: number) : Observable<Usuario>{
    return this.http.delete<Usuario>(`${this.apiUrl}/${id}`);
  }

}

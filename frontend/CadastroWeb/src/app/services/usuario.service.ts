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

}

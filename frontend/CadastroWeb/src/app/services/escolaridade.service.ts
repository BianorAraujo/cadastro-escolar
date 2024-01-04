import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { NivelEscolar } from '../models/NivelEscolar';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class EscolaridadeService {

  private apiUrl = `${environment.ApiUrl}/escolaridade`

  constructor(private http: HttpClient) { }

  GetEscolaridades() : Observable<NivelEscolar[]>{
    return this.http.get<NivelEscolar[]>(this.apiUrl);
  }

}

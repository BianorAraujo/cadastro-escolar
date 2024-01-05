import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HistoricoService {

  private apiUrl = `${environment.ApiUrl}/historico`
  
  constructor(private http: HttpClient) { }

  Upload(formData: FormData) : Observable<any>{
    return this.http.post<any>(`${this.apiUrl}`, formData);
  }

  Download(id: number) : Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.get(`${this.apiUrl}/${id}`, {headers, responseType: 'blob'});
  }

  ExcluirHistorico(id: number) : Observable<any>{
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Obra } from '../models/obra.model';


@Injectable({
  providedIn: 'root'
})
export class ObraService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getObras(): Observable<Obra[]> {
    return this.http.get<Obra[]>(`${this.baseUrl}/obras`);
  }

  getObra(id: number): Observable<Obra> {
    return this.http.get<Obra>(`${this.baseUrl}/obras/${id}`);
  }

  addObra(obra: Obra): Observable<Obra> {
    return this.http.post<Obra>(`${this.baseUrl}/obras`, obra);
  }

  updateObra(id: number, obra: Obra): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/obras/${id}`, obra);
  }

  deleteObra(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/obras/${id}`);
  }
}

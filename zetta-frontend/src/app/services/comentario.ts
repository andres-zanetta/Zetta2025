import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Comentario } from '../models/comentario.model';


@Injectable({
  providedIn: 'root'
})
export class ComentarioService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getComentarios(): Observable<Comentario[]> {
    return this.http.get<Comentario[]>(`${this.baseUrl}/comentarios`);
  }

  getComentario(id: number): Observable<Comentario> {
    return this.http.get<Comentario>(`${this.baseUrl}/comentarios/${id}`);
  }

  addComentario(comentario: Comentario): Observable<Comentario> {
    return this.http.post<Comentario>(`${this.baseUrl}/comentarios`, comentario);
  }

  deleteComentario(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/comentarios/${id}`);
  }
}

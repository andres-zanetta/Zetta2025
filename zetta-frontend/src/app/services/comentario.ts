import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comentario } from '../models/comentario.model';

@Injectable({ providedIn: 'root' })
export class ComentarioService {
  private baseUrl = 'https://localhost:5001/api/comentarios';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Comentario[]> {
    return this.http.get<Comentario[]>(this.baseUrl);
  }
  getById(id: number): Observable<Comentario> {
    return this.http.get<Comentario>(`${this.baseUrl}/${id}`);
  }
  create(comentario: Comentario): Observable<Comentario> {
    return this.http.post<Comentario>(this.baseUrl, comentario);
  }
  update(id: number, comentario: Comentario): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, comentario);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

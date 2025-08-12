import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Obra } from '../models/obra.model';

@Injectable({ providedIn: 'root' })
export class ObraService {
  private baseUrl = 'https://localhost:5001/api/obras';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Obra[]> {
    return this.http.get<Obra[]>(this.baseUrl);
  }
  getById(id: number): Observable<Obra> {
    return this.http.get<Obra>(`${this.baseUrl}/${id}`);
  }
  create(obra: Obra): Observable<Obra> {
    return this.http.post<Obra>(this.baseUrl, obra);
  }
  update(id: number, obra: Obra): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, obra);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

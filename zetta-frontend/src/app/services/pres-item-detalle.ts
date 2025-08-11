import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PresItemDetalle } from '../models/pres-item-detalle.model';

@Injectable({ providedIn: 'root' })
export class PresItemDetalleService {
  private baseUrl = 'https://localhost:5001/api/pres-item-detalle';

  constructor(private http: HttpClient) {}

  getAll(): Observable<PresItemDetalle[]> {
    return this.http.get<PresItemDetalle[]>(this.baseUrl);
  }
  getById(id: number): Observable<PresItemDetalle> {
    return this.http.get<PresItemDetalle>(`${this.baseUrl}/${id}`);
  }
  create(item: PresItemDetalle): Observable<PresItemDetalle> {
    return this.http.post<PresItemDetalle>(this.baseUrl, item);
  }
  update(id: number, item: PresItemDetalle): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, item);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

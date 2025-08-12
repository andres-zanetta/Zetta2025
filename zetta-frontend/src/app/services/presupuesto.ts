import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Presupuesto } from '../models/presupuesto.model';

@Injectable({ providedIn: 'root' })
export class PresupuestoService {
  private baseUrl = 'https://localhost:5001/api/presupuestos';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Presupuesto[]> {
    return this.http.get<Presupuesto[]>(this.baseUrl);
  }
  getById(id: number): Observable<Presupuesto> {
    return this.http.get<Presupuesto>(`${this.baseUrl}/${id}`);
  }
  create(presupuesto: Presupuesto): Observable<Presupuesto> {
    return this.http.post<Presupuesto>(this.baseUrl, presupuesto);
  }
  update(id: number, presupuesto: Presupuesto): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, presupuesto);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

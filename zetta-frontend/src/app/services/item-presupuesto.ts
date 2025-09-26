import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ItemPresupuesto } from '../models/item-presupuesto.model';

@Injectable({ providedIn: 'root' })
export class ItemPresupuestoService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<ItemPresupuesto[]> {
    return this.http.get<ItemPresupuesto[]>(this.baseUrl);
  }
  getById(id: number): Observable<ItemPresupuesto> {
    return this.http.get<ItemPresupuesto>(`${this.baseUrl}/${id}`);
  }
  create(item: ItemPresupuesto): Observable<ItemPresupuesto> {
    return this.http.post<ItemPresupuesto>(this.baseUrl, item);
  }
  update(id: number, item: ItemPresupuesto): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, item);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
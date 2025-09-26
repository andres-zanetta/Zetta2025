import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { PresItemDetalle } from '../models/pres-item-detalle.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PresItemDetalleService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDetalles(presupuestoId: number): Observable<PresItemDetalle[]> {
    return this.http.get<PresItemDetalle[]>(`${this.baseUrl}/presupuestos/${presupuestoId}/detalles`);
  }

  addDetalle(detalle: PresItemDetalle): Observable<PresItemDetalle> {
    return this.http.post<PresItemDetalle>(`${this.baseUrl}/presupuestos/${detalle.presupuestoId}/detalles`, detalle);
  }

  updateDetalle(id: number, detalle: PresItemDetalle): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/presupuestos/${detalle.presupuestoId}/detalles/${id}`, detalle);
  }

  deleteDetalle(presupuestoId: number, id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/presupuestos/${presupuestoId}/detalles/${id}`);
  }
}

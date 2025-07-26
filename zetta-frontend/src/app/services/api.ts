// src/app/services/api.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  // Ajusta la URL base para incluir el prefijo 'api'.
  // Esto hará que todas las llamadas comiencen con https://localhost:7025/api
  private baseUrl = 'https://localhost:7025/api';

  constructor(private http: HttpClient) { }

  // Método para obtener Clientes
  // La ruta es 'api/clientes' (plural y minúsculas)
  getClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/clientes`);
  }

  // Método para obtener Obras
  // La ruta es 'api/obra' (singular y minúsculas)
  getObras(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/obra`);
  }

  // Ejemplo de método POST para crear un nuevo Cliente
  createCliente(clienteData: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/clientes`, clienteData);
  }

  // Puedes añadir más métodos para ItemPresupuesto y PressItemDetalle
  getItemPresupuestos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/ItemPresupuesto`);
  }

  getPressItemDetalles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/PressItemDetalle`);
  }
}
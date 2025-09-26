import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.model';

@Injectable({ providedIn: 'root' })
export class ClienteService {
private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl);
  }
  getById(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/${id}`);
  }
  create(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseUrl, cliente);
  }
  update(id: number, cliente: Cliente): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, cliente);
  }
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}

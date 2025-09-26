import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Presupuesto } from '../models/presupuesto.model';

@Injectable({
  providedIn: 'root'
})
export class PresupuestoService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  private handleError(error: HttpErrorResponse): Observable<never> {
    console.error('Ha ocurrido un error:', error.error);
    return throwError(() => new Error('Algo salió mal; por favor, inténtalo de nuevo más tarde.'));
  }

  getAll(): Observable<Presupuesto[]> {
    return this.http.get<Presupuesto[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  getById(id: number): Observable<Presupuesto> {
    return this.http.get<Presupuesto>(`${this.baseUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  create(presupuesto: Presupuesto): Observable<number> {
    return this.http.post<number>(this.baseUrl, presupuesto)
      .pipe(
        catchError(this.handleError)
      );
  }

  update(id: number, presupuesto: Presupuesto): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, presupuesto)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }
}
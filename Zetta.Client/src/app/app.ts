import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected title = 'Zetta.Client';
  itemPresupuestoData: any;
  errorMessage: string | null = null;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.fetchItemPresupuesto();
  }

  fetchItemPresupuesto() {
    // La URL debe ser '/api/ItemPresupuesto' para coincidir con la ruta del backend.
    this.http.get('/api/ItemPresupuesto').subscribe({ // CAMBIO AQUÍ
      next: (data) => {
        this.itemPresupuestoData = data;
        console.log('Datos de ItemPresupuesto recibidos:', data);
        this.errorMessage = null;
      },
      error: (error) => {
        this.errorMessage = `Error al cargar ItemPresupuesto: ${error.message || error.statusText}`;
        console.error('Hubo un error al obtener ItemPresupuesto:', error);
      }
    });
  }
}

// src/app/app.ts
import { Component, OnInit } from '@angular/core';
import { ApiService } from './services/api'; // Asegúrate de que esta ruta sea correcta

@Component({
  selector: 'app-root',
  standalone: true, // <-- ¡ASEGÚRATE DE QUE ESTA LÍNEA ESTÉ AQUÍ!
  templateUrl: './app.html',
  styleUrls: ['./app.css'],

})
export class AppComponent implements OnInit {
  title = 'Zetta Frontend';
  clientes: any[] = [];
  obras: any[] = [];
  errorMessage: string = '';

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getClientesData();
    this.getObrasData();
  }

  getClientesData(): void {
    this.apiService.getClientes().subscribe({
      next: (data) => {
        this.clientes = data;
        console.log('Datos de Clientes recibidos:', this.clientes);
      },
      error: (error) => {
        console.error('Error al obtener datos de clientes:', error);
      }
    });
  }

  getObrasData(): void {
    this.apiService.getObras().subscribe({
      next: (data) => {
        this.obras = data;
        console.log('Datos de Obras recibidos:', this.obras);
      },
      error: (error) => {
        console.error('Error al obtener datos de obras:', error);
      }
    });
  }
}
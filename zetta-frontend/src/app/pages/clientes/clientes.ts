// src/app/pages/clientes/clientes.ts

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from '../../services/cliente';
import { Cliente } from '../../models/cliente.model';
import { Router } from '@angular/router';

// 1. Importa los módulos y los íconos necesarios para Font Awesome
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-clientes',
  standalone: true,
  // 2. Agrega FontAwesomeModule al array de imports
  imports: [CommonModule, FontAwesomeModule],
  templateUrl: './clientes.html',
  styleUrl: './clientes.css'
})
export class Clientes implements OnInit {
  clientes: Cliente[] = [];
  // Se conserva el elemento `cargando`
  cargando = true;

  // 3. Define los íconos como propiedades de la clase
  faEdit = faEdit;
  faTrash = faTrash;

  constructor(
    private clienteService: ClienteService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.cargarClientes();
  }

  cargarClientes(): void {
    this.clienteService.getAll().subscribe({
      next: (data) => {
        this.clientes = data;
        this.cargando = false;
      },
      error: (err) => {
        console.error('Error al cargar clientes:', err);
        this.cargando = false;
      }
    });
  }

  eliminarCliente(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este cliente?')) {
      this.clienteService.delete(id).subscribe({
        next: () => {
          this.cargarClientes();
        },
        error: (err) => {
          console.error('Error al eliminar cliente:', err);
        }
      });
    }
  }

  abrirFormularioNuevo(): void {
    this.router.navigate(['/clientes/nuevo']);
  }

  abrirFormularioEdicion(id: number): void {
    this.router.navigate(['/clientes/editar', id]);
  }
}
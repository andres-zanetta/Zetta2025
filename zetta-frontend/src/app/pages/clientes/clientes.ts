import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // Importa CommonModule para usar *ngFor
import { ClienteService } from '../../services/cliente';
import { Cliente } from '../../models/cliente.model';

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [CommonModule], // Añade CommonModule aquí
  templateUrl: './clientes.html',
  styleUrl: './clientes.css'
})
export class Clientes implements OnInit {

  clientes: Cliente[] = [];

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.cargarClientes();
  }

  cargarClientes(): void {
    this.clienteService.getAll().subscribe({
      next: (data) => {
        this.clientes = data;
      },
      error: (err) => {
        console.error('Error al cargar clientes:', err);
      }
    });
  }

  eliminarCliente(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este cliente?')) {
      this.clienteService.delete(id).subscribe({
        next: () => {
          this.cargarClientes(); // Recarga la lista después de eliminar
        },
        error: (err) => {
          console.error('Error al eliminar cliente:', err);
        }
      });
    }
  }

  // Puedes añadir métodos para navegar al formulario de nuevo cliente o editar
  abrirFormularioNuevo(): void {
    // Lógica para abrir el formulario
    console.log('Abrir formulario para nuevo cliente');
  }

  abrirFormularioEdicion(cliente: Cliente): void {
    // Lógica para abrir el formulario con los datos del cliente
    console.log('Abrir formulario para editar cliente:', cliente);
  }
}
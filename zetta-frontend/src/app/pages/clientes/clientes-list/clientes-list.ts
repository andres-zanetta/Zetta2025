import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../../services/cliente';
import { Cliente } from '../../../models/cliente.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes-list',
  templateUrl: './clientes-list.html',
  styleUrls: ['./clientes-list.css']
})
export class ClientesList implements OnInit {
  clientes: Cliente[] = [];
  cargando = true;

  constructor(
    private clienteService: ClienteService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cargarClientes();
  }

  cargarClientes() {
    this.clienteService.getAll().subscribe({
      next: (data) => {
        this.clientes = data;
        this.cargando = false;
      },
      error: (err) => console.error('Error cargando clientes', err)
    });
  }

  eliminarCliente(id: number) {
    if (confirm('¿Seguro que deseas eliminar este cliente?')) {
      this.clienteService.delete(id).subscribe(() => {
        this.cargarClientes();
      });
    }
  }

  editarCliente(id: number) {
    this.router.navigate(['/clientes/editar', id]);
  }

  nuevoCliente() {
    this.router.navigate(['/clientes/nuevo']);
  }
}

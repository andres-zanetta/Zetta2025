// src/app/pages/clientes/clientes-form/clientes-form.ts

import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../../services/cliente';
import { Cliente } from '../../../models/cliente.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-clientes-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './clientes-form.html',
  styleUrls: ['./clientes-form.css']
})
export class ClientesForm implements OnInit {
  // Corregido: inicializar la propiedad Presupuestos como un arreglo vacío
  cliente: Cliente = { nombre: '',apellido:'', id: 0, telefono: '', presupuestos: [] }; 
  esEdicion = false;

  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.esEdicion = true;
      this.clienteService.getById(+id).subscribe({
        next: (data) => (this.cliente = data),
        error: (err) => console.error('Error obteniendo cliente', err)
      });
    }
  }

  guardarCliente() {
    if (this.esEdicion) {
      this.clienteService.update(this.cliente.id, this.cliente).subscribe(() => {
        this.router.navigate(['/clientes']);
      });
    } else {
      this.clienteService.create(this.cliente).subscribe(() => {
        this.router.navigate(['/clientes']);
      });
    }
  }

  cancelar() {
    this.router.navigate(['/clientes']);
  }
}
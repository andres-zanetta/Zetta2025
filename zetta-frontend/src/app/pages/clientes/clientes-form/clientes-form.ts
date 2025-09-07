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
  cliente: Cliente = { nombre: '', apellido: '', id: 0, telefono: '', presupuestos: [], direccion: '', localidad: '', email: '' };
  esEdicion = false;
  private returnUrl: string | null = null;

  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    // Leer el parámetro de consulta 'returnUrl'
    this.returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');

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
      this.clienteService.update(this.cliente.id, this.cliente).subscribe({
        next: () => this.router.navigate(['/clientes']),
        error: (err) => console.error('Error actualizando cliente', err)
      });
    } else {
      this.clienteService.create(this.cliente).subscribe({
        next: (clienteCreado) => {
          // Si hay una URL de retorno, navegamos de vuelta y pasamos el ID del nuevo cliente
          if (this.returnUrl === 'presupuesto') {
            this.router.navigate(['/presupuesto/0'], { queryParams: { clienteId: clienteCreado.id } });
          } else {
            this.router.navigate(['/clientes']);
          }
        },
        error: (err) => console.error('Error creando cliente', err)
      });
    }
  }

  volver(): void {
    if (this.returnUrl === 'presupuesto') {
      this.router.navigate(['/presupuesto/0']);
    } else {
      this.router.navigate(['/clientes']);
    }
  }
}
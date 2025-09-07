import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { empty, Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Presupuesto, Rubro, OpcionDePago } from '../../models/presupuesto.model';
import { PresItemDetalle } from '../../models/pres-item-detalle.model';
import { ItemPresupuesto } from '../../models/item-presupuesto.model';
import { PresupuestoService } from '../../services/presupuesto';
import { PresItemDetalleService } from '../../services/pres-item-detalle';
import { ItemPresupuestoService } from '../../services/item-presupuesto';
import { ClienteService } from '../../services/cliente';
import { Cliente } from '../../models/cliente.model';

// Interface que coincide con el DTO del backend para crear un presupuesto
interface POST_PresupuestoDTO {
  clienteNombre: string;
  direccion: string;
  localidad: string;
  telefono: string;
  email: string;
  incluyeMateriales: boolean;
  items: {
    id: number;
    nombre: string;
    descripcion: string;
    precio: number;
    rubro: Rubro;
    medida: string;
    material: string;
    fabricante: string;
    marca: string;
  }[];
}

@Component({
  selector: 'app-presupuesto',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './presupuesto.html',
  styleUrl: './presupuesto.css'
})
export class PresupuestoPage implements OnInit {
  presupuesto: Presupuesto = {
    id: 0,
    rubro: Rubro.Gas,
    aceptado: false,
    itemsDetalle: [],
    subtotal: 0,
    total: 0,
    totalP: 0,
    tiempoAproxObra: '0',
    validacionDias: '30',
    opcionDePago: OpcionDePago.Contado,
  };

  itemsCatalogo: ItemPresupuesto[] = [];
  clientes: Cliente[] = [];
  clienteSeleccionado: Cliente | null = null;

  nuevoItemId: number | null = null;
  nuevaCantidad: number = 1;

  constructor(
    private presupuestoService: PresupuestoService,
    private presItemDetalleService: PresItemDetalleService,
    private itemPresupuestoService: ItemPresupuestoService,
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    const clienteId = this.route.snapshot.queryParamMap.get('clienteId');

    // Cargar clientes e items del catálogo
    this.clienteService.getAll().subscribe({
        next: (clientes) => this.clientes = clientes,
        error: (err) => console.error('Error al cargar clientes:', err)
    });

    this.itemPresupuestoService.getAll().subscribe({
        next: (items) => this.itemsCatalogo = items,
        error: (err) => console.error('Error al cargar ítems del catálogo:', err)
    });

    // Si hay un ID de presupuesto en la URL, cargar el presupuesto
    if (id) {
      this.presupuestoService.getById(+id).subscribe({
        next: (presupuesto) => {
          if (presupuesto) {
            this.presupuesto = presupuesto;
            this.recalcularTotales();
            // Lógica para cargar el cliente del presupuesto si existe
            if (presupuesto.clienteId) {
                this.clienteService.getById(presupuesto.clienteId).subscribe({
                    next: (cliente) => this.clienteSeleccionado = cliente,
                    error: (err) => console.error('Error al cargar cliente del presupuesto:', err)
                });
            }
          } else {
            console.error('Presupuesto no encontrado.');
          }
        },
        error: (err) => console.error('Error al cargar datos del presupuesto:', err)
      });
    }

    // Si hay un clienteId en los queryParams, seleccionar ese cliente
    if (clienteId) {
      this.clienteService.getById(+clienteId).subscribe({
        next: (cliente) => this.clienteSeleccionado = cliente,
        error: (err) => console.error('Error al cargar el cliente desde la URL:', err)
      });
    }
  }

  // Navega al formulario de creación de cliente
  navegarANuevoCliente(): void {
    this.router.navigate(['/clientes/crear'], { queryParams: { returnUrl: 'presupuesto' } });
  }

  seleccionarCliente(cliente: Cliente): void {
    this.clienteSeleccionado = cliente;
    alert(`Cliente seleccionado: ${cliente.nombre}`);
  }

  agregarItem(): void {
    if (this.nuevoItemId && this.nuevaCantidad > 0) {
      const itemSeleccionado = this.itemsCatalogo.find(item => item.id === this.nuevoItemId);
      if (itemSeleccionado) {
        const nuevoDetalle: PresItemDetalle = {
          id: 0,
          presupuestoId: this.presupuesto.id,
          itemPresupuestoId: itemSeleccionado.id,
          cantidad: this.nuevaCantidad,
          precioUnitario: itemSeleccionado.precio || 0,
          itemPresupuesto: itemSeleccionado,
          presupuesto: this.presupuesto,
        };
        this.presupuesto.itemsDetalle.push(nuevoDetalle);
        this.recalcularTotales();
        alert('Ítem agregado a la lista local.');
        this.nuevoItemId = null;
        this.nuevaCantidad = 1;
      } else {
        alert('Por favor, selecciona un ítem válido.');
      }
    } else {
      alert('Por favor, selecciona un ítem y especifica una cantidad válida.');
    }
  }

  eliminarItem(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este ítem?')) {
        this.presupuesto.itemsDetalle = this.presupuesto.itemsDetalle.filter(item => item.id !== id);
        this.recalcularTotales();
        alert('Ítem eliminado con éxito.');
    }
  }

  guardarPresupuesto(): void {
    if (!this.clienteSeleccionado) {
      alert('Por favor, selecciona un cliente existente o añade uno nuevo.');
      return;
    }

    if (this.presupuesto.itemsDetalle.length === 0) {
        alert('Por favor, añade al menos un ítem al presupuesto.');
        return;
    }

    // Adaptar el DTO para el nuevo flujo
    const postDto: POST_PresupuestoDTO = {
        clienteNombre: this.clienteSeleccionado.nombre,
        direccion: this.clienteSeleccionado.direccion,
        localidad: this.clienteSeleccionado.localidad,
        telefono: this.clienteSeleccionado.telefono,
        email: this.clienteSeleccionado.email,
        incluyeMateriales: true,
        items: this.presupuesto.itemsDetalle.map(itemDetalle => {
            const item = itemDetalle.itemPresupuesto;
            return {
                id: item.id,
                nombre: item.nombre || '',
                descripcion: item.descripcion || '',
                precio: item.precio || 0,
                rubro: item.rubro || Rubro.Gas,
                medida: item.medida || '',
                material: item.material || '',
                fabricante: item.fabricante || '',
                marca: item.marca || '',
            };
        }),
    };

    if (this.presupuesto.id === 0) {
      this.presupuestoService.create(postDto as any).subscribe({
        next: (data: any) => {
          this.presupuesto.id = data;
          alert('Presupuesto creado con éxito.');
          this.router.navigate(['/presupuesto', this.presupuesto.id]);
        },
        error: (err) => console.error('Error al crear el presupuesto:', err)
      });
    } else {
      this.presupuestoService.update(this.presupuesto.id, this.presupuesto).subscribe({
        next: () => alert('Presupuesto actualizado con éxito.'),
        error: (err) => console.error('Error al actualizar el presupuesto:', err)
      });
    }
  }

  recalcularTotales(): void {
    const subtotal = this.presupuesto.itemsDetalle.reduce(
      (acc, item) => acc + (item.precioUnitario * item.cantidad),
      0
    );
    this.presupuesto.subtotal = subtotal;
    const manodeObra = this.presupuesto.manodeObra || 0;
    this.presupuesto.total = subtotal + manodeObra;
    this.presupuesto.totalP = this.presupuesto.total;
  }
}
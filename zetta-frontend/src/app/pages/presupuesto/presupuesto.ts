import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { empty, Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Presupuesto, Rubro, OpcionDePago } from '../../models/presupuesto.model';
import { PresItemDetalle } from '../../models/pres-item-detalle.model';
import { ItemPresupuesto } from '../../models/item-presupuesto.model';
import { PresupuestoService } from '../../services/presupuesto'; 
import { PresItemDetalleService } from '../../services/pres-item-detalle';
import { ItemPresupuestoService } from '../../services/item-presupuesto';

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
    opcionDePago: OpcionDePago.Contado
  };

  itemsCatalogo: ItemPresupuesto[] = [];
  nuevoItemId: number | null = null;
  nuevaCantidad: number = 1;

  constructor(
    private presupuestoService: PresupuestoService,
    private presItemDetalleService: PresItemDetalleService,
    private itemPresupuestoService: ItemPresupuestoService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.cargarItemsCatalogo();

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.presupuesto.id = +id;
      this.cargarPresupuesto();
    }
  }

  cargarItemsCatalogo(): void {
    this.itemPresupuestoService.getAll().subscribe({
      next: (data) => {
        this.itemsCatalogo = data;
        console.log('Items del catálogo cargados:', this.itemsCatalogo);
      },
      error: (err) => console.error('Error al cargar los ítems del catálogo:', err)
    });
  }

  cargarPresupuesto(): void {
    this.presupuestoService.getById(this.presupuesto.id).subscribe({
      next: (data) => {
        this.presupuesto = data;
        this.recalcularTotales();
      },
      error: (err) => console.error('Error al cargar el presupuesto:', err)
    });
  }

  agregarItem(): void {
    if (!this.nuevoItemId || this.nuevaCantidad <= 0) {
      alert('Por favor, selecciona un ítem y una cantidad válida.');
      return;
    }

    //si el presupuesto no existe, lo crea primero.
    const createOrUpdatePresupuesto$: Observable<Presupuesto> = (this.presupuesto.id === 0)
      ? this.presupuestoService.create(this.presupuesto) // Crea el presupuesto si no tiene ID
      : this.presupuestoService.getById(this.presupuesto.id); // Si ya tiene ID, solo obtiene la referencia para el flujo

    createOrUpdatePresupuesto$.pipe(
      switchMap((presupuestoGuardado) => {
        this.presupuesto.id = presupuestoGuardado.id; // Asigna el ID del presupuesto guardado
        return this.agregarItemAPresupuesto(presupuestoGuardado.id);
      })
    ).subscribe({
      next: (detalle) => {
        this.presupuesto.itemsDetalle.push(detalle);
        this.recalcularTotales();
        this.resetFormularioItem();
        alert('Ítem agregado con éxito.');
      },
      error: (err) => console.error('Error al agregar el ítem:', err)
    });
  }

  private agregarItemAPresupuesto(presupuestoId: number): Observable<PresItemDetalle> {
    const itemSeleccionado = this.itemsCatalogo.find(i => i.id === this.nuevoItemId);
    if (!itemSeleccionado) {
      return of(); 
    }

    const nuevoDetalle: PresItemDetalle = {
      id: 0,
      presupuestoId: presupuestoId,
      presupuesto: this.presupuesto,
      itemPresupuestoId: itemSeleccionado.id,
      itemPresupuesto: itemSeleccionado,
      cantidad: this.nuevaCantidad,
      precioUnitario: itemSeleccionado.precio || 0
    };

    return this.presItemDetalleService.create(nuevoDetalle);
  }

  eliminarItem(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este ítem?')) {
      this.presItemDetalleService.delete(id).subscribe({
        next: () => {
          this.presupuesto.itemsDetalle = this.presupuesto.itemsDetalle.filter(item => item.id !== id);
          this.recalcularTotales();
          alert('Ítem eliminado con éxito.');
        },
        error: (err) => console.error('Error al eliminar el ítem:', err)
      });
    }
  }

  guardarPresupuesto(): void {
    if (this.presupuesto.id === 0) {
      this.presupuestoService.create(this.presupuesto).subscribe({
        next: (data) => {
          this.presupuesto.id = data.id;
          alert('Presupuesto creado con éxito.');
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
      (acc, item) => acc + (item.cantidad * item.precioUnitario), 0
    );
    this.presupuesto.subtotal = subtotal;
    this.presupuesto.total = subtotal + (this.presupuesto.manodeObra || 0);
  }

  resetFormularioItem(): void {
    this.nuevoItemId = null;
    this.nuevaCantidad = 1;
  }
}
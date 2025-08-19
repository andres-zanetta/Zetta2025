// src/app/pages/items/item-presupuesto-form/item-presupuesto-form.ts

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemPresupuestoService } from '../../../services/item-presupuesto';
import { ItemPresupuesto, Rubro } from '../../../models/item-presupuesto.model';

@Component({
  selector: 'app-item-presupuesto-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './item-presupuesto-form.html',
  styleUrls: ['./item-presupuesto-form.css']
})
export class ItemPresupuestoForm implements OnInit {
  item: ItemPresupuesto = {
    id: 0,
    nombre: '',
    descripcion: '',
    precio: 0,
    rubro: undefined,
    medida: '',
    material: '',
    fabricante: '',
    marca: '',
    fechActuPrecio: new Date().toISOString()
  };
  esEdicion = false;
  rubrosDisponibles = ['Albañilería', 'Electricidad', 'Plomería', 'Pintura', 'Carpintería'];

  constructor(
    private itemPresupuestoService: ItemPresupuestoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.esEdicion = true;
      this.itemPresupuestoService.getById(+id).subscribe({
        next: (data) => (this.item = data),
        error: (err) => console.error('Error obteniendo ítem', err)
      });
    }
  }

  guardarItem(): void {
    if (this.esEdicion) {
      this.itemPresupuestoService.update(this.item.id, this.item).subscribe({
        next: () => this.router.navigate(['/items']),
        error: (err) => console.error('Error actualizando ítem', err)
      });
    } else {
      this.itemPresupuestoService.create(this.item).subscribe({
        next: () => this.router.navigate(['/items']),
        error: (err) => console.error('Error creando ítem', err)
      });
    }
  }

  cancelar(): void {
    this.router.navigate(['/items']);
  }
}
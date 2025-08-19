// src/app/pages/items/items.ts

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ItemPresupuestoService } from '../../services/item-presupuesto';
import { ItemPresupuesto } from '../../models/item-presupuesto.model';

@Component({
  selector: 'app-items',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './items.html',
  styleUrl: './items.css'
})
export class Items implements OnInit {
  items: ItemPresupuesto[] = [];
  cargando = true;

  constructor(
    private itemPresupuestoService: ItemPresupuestoService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.cargarItems();
  }

  cargarItems(): void {
    this.itemPresupuestoService.getAll().subscribe({
      next: (data) => {
        this.items = data;
        this.cargando = false;
      },
      error: (err) => {
        console.error('Error al cargar items:', err);
        this.cargando = false;
      }
    });
  }

  eliminarItem(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este ítem?')) {
      this.itemPresupuestoService.delete(id).subscribe({
        next: () => {
          this.cargarItems();
        },
        error: (err) => {
          console.error('Error al eliminar ítem:', err);
        }
      });
    }
  }

  abrirFormularioNuevo(): void {
    this.router.navigate(['/items/nuevo']);
  }

  abrirFormularioEdicion(id: number): void {
    this.router.navigate(['/items/editar', id]);
  }
}
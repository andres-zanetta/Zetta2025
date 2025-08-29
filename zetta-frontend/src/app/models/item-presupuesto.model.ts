// src/app/models/item-presupuesto.model.ts

export enum Rubro {
  Gas = 0,
  Electricidad = 1,
  Refrigeracion = 2,
  Solar = 3,
  Plomeria = 4
}

export interface ItemPresupuesto {
  id: number;
  nombre: string;
  descripcion?: string;
  precio?: number;
  rubro: Rubro;
  medida?: string;
  material?: string;
  fabricante?: string;
  marca?: string;
  fechActuPrecio?: string; // ISO date string
}
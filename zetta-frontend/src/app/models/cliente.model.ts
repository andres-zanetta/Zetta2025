import { Presupuesto } from './presupuesto.model';

export interface Cliente {
  id: number;
  nombre: string;
  apellido: string;
  direccion?: string;
  localidad?: string;
  telefono: string;
  email?: string;
  presupuestos?: Presupuesto[];
}

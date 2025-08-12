import { Presupuesto } from './presupuesto.model';
import { ItemPresupuesto } from './item-presupuesto.model';

export interface PresItemDetalle {
  id: number;
  presupuestoId: number;
  presupuesto: Presupuesto;
  itemPresupuestoId: number;
  itemPresupuesto: ItemPresupuesto;
  cantidad: number;
  precioUnitario: number;
}

import { PresItemDetalle } from './pres-item-detalle.model';

export enum OpcionDePago {
  Contado = 0,
  Tarjeta = 1,
  MercadoPagoConLink = 2
}

export enum Rubro {
  Gas = 0,
  Electricidad = 1,
  Refrigeracion = 2,
  Solar = 3,
  Plomeria = 4
}

export interface Presupuesto {
  id: number;
  rubro: Rubro;
  aceptado: boolean;
  itemsDetalle: PresItemDetalle[];
  subtotal: number;
  observacion?: string;
  total: number;
  manodeObra?: number;
  totalP: number;
  tiempoAproxObra: string;
  validacionDias: string;
  opcionDePago: OpcionDePago;
  clienteId?: number;
}

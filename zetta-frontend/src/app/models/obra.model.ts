import { Presupuesto } from './presupuesto.model';
import { Cliente } from './cliente.model';
import { Comentario } from './comentario.model';

export enum EstadoObra {
  Iniciada = 0,
  EnProceso = 1,
  Finalizada = 2
}

export interface Obra {
  id: number;
  estadoObra: EstadoObra;
  presupuestoId: number;
  presupuesto: Presupuesto;
  fechaInicio: string;
  cliente: Cliente;
  obras?: Obra[];
  comentarios?: Comentario[];
}

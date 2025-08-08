import { Inicio } from './pages/inicio/inicio';
import { Items } from './pages/items/items';
import { Obras } from './pages/obras/obras';
import { Clientes } from './pages/clientes/clientes';
import { Presupuesto } from './pages/presupuesto/presupuesto';
import { Routes } from '@angular/router';

export const routes: Routes = [
  {path: '', component:Inicio},
  {path: 'Items', component: Items},
  {path: 'Obras', component: Obras},
  {path: 'Clientes', component: Clientes},
  {path: 'Presupuesto', component: Presupuesto},
  {path: '**', redirectTo: ''}

];

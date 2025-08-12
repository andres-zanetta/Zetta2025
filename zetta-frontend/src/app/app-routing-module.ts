import { Inicio } from './pages/inicio/inicio';
import { Items } from './pages/items/items';
import { Obras } from './pages/obras/obras';
import { Clientes } from './pages/clientes/clientes';
import { Presupuesto } from './pages/presupuesto/presupuesto';
import { Routes } from '@angular/router';
import { ClientesList } from './pages/clientes/clientes-list/clientes-list';
import { ClientesForm } from './pages/clientes/clientes-form/clientes-form';


export const routes: Routes = [
  {path: '', component:Inicio},
  {path: 'Items', component: Items},
  {path: 'Obras', component: Obras},
  {path: 'Clientes', component: Clientes},
  {path: 'Presupuesto', component: Presupuesto},
  {path: '**', redirectTo: ''},
  { path: 'clientes', component: ClientesList },
  { path: 'clientes/nuevo', component: ClientesForm },
  { path: 'clientes/editar/:id', component: ClientesForm },
  { path: '', redirectTo: '/clientes', pathMatch: 'full' }


];

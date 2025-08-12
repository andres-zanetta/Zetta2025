// src/app/app-routing-module.ts
import { Inicio } from './pages/inicio/inicio';
import { Items } from './pages/items/items';
import { Obras } from './pages/obras/obras';
import { Presupuesto } from './pages/presupuesto/presupuesto';
import { Clientes } from './pages/clientes/clientes';
import { Routes } from '@angular/router';
import { ClientesForm } from './pages/clientes/clientes-form/clientes-form';

export const routes: Routes = [
  { path: '', component: Inicio },
  { path: 'items', component: Items },
  { path: 'obras', component: Obras },
  { path: 'presupuesto', component: Presupuesto },
  { path: 'clientes', component: Clientes },
  { path: 'clientes/nuevo', component: ClientesForm },
  { path: 'clientes/editar/:id', component: ClientesForm },
  { path: '**', redirectTo: '' }
];
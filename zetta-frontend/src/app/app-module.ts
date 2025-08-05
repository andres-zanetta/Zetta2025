// src/app/app-module.ts (Solo si lo mantienes, si no, ELIMÍNALO)
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing-module';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { Items } from './pages/items/items';
import { Presupuesto } from './pages/presupuesto/presupuesto';
import { Obras } from './pages/obras/obras';
import { Clientes } from './pages/clientes/clientes';
import { Inicio } from './pages/inicio/inicio';

@NgModule({
  // declarations: [
  //   // Aquí irían otros componentes, directivas, pipes que NO sean standalone
  // ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule // Aunque HttpClient se provee en main.ts, puedes mantenerlo aquí si otros módulos lo necesitan
  ],
  providers: [
    // Aquí irían providers específicos de este módulo
  ],
  declarations: [
    Header,
    Footer,
    Items,
    Presupuesto,
    Obras,
    Clientes,
    Inicio
  ],
  // bootstrap: [AppComponent] // <-- ¡ELIMINA ESTA LÍNEA!
})
export class AppModule { }
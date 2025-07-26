// src/app/app-module.ts (Solo si lo mantienes, si no, ELIMÍNALO)
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing-module';

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
  // bootstrap: [AppComponent] // <-- ¡ELIMINA ESTA LÍNEA!
})
export class AppModule { }
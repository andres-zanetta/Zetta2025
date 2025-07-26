// src/main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http'; // Para que HttpClient esté disponible
import { provideRouter } from '@angular/router';     // Para que el enrutador esté disponible

import { AppComponent } from './app/app'; // Importa tu AppComponent standalone
import { routes } from './app/app-routing-module'; // Importa tus rutas desde app-routing-module.ts

bootstrapApplication(AppComponent, {
  providers: [
    // Proveedores globales para tu aplicación standalone
    provideHttpClient(), // Habilita el servicio HttpClient
    provideRouter(routes), // Configura el enrutador con tus rutas

    // Si tenías otros providers en tu AppModule (como provideBrowserGlobalErrorListeners()),
    // también irían aquí. Por ejemplo:
    // provideBrowserGlobalErrorListeners()
  ]
})
.catch(err => console.error(err));
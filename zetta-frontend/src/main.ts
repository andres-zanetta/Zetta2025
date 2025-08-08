// src/main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';

import { App } from './app/app'; // <-- Corregido: 'App' en lugar de 'AppComponent'
import { routes } from './app/app-routing-module';

bootstrapApplication(App, { // <-- Corregido: 'App' en lugar de 'AppComponent'
  providers: [
    // Proveedores globales para tu aplicación standalone
    provideHttpClient(), // Habilita el servicio HttpClient
    provideRouter(routes), // Configura el enrutador con tus rutas

    // Si tenías otros providers en tu AppModule, también irían aquí.
    // Por ejemplo:
    // provideBrowserGlobalErrorListeners()
  ]
})
.catch(err => console.error(err));
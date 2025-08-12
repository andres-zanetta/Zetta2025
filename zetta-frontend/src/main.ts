// src/main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';

import { App } from './app/app'; // 
import { routes } from './app/app-routing-module';

bootstrapApplication(App, { 
  providers: [
    // Proveedores globales para tu aplicación standalone
    provideHttpClient(),
    provideRouter(routes), 

  ]
})
.catch(err => console.error(err));
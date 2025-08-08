// src/app/app.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    Header,
    Footer
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
})
export class App {
   title = 'Zetta Frontend';
}
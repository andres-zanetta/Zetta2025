// src/app/app.ts
import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    Header,
    Footer,
    FormsModule,
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
})

export class App {
   title = 'Zetta Frontend';

   constructor(private http: HttpClient) {
  }
}
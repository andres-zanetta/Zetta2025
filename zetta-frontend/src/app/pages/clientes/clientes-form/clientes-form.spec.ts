import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ClientesForm } from './clientes-form';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterTestingModule } from '@angular/router/testing'; 

describe('ClientesForm', () => {
  let component: ClientesForm;
  let fixture: ComponentFixture<ClientesForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientesForm, FormsModule, CommonModule, RouterTestingModule] 
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientesForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
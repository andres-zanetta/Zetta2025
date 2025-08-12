import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Clientes } from './clientes';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ClienteService } from '../../services/cliente';
import { of } from 'rxjs';

describe('Clientes', () => {
  let component: Clientes;
  let fixture: ComponentFixture<Clientes>;
  let clienteService: ClienteService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        Clientes, 
        HttpClientTestingModule,
        RouterTestingModule
      ],
      providers: [
        {
          provide: ClienteService,
          useValue: {
            getAll: () => of([]), 
            delete: () => of(null)
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(Clientes);
    component = fixture.componentInstance;
    clienteService = TestBed.inject(ClienteService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
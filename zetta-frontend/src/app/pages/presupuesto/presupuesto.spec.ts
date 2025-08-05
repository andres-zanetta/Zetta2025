import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Presupuesto } from './presupuesto';

describe('Presupuesto', () => {
  let component: Presupuesto;
  let fixture: ComponentFixture<Presupuesto>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Presupuesto]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Presupuesto);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

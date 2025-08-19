import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemPresupuestoForm } from './item-presupuesto-form';

describe('ItemPresupuestoForm', () => {
  let component: ItemPresupuestoForm;
  let fixture: ComponentFixture<ItemPresupuestoForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItemPresupuestoForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemPresupuestoForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

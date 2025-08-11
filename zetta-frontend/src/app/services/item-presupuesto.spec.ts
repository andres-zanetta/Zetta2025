import { TestBed } from '@angular/core/testing';

import { ItemPresupuesto } from './item-presupuesto';

describe('ItemPresupuesto', () => {
  let service: ItemPresupuesto;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItemPresupuesto);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

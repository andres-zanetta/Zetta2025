import { TestBed } from '@angular/core/testing';

import { Presupuesto } from './presupuesto';

describe('Presupuesto', () => {
  let service: Presupuesto;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Presupuesto);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

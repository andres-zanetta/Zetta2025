import { TestBed } from '@angular/core/testing';

import { PresItemDetalle } from './pres-item-detalle';

describe('PresItemDetalle', () => {
  let service: PresItemDetalle;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PresItemDetalle);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { Obra } from './obra';

describe('Obra', () => {
  let service: Obra;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Obra);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

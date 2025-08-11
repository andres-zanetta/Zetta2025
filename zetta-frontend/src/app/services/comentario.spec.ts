import { TestBed } from '@angular/core/testing';

import { Comentario } from './comentario';

describe('Comentario', () => {
  let service: Comentario;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Comentario);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

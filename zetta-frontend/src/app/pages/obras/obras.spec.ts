import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Obras } from './obras';

describe('Obras', () => {
  let component: Obras;
  let fixture: ComponentFixture<Obras>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Obras]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Obras);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

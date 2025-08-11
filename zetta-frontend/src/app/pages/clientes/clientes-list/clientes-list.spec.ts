import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientesList } from './clientes-list';

describe('ClientesList', () => {
  let component: ClientesList;
  let fixture: ComponentFixture<ClientesList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientesList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientesList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

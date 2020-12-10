import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecuperacionClaveComponent } from './recuperacion-clave.component';

describe('RecuperacionClaveComponent', () => {
  let component: RecuperacionClaveComponent;
  let fixture: ComponentFixture<RecuperacionClaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecuperacionClaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecuperacionClaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});

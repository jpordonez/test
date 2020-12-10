/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { #{Entidad}Component } from './#{filename}.component';

describe('#{Entidad}Component', () => {
  let component: #{Entidad}Component;
  let fixture: ComponentFixture<#{Entidad}Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ #{Entidad}Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(#{Entidad}Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

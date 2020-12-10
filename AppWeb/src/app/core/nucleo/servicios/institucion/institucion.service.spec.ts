/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InstitucionService } from './institucion.service';

describe('InstitucionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InstitucionService]
    });
  });

  it('should ...', inject([InstitucionService], (service: InstitucionService) => {
    expect(service).toBeTruthy();
  }));
});

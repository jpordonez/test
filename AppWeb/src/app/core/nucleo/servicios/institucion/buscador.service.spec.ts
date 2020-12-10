/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BuscadorInstitucionService } from './buscador.service';

describe('BuscadorInstitucionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BuscadorInstitucionService]
    });
  });

  it('should ...', inject([BuscadorInstitucionService], (service: BuscadorInstitucionService) => {
    expect(service).toBeTruthy();
  }));
});

/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BuscadorPersonaService } from './buscador.service';

describe('BuscadorPersonaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BuscadorPersonaService]
    });
  });

  it('should ...', inject([BuscadorPersonaService], (service: BuscadorPersonaService) => {
    expect(service).toBeTruthy();
  }));
});

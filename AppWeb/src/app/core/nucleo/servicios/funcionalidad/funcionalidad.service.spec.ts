import { TestBed, inject } from '@angular/core/testing';

import { FuncionalidadService } from './funcionalidad.service';

describe('FuncionalidadService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FuncionalidadService]
    });
  });

  it('should ...', inject([FuncionalidadService], (service: FuncionalidadService) => {
    expect(service).toBeTruthy();
  }));
});

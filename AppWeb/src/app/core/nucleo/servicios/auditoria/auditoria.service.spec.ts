import { TestBed, inject } from '@angular/core/testing';

import { AuditoriaService } from './auditoria.service';

describe('AuditoriaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuditoriaService]
    });
  });

  it('should ...', inject([AuditoriaService], (service: AuditoriaService) => {
    expect(service).toBeTruthy();
  }));
});

import { TestBed, inject } from '@angular/core/testing';

import { SesionService } from './sesion.service';

describe('SesionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SesionService]
    });
  });

  it('should ...', inject([SesionService], (service: SesionService) => {
    expect(service).toBeTruthy();
  }));
});

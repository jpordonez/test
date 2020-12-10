/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CatalogoService } from './catalogo.service';

describe('CatalogoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CatalogoService]
    });
  });

  it('should ...', inject([CatalogoService], (service: CatalogoService) => {
    expect(service).toBeTruthy();
  }));
});

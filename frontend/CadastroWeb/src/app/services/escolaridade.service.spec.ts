import { TestBed } from '@angular/core/testing';

import { EscolaridadeService } from './escolaridade.service';

describe('EscolaridadeService', () => {
  let service: EscolaridadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EscolaridadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

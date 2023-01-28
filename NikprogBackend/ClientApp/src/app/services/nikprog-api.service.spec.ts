import { TestBed } from '@angular/core/testing';

import { NikprogApiService } from './nikprog-api.service';

describe('NikprogApiService', () => {
  let service: NikprogApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NikprogApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

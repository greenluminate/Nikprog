import { TestBed } from '@angular/core/testing';

import { MaterialInfoApiService } from './material-info-api.service';

describe('MaterialInfoApiService', () => {
  let service: MaterialInfoApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialInfoApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

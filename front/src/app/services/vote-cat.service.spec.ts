import { TestBed } from '@angular/core/testing';

import { VoteCatService } from './vote-cat.service';

describe('VoteCatService', () => {
  let service: VoteCatService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VoteCatService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

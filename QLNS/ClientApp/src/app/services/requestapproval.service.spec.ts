import { TestBed } from '@angular/core/testing';

import { RequestapprovalService } from './requestapproval.service';

describe('RequestapprovalService', () => {
  let service: RequestapprovalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestapprovalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { EmployeeModalService } from './employee-modal.service';

describe('EmployeeModalService', () => {
  let service: EmployeeModalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeModalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

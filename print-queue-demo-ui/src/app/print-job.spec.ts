import { TestBed } from '@angular/core/testing';

import { PrintJob } from './print-job';

describe('PrintJob', () => {
  let service: PrintJob;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrintJob);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

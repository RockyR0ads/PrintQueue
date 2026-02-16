import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CostEstimator } from './cost-estimator';

describe('CostEstimator', () => {
  let component: CostEstimator;
  let fixture: ComponentFixture<CostEstimator>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CostEstimator]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CostEstimator);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

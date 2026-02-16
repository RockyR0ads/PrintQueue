import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PrintJobService } from '../print-job';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cost-estimator',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './cost-estimator.html',
  styleUrl: './cost-estimator.scss'
})
export class CostEstimator {

  modelName: string = '';
  filamentType: string | null = null;
  estimatedMinutes: number | null = null;
  printer: string | null = null;

  // Existing filament types
  filamentTypes = ['PLA', 'PETG', 'ABS', 'TPU'];

  // ⭐ New printer dropdown options
  printers = ['P1P','A1-Mini','A1',];

  result: any = null;

  constructor(private printJobService: PrintJobService) {}

  calculateCost() {
  const job = {
    modelName: this.modelName,
    filamentType: this.filamentType,
    estimatedMinutes: this.estimatedMinutes,
    printer: this.printer
  };

  this.printJobService.createJob(job).subscribe(created => {
    this.printJobService.getCost(created.id).subscribe(costResult => {
      this.result = costResult;   // <-- correct
    });
  });
}
}


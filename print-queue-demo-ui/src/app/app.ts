import { Component, signal } from '@angular/core';
import { CostEstimator } from './cost-estimator/cost-estimator';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CostEstimator],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('print-queue-demo-ui');
}

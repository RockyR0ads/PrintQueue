import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PrintJobService {
  private apiUrl = 'https://localhost:7177/api/jobs';


  constructor(private http: HttpClient) {}

  createJob(job: any) {
    return this.http.post<any>(this.apiUrl, job);
  }

  getCost(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}/cost`);
  }
}

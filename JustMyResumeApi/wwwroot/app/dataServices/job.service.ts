import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Job } from '../models/job';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private url = `/api/jobs`;

  constructor(private http: HttpClient) { }

  getJobs(id: number): Observable<Job[]> {
    //let retval = this.http.get<Job[]>(`${this.url}/${id}`);
    const retval = this.http.get<Job[]>(this.url);
    return retval;
  }
}

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url = `/api/projects`;

  constructor(private http: HttpClient) { }

  getProjects(id: number): Observable<Project[]> {
    //let retval = this.http.get<Project[]>(`${this.url}/${id}`);
    const retval = this.http.get<Project[]>(this.url);
    return retval;
  }
}
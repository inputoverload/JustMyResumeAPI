import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { SkillCategory } from '../models/skill-category';

@Injectable({
  providedIn: 'root'
})
export class SkillCategoryService {
  private url = '/api/skillCategories';

  constructor(private http: HttpClient) { }

  getSkillCategories(): Observable<SkillCategory[]> {
    const retval = this.http.get<SkillCategory[]>(this.url);
    return retval;
  }
}

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';


import { User } from '../models/user';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userUrl = '/api/user';

  constructor(private http: HttpClient) { }

  getUser(): Observable<User> {
    let retval = this.http.get<User>(this.userUrl); 
    return retval;

  }
}

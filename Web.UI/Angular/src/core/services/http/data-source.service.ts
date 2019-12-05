import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { marlData } from '@app/mocks';

@Injectable({
    providedIn: 'root'
  })
  export class DataSourceService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<any> {
        return of(marlData);
      // return this.http.get('/movies');
    }
  }

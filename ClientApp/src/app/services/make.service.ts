import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MakeService {

  constructor(private http: HttpClient) {}

  getMakes(): Observable<any> {
    return this.http.get('/api/makes');
  }
}

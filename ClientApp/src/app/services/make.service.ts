import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { filter, map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MakeService {

  constructor(private http: Http) {}

  getMakes(): Observable<any> {
    return this.http.get('/api/makes')
      .pipe(map(res => res.json()));
  }
}

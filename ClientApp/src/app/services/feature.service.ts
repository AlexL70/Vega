import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeatureService {

  constructor(private http: HttpClient) { }

  getFeatures(): Observable<Feature[]> {
    return <Observable<Feature[]>> this.http.get('/api/features');
  }
}

export class Feature {
  public id: number;
  public name: string;
}

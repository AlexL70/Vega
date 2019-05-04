import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) {}

  getMakes(): Observable<Make[]> {
    return <Observable<Make[]>> this.http.get('/api/makes');
  }

  getFeatures(): Observable<Feature[]> {
    return <Observable<Feature[]>> this.http.get('/api/features');
  }
}

export class Make {
  public id: number;
  public name: string;
  public models: Model[];
}

export class Model {
  public id: number;
  public name: string;
  public makeId: number;
}

export class Feature {
  public id: number;
  public name: string;
}

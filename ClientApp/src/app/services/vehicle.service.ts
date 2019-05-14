import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Make } from '../Models/Make';
import { Feature } from '../Models/Feature';
import { SaveVehicle } from '../Models/SaveVehicle';
import { Vehicle } from '../Models/Vehicle';
import { VehicleQuery } from '../models/VehicleQuery';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private readonly vehicleEndpoint: string = '/api/vehicles';
  constructor(private http: HttpClient) {}

  getMakes(): Observable<Make[]> {
    return <Observable<Make[]>> this.http.get('/api/makes');
  }

  getFeatures(): Observable<Feature[]> {
    return <Observable<Feature[]>> this.http.get('/api/features');
  }

  getVehicles(query: VehicleQuery): Observable<Vehicle[]> {
    return<Observable<Vehicle[]>> this.http.get(`${this.vehicleEndpoint}?${this.toQueryString(query)}`);
  }

  private toQueryString(query: VehicleQuery): string {
    var parts: string[] = [];
    for(var prop in query) {
      var value = query[prop];
      if(value !== null && value !== undefined)
        parts.push(`${encodeURIComponent(prop)}=${encodeURIComponent(value)}`);
    }

    return parts.join('&');
  }

  create(vehicle: SaveVehicle): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.post(this.vehicleEndpoint, vehicle);
  }

  update(vehicle: SaveVehicle): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.put(`${this.vehicleEndpoint}/${vehicle.id}`, vehicle);
  }

  delete(id: number): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.delete(`${this.vehicleEndpoint}/${id}`);
  }

  getVehicle(id: number) {
    return <Observable<SaveVehicle>> this.http.get(`${this.vehicleEndpoint}/${id}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Make } from '../Models/Make';
import { Feature } from '../Models/Feature';
import { SaveVehicle } from '../Models/SaveVehicle';
import { Vehicle } from '../Models/Vehicle';

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

  create(vehicle: SaveVehicle): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.post('/api/vehicles', vehicle);
  }

  update(vehicle: SaveVehicle): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.put('/api/vehicles/' + vehicle.id, vehicle);
  }

  delete(id: number): Observable<Vehicle> {
    return <Observable<Vehicle>> this.http.delete('/api/vehicles/' + id);
  }

  getVehicle(id: number) {
    return <Observable<SaveVehicle>> this.http.get('/api/vehicles/' + id);
  }
}

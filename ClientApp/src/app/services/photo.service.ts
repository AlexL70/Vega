import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {

  constructor(private http: HttpClient) { }

  upload(vehicleId: number, photo: Blob) {
    let formData = new FormData();
    formData.append('file', photo );
    return this.http.post(`/api/vehicles/${vehicleId}/photos`, formData);
  }
}

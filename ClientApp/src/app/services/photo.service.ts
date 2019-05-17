import { HttpClient, HttpRequest, HttpProgressEvent, HttpEventType, HttpXhrBackend } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpUploadProgressEvent } from '@angular/common/http/src/response';

@Injectable()
export class PhotoService {

  constructor(private http: HttpClient) { }

  upload(vehicleId: number, photo: Blob,
    progressCallback: (HttpUploadProgressEvent) => void,
    completeCallback: (HttpEvent) => void) {
    let formData = new FormData();
    formData.append('file', photo );
    const req = new HttpRequest('POST', `/api/vehicles/${vehicleId}/photos`,
      formData, { reportProgress: true } )
    return this.http.request(req)
      .subscribe(event => {
        switch (event.type) {
          case HttpEventType.UploadProgress:
            progressCallback(event);
          break;

          case HttpEventType.Response:
            completeCallback(event);
          break;
        }
    });
  }

  getPhotos(vehicleId: number) {
    return this.http.get(`/api/vehicles/${vehicleId}/photos`);
  }
}

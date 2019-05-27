import { ToastyService } from 'ng2-toasty';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { Injectable, isDevMode } from '@angular/core';
import { HttpUploadProgressEvent } from '@angular/common/http/src/response';

@Injectable()
export class PhotoService {

  constructor(private http: HttpClient,
    private toasty: ToastyService
    ) { }

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
    },
    err => {
      if (isDevMode)
        console.log(err);
        this.toasty.error({
          title: 'Error',
          msg: err.error,
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
    });
  }

  getPhotos(vehicleId: number) {
    return this.http.get(`/api/vehicles/${vehicleId}/photos`);
  }
}

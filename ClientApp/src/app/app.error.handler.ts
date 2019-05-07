import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject, NgZone } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
  constructor(@Inject(ToastyService) private toastyService: ToastyService,
    private ngZone: NgZone) {}

  handleError(error: any): void {
    //console.log("Error from central error handler:", error);
    this.ngZone.run(() => {
      this.toastyService.error({
        title: 'Error',
        msg: 'Unexpected server error occured',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
    });
  }
}

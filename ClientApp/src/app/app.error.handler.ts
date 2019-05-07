import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
  constructor(@Inject(ToastyService) private toastyService: ToastyService) {}

  handleError(error: any): void {
    console.log("Error from central error handler:", error);
    this.toastyService.error({
      title: 'Error',
      msg: 'Unexpected server error occured while saving vehicle',
      theme: 'bootstrap',
      showClose: true,
      timeout: 5000
    });
  }
}

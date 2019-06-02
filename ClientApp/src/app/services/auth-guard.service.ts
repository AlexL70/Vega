import { ToastyService } from 'ng2-toasty';
import { Injectable } from '@angular/core';
import { Auth } from './auth.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private auth: Auth,
    private toasty: ToastyService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (!this.auth.authenticated()) {
      this.toasty.warning({
        title: 'Warning',
        msg: 'You need to login to access this route.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      return false;
    }
    else
      return true;
  }
}

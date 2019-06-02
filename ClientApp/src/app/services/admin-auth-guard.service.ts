import { ToastyService } from 'ng2-toasty';
import { Injectable } from '@angular/core';
import { Auth } from './auth.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AdminAuthGuard implements CanActivate {
  constructor(private auth: Auth, private toasty: ToastyService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const enabled = this.auth.hasRole('Admin');
    if (!enabled) {
      this.toasty.warning({
        title: 'Warning',
        msg: 'You need Admin role to access this route.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
    }
    return enabled;
  }
}

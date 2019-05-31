import { Injectable } from '@angular/core';
import { tokenNotExpired } from 'angular2-jwt';
import Auth0Lock from 'auth0-lock';

Injectable()
export class Auth {
  private readonly token = 'token';
  //  Configure Auth0
  lock = new Auth0Lock('dfyTdzt05ACS3z82F65bLcjrg84FYNbO', 'dev-zlon.eu.auth0.com');

  constructor() {
    //  Add callback for lock `authenticated` event
    this.lock.on('authenticated', (authResult) => {
      console.log('AuthResult', authResult);
      localStorage.setItem(this.token, authResult.idToken);
    });
  }

  public login(): void {
    //  Call the show method to display the widget.
    this.lock.show();
  }

  public authenticated(): boolean {
    //  Check if there is unexpired JWT
    //  This searches for an item in localStorage with key == this.token
    return tokenNotExpired(this.token);
  }

  public logout(): void {
    //  Remove token from localStorage
    localStorage.removeItem(this.token);
  }
}
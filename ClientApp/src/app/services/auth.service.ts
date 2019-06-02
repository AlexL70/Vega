import { Injectable } from '@angular/core';
import { tokenNotExpired } from 'angular2-jwt';
import Auth0Lock from 'auth0-lock';

Injectable()
export class Auth {
  private readonly token = 'token';
  lock: Auth0LockStatic;
  profile: any;

  constructor() {
    //  lock configuration options
    var options = {
      auth: {
        responseType: 'token id_token',
        audience: 'https://api.vega.com',
        redirectUrl: 'https://localhost:5001',
        params: {
          scope: 'openid email profile'
        }
      },
      additionalSignUpFields: [
        {
          name: "name",
          placeholder: "Name"
        }
      ],
      autoclose: true,
      oidcConformant: true
    };
    //  Configure Auth0
    this.lock = new Auth0Lock('dfyTdzt05ACS3z82F65bLcjrg84FYNbO', 'dev-zlon.eu.auth0.com', options);
    //  Get user profile from the local storage if any
    this.profile = JSON.parse(localStorage.getItem('profile'));
    // if(this.profile)
    //   console.log("User profile got from the local storage: ", this.profile);
    //  Add callback for lock `authenticated` event
    this.lock.on('authenticated', (authResult) => {
      // console.log('AuthResult', authResult);
      localStorage.setItem(this.token, authResult.accessToken);

      this.lock.getUserInfo(authResult.accessToken, (error, profile) => {
        if (error) {
          throw error;
        }
        if (profile) {
          // console.log("User profile: ", profile);
          localStorage.setItem('profile', JSON.stringify(profile));
          this.profile = profile;
        }
      });
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
    localStorage.removeItem('profile');
    this.profile = null;
  }
}

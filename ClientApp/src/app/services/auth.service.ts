import { Injectable, isDevMode } from '@angular/core';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';
import Auth0Lock from 'auth0-lock';

Injectable()
export class Auth {
  private readonly token = 'token';
  lock: Auth0LockStatic;
  profile: any;
  private roles: string[] = [];

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
    //  Get user roles from the token
    this.extractRoles();
    //  Get user profile from the local storage if any
    this.profile = JSON.parse(localStorage.getItem('profile'));
    // if(this.profile)
    //   console.log("User profile got from the local storage: ", this.profile);
    //  Add callback for lock `authenticated` event
    this.lock.on('authenticated', (authResult) => {
      // console.log('AuthResult', authResult);
      localStorage.setItem(this.token, authResult.accessToken);

      this.extractRoles();

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

  private extractRoles() {
    let tkn = localStorage.getItem(this.token);
    if(tkn) {
      let jwtHelper = new JwtHelper();
      let tknDecoded = jwtHelper.decodeToken(tkn);
      let roles: string[] = tknDecoded['https://vega.com/roles'];
      this.roles = roles ? roles : [];
      if (isDevMode)
        console.log("User roles: ", this.roles);
    }
  }

  public hasRole(role: string) {
    return this.roles && this.roles.indexOf(role) > -1;
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
    this.roles = [];
  }
}

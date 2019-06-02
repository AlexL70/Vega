import { Injectable, isDevMode } from '@angular/core';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';
import Auth0Lock from 'auth0-lock';
import { HttpHeaders } from '@angular/common/http';

Injectable()
export class Auth {
  private readonly tokenKey = 'token';
  private readonly profileKey = 'profile';
  lock: Auth0LockStatic;
  profile: any;
  private roles: string[] = [];
  //  lock configuration options
  private readonly lockOptions: Auth0LockConstructorOptions = {
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

  constructor() {
    //  Configure Auth0
    this.lock = new Auth0Lock('dfyTdzt05ACS3z82F65bLcjrg84FYNbO', 'dev-zlon.eu.auth0.com', this.lockOptions);
    //  Read auth data from local storage if any
    this.readAuthDataFromLocalStorage();
    //  Add callback for lock `authenticated` event
    this.lock.on('authenticated', (authResult) => this.onUserAuthenticated(authResult));
  }

  private onUserAuthenticated(authResult: AuthResult) {
    localStorage.setItem(this.tokenKey, authResult.accessToken);
    this.lock.getUserInfo(authResult.accessToken, (error, profile) => {
      if (error) {
        throw error;
      }
      if (profile) {
        localStorage.setItem(this.profileKey, JSON.stringify(profile));
      }
      this.readAuthDataFromLocalStorage();
    });
  }

  private readAuthDataFromLocalStorage() {
    let tkn = localStorage.getItem(this.tokenKey);
    if(tkn) {
      let jwtHelper = new JwtHelper();
      let tknDecoded = jwtHelper.decodeToken(tkn);
      let roles: string[] = tknDecoded['https://vega.com/roles'];
      this.roles = roles ? roles : [];
      if (isDevMode)
        console.log("User roles: ", this.roles);
    }
    this.profile = JSON.parse(localStorage.getItem(this.profileKey));
    if (isDevMode)
      console.log("User profile:", this.profile);
  }

  public hasRole(role: string) {
    return this.roles && this.roles.indexOf(role) > -1;
  }

  public getSecureHeades(): { headers: HttpHeaders} | {} {
    if (this.authenticated) {
      let token = localStorage.getItem(this.tokenKey);
      return { headers: new HttpHeaders().set("Authorization", `Bearer ${token}`) };
    }
    else return {};
  }

  public login(): void {
    //  Call the show method to display the widget.
    this.lock.show();
  }

  public authenticated(): boolean {
    //  Check if there is unexpired JWT
    //  This searches for an item in localStorage with key == this.token
    return tokenNotExpired(this.tokenKey);
  }

  public logout(): void {
    //  Remove token from localStorage
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.profileKey);
    this.profile = null;
    this.roles = [];
  }
}

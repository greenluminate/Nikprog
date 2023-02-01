import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NikprogToken } from '../models/nikprog-token';
import { SocialToken } from '../models/social-token';
import { NavigatorService } from './navigator.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private navigator: NavigatorService, private http: HttpClient) { }

  public o365Login(socialToken: SocialToken) {
    this.http.post<NikprogToken>('https://localhost:7224/auth/microsoft', socialToken)//ToDo: to outsource into userApiService
      .subscribe(t => {
        t.expiration = new Date(t.expiration);
        localStorage.setItem('token', t.token);
        localStorage.setItem('expiration', t.expiration.getTime().toString());
        this.navigator.goTo('/courses');
      });
  }

  public logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('expiration');
    this.navigator.goTo('/login');
  }

  public isLoggedIn(): boolean {
    let exp = localStorage.getItem('expiration');
    if (exp != null) {
      return new Date().getTime() < parseInt(exp)
    }
    else {
      return false;
    }
  }

  public getRole(): string {
    if (this.isLoggedIn()) {
    }
    return "Admin"; // ToDo: implement on server side to be able to get role of loggedin user
  }

  public getToken() {
    if (this.isLoggedIn()) {
      return localStorage.getItem('token');
    }
    else {
      return '';
    }
  }

  public blockUser(route: string) {
    if (this.isLoggedIn()) {
      this.navigator.goTo('/' + route);
    }
  }
}

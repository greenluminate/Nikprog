import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { observable, Observable } from 'rxjs';
import { __values } from 'tslib';
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
        this.setRoleToLocalStorage();
        this.navigator.goTo('/courses');
      });
  }

  public logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('expiration');
    localStorage.removeItem('role');
    this.navigator.goTo('/login');
  }

  public isLoggedIn(): boolean {
    let exp = localStorage.getItem('expiration');
    if (exp != null) {
      return new Date().getTime() <= parseInt(exp)
    }
    else {
      return false;
    }
  }

  private setRoleToLocalStorage() {
    if (this.isLoggedIn()) {
      this.getRolesFromServer().subscribe(role => localStorage.setItem('role', JSON.parse(JSON.stringify(role)).role));
    }
  }

  private getRolesFromServer(): Observable<string> {
    return this.http.get<string>('https://localhost:7224/auth/getRoles',
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': `${localStorage.getItem('token')}`
        })
      });
  }

  public getRoleFromLocalStorage(): string {
    if (this.isLoggedIn()) {
      return localStorage.getItem('role') ?? '';
    }
    return ""; // ToDo: implement on server side to be able to get role of loggedin user
  }

  public getIsEditorMode(): string {
    if (this.isLoggedIn()) {
      return localStorage.getItem('editorMode') ?? 'false';
    }
    return ''; // ToDo: implement on server side to be able to get role of loggedin user
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

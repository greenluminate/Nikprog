import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class NavigatorService {

  constructor(private router: Router) { }

  public goTo(uri: string) {
    this.router.navigate([uri]);
  }

  public forceLogin() {
    this.router.navigate(['/login']);
  }
}

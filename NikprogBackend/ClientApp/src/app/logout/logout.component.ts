import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { NavigatorService } from '../services/navigator.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  constructor(private userService: UserService, private authService: SocialAuthService, private navigate: NavigatorService) { }

  ngOnInit(): void {
    if (!this.userService.isLoggedIn()) {
      this.navigate.forceLogin();
    }
    this.authService.signOut().finally(() => this.userService.logout());
  }
}

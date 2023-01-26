import { Component, OnInit } from '@angular/core';
import { NavigatorService } from '../services/navigator.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private userService: UserService, private navigate: NavigatorService) { }

  ngOnInit(): void {
    if (!this.userService.isLoggedIn()) {
      this.navigate.forceLogin();
    }
  }

}

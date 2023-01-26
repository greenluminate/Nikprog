import { Component, OnInit } from '@angular/core';
import { MicrosoftLoginProvider, SocialAuthService } from "@abacritt/angularx-social-login";
import { UserService } from '../services/user.service';
import { TextService } from '../services/text.service';
import { SocialToken } from '../models/social-token';
import { NavigatorService } from '../services/navigator.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: SocialAuthService, private userService: UserService, public textService: TextService, private navigate: NavigatorService) {
    this.authService.authState.subscribe((user) => {
      this.userService.o365Login(new SocialToken(user.authToken));
    });
  }

  ngOnInit(): void {
    if (!this.userService.isLoggedIn()) {
      this.signInWithO365();//It would be good with redirect mode
    }
  }

  signInWithO365(): void {
    this.authService.signIn(MicrosoftLoginProvider.PROVIDER_ID);
  }
}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TextService {

  // Login page
  public loginTitle: string = 'Bejelentkezés';
  public loginMsButton: string = 'Bejelentkezés OE - O365 fiókkal';

  constructor() { }
}

import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  isExpanded: boolean = false;
  public isEditorMode: boolean = false;
  constructor(public userService: UserService) { this.switchEditorMode(); }

  ngOnInit(): void {
    this.switchEditorMode();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  switchEditorMode() {
    this.isEditorMode = !this.isEditorMode;
    localStorage.setItem('editorMode', this.isEditorMode ? 'true' : 'false');
  }
}

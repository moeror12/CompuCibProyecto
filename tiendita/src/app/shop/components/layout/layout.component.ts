import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {

  constructor(
    private router: Router
  ) {
  }

  @ViewChild(MatDrawer) drawer: MatDrawer | undefined;

  onToggleCart() {
    this.drawer?.toggle();
  }

  logout() {
    
  }
}

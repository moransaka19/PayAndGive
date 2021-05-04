import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter, startWith } from 'rxjs/operators';
import { parseJwt } from '../helpers/parse-jwt';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {

  authenticated: boolean;
  name: string;
  isAdmin: boolean;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events.pipe(
      filter(x => x instanceof NavigationEnd),
      startWith(false)
    )
      .subscribe(() => {
        this.authenticated = !!localStorage.getItem('token');
        this.name = this.authenticated && parseJwt(localStorage.getItem('token')).unique_name;
        this.isAdmin = this.authenticated && parseJwt(localStorage.getItem('token')).role === 'Admin';
      });
  }

  onLogout() {
    localStorage.removeItem('token');
    setTimeout(() => this.router.navigateByUrl('login'), 5);
  }
}

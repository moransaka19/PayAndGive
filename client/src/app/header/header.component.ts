import {Component, OnInit, ChangeDetectionStrategy} from '@angular/core';
import {NavigationEnd, Router} from '@angular/router';
import {filter, startWith} from 'rxjs/operators';
import {parseJwt} from '../helpers/parse-jwt';
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {

  authenticated: boolean;
  name: string;
  isAdmin: boolean;
  language = true;

  constructor(private router: Router,
              private translateService: TranslateService) {
  }

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

  changeLanguage() {
    this.language = !this.language;
    if (this.language) {
      this.translateService.use('en');
    } else {
      this.translateService.use('ua');
    }
  }
}

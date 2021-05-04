import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  get isAuthenticated() {
    return !!localStorage.getItem('token');
  }

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl(''),
      password: new FormControl(''),
      name: new FormControl(''),
      role: new FormControl(2),
    });
  }

  onRegister() {
    this.http.post(`${environment.apiUrl}/auth/registration`, this.form.value)
      .subscribe(({ token }: { token: string }) => {
        if (!localStorage.getItem('token')) {
          localStorage.setItem('token', token);
        }

        setTimeout(() => this.router.navigateByUrl(''), 50);
      });
  }
}
